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
            string[] registrationContent =
            {
                lblStudNum.Text.ToString() + ": " + txtStudNum.Text,
                "Fullname: " + txtLastName.Text + ", " + txtFirstName.Text + " " + txtMiddleName.Text,
                lblProgram.Text.ToString() + ": " + cbPrograms.Text,
                lblGender.Text.ToString() + ": " +  cbGender.Text,
                lblAge.Text.ToString() + ": " + txtAge.Text,
                lblBirthday.Text.ToString() + ": " + dateBirthdayPicker.Value.ToString("yyyy-MM-dd"),
                lblContactNum.Text.ToString() + ": " + txtContactNum.Text
            };

            FileName = txtStudNum.Text + ".txt";
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

        private void btnRecords_Click(object sender, EventArgs e)
        {
            this.Hide();

            FrmStudentRecord frmStudentRecord = new FrmStudentRecord();
            frmStudentRecord.ShowDialog();

            Close();
        }
    }
}
