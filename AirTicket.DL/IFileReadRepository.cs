using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTicket.DL
{
    public interface IFileReadRepository
    {
        List<string> ReadXmlFile();
        string ReadXsltFile();
    }
}
