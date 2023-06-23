using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.BLL.Dtos
{
    public class ResponseModel
    {
        public string? Message { get; set; }
        public string? Result { get; set; }
    }

    public enum Result
    {
        Success,
        Error
    }
}
