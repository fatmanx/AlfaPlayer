using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AlfaPlayer2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //RegisterForRecovery();
            //RegisterForRestart();

            try
            {

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                


                //Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                //Application.ThreadException += Application_ThreadException;
                //AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
                Application.Run(new MainForm());
            }
            catch
            {

            }
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            if (!Debugger.IsAttached)
            {
                System.Diagnostics.Process.Start(System.Reflection.Assembly.GetEntryAssembly().Location);
            }
            Environment.Exit(1);

        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (!Debugger.IsAttached)
            {
                System.Diagnostics.Process.Start(System.Reflection.Assembly.GetEntryAssembly().Location);
            }
            Environment.Exit(1);
        }


        #region recovery



        [Flags]
        public enum RestartRestrictions
        {
            None = 0,
            NotOnCrash = 1,
            NotOnHang = 2,
            NotOnPatch = 4,
            NotOnReboot = 8
        }

        public delegate int RecoveryDelegate(RecoveryData parameter);

        public static class ArrImports
        {
            [DllImport("kernel32.dll")]
            public static extern void ApplicationRecoveryFinished(
                bool success);

            [DllImport("kernel32.dll")]
            public static extern int ApplicationRecoveryInProgress(
                out bool canceled);

            [DllImport("kernel32.dll")]
            public static extern int GetApplicationRecoveryCallback(
                IntPtr processHandle,
                out RecoveryDelegate recoveryCallback,
                out RecoveryData parameter,
                out uint pingInterval,
                out uint flags);

            [DllImport("KERNEL32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
            public static extern int GetApplicationRestartSettings(
                IntPtr process,
                IntPtr commandLine,
                ref uint size,
                out uint flags);

            [DllImport("kernel32.dll")]
            public static extern int RegisterApplicationRecoveryCallback(
                RecoveryDelegate recoveryCallback,
                RecoveryData parameter,
                uint pingInterval,
                uint flags);

            [DllImport("kernel32.dll")]
            public static extern int RegisterApplicationRestart(
                [MarshalAs(UnmanagedType.BStr)] string commandLineArgs,
                int flags);

            [DllImport("kernel32.dll")]
            public static extern int UnregisterApplicationRecoveryCallback();

            [DllImport("kernel32.dll")]
            public static extern int UnregisterApplicationRestart();
        }

        public class RecoveryData
        {
            string currentUser;

            public RecoveryData(string who)
            {
                currentUser = who;
            }
            public string CurrentUser
            {
                get { return currentUser; }
            }
        }

        // This method is invoked by WER 
        static int RecoveryProcedure(RecoveryData parameter)
        {
            Console.WriteLine("Recovery in progress for {0}", parameter.CurrentUser);

            // Set up timer to notify WER that recovery work is in progress.
            //Timer pinger = new Timer(4000);
            //pinger.Elapsed += new ElapsedEventHandler(PingSystem);
            //pinger.Enabled = true;

            // Do recovery work here.
            //if (log != null)
            //    log.Close();

            // Simulate long running recovery.
            System.Threading.Thread.Sleep(9000);

            // Indicate that recovery work is done.
            Console.WriteLine("Application shutting down...");
            ArrImports.ApplicationRecoveryFinished(true);
            return 0;
        }


        private static void RegisterForRestart()
        {
            // Register for automatic restart if the application was terminated for any reason.
            ArrImports.RegisterApplicationRestart("/restart",
               (int)RestartRestrictions.None);
        }

        private static void RegisterForRecovery()
        {
            // Create the delegate that will invoke the recovery method.
            RecoveryDelegate recoveryCallback = new RecoveryDelegate(RecoveryProcedure);
            uint pingInterval = 5000, flags = 0;
            RecoveryData parameter = new RecoveryData(Environment.UserName);

            // Register for recovery notification.
            int regReturn = ArrImports.RegisterApplicationRecoveryCallback(
            recoveryCallback,
            parameter,
            pingInterval,
            flags);
        }




        #endregion
    }
}
