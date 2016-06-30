using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    class NewNameClass
    {
        public NewNameClass()
        {

        }
        private string _address;
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public string AnotherName { get; set; }
    }
}
