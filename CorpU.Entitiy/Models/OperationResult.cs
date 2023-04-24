using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Entitiy.Models
{
    public class OperationResult
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Error { get; set; }
        public dynamic Data { get; set; }
    }
}
