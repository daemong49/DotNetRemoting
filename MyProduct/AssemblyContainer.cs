using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProduct
{
    [Serializable]
    public class AssemblyContainer
    {
        public string AssemblyName { get; set; }

        public string Version { get; set; }

        public byte[] Bytes { get; set; }
        
    }
}
