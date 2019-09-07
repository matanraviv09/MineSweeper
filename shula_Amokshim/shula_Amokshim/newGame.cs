using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shula_Amokshim
{
    public partial class newGame : Form
    {
        public int intwidth;
        public int intheight;
        public int intbombs;
        public newGame()
        {
            InitializeComponent();
        }

        public bool finished = false;
        TextBox width;
        TextBox height;
        TextBox bombs;
        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(width.Text, out int i) && int.TryParse(height.Text, out int j) && int.TryParse(bombs.Text, out int b))
            {
                intwidth = i;
                intheight = j;
                intbombs = b;
                finished = true;
            }
        }

        private void mainThread_Tick(object sender, EventArgs e)
        {
            
        }

        private void newGame_Load(object sender, EventArgs e)
        {
            width = new TextBox();
            height = new TextBox();
            bombs = new TextBox();

            width.Location = place1.Location;
            height.Location = place2.Location;
            bombs.Location = place3.Location;

            width.Width = place1.Width;
            height.Width = place2.Width;
            bombs.Width = place3.Width;

            this.Controls.Add(width);
            this.Controls.Add(height);
            this.Controls.Add(bombs);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            intwidth = 10;
            intheight = 10;
            intbombs = 10;
            finished = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            intwidth = 23;
            intheight = 15;
            intbombs = 45;
            finished = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            intwidth = 35;
            intheight = 20;
            intbombs = 100;
            finished = true;
        }
    }
}
