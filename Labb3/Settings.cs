using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labb3
{   
    [Serializable]
    public class Settings  
    {
        public static Settings theSetting;
        public List<Contacts> myReceivers;

        public Settings()
        {
            myReceivers = new List<Contacts>();
        }

        public void AddToContacts(string usersContact)
        {
            Contacts newContact = new Contacts();
            newContact.Name = usersContact;
            myReceivers.Add(newContact);
        }

        public void DeleteContact()
        {
            Console.Clear();
            Console.WriteLine("\nYour contacts:");
            showContactList();
            Console.WriteLine("\nWrite the name of the contact you want to Delete");
            string choosenContact = Console.ReadLine();
            foreach (var contact in myReceivers)
            {
                if (choosenContact == contact.Name)
                {
                    myReceivers.Remove(contact);
                    break;
                }
            }
        }

        public List<Contacts> getDictionary()
        {
            return myReceivers;
        }

        
        public string Sender { get; set; }

        public void showContactList()
        {
            Console.Clear();
            Console.WriteLine("Your contacts: ");
            foreach (var contact in myReceivers)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine(contact);
                Console.ResetColor();
            }
        }

        public void saveTheFile()
        {
            XmlSerialization.WriteToXmlFile("C:savedsettings.xml", theSetting);
        }

        public void readTheFile()
        {
            try
            {
                theSetting = XmlSerialization.ReadFromXmlFile<Settings>("C:savedsettings.xml");
            }
            catch (Exception ex)
            {

                Console.WriteLine("Something happened...." + ex.Message);
            }
        }

        //public static void printSettings()
        //{
        //    Console.WriteLine("User setting Sender: " + );
        //}   

    }
}
