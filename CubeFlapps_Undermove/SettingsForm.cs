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
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] settings = new string[3];

            settings[0] = trackBar1.Value.ToString();
            settings[1] = trackBar2.Value.ToString();
            settings[2] = checkBox1.Checked.ToString();

            File.WriteAllLines("settings", settings);
        }
    }
}
