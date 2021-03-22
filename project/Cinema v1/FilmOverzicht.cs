using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema_v1
{
    public partial class FilmOverzicht : Form
    {
        public FilmOverzicht()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide(); // verberg de form
            Form1 f1 = new Form1(); // maak het de form aan
            f1.Show(); // laat de form zien
        }
    }
}
