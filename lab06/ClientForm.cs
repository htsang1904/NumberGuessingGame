using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace lab06
{
    public partial class ClientForm : Form
    {
        private TcpClient client;
        private Thread thread;
        private String _username;
        private int timeOut = -1, lastSubmitTime, valRange;
        public bool isIngame = false, isAuto = false;
        private int minRange;
        private int maxRange;
        private Random rnd = new Random();
        private List<int> ansList;

        public ClientForm()
        {
            InitializeComponent();
        }

        public void SetUsername(string username)
        {
            _username = username;
        }

        public string GetUsername()
        {
            return _username;
        }

        public bool ConnectToServer()
        {
            try
            {
                client = new TcpClient();
                client.Connect("127.0.0.1", 8080);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không có game nào đang diễn ra");
                return false;
            }
        }
        private async void ClientForm_Load(object sender, EventArgs e)
        {
            try
            {
                NetworkStream stream = client.GetStream();
                byte[] buffer = Encoding.UTF8.GetBytes(_username);
                stream.Write(buffer, 0, buffer.Length);
                stream.Flush();

                this.Invoke(new MethodInvoker(delegate ()
                {
                    this.Text = _username;
                    answer.Enabled = btnSubmit.Enabled =  btnAutoplayAllRound.Enabled = false;
                }));
                sendData($"m>>> {_username} vừa vào phòng");

                thread = new Thread(o => ClientThread((TcpClient)o));
                thread.Start(client);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khởi động form: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

        }
        
        private void ClientThread(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            byte[] receivedBytes = new byte[1024];
            int bytesCount;

            while (Thread.CurrentThread.IsAlive)
            {
                try
                {
                    if ((bytesCount = stream.Read(receivedBytes, 0, receivedBytes.Length)) <= 0) break;
                }
                catch { break; }
                string respondFromServer = Encoding.UTF8.GetString(receivedBytes, 0, bytesCount);
                if (respondFromServer.StartsWith("@@@SaveHistory!@@@"))
                {
                    Console.WriteLine("data: " + respondFromServer);
                    string historyToken = "@@@SaveHistory!@@@";
                    int index = respondFromServer.IndexOf(historyToken);
                    string history = respondFromServer.Substring(index + historyToken.Length);
                    Console.WriteLine("history: " + history);
                    SaveHistory(history);
                    new Thread(() => MessageBox.Show("Đã lưu lịch sử trò chơi")).Start();
                }
                var dataList = respondFromServer.Split(new String[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (String data in dataList)
                {
                    if (data[0] == 's')
                        conversation.Invoke(new MethodInvoker(delegate ()
                        {
                            conversation.AppendText($"{data.Substring(1)}\n");
                            conversation.ScrollToCaret();
                        }));
                    else if (data[0] == '\t')
                        this.Invoke(new MethodInvoker(delegate ()
                        {
                            tbClientCount.Text = $"Phòng có: {data.Substring(1)} người chơi";
                        }));
                    else if (data.StartsWith("@@@Nextround!@@@"))
                    {
                        if (!isIngame) isIngame = true;
                        var rand = data.Substring(16).Split(new String[] { "\t" }, StringSplitOptions.RemoveEmptyEntries);
                        minRange = Int32.Parse(rand[1]);
                        maxRange = Int32.Parse(rand[2]);
                        valRange = maxRange - minRange;
                        ansList = Enumerable.Range(minRange, valRange + 1).ToList();
                        lastSubmitTime = 100;
                        this.Invoke(new MethodInvoker(delegate ()
                        {
                            answer.Focus();
                            answer.Select();
                        }));
                        timeOut = 8;
                        this.Invoke(new MethodInvoker(delegate ()
                        {
                            answer.Focus();
                            timerCountDown.Text = timeOut.ToString();
                            timer1.Start();
                        }));
                    }
                    else if (data == "@@@Newgame!@@@")
                    {
                        this.Invoke(new MethodInvoker(delegate ()
                        {
                            btnReady.Enabled = true;
                            btnSubmit.Enabled = btnAutoplayAllRound.Enabled = answer.Enabled = false;
                        }));
                        isIngame = isAuto = false;
                    }
                }
            }
            stream.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            submit(Int32.Parse(answer.Text));
            answer.Clear();
        }

        private void submit(int val)
        {
            if (timeOut <= 0 || lastSubmitTime - timeOut < 3)
            {
                Console.WriteLine("đợi 3 giây");
                return;
            }
            new Thread(() => sendData($"g{val}")).Start();

            lastSubmitTime = timeOut;
            if (!this.InvokeRequired)
            {
                btnSubmit.Enabled = answer.Enabled = false;
            }
            int index = ansList.IndexOf(val);

            if (index != -1 && index <= valRange)
            {
                int temp = ansList[valRange];
                ansList[valRange] = ansList[index];
                ansList[index] = temp;
                valRange--;
            }
        }

        private void autoSubmit()
        {
            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(delegate ()
                {
                    autoSubmit();
                }));
            else
            {
                btnSubmit.Enabled = answer.Enabled = false;
                if (isAuto)
                {
                    btnAutoplayAllRound.Enabled = false;
                }
                int val = rnd.Next(0, valRange + 1);
                submit(ansList[val]);
            }
        }

        private void btnReady_Click(object sender, EventArgs e)
        {
            btnReady.Enabled = false;
            sendData($"m---- {_username} đã sẵn sàng! ----");
            sendData("---Ready!---");
            this.Invoke(new MethodInvoker(delegate ()
            {
                answer.Enabled = btnSubmit.Enabled = btnAutoplayAllRound.Enabled = true;
            }));
        }

        private void btnAutoplayAllRound_Click(object sender, EventArgs e)
        {
            isAuto = true;
            autoSubmit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timeOut--;
            if (timeOut > -1)
            {
                timerCountDown.Text = timeOut.ToString();
                if (timeOut == 0)
                {
                    sendData("@@@Timeup!@@@");
                }
                else if (isAuto && lastSubmitTime - timeOut >= 3)
                {
                    new Thread(() => autoSubmit()).Start();
                }
                else if (!isAuto && lastSubmitTime - timeOut >= 3)
                {
                    btnSubmit.Enabled = answer.Enabled = true;
                    answer.Focus();
                    answer.Select();
                }
            }
            else
            {
                timerCountDown.Text = "...";
                timer1.Stop();
            }
        }
        private void sendData(String message)
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = Encoding.UTF8.GetBytes($"{message}\n");
            stream.Write(buffer, 0, buffer.Length);
        }

        private void SaveHistory(string message)
        {
            using (StreamWriter writer = new StreamWriter($"C:\\Users\\sang\\source\\repos\\lab06\\lab06\\history\\{_username}_history.txt", true))
            {
                writer.WriteLine(message);
            }
        }

        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isIngame)
            {
                new Thread(() => MessageBox.Show("Vui lòng chờ round hiện tại kết thúc", "Error")).Start();
                e.Cancel = true;
                return;
            }
            sendData($"m>>> {_username} đã rời khỏi phòng");
            if (client != null)
            {
                client.Close();
                client = null;
            }
            if (thread != null)
            {
                thread.Abort();
            }
        }
    }
}
