using Serilog;
using System;
using System.Windows.Forms;


namespace AdmissionCommittee
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Log.Logger = new LoggerConfiguration()
        .MinimumLevel.Information()
        .WriteTo.File("logs/performance.log",
            rollingInterval: RollingInterval.Day)
        .CreateLogger();

            ApplicationConfiguration.Initialize();
            System.Windows.Forms.Application.Run(new MainForm());
        }
    }
}