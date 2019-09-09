using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quaker.Classes
{
    public class Sound
    {
        private String path = "";
        private String type = "";

        public String Path
        {
            get => path;
            set { path = value; }
        }
        public String Type
        {
            get => type;
            set { type = value; }
        }
    }
}
