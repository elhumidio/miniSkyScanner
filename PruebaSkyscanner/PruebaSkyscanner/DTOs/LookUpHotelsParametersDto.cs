using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PruebaSkyscanner.DTOs
{
    public class LookUpHotelsParametersDto
    {
        [DataMember]
        public string Market { get; set; }

        [DataMember]
        public string Currency { get; set; }

        [DataMember]
        public string Locale { get; set; }

        [DataMember]
        public string EntityId { get; set; }

        [DataMember]
        public string CheckInDate { get; set; }

        [DataMember]
        public string CheckOutDate { get; set; }

        [DataMember]
        public string Guests { get; set; }

        [DataMember]
        public string Rooms { get; set; }

        [DataMember]
        public string ApiKey { get; set; }

        [DataMember]
        public string PageSize { get; set; }

        [DataMember]
        public string ImageLimit { get; set; }
    }
}
