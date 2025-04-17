using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardFlip.Classes
{
    [Serializable]
    public  class ApplicationSetting
    {
        public string Name { get; set; }

        public Gender Gender { get; set; }
        public string OnlineServerHostName { get; set; }
        public string OnlineServerIpAddress { get; set; }
        public string OnlineServerPassword { get; set; }
        public string OnlineServerUserName { get; set; }

        public string OnlineServerDatabaseName { get; set; }
        public string OnlineServerPort { get; set; }

    }
}
