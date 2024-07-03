using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.Xml.Linq;
using System.Runtime.InteropServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;
using System.Reflection.Emit;
using System.Timers;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Runtime.InteropServices.ComTypes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using System.Net.Http;

namespace lab06
{
    public partial class ServerForm : Form
    {
        private TcpListener server;
        private readonly Dictionary<String, TcpClient> clients = new Dictionary<string, TcpClient>();
        private Thread thread;
        private readonly object _lock = new object();
        private int randomNumber;
        private int minRange;
        private int maxRange;
        private Random rnd = new Random();
        private bool ingame = false;
        private int roundsPlayed = 0, ansNumber;
        private int timeupCount, currentRound;
        private string winnerName;
        private Dictionary<String, int> scoreBoard = new Dictionary<string, int>();
        private Dictionary<String, bool> readyPlayers = new Dictionary<string, bool>();

        public ServerForm()
        {
            InitializeComponent();
            this.Shown += new EventHandler(this.ServerForm_Shown);
        }
        private void ServerForm_Shown(object sender, EventArgs e)
        {
            this.Hide();
            thread = new Thread(serverThread);
            thread.Start();
        }
        private void serverThread()
        {
            try
            {
                server = new TcpListener(IPAddress.Any, 8080);
                server.Start();
            }
            catch
            {
                MessageBox.Show("Lỗi!");
                return;
            }

            this.Invoke((MethodInvoker)delegate {
                MessageBox.Show("Tạo game mới thành công");
                this.Show();
            });

            while (Thread.CurrentThread.IsAlive)
            {
                TcpClient client = null;
                try
                {
                    client = server.AcceptTcpClient();
                }
                catch (SocketException e)
                {
                    if ((e.SocketErrorCode == SocketError.Interrupted))
                    {
                        break;
                    }
                }
                NetworkStream networkStream = client.GetStream();
                byte[] dataBuffer = new byte[1024];
                int bytesRead = networkStream.Read(dataBuffer, 0, dataBuffer.Length);
                String receivedUsername = Encoding.UTF8.GetString(dataBuffer, 0, bytesRead);

                lock (_lock)
                {
                    if (clients.ContainsKey(receivedUsername))
                    {
                        BroadcastMessage("user_existed");
                        client.Close();
                        continue;
                    }
                    clients.Add(receivedUsername, client);
                    scoreBoard.Add(receivedUsername, 0);
                }
                UpdateClientCount();
                BroadcastMessage($"s>>> {receivedUsername} vừa vào phòng");
                BroadcastMessage($"\t{clients.Count}");
                Thread handlingThread = new Thread(o => clientCheck((string)o));
                handlingThread.Start(receivedUsername);
            }

        }

        private void BroadcastMessage(string message)
        {
            byte[] data = Encoding.UTF8.GetBytes($"{message}\n");
            lock (_lock)
            {
                foreach (var client in clients)
                {
                    NetworkStream stream = client.Value.GetStream();
                    stream.Write(data, 0, data.Length);
                }
            }
        }

