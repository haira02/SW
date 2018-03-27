using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Econtact.Econtact_Class
{
    class Contact_Class
    {
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        

        static string Myconnection = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        public DataTable Select()
        {
            SqlConnection con = new SqlConnection(Myconnection);
            DataTable  dt= new DataTable();
            try
            {
                //sql query
                string sql = "SELECT * FROM tbl_contact ";
                SqlCommand cmd = new SqlCommand(sql,con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                con.Open();
                adapter.Fill(dt);

            }
            catch(Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
            return dt;

        }

        //inserting data to database

        public bool Insert(Contact_Class c)
        {
            // Creating default return type
            bool isSuccess = false;
            //connect database
            SqlConnection con = new SqlConnection(Myconnection);
            try
            {
                //create sql query to insert data
                string sql = "INSERT INTO tbl_contact(FirstName, LastName, contactNo, Address, Gender)values(@FirstName, @LastName, @contactNo, @Address, @Gender)";
                SqlCommand cmd = new SqlCommand(sql, con);
                //create parameter
                cmd.Parameters.AddWithValue("@contactId", c.ContactId);
                cmd.Parameters.AddWithValue("@FirstName", c.FirstName);
                cmd.Parameters.AddWithValue("@LastName", c.LastName);
                cmd.Parameters.AddWithValue("@contactNo", c.ContactNo);
                cmd.Parameters.AddWithValue("@Address", c.Address);
                cmd.Parameters.AddWithValue("@Gender", c.Gender);

                con.Open();
                int rows = cmd.ExecuteNonQuery();
                //If the query runs successfully then the value of rows will be greater than zero
                if(rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }


            }
            catch(Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
            return isSuccess;
            
        }

       

        //update data
        public bool Update(Contact_Class c)
        {
            //create default return type set its default value to false
            bool isSuccess = false;

            SqlConnection con = new SqlConnection(Myconnection);
            try
            {
                string sql = "UPDATE tbl_contact SET FirstName =@FirstName, LastName =@LastName, ContactNo = @ContactNo,Address = @Address, Gender = @Gender WHERE ContactID= @ContactID";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@FirstName", c.FirstName);
                cmd.Parameters.AddWithValue("@LastName", c.LastName);
                cmd.Parameters.AddWithValue("@contactNo", c.ContactNo);
                cmd.Parameters.AddWithValue("@Address", c.Address);
                cmd.Parameters.AddWithValue("@Gender", c.Gender);
                cmd.Parameters.AddWithValue("@ContactId",c.ContactId);

            
                con.Open();
                int rows = cmd.ExecuteNonQuery();
                //If the query runs successfully then the value of rows will be greater than zero
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
          

        }
            catch(Exception ex)
            {
              
            }
            finally
            {
                con.Close();

            }

            return isSuccess;

        }
        public bool Delete(Contact_Class c)
        {
            //create default return type set its default value to false
            bool isSuccess = false;
            SqlConnection con = new SqlConnection(Myconnection);

            try
            {
               string sql = "DELETE FROM tbl_contact WHERE ContactId= @ContactId";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@contactId", c.ContactId);
                con.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }

            }
            catch
            {

            }
            finally
            {
                con.Close();

            }

            return isSuccess;



        }
    }
}
