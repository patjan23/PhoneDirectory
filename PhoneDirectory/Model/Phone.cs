using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace PhoneDirectory.Model
{
   
    public class Phone
    {       
        public string Name { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; } = true;
        public string Number { get; set; }
       
    }


}
