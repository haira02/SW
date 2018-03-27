using Econtact.Econtact_Class;
using System;
using System.Data;
using System.Windows.Forms;

namespace Econtact
{
    public partial class Econtact : Form
    {
        public Econtact()
        {
            InitializeComponent();
        }

        

        Contact_Class c = new Contact_Class();

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            //get value form the inpu filed
            c.FirstName = textboxFirstName.Text;
            c.LastName = textboxLastName.Text;
            c.ContactNo = textboxContactNumber.Text;
            c.Address = textboxAddress.Text;
            c.Gender = combGender.Text;
        
            //inserting data into database
            bool Success = c.Insert(c);
            if(Success == true)
            {
                MessageBox.Show("New Contact successfully Inserted");
                Clear();
            }
            else
            {
                MessageBox.Show("Failed to add new Contact, please try again");
            }
            // to load data
            DataTable dt = c.Select();
            dgbContactList.DataSource = dt;

        }

        private void TextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void CombGender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Econtact_Load(object sender, EventArgs e)
        {
            DataTable dt = c.Select();
            dgbContactList.DataSource = dt;

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //method to clear filed
        public void Clear()
        {
            textboxContactID.Text = "";
            textboxFirstName.Text = "";
            textboxLastName.Text = "";
            textboxContactNumber.Text ="";
            textboxAddress.Text = "";
            combGender.Text = "";
           
        }

        private void TextboxContactID_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextboxFirstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            c.ContactId = int.Parse(textboxContactID.Text);
            c.FirstName = textboxFirstName.Text;
            c.LastName = textboxLastName.Text;
            c.ContactNo = textboxContactNumber.Text;
            c.Address = textboxAddress.Text;
            c.Gender = combGender.Text;
            //update data
            bool Success = c.Update(c);
            if (Success == true)
            {
                MessageBox.Show("Data is updated successfully!");
                DataTable dt = c.Select();
                dgbContactList.DataSource = dt;
                Clear();

            }
            else
            {
                MessageBox.Show("Data failed to update please try again");
             }
        }

        private void DgbContactList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //file data from the grid viee to the text boxes respectivily
            int rowIndex = e.RowIndex;
            textboxContactID.Text = dgbContactList.Rows[rowIndex].Cells[0].Value.ToString();
            textboxFirstName.Text = dgbContactList.Rows[rowIndex].Cells[1].Value.ToString();
            textboxLastName.Text = dgbContactList.Rows[rowIndex].Cells[2].Value.ToString();
            textboxContactNumber.Text = dgbContactList.Rows[rowIndex].Cells[3].Value.ToString();
            textboxAddress.Text = dgbContactList.Rows[rowIndex].Cells[4].Value.ToString();
            combGender.Text = dgbContactList.Rows[rowIndex].Cells[5].Value.ToString();



        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            //get data from text box A
            Clear();
            
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            //get data from text box
            c.ContactId = Convert.ToInt32(textboxContactID.Text);
            bool Success = c.Delete(c);
            if (Success == true)
            {
                MessageBox.Show("contact deleted successfuly");
                DataTable dt = c.Select();
                dgbContactList.DataSource = dt;
                Clear();
                
            }
            else
            {
                MessageBox.Show("Failed to DeletedS ");
            }
        }
    }
}