        private void UpdateClientCount()
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                tbClientCount.Text = $"Tổng số người chơi: {clients.Count}";
            }));
        }

        public void clientCheck(string username)
        {
            TcpClient client;
            lock (_lock) client = clients[username];
            while (thread.IsAlive)
            {
                int bytesCount = 0;
                NetworkStream stream = client.GetStream();
                byte[] buffer = new byte[1024];
                try
                {
                    bytesCount = stream.Read(buffer, 0, buffer.Length);
                }
                catch { }
                if (bytesCount == 0) break;

                string requestFromClient = Encoding.UTF8.GetString(buffer, 0, bytesCount);
                var dataList = requestFromClient.Split(new String[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (String data in dataList)
                {
                    if (data[0] == 'g')
                    {
                        if (winnerName == "")
                            try
                            {
                                int ans = Int32.Parse(data.Substring(1));
                                if (ans == ansNumber)
                                {
                                    winnerName = username;
                                    scoreBoard[username] += 10;
                                    BroadcastMessage($"s{winnerName} đã đoán đúng tại vòng {currentRound - 1}");
                                }
                                if (ans != ansNumber)
                                {
                                    BroadcastMessage($"s{username} đoán sai! ({ans}). -1 điểm");
                                    scoreBoard[username]--;
                                }
                            }
                            catch
                            {
                                BroadcastMessage($"s{username} nhập đáp án không hợp lệ. -1 điểm");
                                scoreBoard[username]--;
                            }
                    }
                    else if(data[0] == 'm')
                        conversation.Invoke(new MethodInvoker(delegate ()
                        {
                            conversation.AppendText($"{data.Substring(1)}\n");
                            conversation.ScrollToCaret();
                        }));
                    else if (data == "---Ready!---")
                    {
                        BroadcastMessage($"s---- {username} đã sẵn sàng! ----");
                        readyPlayers.Add(username, true);
                        readyCheck();
                    }
                    else if (data == "@@@Timeup!@@@")
                    {
                        timeupCount++;
                        if (timeupCount == readyPlayers.Count) (new Thread(() => timeUp())).Start();
                    }
                }
            } 

            lock (_lock)
            {
                clients.Remove(username);
                scoreBoard.Remove(username);
                readyPlayers.Remove(username);
                BroadcastMessage($"s>>> {username} đã rời khỏi phòng");
                UpdateClientCount();
                BroadcastMessage($"\t{clients.Count}");
                ingame = false;
            }
            client.Client.Shutdown(SocketShutdown.Both);
            client.Close();

        }
        private void readyCheck()
        {
            if (readyPlayers.Count != 0 && readyPlayers.Count == clients.Count)
            {
                ingame = true;
                (new Thread(roundStart)).Start();
            }
        }
        private void roundStart()
        {
            Thread.Sleep(2000);
            timeupCount = 0;

            if (roundsPlayed == 0)
            {
                roundsPlayed = rnd.Next(5, 10);
                BroadcastMessage($"s------ Trò chơi có {roundsPlayed} vòng ------");
                currentRound = 1;
            }

            minRange = rnd.Next(0, 50);
            maxRange = minRange + rnd.Next(1, 50);
            tbNumberRange.Invoke(new MethodInvoker(delegate ()
            {
                tbNumberRange.Text = $"Phạm vi: [{minRange}, {maxRange}]";
            }));
            ansNumber = rnd.Next(minRange, maxRange + 1);
            tbAnswer.Invoke(new MethodInvoker(delegate ()
            {
                tbAnswer.Text = $"Kết quả: {ansNumber}";
            }));
            string message = $">>>> Vòng thứ {currentRound}: Đoán số trong vùng [{minRange}, {maxRange}]. <<<<";
            conversation.Invoke(new MethodInvoker(delegate ()
            {
                conversation.AppendText($"{message}\n");
                conversation.ScrollToCaret();
            }));
            BroadcastMessage($"s{message}\n@@@Nextround!@@@{rnd.Next(5, 11)}\t{minRange}\t{maxRange}\t{ansNumber}");
            currentRound++;
            winnerName = "";
        }

        private void timeUp()
        {
            string message;
            if (winnerName == "")
            {
                message = $"Không ai có đáp án chính xác";
            }    
            else 
                message = $"{winnerName} là người chơi đưa ra đáp án nhanh nhất, +10 điểm";
            conversation.Invoke(new MethodInvoker(delegate ()
            {
                conversation.AppendText($"{message}\nĐáp án là: {ansNumber}.\n----------0o0----------\n");
                conversation.ScrollToCaret();
            }));
            BroadcastMessage($"s\ns{message}\nsĐáp án là: {ansNumber}.\ns----------0o0----------");
            if (currentRound > roundsPlayed) 
                (new Thread(endGame)).Start();
            else if (ingame) 
                (new Thread(roundStart)).Start();
        }

        private async void endGame()
        {
            string message;
            if (ingame)
            {
                ingame = false;
                int highscore = int.MinValue;
                foreach (var i in scoreBoard)
                {
                    if (i.Value > highscore)
                    {
                        highscore = i.Value;
                    }
                }

                message = $"sĐiểm cao nhất là: {highscore}\nNgười chơi có điểm cao nhất:\n";
                foreach (var i in scoreBoard)
                {
                    if (i.Value == highscore)
                    {
                        message += $"s  + {i.Key}\n";
                    }
                }

                foreach (var i in clients)
                {
                    try
                    {
                        NetworkStream stream = i.Value.GetStream();
                        byte[] buffer;
                        buffer = Encoding.UTF8.GetBytes($"{message}\nsĐiểm của bạn: {scoreBoard[i.Key]}\n");
                        stream.Write(buffer, 0, buffer.Length);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show($"Lỗi: {e.Message}");
                    }
                }
            }
            BroadcastMessage($"s=================\ns\nsTrò chơi đã kết thúc...\nsTấ cả người chơi hãy sẵn sàng...\n@@@Newgame!@@@");
            conversation.Invoke(new MethodInvoker(delegate ()
            {
                conversation.AppendText($"=================\n\nTrò chơi đã kết thúc...\nTấ cả người chơi hãy sẵn sàng...\n");
                conversation.ScrollToCaret();
            }));
            scoreBoard = scoreBoard.ToDictionary(p => p.Key, p => 0);
            roundsPlayed = 0;
            readyPlayers.Clear();

            string history = GetConversationText();
            await SendHistoryToWebsite(history);

            BroadcastMessage($"@@@SaveHistory!@@@{history}");
        }
        private string GetConversationText()
        {
            if (conversation.InvokeRequired)
            {
                return (string)conversation.Invoke(new Func<string>(GetConversationText));
            }
            else
            {
                return conversation.Text;
            }
        }

        private async Task SendHistoryToWebsite(string history)
        {
            Console.WriteLine(history);
            using (HttpClient client = new HttpClient())
            {
                var content = new StringContent(history, Encoding.UTF8, "text/plain");
                HttpResponseMessage response = await client.PostAsync("https://ctxt.io", content);
                Console.WriteLine(response);

                if (response.IsSuccessStatusCode)
                {
                    string responseUri = response.Headers.Location.ToString();
                    MessageBox.Show("History uploaded successfully. URL: " + responseUri);
                }
                else
                {
                    MessageBox.Show("Failed to upload history.");
                }
            }
        }

        private void ServerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ingame)
            {
                MessageBox.Show("Chờ game hiện tại kết thúc");
                e.Cancel = true;
                return;
            }


            if (server != null)
            {
                server.Stop();
            }

            if (thread != null)
            {
                thread.Abort();
            }
        }

    }

}
