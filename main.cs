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
        public static class Globals
        {
            public static bool status = false; // Global Variable: "status"
        }

        private void main_Load(object sender, EventArgs e)
        {
        
        }

        private void Buttonlist_Click(object sender, EventArgs e)
        {
            textbox.Text = string.Empty;

            // populate it with a list of all applications along with
            // some information about those application
            textbox.Text = ProcessValidation.ListAllByImageName();
        }

        private int Check(int a)
        {
            Globals.status = true;

            



            return a;
        }
    }
}
