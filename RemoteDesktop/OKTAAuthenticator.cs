using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OtpNet;


namespace RemoteDesktop
{
    public class OKTAAuthenticator
    {
      private  Totp otpReader;
        public OKTAAuthenticator()
        {
            byte[] secreatKey = Encoding.ASCII.GetBytes(("080693"));
            otpReader = new Totp(secreatKey);
            otpReader.ComputeTotp(DateTime.UtcNow);
        }
    }
}
