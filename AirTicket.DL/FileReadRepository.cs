using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTicket.DL
{
    public class FileReadRepository : IFileReadRepository
    {
        string projectPath = System.Configuration.ConfigurationManager.AppSettings["ProjectPath"];
        public List<string> ReadXmlFile()
        {
            var xmlDataStr = new List<string>();
            foreach (string file in Directory.EnumerateFiles(Path.Combine(projectPath,"Data/Computers"), "*.xml"))
            {
                //xmlDataStr.Add(File.ReadAllText(file));
                using (var reader = new StreamReader(file))
                {
                    xmlDataStr.Add(reader.ReadToEndAsync().Result);
                }
            }
            return xmlDataStr;
        }
        public string ReadXsltFile()
        {
            var xsltDataStr = string.Empty;
            using (var reader = new StreamReader(Path.Combine(projectPath, "Resources/Computer.xslt")))
            {
                xsltDataStr = reader.ReadToEndAsync().Result;
            }
            //var xsltDataStr = File.ReadAllText(Path.Combine(projectPath, "Resources/Computer.xslt"));

            return xsltDataStr;
        }
    }
}
