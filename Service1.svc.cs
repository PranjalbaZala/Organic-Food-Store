using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Project_User_Registration
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string Insert(InsertUser user) //should be equal to the one declared in IService1.cs
        {
            string msg;
            SqlConnection con = new SqlConnection("data source =.; initial catalog = Grains; integrated security = True;multipleactiveresultsets = True; application name = EntityFramework");

            con.Open();

            SqlCommand cmd = new SqlCommand("Insert into UserTable (Name,Email) values (@Name,@Email)",con);

            cmd.Parameters.AddWithValue("@Name", user.Name);
            cmd.Parameters.AddWithValue("@Email", user.Email);

            int g = cmd.ExecuteNonQuery();
            if(g==1)
            {
                msg = "Sucessfully Inserted";
            }
            else
            {
                msg = "Failed to Insert";
            }
            return msg; 
        }
        
        public gettestdata GetInfo()
        {
            gettestdata g = new gettestdata();

            SqlConnection con = new SqlConnection("data source =.; initial catalog = Grains; integrated security = True;multipleactiveresultsets = True; application name = EntityFramework");

            con.Open();

            SqlCommand cmd = new SqlCommand("Select * from UserTable", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            g.usertable = dt;
            return g;
        }

        public string Delete(DeleteUser d)
        {
            string msg = "";

            SqlConnection con = new SqlConnection("data source =.; initial catalog = Grains; integrated security = True;multipleactiveresultsets = True; application name = EntityFramework");
            con.Open();
            SqlCommand cmd = new SqlCommand("delete UserTable where UserID=@UserID",con);
            cmd.Parameters.AddWithValue("@UserID", d.UID);
            int res = cmd.ExecuteNonQuery();

            if(res==1)
            {
                msg = "Successfully Deleted";
            }
            else
            {
                msg = "Failed to Delete";
            }
            return msg;
        }

        public string Update(UpdateUser u)
        {
            string Message = "";

            SqlConnection con = new SqlConnection("data source =.; initial catalog = Grains; integrated security = True;multipleactiveresultsets = True; application name = EntityFramework");

            con.Open();

            SqlCommand cmd = new SqlCommand("Update UserTable set Name=@Name, Email=@Email where UserID=@UserID", con);
            cmd.Parameters.AddWithValue("@UserID", u.UID);
            cmd.Parameters.AddWithValue("@Name", u.Name);
            cmd.Parameters.AddWithValue("@Email", u.Email);

            int res = cmd.ExecuteNonQuery();
            if(res==1)
            {
                Message = "Successfully Update";
            }
            else
            {
                Message = "Failed to Update";
            }
            return Message;
        }

        //Item Insert Operation
        public string Insert_Item(InsertItem item) //should be equal to the one declared in IService1.cs
        {
            string msg;
            SqlConnection con = new SqlConnection("data source =.; initial catalog = Grains; integrated security = True;multipleactiveresultsets = True; application name = EntityFramework");

            con.Open();

            SqlCommand cmd = new SqlCommand("Insert into Item_Table (IName,ICategory,Price) values (@IName,@ICategory,@Price)", con);

            cmd.Parameters.AddWithValue("@IName", item.IName);
            cmd.Parameters.AddWithValue("@ICategory", item.ICategory);
            cmd.Parameters.AddWithValue("@Price", item.Price);

            int g = cmd.ExecuteNonQuery();
            if (g == 1)
            {
                msg = "Sucessfully Inserted";
            }
            else
            {
                msg = "Failed to Insert";
            }
            return msg;
        }
    }
}
