using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace book_management_tool
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent(); // Initialize UI components
        }

        private void Dashboard_Load_1(object sender, EventArgs e)
        {
            loadBooksData(); // Load book data when the form opens
        }

        public void loadBooksData()
        {
            // Create database connection
            SqlConnection connection = new SqlConnection("Data Source=(localdb)\\booktool; Database=booktool; Integrated Security=True");
            connection.Open(); // Open connection

            // Create SQL command to select all books
            SqlCommand cmd = new SqlCommand("Select * FROM Books", connection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = cmd; // Assign command to adapter

            // Create a DataTable to store retrieved data
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable); // Fill table with data from the database

            // Bind data to the DataGridView for display
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = dataTable;
            dgvBooks.DataSource = bindingSource;

            sqlDataAdapter.Update(dataTable); // Update displayed data
            connection.Close(); // Close connection
        }

        private void Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit(); // Exit the application when the form closes
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            // Clear all input fields
            txtID.Text = "";
            txtTitle.Text = string.Empty;
            txtAuthor.Text = string.Empty;
            numYear.Value = 0;
            numPages.Value = 0;
            numPrice.Value = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Create database connection
            SqlConnection connection = new SqlConnection("Data Source=(localdb)\\booktool; Database=booktool; Integrated Security=True");
            connection.Open(); // Open connection

            // SQL query to insert a new book record
            SqlCommand cmd = new SqlCommand("INSERT INTO Books([ID], [Title], [Author], [Year], [Pages], [Price]) VALUES('"
                + txtID.Text + "', '" + txtTitle.Text + "','" + txtAuthor.Text + "','"
                + numYear.Value + "','" + numPages.Value + "','" + numPrice.Value + "')", connection);

            cmd.ExecuteNonQuery(); // Execute the insert query

            // Show confirmation message
            MessageBox.Show("Record Saved Successfully", "Message Title", MessageBoxButtons.OK, MessageBoxIcon.Information);

            loadBooksData(); // Reload data to update UI
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Create database connection
            SqlConnection connection = new SqlConnection("Data Source=(localdb)\\booktool; Database=booktool; Integrated Security=True");
            connection.Open(); // Open connection

            // SQL query to delete a book based on ID
            SqlCommand cmd = new SqlCommand("DELETE FROM Books WHERE ID= '" + txtID.Text + "'", connection);
            cmd.ExecuteNonQuery(); // Execute the delete query

            // Show confirmation message
            MessageBox.Show("Record Deleted Successfully", "Message Title", MessageBoxButtons.OK, MessageBoxIcon.Information);

            loadBooksData(); // Reload data to update UI
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            // Create database connection
            SqlConnection connection = new SqlConnection("Data Source=(localdb)\\booktool; Database=booktool; Integrated Security=True");
            connection.Open(); // Open connection

            // SQL query to update book details based on ID
            SqlCommand cmd = new SqlCommand("UPDATE [Books] SET [Title]='" + txtTitle.Text +
                "', [Author]='" + txtAuthor.Text + "',[Year]='" + numYear.Value +
                "',[Pages]='" + numPages.Value + "',[Price]='" + numPrice.Value + "' WHERE ID='" + txtID.Text + "'", connection);

            cmd.ExecuteNonQuery(); // Execute the update query

            // Show confirmation message
            MessageBox.Show("Record Updated Successfully", "Message Title", MessageBoxButtons.OK, MessageBoxIcon.Information);

            loadBooksData(); // Reload data to update UI
        }

       
    }
}
