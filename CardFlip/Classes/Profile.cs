using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardFlip.Classes
{
    public  class Profile
    {
        public string Name { get; set; }

        public Gender Gender { get; set; }

        public string Ipaddress {  get; set; }

        public string Hostname { get; set; }


        public Profile() { }
        public Profile(string name,Gender  gender,string ipAddress,string hostName) 
        {
            Name = name;
            Gender = gender;
            Ipaddress = ipAddress;
            Hostname = hostName;
        }
    }
}
