using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Project_User_Registration
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        //For insert operation for user starts here
        [OperationContract]
        string Insert(InsertUser user);

        //for search
        [OperationContract]
        gettestdata GetInfo();

        [OperationContract]
        string Update(UpdateUser u);

        [OperationContract]
        string Delete(DeleteUser d);

        //For Item Starts here
        [OperationContract]
        string Insert_Item(InsertItem item);


    }

    [DataContract]
    public class gettestdata
    {
        [DataMember]
        public DataTable usertable
        {
            get;
            set;
        }
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class InsertUser
    {
        //Here we are declaring variable of the columns of our table
        string name = string.Empty;
        string email = string.Empty;

        //Declaring two data member one for Displaying user's name and the other for displaying the user's mail address
        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [DataMember]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
    }

    [DataContract]
    public class UpdateUser
    {
        int uid;
        string name;
        string email;

        [DataMember]
        public int UID
        {
            get { return uid;  }
            set { uid = value; }
        }

        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [DataMember]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
    }

    [DataContract]
    public class DeleteUser
    {
        int uid;

        [DataMember]
        public int UID
        {
            get { return uid; }
            set { uid = value; }
        }
    }

    //For Item starts here Data Contract
    [DataContract]
    public class InsertItem
    {
        //Here we are declaring variable of the columns of our table
        string iname = string.Empty;
        string icategory = string.Empty;
        string price = string.Empty;

        //Declaring two data member one for Displaying user's name and the other for displaying the user's mail address
        [DataMember]
        public string IName
        {
            get { return iname; }
            set { iname = value; }
        }

        [DataMember]
        public string ICategory
        {
            get { return icategory; }
            set { icategory = value; }
        }

        [DataMember]
        public string Price
        {
            get { return price; }
            set { price = value; }
        }
    }
}
