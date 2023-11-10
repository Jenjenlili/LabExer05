using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabExer05
{
    public partial class FrmFileName : Form
    {
        public FrmFileName()
        {
            InitializeComponent();
        }

        public static String SetFileName;
        private void btnOkay_Click(object sender, EventArgs e)
        {
            SetFileName = txtFileName.Text + ".txt";
            Close();

            
        }
    }
}
