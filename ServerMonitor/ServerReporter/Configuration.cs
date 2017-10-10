using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerReporter
{
    public partial class Configuration : Form
    {
        public Configuration()
        {
            InitializeComponent();
        }

        private void LoadSettings(object sender, EventArgs e)
        {
            txt_ip.Text = Properties.Settings.Default.IP;
            txt_int.Text = Properties.Settings.Default.INT.ToString();
        }

        private void SaveSettings(object sender, EventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                Properties.Settings.Default.IP = txt_ip.Text;
                Properties.Settings.Default.INT = Convert.ToInt32(txt_int.Text);
                Properties.Settings.Default.Save();

                AsyncClient client = new AsyncClient();
                client.StartClient();
            }
        }
    }
}
