using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTicket.BL
{
    public interface IFileTransformService
    {
        string TransformXMLToHTML(string inputXml, string xsltString);
    }
}
