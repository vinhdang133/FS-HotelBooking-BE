using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSDotNet.Common.DTO
{
    public class ResponseDTO
    {

        public bool IsSuccess { get; set; } 
        public object Data { get; set; }

        public BusinessCode.BusinessCode BusinessCode { get; set; }

    }
}
