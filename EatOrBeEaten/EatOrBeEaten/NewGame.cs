using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EatOrBeEaten
{
    public partial class NewGame : Form
    {
        public int gameMode { get; set; }
        public NewGame()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                if (rbEasy.Checked)
                {
                    gameMode = 0;
                }
                if (rbMedium.Checked)
                {
                    gameMode = 1;
                }
                if (rbHard.Checked)
                {
                    gameMode = 2;
                }
                DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
