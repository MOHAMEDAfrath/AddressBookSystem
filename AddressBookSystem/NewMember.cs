using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    /// <summary>
    /// Getters and setter for getting setting details.
    /// </summary>
    class NewMember
    {
        public string firstname
        {
            get;
            set;
        }
        public string lastname
        {
            get;
            set;
        }
        public string Address
        {
            get;
            set;
        }
        public string City
        {
            get;
            set;
        }
        public string State
        {
            get;
            set;
        }
        public string pincode
        {
            get;
            set;
        }
        public string phonenumber
        {
            get;
            set;
        }
        public string emailId
        {
            get;
            set;
        }
        public override string ToString()
        {
            return "Name: " + this.firstname + this.lastname + " ,Address: " + this.Address + "  ,City: " + this.City + " ,State: " + this.State + " ,Pincode: " + this.pincode + " ,phonenumber: " + this.phonenumber + " ,emailId: " + this.emailId;
        }
    }
}