using System;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace ServerReporter
{
    class ServerReporterApplicationContext : ApplicationContext
    {
        NotifyIcon notifyIcon = new NotifyIcon();
        Configuration configWindow = new Configuration();

        public ServerReporterApplicationContext()
        {
            MenuItem configMenuItem = new MenuItem("Configuration", new EventHandler(ShowConfig));
            MenuItem exitMenuItem = new MenuItem("Exit", new EventHandler(Exit));

            notifyIcon.Icon = Properties.Resources.AppIcon;
            notifyIcon.DoubleClick += new EventHandler(ShowConfiguration);
            notifyIcon.ContextMenu = new ContextMenu(new MenuItem[] { configMenuItem, exitMenuItem });
            notifyIcon.Visible = true;

            Thread thread = new Thread(this.EventLoop);
            thread.Start();
        }

        void ShowConfiguration(object sender, EventArgs e)
        {
            MessageBox.Show("Connecting to: " + Properties.Settings.Default.IP);
        }

        void ShowConfig(object sender, EventArgs e)
        {
            if (configWindow.Visible)
                configWindow.Focus();
            else
                configWindow.ShowDialog();
        }

        void Exit(object sender, EventArgs e)
        {
            notifyIcon.Visible = false;
            Application.Exit();
        }

        async void EventLoop()
        {
            while(true)
            {
                if (!configWindow.Visible)
                {
                    try
                    {
                        AsyncClient client = new AsyncClient();
                        client.StartClient();
                        await Task.Delay(Properties.Settings.Default.INT * 500);
                    }
                    catch
                    {
                        MessageBox.Show("Connection Error\nCheck Network\n\n", "Network Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                        configWindow.ShowDialog();
                        configWindow.Focus();
                    }
                }
            }
        }
    }
}