using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PruebaSkyscanner.DTOs;
using PruebaSkyscanner.Model;
using PruebaSkyscanner.Views;

namespace PruebaSkyscanner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Utils.WebServiceAccess.GetCountries();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Session session = new Session(txtCity.Text);
            var data = session.GenerateListOfPlaces();
            listHotels.SelectedIndexChanged -= listHotels_SelectedIndexChanged;
            listHotels.DataSource = data;
            listHotels.DisplayMember = "DisplayData";
            listHotels.ValueMember = "IndividualId";
            listHotels.SelectedIndexChanged += listHotels_SelectedIndexChanged;
            listHotels.SelectedIndex = -1;

        }


        private void listHotels_SelectedIndexChanged(object sender, EventArgs e)
        {

            var list = listHotels.SelectedItem as HotelResultDto;
            if (list != null)
            {
                var tooltip = Utils.WebServiceAccess.GetToolTip(list.IndividualId);
                var locationId = list.IndividualId;
                lblExtraData.Text = tooltip;

                var frmViews = new FrmInsertHotelDetails((listHotels.SelectedItem as HotelResultDto).IndividualId);
                frmViews.Show();
            }

        }

        private void btnLookUpHotels_Click(object sender, EventArgs e)
        {
            var id = (listHotels.SelectedItem as HotelResultDto).IndividualId;

            // var result = Utils.WebServiceAccess.GetHotelsFromSelectedLocation(id);
        }

        private void txtCity_TextChanged(object sender, EventArgs e)
        {
            Session session = new Session(txtCity.Text);
            var data = session.GenerateListOfPlaces();
            listHotels.SelectedIndexChanged -= listHotels_SelectedIndexChanged;
            listHotels.DataSource = data;
            listHotels.DisplayMember = "DisplayData";
            listHotels.ValueMember = "IndividualId";
            listHotels.SelectedIndexChanged += listHotels_SelectedIndexChanged;
            listHotels.SelectedIndex = -1;
        }
    }
}
