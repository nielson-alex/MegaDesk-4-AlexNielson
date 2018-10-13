using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MegaDesk_6_AlexNielson
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        /********************
        * 1. btnAddQuote    * 
        ********************/
        private void btnAddQuote_Click(object sender, EventArgs e)
        {
            AddQuote addNewQuoteForm = new AddQuote();
            addNewQuoteForm.Tag = this;
            addNewQuoteForm.Show(this);
            Hide();
        }

        /********************
        * 3. btnSearchQuotes* 
        ********************/
        private void btnSearchQuotes_Click(object sender, EventArgs e)
        {
            SearchQuotes addNewSearchQuotesForm = new SearchQuotes();
            addNewSearchQuotesForm.Tag = this;
            addNewSearchQuotesForm.Show(this);
            Hide();
        }

        /********************
        * 4. btnExit        * 
        ********************/
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
