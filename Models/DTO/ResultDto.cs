using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class ResultDto
    {
        public string Location {get;set;} = null!;
        public List<IspSpeedDto> ISPs {get; set;} = null!;
    }

    public class IspSpeedDto {
        public string ISP {get;set;} = null!;
        public double UploadSpeed {get; set;}
        public double DownloadSpeed {get;set;}
    }
}