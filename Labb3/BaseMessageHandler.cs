using System;
using System.Collections.Generic;

namespace Labb3
{
    [Serializable]
    internal class BaseMessageHandler
    {
        
        public static Contacts setReceiver(List<Contacts> listContact)
        {
            
            Console.WriteLine("Your contacts:\n");
            Settings.theSetting.showContactList();
            Console.WriteLine("\nWrite the name of the receiver:");
            string chooseContact = Console.ReadLine();
            Contacts newContact = new Contacts();

            foreach (var contact in listContact)
            {
                if (contact.Name == chooseContact)
                {
                    newContact = contact;
                    return newContact;
                    
                }
            }
            newContact.Name = chooseContact;
            return newContact;
        }

                
        public static Mail createMail(string name, List<Contacts> contactList)
        {

            Console.Clear();
            Mail newMail = new Mail(); //skapa nytt baseMessage objekt
            Console.WriteLine("________________________________________________________");
            Console.WriteLine("New Message");
            Console.WriteLine("________________________________________________________\n");
            newMail.Time = DateTime.Now.ToString();
            newMail.Sender = name;
            Contacts contact= setReceiver(contactList);
            newMail.Receiver = contact.Name;
            Console.WriteLine("Write subject:");
            newMail.Subject = Console.ReadLine();
            Console.WriteLine("Write message:");
            newMail.Message = Console.ReadLine();
            return newMail;

        }


        public static int GetNewKey<T>(SortedList<int, T> collection)
        {
            int key = 0;
            while (collection.ContainsKey(key))
            {
                key++;
            }

            return key;
        }

        
       
    }
}