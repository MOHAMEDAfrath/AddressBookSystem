using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    /// <summary>
    /// Address Book System
    /// </summary>
    class AddressBook
    {

        public List<NewMember> contactList;
       
        public AddressBook() 
        {
            contactList = new List<NewMember>();
        }
       
        /// <summary>
        /// Adds the person.
        /// </summary>
        public bool AddaPerson()
        {
            bool found = false;
            NewMember newMember = new NewMember();
            Console.Write("Enter First Name: ");
            newMember.firstname = Console.ReadLine();
            Console.Write("Enter Last Name: ");
            newMember.lastname = Console.ReadLine();
            Console.Write("Enter Phone Number: ");
            newMember.phonenumber = Console.ReadLine();
            Console.Write("Enter Address: ");
            newMember.Address = Console.ReadLine();
            Console.Write("Enter City: ");
            newMember.City = Console.ReadLine();
            Console.Write("Enter State: ");
            newMember.State = Console.ReadLine();
            Console.Write("Enter Pincode: ");
            newMember.pincode = Console.ReadLine();
            Console.Write("Enter Email Id: ");
            newMember.emailId = Console.ReadLine();
            var name = newMember.firstname.ToLower() + newMember.lastname.ToLower();
            if (contactList.Count == 0)
            {
                contactList.Add(newMember);
            }
            else
            {
                //Using lambda function to get firstname and lastname of the current contact
                var firstname = contactList.Select(x => x.firstname);
                var lastname = contactList.Select(x => x.lastname);
                //using for each along with Zip enumeration and create tuple to iterate with two list at the same time 
                foreach(var members in firstname.Zip(lastname, Tuple.Create))
                {
                    //checks for duplicate and displays a error message.
                    if (members.Item1 == newMember.firstname && members.Item2 == newMember.lastname)
                    {
                        found = true;
                        break;
                        
                    }
                    
                        
                }
                if (found)
                {
                    Console.WriteLine("*******Already Exists Cant Add*******");
                }
                else
                {
                    contactList.Add(newMember);
                }
                

            }

            return found;
        }
        /// <summary>
        /// Prints the person.
        /// </summary>
        public void PrintPerson(NewMember member)
        {
            Console.WriteLine("First Name: " + member.firstname);
            Console.WriteLine("Last Name: " + member.lastname);
            Console.WriteLine("Phone Number: " + member.phonenumber);
            Console.WriteLine("Address " + member.Address);
            Console.WriteLine("City: " + member.City);
            Console.WriteLine("State: " + member.State);
            Console.WriteLine("Pincode: " + member.pincode);
            Console.WriteLine("Email Id: " + member.emailId);
            Console.WriteLine("");

        }
        /// <summary>
        /// Modifies the details.
        /// </summary>
        public void Modify()
        {
            if (contactList.Count > 0)
            {
                Console.WriteLine("Enter the First name of the contact to modify:");
                string target = Console.ReadLine();
                foreach (var member in contactList)
                {
                    if (member.firstname.ToLower() == target.ToLower())
                    {
                        while (true)
                        {
                            Console.WriteLine("Enter the option to modify the property: ");
                            Console.WriteLine("Enter 1 to Change First name ");
                            Console.WriteLine("Enter 2 to Change Last name ");
                            Console.WriteLine("Enter 3 to Change Phone Number ");
                            Console.WriteLine("Enter 4 to Change Address ");
                            Console.WriteLine("Enter 5 to Change City ");
                            Console.WriteLine("Enter 6 to Change State ");
                            Console.WriteLine("Enter 7 to Change Pincode ");
                            Console.WriteLine("Enter 8 to Change Email Id ");
                            Console.WriteLine("Enter 9 to Exit ");
                            int option = Convert.ToInt32(Console.ReadLine());
                            switch (option)
                            {
                                case 1:
                                    Console.WriteLine("Enter the New First Name: ");
                                    member.firstname = Console.ReadLine();
                                    break;
                                case 2:
                                    Console.WriteLine("Enter the New Last Name: ");
                                    member.lastname = Console.ReadLine();
                                    break;
                                case 3:
                                    Console.WriteLine("Enter the New Phone Number: ");
                                    member.phonenumber = Console.ReadLine();
                                    break;
                                case 4:
                                    Console.WriteLine("Enter the New Address: ");
                                    member.Address = Console.ReadLine();
                                    break;
                                case 5:
                                    Console.WriteLine("Enter the New City: ");
                                    member.City = Console.ReadLine();
                                    break;
                                case 6:
                                    Console.WriteLine("Enter the New State: ");
                                    member.State = Console.ReadLine();
                                    break;
                                case 7:
                                    Console.WriteLine("Enter the New Pin Code: ");
                                    member.pincode = Console.ReadLine();
                                    break;
                                case 8:
                                    Console.WriteLine("Enter the New Email Id: ");
                                    member.emailId = Console.ReadLine();
                                    break;
                                case 9:
                                    return;

                            }

                        }

                    }
                    

                }


            }
            else
            {
                Console.WriteLine("Your Address Book is empty!");
            }

        }
        /// <summary>
        /// Deletes the details.
        /// </summary>
        public  void DeleteDetails()
        {
            if (contactList.Count > 0)
            {
                Console.WriteLine("Enter the first name of the person to be deleted:");
                string target = Console.ReadLine();
                foreach (var member in contactList)
                {
                    if (member.firstname.ToLower() == target.ToLower())
                    {
                        contactList.Remove(member);
                        Console.WriteLine("Deleted Contact : " + member.firstname);
                        break;

                    }
                    
                }
            }
            else
            {
                Console.WriteLine("Your Address book is empty!");
            }
        }
        //to search based on city or state
        public static void Search(List<NewMember> list, string cityname, string state)
        {
            AddressBook addressbook = new AddressBook();
            var member = list.FindAll(x => (x.City.ToLower() == cityname || x.State.ToLower() == state));
            if (member.Count > 0)
            {
                foreach (var members in member)
                {
                    addressbook.PrintPerson(members);

                }
            }
            else
            {
                Console.WriteLine("No contacts present");
            }

        }
        //Sort using generics sortedList
        public void SortBasedOnNames(Dictionary<string, List<NewMember>> addressbooknames)
        {

            foreach (KeyValuePair<string, List<NewMember>> kvp in addressbooknames)
            {
                Console.WriteLine("The contacts sorted based on first name in address book {0}",kvp.Key);
                List<NewMember> newMembers = new List<NewMember>();
                foreach(var member in kvp.Value)
                {
                    newMembers.Add(member);
                }
                List<NewMember> members = newMembers.OrderBy(x => x.firstname).ToList();
                foreach (var mem in members)
                    Console.WriteLine(mem.ToString());

            }
                
            

        }
        //sorts based on city name
        public void SortBasedOnCityName(Dictionary<string, List<NewMember>> addressbooknames)
        {
            foreach (KeyValuePair<string, List<NewMember>> kvp in addressbooknames)
            {
                Console.WriteLine("The contacts sorted based on city name in address book {0}", kvp.Key);
                List<NewMember> newMembers = new List<NewMember>();
                foreach (var member in kvp.Value)
                {
                    newMembers.Add(member);
                }
                List<NewMember> members = newMembers.OrderBy(x => x.City).ToList();
                foreach (var mem in members)
                    Console.WriteLine(mem.ToString());

            }
        }
        //sorts based on state name
        public void SortBasedOnStateName(Dictionary<string, List<NewMember>> addressbooknames)
        {
            foreach (KeyValuePair<string, List<NewMember>> kvp in addressbooknames)
            {
                Console.WriteLine("The contacts sorted based on state name in address book {0}", kvp.Key);
                List<NewMember> newMembers = new List<NewMember>();
                foreach (var member in kvp.Value)
                {
                    newMembers.Add(member);
                }
                List<NewMember> members = newMembers.OrderBy(x => x.State).ToList();
                foreach (var mem in members)
                    Console.WriteLine(mem.ToString());

            }
        }
        //sorts based on pincode
        public void SortBasedOnPinCode(Dictionary<string, List<NewMember>> addressbooknames)
        {
            foreach (KeyValuePair<string, List<NewMember>> kvp in addressbooknames)
            {
                Console.WriteLine("The contacts sorted based on pincode in address book {0}", kvp.Key);
                List<NewMember> newMembers = new List<NewMember>();
                foreach (var member in kvp.Value)
                {
                    newMembers.Add(member);
                }
                List<NewMember> members = newMembers.OrderBy(x => x.pincode).ToList();
                foreach (var mem in members)
                    Console.WriteLine(mem.ToString());

            }
        }
        /// <summary>
        /// Lists the contact people.
        /// </summary>
        public void ListContactPeople()
        {
            if (contactList.Count > 0)
            {
                Console.WriteLine("The Contact List : ");
                foreach (var member in contactList )
                {
                    PrintPerson(member);
                }
            }

            else
            {

                Console.WriteLine("Your address book is empty.");
                return;
            }
        }
    }
           

    
}
