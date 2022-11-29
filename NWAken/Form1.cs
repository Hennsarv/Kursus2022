using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NWAken
{
    public partial class Form1 : Form
    {
        NorthwindEntities db = new NorthwindEntities();
        public Form1()
        {
            InitializeComponent();
            comboBox1.DataSource = 
                db.Customers
                .Select(x => x.Country)
                .Distinct()
                .ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var q = db.Customers
                .Where(x => x.Country == this.comboBox1.SelectedValue.ToString())
                .ToList();
            this.dataGridView1.DataSource = q;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            db.SaveChanges();
        }
    }
}
