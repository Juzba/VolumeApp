namespace VolumeApp.Main;

internal static class Program
{
    static Form1 mainForm;
    public static bool form1Visible = false;

    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        mainForm = new Form1 { ShowInTaskbar = false, WindowState = FormWindowState.Minimized };
        mainForm.FormClosing += MainForm_FormClosing;

        Tray.Minimized(mainForm);




        Application.Run(mainForm);

    }


    private static void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (form1Visible)
        {
            e.Cancel = true;
            mainForm.Hide();
            mainForm.ShowInTaskbar = false;
        }
    }
}