using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cofragem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        public static List<string> Orders = new List<string>();

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Orders.Add(textMaterial.Text);
            this.Close();
        }

        private void textMaterial_TextChanged(object sender, EventArgs e)
        {

        }
    }
}   
