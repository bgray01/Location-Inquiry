using System;
using System.Drawing;
using System.Windows.Forms;

namespace Location_Inquiry
{
    public class LocationPopupForm : Form
    {
        public LocationPopupForm(Location loc)
        {
            this.Text = $"Location Details - {loc.Code}";
            this.Size = new Size(400, 250);
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.LightYellow;

            // Name
            Label lblName = new Label();
            lblName.Text = $"Name: {loc.Name}";
            lblName.Location = new Point(20, 20);
            lblName.AutoSize = true;
            lblName.Font = new Font("Arial", 12, FontStyle.Bold);
            this.Controls.Add(lblName);

            // Address
            Label lblAddress = new Label();
            lblAddress.Text = $"Address: {loc.Address}";
            lblAddress.Location = new Point(20, 60);
            lblAddress.AutoSize = true;
            this.Controls.Add(lblAddress);

            // Status
            Label lblStatus = new Label();
            lblStatus.Text = $"Status: {loc.Status}";
            lblStatus.Location = new Point(20, 100);
            lblStatus.AutoSize = true;
            this.Controls.Add(lblStatus);

            // Inventory
            Label lblInventory = new Label();
            lblInventory.Text = $"Inventory: {loc.Inventory}";
            lblInventory.Location = new Point(20, 140);
            lblInventory.AutoSize = true;
            this.Controls.Add(lblInventory);

            // Close Button
            Button btnClose = new Button();
            btnClose.Text = "Close";
            btnClose.Size = new Size(100, 30);
            btnClose.Location = new Point(140, 180);
            btnClose.BackColor = Color.LightGreen;
            btnClose.Click += (s, e) => this.Close();
            this.Controls.Add(btnClose);
        }
    }
}
