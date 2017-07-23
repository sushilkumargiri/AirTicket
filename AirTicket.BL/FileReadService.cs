using AirTicket.DL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTicket.BL
{
    public class FileReadService : IFileReadService
    {
        private readonly IFileReadRepository _fileReadRepository;
        public FileReadService(IFileReadRepository fileReadRepository)
        {
            _fileReadRepository = fileReadRepository;
        }
        public List<string> ReadXmlFile()
        {
            var xmlDataStr = _fileReadRepository.ReadXmlFile();
            return xmlDataStr;
        }

        public string ReadXsltFile()
        {
            var xsltDataStr = _fileReadRepository.ReadXsltFile();
            return xsltDataStr;
        }
    }
}
