using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HIAWebService.Models
{
    public class RealTimeData
    {
        public string Email { get; set; }
        public string Lat { get; set; }

        public string Lng { get; set; }

        public string BPM { get; set; }

        public string Temperatura { get; set; }
    }


    public class RealTimeCoordinates
    {
        public string Email { get; set; }
        public string Lat { get; set; }

    }
}
