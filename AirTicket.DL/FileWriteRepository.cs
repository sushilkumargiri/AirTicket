using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTicket.DL
{
    public class FileWriteRepository : IFileWriteRepository
    {
        string projectPath = System.Configuration.ConfigurationManager.AppSettings["ProjectPath"];
        public bool WriteHtmlFile(string htmlStrings, string fileName)
        {
            try
            {
                string path = Path.Combine(projectPath, "Data/Output/");
                using (FileStream fs = new FileStream(path + fileName, FileMode.Create))
                {
                    using (StreamWriter w = new StreamWriter(fs, Encoding.UTF8))
                    {
                        w.WriteLine(htmlStrings);
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
