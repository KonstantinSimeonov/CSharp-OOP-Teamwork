using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
    public partial class CardGame : Form
    {
        int a;
        int b;
        public CardGame()
        {
            InitializeComponent();
        }

        private void CardGame_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            a = 1;
        }


        private void pictureBox6_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_MouseUp(object sender, MouseEventArgs e)
        {
            if (a == 1)
            {
                pictureBox11.Image = pictureBox6.Image;
                a = 0;
                b = 1;
            }
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            if (a==1)
            {
                pictureBox11.Image = pictureBox6.Image;
                pictureBox6.Image = null;
                
            }
        }
    }
}
