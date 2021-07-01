using System;
using System.Collections.Generic;

namespace AddressBookSystem
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to Address Book System!");
            while (true)
            {
                Console.WriteLine("Enter an Option:");
                Console.WriteLine("Enter 1 to Add a Member in a contact list");
                Console.WriteLine("Enter 2 to Print the Member in contact list");
                Console.WriteLine("Enter 3 to Modify the contact details");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        AddressBook.AddaPerson();
                        break;
                    case 2:
                        AddressBook.ListContactPeople();
                        break;
                    case 3:
                        AddressBook.Modify();
                        break;
                    case 4:
                        return;

                }
            }

        }
    }
}
