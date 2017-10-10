using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerMonitor
{
    public partial class CommunicationDisplay : Form
    {
        private string raw_data = string.Empty;
        private List<string> data = new List<string>();

        Socket listener;
        IPEndPoint localEndPoint;

        public CommunicationDisplay()
        {
            InitializeComponent();

            bw_socket.WorkerReportsProgress = false;
            bw_socket.WorkerSupportsCancellation = false;

            bw_socket.DoWork += new DoWorkEventHandler(bw_socket_dowork);
            bw_socket.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_socket_runworkercomplete);

            //Establish local endpoint for socket.
            IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            localEndPoint = new IPEndPoint(ipAddress, 11047);

            //Create TCP/IP socket.
            listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            listener.Bind(localEndPoint);
            listener.Listen(10);

            bw_socket.RunWorkerAsync();
        }

        private void bw_socket_dowork(object sender, DoWorkEventArgs e)
        {
            //Listens for request
            byte[] bytes = new byte[1024];

            //Bind socket local endpoint and listen for connections.
            try
            {
                Socket handler = listener.Accept();
                raw_data = string.Empty;

                while (true)
                {
                    bytes = new byte[1024];
                    int bytesRec = handler.Receive(bytes);
                    raw_data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                    if (raw_data.IndexOf("<EOF>") > -1)
                        break;
                }

                // Echo data back
                byte[] msg = Encoding.ASCII.GetBytes(raw_data);
                handler.Send(msg);
                handler.Shutdown(SocketShutdown.Both);
                handler.Close();

                // Store Data
                data.Clear();

                string[] words = raw_data.Split(' ');
                data = new List<string>(words);
                data.Remove("<EOF>");
                data.Add(System.DateTime.Now.ToLongTimeString());
            }
            catch (Exception exp)
            {
                System.Console.WriteLine(exp.ToString());
            }
        }

        private void bw_socket_runworkercomplete(object sender, RunWorkerCompletedEventArgs e)
        {
            //Displays data
            bool update = false;

            foreach (DataGridViewRow row in dgv_data.Rows)
            {
                if ((string)row.Cells["server_name"].Value == data[0])
                {
                    row.Cells["server_ip"].Value = data[1];
                    row.Cells["last_comm"].Value = data[2];
                    update = true;
                }
            }

            if (!update)
                dgv_data.Rows.Add(data.ToArray());

            //Restarts socket
            bw_socket.RunWorkerAsync();
        }
    }
}
