using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RemoteDesktop
{
    sealed class SetGlobalParameters
    {
        private XmlDocument xmlDocument = null;
        string globalPath = new DirectoryInfo(Assembly.GetExecutingAssembly().Location.ToString()).Parent.Parent.Parent.FullName.ToString() + "\\Config\\Config.xml";
        public SetGlobalParameters()
        {
            xmlDocument = new XmlDocument();
            xmlDocument.Load(globalPath);
        }

        public void SetGlobalParams()
        {
            Console.WriteLine("Setting Global Parameters");
            GlobalParameters.URL = xmlDocument["Configuration"]["URL"].InnerText;
            Console.WriteLine("URL is " +  GlobalParameters.URL);
            GlobalParameters.UserName = xmlDocument["Configuration"]["UserName"].InnerText.Replace("{",string.Empty).Replace("}",string.Empty);
            Console.WriteLine("UserName is " + GlobalParameters.UserName);

            GlobalParameters.Browser = xmlDocument["Configuration"]["Browser"].InnerText.Replace("{", string.Empty).Replace("}", string.Empty);
            Console.WriteLine("Browser is " + GlobalParameters.Browser);

        }
    }
}
