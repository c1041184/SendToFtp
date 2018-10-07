using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendToFtp
{
    class FileName
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public FileName(string name)
        {
            Name = name;
        }
    }
}
