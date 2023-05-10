using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Common
{
    public class PasswordSettings
    {
        public string LowerCase { get; set; }
        public string UpperCase { get; set; }
        public string Numbers { get; set; }
        public string Specials { get; set; }
        public int keySize { get; set; }
        public int iterations { get; set; }
    }
}
