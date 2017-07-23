using AirTicket.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTicket.BL
{
    public class FileWriteService : IFileWriteService
    {
        private readonly IFileWriteRepository _fileWriteRepository;
        public FileWriteService(IFileWriteRepository fileWriteRepository)
        {
            _fileWriteRepository = fileWriteRepository;
        }
        public bool WriteHtmlFile(string htmlData, string fileName)
        {
            return _fileWriteRepository.WriteHtmlFile(htmlData, fileName);
        }
    }
}
