using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotelCalifornia
{
    class Command
    {
        //Command words class wrapper
        public String CommandWord { get; set; }
        public String SecondWord { get; set; }
        public String ThirdWord { get; set; }
        public String FourthWord { get; set; }

        public Boolean IsUnknown { get { return (CommandWord == null); } }
    }
}
