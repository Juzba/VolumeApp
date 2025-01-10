namespace VolumeApp.Main;

internal static class Program
{
    public static bool form1Visible = false;
    public static CancellationTokenSource cts = new(); 
    private static Form1 mainForm;
    private static System.Timers.Timer myTimer;

    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        mainForm = new Form1 { ShowInTaskbar = false, WindowState = FormWindowState.Minimized };
        mainForm.FormClosing += MainForm_FormClosing;


        // Vytvoøí nové vlákno které bude valit volume
        Thread thread = new Thread(new ThreadStart(ThreadVolume));
        thread.Start();



        



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


    static void ThreadVolume()
    {
        Volume.VolumeMain();
    }


}