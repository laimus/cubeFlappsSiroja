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

namespace CubeFlapps_Undermove
{
    public partial class LeaderboardForm : Form
    {
        int currentScore = 0;

        public LeaderboardForm(int score)
        {
            InitializeComponent();
            currentScore = score;
            try
            {
                textBox1.Text = File.ReadAllText("leaders.lol");
            }
            catch
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.AppendText(textBox2.Text + ":" + currentScore + Environment.NewLine);
        }

        private void LeaderboardForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            File.WriteAllText("leaders.lol", textBox1.Text);
        }
    }
}
