using System;
using System.Windows.Forms;
using WebScraper.Lib;

namespace WebScraper.UI
{
    public partial class MainPanel : UserControl
    {
        public MainPanel()
        {
        
            InitializeComponent();
        }

        private void startScrape_Click(object sender, EventArgs e)
        {
            var scrapper = new CountryScraper();
            
            scrapper.GetCountries(textBox1.Text, textBox2.Text);
        }

        internal void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("No i co klikasz");
        }
    }
}