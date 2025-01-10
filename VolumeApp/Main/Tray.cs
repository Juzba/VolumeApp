namespace VolumeApp.Main
{
    internal class Tray
    {

        public static void Minimized(Form1 form)
        {

            NotifyIcon trayIcon = new NotifyIcon
            {
                Icon = SystemIcons.Application,
                Visible = true,
                ContextMenuStrip = new ContextMenuStrip()
            };


            trayIcon.ContextMenuStrip.Items.Add("Open", null, (sender, e) =>
            {
                form.Show();
                Program.form1Visible = true;
                form.WindowState = FormWindowState.Normal;
                form.ShowInTaskbar = true;
                form.BringToFront();
            });


            trayIcon.ContextMenuStrip.Items.Add("Exit", null, (sender, e) =>
            {
                Program.form1Visible = false;
                trayIcon.Visible = false;
                Application.Exit();
            });

        }















    }
}
