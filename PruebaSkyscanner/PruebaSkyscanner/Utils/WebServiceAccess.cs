using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using PruebaSkyscanner.DTOs;
using PruebaSkyscanner.Extensions;

namespace PruebaSkyscanner.Utils
{

    public class WebServiceAccess : IWebServiceAccess
    {

        private readonly string urlServices = "http://services.gisgraphy.com//geocoding/geocode";
        private static readonly string skyscannerKey = "?apikey=prtl6749387986743898559646983194";
        private static string country = "ES";
        private static string currency = "EUR";
        private static string locale = "es-ES";
        public static string Query { get; set; }
        public static dynamic JsonHoteles { get; set; }
        public static dynamic JsonCountries { get; set; }
        private const string hotelsAutosuggest = "http://partners.api.skyscanner.net/apiservices/hotels/autosuggest/v2/";

        public WebServiceAccess()
        { }
        public WebServiceAccess(string query)
        {
            Query = query;
        }
        private static string GenerateUrlAutoSuggest()
        {
            return Path.Combine(hotelsAutosuggest, country, currency, locale, Query, skyscannerKey);
        }

        public static dynamic GetCountries()
        {
            var query = "https://restcountries.eu/rest/v1/all";

            var wrGetUrl = CreateWebRequest(query);
            using (var objStream = wrGetUrl.GetResponse().GetResponseStream())
            {
                if (objStream == null)
                {
                    return null;
                }
                var objReader = new StreamReader(objStream);
                var readObj = objReader.ReadToEnd();
                dynamic o = JArray.Parse(readObj);
                JsonCountries = o;
                return o;
            }
        }

        public static List<string> GetCurrencyList()
        {
            var currencylist = new List<string>();

            foreach (var valor in JsonCountries)
            {
                string cu = valor.currencies.ToString();
                cu = cu.ReplaceSymbols().Trim();
                if (!currencylist.Contains(cu) && cu.Length < 4)
                {
                    currencylist.Add(cu.Trim());
                }
            }

            return currencylist;
        }

        public static string GetCountryData(string countryName)
        {
            return countryName;
        }

        public static dynamic GetHotelsFromSelectedLocation(LookUpHotelsParametersDto dto)
        {

            var query = "http://partners.api.skyscanner.net/apiservices/hotels/liveprices/v2/";

            var extraQuery = "?apikey=" + dto.ApiKey + "?pagesize=" + dto.PageSize + "?imagelimit=" + dto.ImageLimit;
            var uri = Path.Combine(query, dto.Market, dto.Currency, dto.Locale, dto.EntityId, dto.CheckInDate, dto.CheckOutDate, dto.Guests, dto.Rooms, extraQuery);
            var wrGetUrl = CreateWebRequest(uri);
            using (var objStream = wrGetUrl.GetResponse().GetResponseStream())
            {
                if (objStream == null)
                {
                    return null;
                }
                var objReader = new StreamReader(objStream);
                var readObj = objReader.ReadToEnd();
                dynamic o = JObject.Parse(readObj);
                JsonHoteles = o;
                return o;
            }


            return new object();
        }
        private static dynamic GetXmlSuggestedHotels()
        {

            try
            {
                var Url = GenerateUrlAutoSuggest();
                var wrGetUrl = CreateWebRequest(Url);
                using (var objStream = wrGetUrl.GetResponse().GetResponseStream())
                {
                    if (objStream == null)
                    {
                        return null;
                    }
                    var objReader = new StreamReader(objStream);
                    var readObj = objReader.ReadToEnd();
                    dynamic o = JObject.Parse(readObj);
                    JsonHoteles = o;
                    return o;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private static WebRequest CreateWebRequest(string query)
        {
            var wrGeturl = WebRequest.Create(query);
            wrGeturl.Proxy = WebProxy.GetDefaultProxy();
            return wrGeturl;
        }


        public static List<HotelResultDto> GetListHotelPlaceDto()
        {
            var citiesList = new List<HotelResultDto>();
            try
            {
                var doc = GetXmlSuggestedHotels();
                // returns to the view all places HotelPlaceDto, extracted from xml file


                foreach (var hotelPlace in doc.results)
                {
                    HotelResultDto dto;
                    dto = new HotelResultDto
                    {
                        DisplayName = hotelPlace.display_name,
                        ParentPlaceId = hotelPlace.parent_place_id,
                        IndividualId = hotelPlace.individual_id,
                        GeoType = hotelPlace.geo_type,
                        IsBookable = hotelPlace.is_bookable,
                        LocalisedGeoType = hotelPlace.localised_geo_type
                    };

                    dto.DisplayData = dto.DisplayName + " - " + GetToolTip(dto.IndividualId);

                    if (dto.GeoType.Equals("City"))
                        citiesList.Add(dto);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }



            return citiesList;
        }

        public static string GetIndividualId(XDocument doc, string parentPlaceId)
        {
            //return the IndividualId of the selected location
            //if GeoType is "City" and parentplaceid is selected

            return "";
        }

        //public string GetCoordinates(string city)
        //{
        //    string localization = "";
        //    var query = GenerateQuery(city);
        //    var wrGeturl = WebRequest.Create(query);
        //    wrGeturl.Proxy = WebProxy.GetDefaultProxy();
        //    using (var objStream = wrGeturl.GetResponse().GetResponseStream())
        //    {
        //        if (objStream != null)
        //        {
        //            var objReader = new StreamReader(objStream);
        //            var readObj = objReader.ReadToEnd();
        //            var xmlDoc = XDocument.Parse(readObj);
        //            var xElement = xmlDoc.Element("results");
        //            if (xElement != null)
        //            {
        //                var lat = xElement.Element("result").Element("lat");
        //                var lng = xElement.Element("result").Element("lng");
        //                localization = lat.Value + "," + lng.Value + "-latlong";
        //            }
        //        }
        //    }

        //    return localization;

        //}

        public string GenerateQuery(string city)
        {
            var ret = urlServices + "?address=" + city;

            return ret;
        }


        public static string GetToolTip(string selectedValue)
        {
            string ret = "";
            var parentId = "";
            foreach (var hotel in JsonHoteles.results)
            {
                if (hotel.individual_id == selectedValue)
                {
                    parentId = hotel.parent_place_id;
                }
            }
            foreach (var place in JsonHoteles.places)
            {

                if (place.place_id == parentId)
                {
                    ret += place.admin_level1 + " - " + place.country_name;
                }

            }
            return ret;
        }

        internal static List<Tuple<string, string>> GetLanguageList()
        {
            var languageList = new List<Tuple<string,string>>();
            languageList.Add(new Tuple<string, string> ( "Español", "es-ES") );
            languageList.Add(new Tuple<string, string> ("Ingles", "en-US" ));
            languageList.Add(new Tuple<string, string> ( "Aleman", "de-DE" ));
            languageList.Add(new Tuple<string, string> ( "Frances", "fr-FR" ));
            languageList.Add(new Tuple<string, string>("Frances", "it-IT"));
            languageList.Add(new Tuple<string, string>("Frances", "jp-JP"));
            return languageList;
        }

        internal static List<string> GetCountryList(string country)
        {

          var key = country.Split('-')[0].ToString();
            foreach (var item in JsonCountries.translations)
            {
              var a = item;
            }
          return new List<string> ();
        }
    }
}
