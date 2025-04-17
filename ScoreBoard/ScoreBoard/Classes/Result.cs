using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CardFlip.Classes
{
    public class Result
    {
        public string Name {  get; set; }
        public int Position { get; set; }
        public string Hostname {  get; set; }
        public string IpAddress {  get; set; }
        public TimeSpan Duration { get; set; }

        public Result(string name,int position,string hostname,string ipAddress,TimeSpan duration) 
        {
            Name = name;
            Position = position;
            Hostname = hostname;
            IpAddress = ipAddress;
            Duration = duration;
        }

        
    }
}
