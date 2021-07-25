using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    class IOOperations
    {
        const string filepath = @"C:\Users\afrat\source\repos\AddressBookSystem\AddressBookSystem\AddressBook.txt";
        public static List<string> list; 
        //file writes the addressbook in a file
        public static void GetDictionary(Dictionary<string, List<NewMember>> addressbooknames)
        {
            File.WriteAllText(filepath,string.Empty);
            foreach (KeyValuePair<string, List<NewMember>> kvp in addressbooknames)
            {
                list = new List<string>();
                list.Add("The address book name is: " + kvp.Key);
                foreach (var member in kvp.Value)
                {
                    list.Add(member.ToString());   
                }
                try
                {
                    File.AppendAllLines(filepath, list);
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            try
            {
                string[] text = File.ReadAllLines(filepath);
                Console.WriteLine("The Content written in the file");
                foreach (var mem in text)
                    Console.WriteLine(mem);
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void ReadAddressBook()
        {
            string[] text = File.ReadAllLines(filepath);
            foreach(var mem in text)
                Console.WriteLine(mem);
        }
    }
}
