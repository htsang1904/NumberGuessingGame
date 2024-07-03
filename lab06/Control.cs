using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab06
{
    public partial class Control : Form
    {
        private Dictionary<string, ClientForm> openClients = new Dictionary<string, ClientForm>();


        public Control()
        {
            InitializeComponent();
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            String username = tbUsername.Text;
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Vui lòng nhập Username!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (openClients.ContainsKey(username))
            {
                MessageBox.Show("User đã tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            ClientForm clientForm = new ClientForm();
            if (clientForm.ConnectToServer())
            {
                clientForm.SetUsername(username);
                clientForm.FormClosed += ClientForm_FormClosed;
                clientForm.Show();
                openClients[username] = clientForm;
            }
        }

        private void btnServer_Click(object sender, EventArgs e)
        {
            ServerForm serverForm = new ServerForm();
            serverForm.Show();
        }

        private void ClientForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            var clientForm = sender as ClientForm;
            
            if (clientForm != null)
            {
                openClients.Remove(clientForm.GetUsername());
            }

            foreach (var client in openClients)
            {
                Console.WriteLine(client.Key);
            }
        }
    }
}
