using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaSkyscanner.Views
{
    public partial class FrmInsertHotelDetails : Form
    {
        private string locationId;
        public FrmInsertHotelDetails()
        {
            InitializeComponent();
        }
        public FrmInsertHotelDetails(string locationId)
        {
            InitializeComponent();
            LocationId = locationId;
        }

        public string LocationId
        {
            get { return locationId; }
            set { locationId = value; }
        }

        private void FrmInsertHotelDetails_Load(object sender, EventArgs e)
        {
            //TODO Load Currency Combo
           cmbCurrencies.DataSource = Utils.WebServiceAccess.GetCurrencyList();
           cmbLanguages.DataSource = Utils.WebServiceAccess.GetLanguageList();
          cmbLanguages.ValueMember = "Item2";
          cmbLanguages.DisplayMember = "Item1";


          // TODO Load language combo
        }

        private void comboCountries_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

      private void cmbLanguages_SelectedIndexChanged(object sender, EventArgs e)
      {
        comboCountries.DataSource =
          Utils.WebServiceAccess.GetCountryList((cmbLanguages.SelectedItem as Tuple<string, string>).Item2);
      }

      private void btnLookHotels_Click(object sender, EventArgs e)
        {

        }


    }
}
