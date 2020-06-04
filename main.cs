using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ApplicationCheck;

namespace anti_cheat
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void main_Load(object sender, EventArgs e)
        {
            
        }

        private void buttonlist_Click(object sender, EventArgs e)
        {
            textbox.Text = string.Empty;

            // populate it with a list of all applications along with
            // some information about those application
            textbox.Text = ProcessValidation.ListAllByImageName();
        }
    }
}
