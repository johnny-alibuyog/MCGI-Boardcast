using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCGIBroadcast.Models
{
    public class BroadcastModel
    {
        public string ChannelID { get; set; }
        public string ChannelName { get; set; }
        public string ChannelDescription { get; set; }
        public string ChannelLogo { get; set; }
        public string StreamSource { get; set; }
        public string StreamName { get; set; }
        public string ListOrder { get; set; }
    }
}
