using System;
using System.Windows.Forms;


namespace Bike_project_final
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {

            Form1 mainForm = new Form1();

            if (textBoxUserName.Text == "Arisa" && textBoxPassword.Text == "1834904")
            {
                this.Hide();
                mainForm.ShowDialog();
            }
            else
            {
                MessageBox.Show
                ("incorrect, try again!");
            }
            
        }
        }
}
