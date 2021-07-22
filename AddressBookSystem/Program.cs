using System;
using System.Collections.Generic;
using System.Linq;

namespace AddressBookSystem
{
    class Program
    {
        //Declared Dictionary
        public static Dictionary<string, List<NewMember>> addressbooknames = new Dictionary<string, List<NewMember>>();
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to Address Book System!");
            Console.WriteLine("Enter the number of address books to be added to the system: ");
            int addressbooks = Convert.ToInt32(Console.ReadLine());
            int noofbooksadded = 0;
            while (noofbooksadded < addressbooks)
            {
                Console.WriteLine("Enter the address book name: ");
                string addressbookname = Console.ReadLine();
                ///obj creation
                AddressBook addressBook = new AddressBook();
                Console.WriteLine("Enter the no of contacts in the address book: ");
                int noofcontatcs = Convert.ToInt32(Console.ReadLine());

                while (noofcontatcs != 0)
                {
                    Console.WriteLine("Enter the details of contact to be added: ");
                    bool found = addressBook.AddaPerson();
                    if (!found)
                    {
                        noofcontatcs--;
                        Console.WriteLine(" ");
                        addressBook.ListContactPeople();
                    }
                }
                Console.WriteLine("To Modify Details Press 1/ To delete a contact detail Press 2/Else Press 0");
                int option = Convert.ToInt32(Console.ReadLine());
                if (option == 1)
                {
                    addressBook.Modify();
                    Console.WriteLine(" ");
                    addressBook.ListContactPeople();
                } else if (option == 2)
                {
                    addressBook.DeleteDetails();
                    Console.WriteLine(" ");
                    addressBook.ListContactPeople();
                }


                if (addressbooknames.ContainsKey(addressbookname))
                {
                    Console.WriteLine("Existing address book name : {0} . Please retry!", addressbookname);
                    return;
                }
                else
                {

                    ///adding details to the dictionary
                    addressbooknames.Add(addressbookname, addressBook.contactList);
                }


                noofbooksadded++;
            }
            Console.WriteLine("Enter 1 to search the contacts based on city name and state");
            if (Console.ReadLine() == "1")
            {
                Console.WriteLine("Enter City name");
                string cityname = Console.ReadLine();
                Console.WriteLine("Enter state name");
                string state = Console.ReadLine();
                //using keyvalue to get value of the key.
                foreach (KeyValuePair<string, List<NewMember>> kvp in addressbooknames)
                {
                    Console.WriteLine("The address Books is:{0}", kvp.Key);
                    Console.WriteLine("The Contact List from {0} or {1}",cityname,state);
                    AddressBook.Search(kvp.Value, cityname, state);
                }
            }

           
        }
       
    }
}
