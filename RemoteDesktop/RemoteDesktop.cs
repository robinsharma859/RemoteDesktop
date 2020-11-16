using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Security;

namespace RemoteDesktop
{
    public class RemoteDesktop
    {
        private Process process = null;
        private ProcessStartInfo processStartInfo;
        //private HashSet<string> VMName = new HashSet<string>() { "CHA-EN-VCDQA4.wsdt.local", "cha-en-vst640.wsdt.local"};
        private HashSet<string> VMName = new HashSet<string>() { "cha-en-vcdwp227" };  //cha-en-vcdwp227
        string argument = string.Empty;
        UserCreds userCreds = null;

        public RemoteDesktop()
        {
            string paramerter = Environment.GetEnvironmentVariable("WorkerVM");
            Console.WriteLine("the paramerts are " + paramerter);
            Debug.WriteLine("paaramerts in debug " + paramerter);
            process = new Process();
            userCreds = new UserCreds() {userName="centraluser",password="$abcd1234" };
            processStartInfo = new ProcessStartInfo();
        }
        public void RemoteDesktopMachines()
        {
            SecureString secureString = new SecureString();
            Array.ForEach(userCreds.password.ToArray(), secureString.AppendChar);
            secureString.MakeReadOnly();


            Console.WriteLine(" Remote Deskop command Called");
            string executable = Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32\mstsc.exe");
            if (executable != null)
            {
                processStartInfo.FileName = executable;
                processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                processStartInfo.Verb = "runas";
                //processStartInfo.Domain = "wse";
                //process.StartInfo.UserName = userCreds.userName;
                //process.StartInfo.Password = secureString;
               // argument = string.Format(@"/generic:TERMSRV{0} /user:{1} /pass:{2}", VMName.FirstOrDefault(), userCreds.userName, userCreds.password);
                //argument = String.Format("/f /v {0}", VMName.FirstOrDefault());

                processStartInfo.Arguments = argument;
                Process.Start(processStartInfo);
                //process.StartInfo.UserName = userCreds.userName;
                //process.StartInfo.Password = userCreds.password;
                //process.StartInfo.Arguments="/v" +  

                String szCmd = "/c cmdkey.exe /generic:"+ VMName.FirstOrDefault() +  @"/user:centraluser" +" /pass:$abcd1234 & mstsc.exe /v " +  VMName.FirstOrDefault();
                ProcessStartInfo info = new ProcessStartInfo("cmd.exe", szCmd);
                info.Domain = "wsdt";
                Process proc = new Process();
                proc.StartInfo = info;
                proc.Start();

            }

        }
    }
}
