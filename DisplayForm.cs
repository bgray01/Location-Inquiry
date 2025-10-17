using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Location_Inquiry
{
    public partial class Form1 : Form
    {
        private List<Location> locations = new List<Location>()
        {
            new Location { Loc = "1AZ001A01", HandlingType = "MP", LPN = "0000007852", SKU = "58006152250006-12", Quantity = 20 },
            new Location { Loc = "1EN007K02", HandlingType = "URI", LPN = "550000001751", SKU = "000000062544", Quantity = 6 },
            new Location { Loc = "1BA029B03", HandlingType = "MP", LPN = "78552", SKU = "580002546600015XL", Quantity = 92 }
        };

        private TextBox txtCode;
        private Button btnSearch;
        private ListBox lstResults;

        public Form1()
        {
            InitializeComponent();
            this.Text = "Location Inquiry Simulator";
            this.Size = new Size(500, 400);

            // TextBox
            txtCode = new TextBox();
            txtCode.Location = new Point(30, 30);
            txtCode.Width = 200;
            this.Controls.Add(txtCode);

            // Button
            btnSearch = new Button();
            btnSearch.Text = "Run Inquiry";
            btnSearch.Location = new Point(250, 28);
            btnSearch.Click += BtnSearch_Click;
            this.Controls.Add(btnSearch);

            // ListBox
            lstResults = new ListBox();
            lstResults.Location = new Point(30, 80);
            lstResults.Size = new Size(400, 200);
            lstResults.DoubleClick += LstResults_DoubleClick;
            this.Controls.Add(lstResults);
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            lstResults.Items.Clear();
            string code = txtCode.Text.Trim();

            var results = locations.Where(l => l.Code.Equals(code, StringComparison.OrdinalIgnoreCase)).ToList();

            if (results.Count == 0)
            {
                MessageBox.Show("No location found.", "Result");
            }
            else
            {
                foreach (var loc in results)
                {
                    lstResults.Items.Add($"{loc.Code} - {loc.Name} ({loc.Status})");
                }
            }
        }

        private void LstResults_DoubleClick(object sender, EventArgs e)
        {
            if (lstResults.SelectedIndex >= 0)
            {
                string selected = lstResults.SelectedItem.ToString();
                string code = selected.Split('-')[0].Trim();
                Location loc = locations.First(l => l.Code == code);

                LocationPopupForm popup = new LocationPopupForm(loc);
                popup.ShowDialog();
            }
        }
    }
}
