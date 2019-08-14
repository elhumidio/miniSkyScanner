using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using PruebaSkyscanner.DTOs;
using PruebaSkyscanner.Properties;



namespace PruebaSkyscanner.Model
{
   public  class Session
    {
       string City { get; set; }
       readonly List<Hotels> hotelList = new List<Hotels>();
       

       public Session(string city)
       {
           City = city;
           Utils.WebServiceAccess.Query = City;
       }

       public List<HotelResultDto> GenerateListOfPlaces()
       {
           List<HotelResultDto> list = new List<HotelResultDto>();
           try
           {
               list = Utils.WebServiceAccess.GetListHotelPlaceDto();
           }
           catch (Exception ex)
           {
               //MessageBox.Show(ex.ToString());
           }

           return list;
       }

       
     

     

    }
}
