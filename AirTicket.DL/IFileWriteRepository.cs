using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTicket.DL
{
    public interface IFileWriteRepository
    {
        bool WriteHtmlFile(string htmlStrings, string fileName);
    }
}
