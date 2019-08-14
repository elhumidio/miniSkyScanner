using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaSkyscanner.DTOs
{
    public class HotelResultDto
    {

        public string DisplayName { get; set; }
        public string ParentPlaceId { get; set; }
        public bool QueryId { get; set; }
        public string IndividualId { get; set; }
        public string GeoType { get; set; }
        public string LocalisedGeoType { get; set; }
        public bool IsBookable { get; set; }
        public string DisplayData { get; set; }

    }
}
