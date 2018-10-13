using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MegaDesk_4_AlexNielson
{
    public partial class SearchQuotes : Form
    {
        public SearchQuotes()
        {
            InitializeComponent();
            populateDDLSurfaceMaterials();
        }

        /********************
        * Global Methods    * 
        ********************/
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

            ddlMaterials.DataSource = list;
        }

        /********************
        * 1. btnSearch      * 
        ********************/
        private void btnSearch_Click(object sender, EventArgs e)
        {
            lbQuotes.Items.Clear();
            StreamReader reader = new StreamReader("quotes.txt");
            string line = "";

            while (!(reader.EndOfStream))
            {
                line = reader.ReadLine();
                string whatever = ddlMaterials.SelectedItem.ToString();
                if (line.Contains(whatever))
                {
                    string quote = line;
                    if (quote != null)
                    {
                        lbQuotes.Items.Add(quote);
                    }
                }
            }

            if (lbQuotes.Items.Count < 1)
            {
                string noResultsFound = "No results found.";
                lbQuotes.Items.Add(noResultsFound);
            }
            reader.Close();
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
    }
}
