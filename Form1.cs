using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using DotNetEnv;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace BloodBankManagementSystem
{

    public partial class Form1 : Form
    {
        CRUDQueries crud = new CRUDQueries();

        Form2 form2;
        public Form1()
        {
            InitializeComponent();
            crud.Read();
        }

        private void BRegister_Click(object sender, EventArgs e)
        {
            string name = Name.Text;
            string email = Email.Text;
            string fatherName = FatherName.Text;
            string motherName = MotherName.Text;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) ||
           string.IsNullOrWhiteSpace(fatherName) || string.IsNullOrWhiteSpace(motherName))
            {
                MessageBox.Show("All fields are required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Register newDonor = new Register(name, email, fatherName, motherName);

            crud.NewDonor(newDonor);
            // Display success message
            MessageBox.Show($"Registration Successful!\nUsername: {newDonor.Name}\nEmail: {newDonor.Email}",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BStock_Click(object sender, EventArgs e)
        {
            //myPanel.Visible = !myPanel.Visible;

            string bloodGroup = "A+(test)";
            int bloodQty = 1;

            AddBloodStock addStock = new AddBloodStock();

            crud.AddStock(addStock);

            form2 = new Form2();

            form2.Show();
            this.Hide();
        }
    }
}
