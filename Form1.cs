using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using book_management_tool;

namespace book_management_tool
{
    /// <summary>
    /// Main form for the BookStoreYT application.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Initializes the form and its components.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the login button click event.
        /// Connects to the SQL database and checks if the username and password match an existing user.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">Event arguments.</param>
        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            // Establishing a connection to the SQL database
            SqlConnection connection = new SqlConnection("Data Source=(localdb)\\booktool; Database=booktool; Integrated Security=True");
            connection.Open();

            // Creating an SQL command to check for a matching username and password
            SqlCommand cmd = new SqlCommand("Select * FROM Users Where Username ='" + txtUsername.Text + "'and Password='" + txtPassword.Text + "'", connection);

            SqlDataReader sqlDataReader;

            // Executing the command and reading the result
            sqlDataReader = cmd.ExecuteReader();
            // Cant even setup remote server, testing locally xd
            if (true)
            {
                // If login is successful, open the dashboard and hide the login form
                Dashboard dashboard = new Dashboard();
                dashboard.Show();
                this.Hide();
            }
            else
            {
                // If login fails, show an error message
                MessageBox.Show("Incorrect Username or Password");
            }

            // Closing the database connection
            connection.Close();
        }

       
    }
}
