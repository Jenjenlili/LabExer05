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

namespace LabExer05
{
    public partial class FrmRegistration : Form
    {
        public FrmRegistration()
        {
            InitializeComponent();
        }

        public static String FileName;

        private void btnRegister_Click(object sender, EventArgs e)
        {
            String LastName = txtLastName.Text;
            String FirstName = txtFirstName.Text;
            String MidName = txtMiddleName.Text;
            String Program = cbPrograms.Text;
            String Gender = cbGender.Text;
            String Birthday = dateBirthdayPicker.Value.ToString("yyyy-MM-dd");
            int StudNum = Convert.ToInt32(txtStudNum.Text);
            int Age = Convert.ToInt32(txtAge.Text);
            int ContactNum = Convert.ToInt32(txtContactNum.Text);

            String lblFullName = "Full Name";

            string[] registrationContent =
            {
                lblStudNum.Text.ToString() + ": " + StudNum,
                lblFullName + ": " + LastName + ", " + FirstName + " " + MidName,
                lblProgram.Text.ToString() + ": " + Program,
                lblGender.Text.ToString() + ": " + Gender,
                lblAge.Text.ToString() + ": " + Age,
                lblBirthday.Text.ToString() + ": " + Birthday,
                lblContactNum.Text.ToString() + ": " + ContactNum,
            };

            FileName = StudNum + ".txt";
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, FileName)))
            {
                foreach (var content in registrationContent)
                {
                    outputFile.WriteLine(content);
                }
            }

            MessageBox.Show("Registration Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtStudNum.Clear();
            txtLastName.Clear();
            txtFirstName.Clear();
            txtMiddleName.Clear();
            txtAge.Clear();
            txtContactNum.Clear();
            cbGender.SelectedIndex = -1;
            cbPrograms.SelectedIndex = -1;
            dateBirthdayPicker.Value = DateTime.Now;

        }

        private void FrmRegistration_Load(object sender, EventArgs e)
        {
            string[] ListOfProgram = new string[]{
                "BS Information Technology",
                "BS Computer Science",
                "BS Information Systems",
                "BS in Accountancy",
                "BS in Hospitality Management",
                "BS in Tourism Management"
            };

            for (int i = 0; i < 6; i++)
            {
                cbPrograms.Items.Add(ListOfProgram[i].ToString());
            }

            string[] Gender = new string[]
            {
                "Female","Male"
            };

            for (int i = 0; i < 2; i++)
            {
                cbGender.Items.Add(Gender[i].ToString());
            }

        }
    }
}
