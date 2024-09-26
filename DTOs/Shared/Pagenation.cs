using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Shared
{
    public class Pagenation<T>
    { 
        public List<T> Entity { set; get; }
        public int Count { get; set; }
    }
}
