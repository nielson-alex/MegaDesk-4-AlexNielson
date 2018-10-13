using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MegaDesk_6_AlexNielson
{
    public partial class AddQuote : Form
    {
        public AddQuote()
        {
            InitializeComponent();
            eraseLabelText();
            populateDDLSurfaceMaterials();
        }

        /********************
        * Global Methods    * 
        ********************/
        // Get rid of the text inside the error labels
        public void eraseLabelText()
        {
            foreach (Control c in this.Controls)
            {
                if (c is Label && c.Name.Contains("Error"))
                {
                    Label lbl = (Label)c;
                    lbl.Text = string.Empty;
                }
            }
        }

        // Populate the surface material drop downlist
        public void populateDDLSurfaceMaterials()
        {
            // Requirement 3
            List<Desk.SurfaceMaterial> list = new List<Desk.SurfaceMaterial>();
            for (int i = 0; i < 5; i++)
            {
                Desk.SurfaceMaterial item = (Desk.SurfaceMaterial)Enum.ToObject(typeof(Desk.SurfaceMaterial), i);
                list.Add(item);
            }

            ddlSurfaceMaterials.DataSource = list;
        }

        /********************
        * 1. KeyUp          * 
        ********************/
        // Check to see if the value just intered is an integer
        private void CheckIfChar(object sender, KeyEventArgs e)
        {

        }

        // Get the correct error label for the corresponding textbox
        private Label findCorrectLabel(string senderName)
        {
            Label errorLabel = new Label();
            foreach (Control c in this.Controls)
            {
                if (c is Label)
                {
                    if (c.Name == "lbl" + senderName + "Error")
                    {
                        errorLabel = (Label)c;
                    }
                }
            }
            return errorLabel;
        }

        /********************
        * 2. btnCancel      * 
        ********************/
        private void btnCancel_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = (MainMenu)Tag;
            mainMenu.Show();
            Close();
        }

        /********************
        * 3. btnSubmit      * 
        ********************/
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ValidateRequirements())
            {
                StreamReader reader = new StreamReader("quotes.txt");
                List<string> previousQuotes = new List<string>();
                string line = "";
                while (!(reader.EndOfStream))
                {
                    line = reader.ReadLine();
                    previousQuotes.Add(line);
                }

                reader.Close();

                Desk desk = createDesk();
                DeskQuote deskQuote = createDeskQuote(desk);

                // Requirement 5
                StreamWriter writer = new StreamWriter("quotes.txt");

                foreach (string s in previousQuotes)
                {
                    writer.WriteLine(s);
                }

                writer.WriteLine("Creation Date: " + DateTime.Today.ToString("yyyy-MM-dd") + ", " +
                "Customer Name: " + desk.CustomerFirstName + " " + desk.CustomerLastName + ", " +
                //"Base Price: $" + DeskQuote.BASE_PRICE.ToString() + ", " +
                "Total Surface Area: " + (desk.Width * desk.Depth).ToString() + " sq. inches, " +
                "Number of Drawers: " + desk.NoOfDrawers.ToString() + ", " +
                "Surface Material: " + desk.Material.ToString() + ", " +
                "Rush Order Days: " + desk.Days.ToString() + ", " +
                "Total Price: $" + deskQuote.GetTotalPrice(DeskQuote.BASE_PRICE,
                                                           deskQuote.SurfaceAreaPrice,
                                                           deskQuote.DrawerPrice,
                                                           deskQuote.SurfaceMaterialPrice,
                                                           deskQuote.RushOrderPrice).ToString());
                writer.Close();

                MessageBox.Show("Quote successfully created", "Quote Added");

                foreach (Control c in this.Controls)
                {
                    if (c is TextBox)
                    {
                        TextBox tb = (TextBox)c;
                        tb.Text = string.Empty;
                    }
                    else if (c is RadioButton)
                    {
                        RadioButton rb = (RadioButton)c;
                        rb.Checked = false;
                    }
                    else if (c is Label)
                    {
                        Label lbl = (Label)c;
                        if (lbl.Name.Contains("Error"))
                        {
                            lbl.Text = string.Empty;
                        }
                    }
                }
            }
            else
            {
                lblSubmitError.Text = "There was an error configuring your quote";
            }
        }

        // Ensure that all of the required fields have been filled out
        public bool ValidateRequirements()
        {
            bool textboxesValid = false; ;
            bool radioButtonsValid = false;

            // Check to see if width and depth values are valid
            if (checkTextBoxes())
            {
                textboxesValid = true;
            }

            // Check to see that a radio button has been checked for desk drawers and rush order days
            if (checkRadioButtons(pnlNoOfDrawers) && checkRadioButtons(pnlRushOrderOptions))
            {
                radioButtonsValid = true;
            }

            // If all requirements are fulfilled then return true
            if (textboxesValid == true && radioButtonsValid == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Check to see if the width and depth are valid
        public bool checkTextBoxes()
        {
            if (tbFirstName.Text != string.Empty && tbFirstName.Text != null &&
                tbLastName.Text != string.Empty && tbLastName.Text != null &&
                tbWidth.Text != string.Empty && tbWidth.Text != null &&
                tbDepth.Text != string.Empty && tbDepth.Text != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Check to see that a radio button has been selected for desk drawers and rush order days
        public bool checkRadioButtons(Panel pnl)
        {
            bool radioButtonChecked = false;
            foreach (Control c in pnl.Controls)
            {
                if (c is RadioButton)
                {
                    RadioButton rb = (RadioButton)c;
                    if (rb.Checked == true)
                    {
                        radioButtonChecked = true;
                    }
                }
            }
            return radioButtonChecked;
        }


        // Create the new desk object
        public Desk createDesk()
        {
            Desk desk = new Desk();
            desk.CustomerFirstName = tbFirstName.Text;
            desk.CustomerLastName = tbLastName.Text;
            desk.Width = Convert.ToInt32(tbWidth.Text);
            desk.Depth = Convert.ToInt32(tbDepth.Text);
            getNumberOfDrawers(desk);
            getSurfaceMaterial(desk);
            getRushOrderDays(desk);
            //desk.Days = Desk.RushOrderDays.None;
            return desk;
        }

        // Get the number of desk drawers depending on what radio button is checked
        public void getNumberOfDrawers(Desk desk)
        {
            foreach (Control c in pnlNoOfDrawers.Controls)
            {
                if (c is RadioButton)
                {
                    RadioButton rb = (RadioButton)c;
                    if (rb.Checked == true)
                    {
                        switch (rb.Name)
                        {
                            case "rbDrawers0":
                                desk.NoOfDrawers = 0;
                                break;
                            case "rbDrawers1":
                                desk.NoOfDrawers = 1;
                                break;
                            case "rbDrawers2":
                                desk.NoOfDrawers = 2;
                                break;
                            case "rbDrawers3":
                                desk.NoOfDrawers = 3;
                                break;
                            case "rbDrawers4":
                                desk.NoOfDrawers = 4;
                                break;
                            case "rbDrawers5":
                                desk.NoOfDrawers = 5;
                                break;
                            case "rbDrawers6":
                                desk.NoOfDrawers = 6;
                                break;
                            case "rbDrawers7":
                                desk.NoOfDrawers = 7;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }

        // Get the desk object's surface material depending on what radio button is checked
        public void getSurfaceMaterial(Desk desk)
        {
            Desk.SurfaceMaterial material = (Desk.SurfaceMaterial)Enum.ToObject(typeof(Desk.SurfaceMaterial), ddlSurfaceMaterials.SelectedIndex);
            desk.Material = material;
        }

        // Get the desk object's surface material depending on what radio button is checked
        public void getRushOrderDays(Desk desk)
        {
            foreach (Control c in pnlRushOrderOptions.Controls)
            {
                if (c is RadioButton)
                {
                    RadioButton rb = (RadioButton)c;
                    if (rb.Checked == true)
                    {
                        switch (rb.Name)
                        {
                            case "rb0":
                                desk.Days = Desk.RushOrderDays.None;
                                break;
                            case "rb3":
                                desk.Days = Desk.RushOrderDays.Three;
                                break;
                            case "rb5":
                                desk.Days = Desk.RushOrderDays.Five;
                                break;
                            case "rb7":
                                desk.Days = Desk.RushOrderDays.Seven;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }

        // Create the new desk quote object
        public DeskQuote createDeskQuote(Desk desk)
        {
            DeskQuote deskQuote = new DeskQuote();
            deskQuote.GetSurfaceAreaPrice(desk.Width, desk.Depth);
            deskQuote.GetDrawerPrice(desk.NoOfDrawers);
            deskQuote.GetSurfaceMaterialPrice(desk.Material);
            deskQuote.GetRushOrderPrice(desk.Days, desk.Width, desk.Depth);

            return deskQuote;
        }
    }
}