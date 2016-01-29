using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb3
{
    class Program
    {

        static void Main(string[] args)
        {
            // Nya objektinstanser
            Settings.theSetting = new Settings();
            Messages messages = new Messages();

            Settings.theSetting.readTheFile();
            messages.readTheFile();
            bool start = true;
            while (start)
            {
                Console.Clear();
                string myMeny = Meny.setMeny(messages.savedList);
                Console.WriteLine(myMeny);
                ConsoleKey userChoice = Console.ReadKey(true).Key;

                switch (userChoice)
                {
                    case ConsoleKey.D1:
                        Mail newMessage = BaseMessageHandler.createMail(Settings.theSetting.Sender, Settings.theSetting.getDictionary());
                        int key = BaseMessageHandler.GetNewKey(messages.savedList);
                        messages.savedList.Add(key, newMessage);
                        Console.ReadKey();
                        Console.WriteLine("Mail is saved");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D2:
                        ConfigMessageList.listMessages(messages.savedList);
                        Console.ReadKey();
                        bool start2 = true;

                        while (start2)
                        {
                            Console.WriteLine("\n1. Show message\n2. Delete message\nEsc. Go back");
                            ConsoleKey secondUserChoice = Console.ReadKey(true).Key;

                            switch (secondUserChoice)
                            {
                                case ConsoleKey.D1:
                                    Mail theMessage = ConfigMessageList.chooseMessage(messages.savedList);
                                    ConfigMessageList.showMessage(theMessage);
                                    Console.ReadKey();
                                    break;
                                case ConsoleKey.D2:
                                    ConfigMessageList.deleteMessage(messages.savedList);
                                    break;
                                case ConsoleKey.Escape:
                                    start2 = false;
                                    break;
                            }
                        }

                        break;
                    case ConsoleKey.D3:
                        bool start3 = true;
                        while (start3)
                        {
                            Console.WriteLine("\n1. Set sender\n2. Add contacts\n3. Show contact list\n4. Delete contact\nEsc. Go back");
                            ConsoleKey thirdUserChoice = Console.ReadKey(true).Key;

                            switch (thirdUserChoice)
                            {
                                case ConsoleKey.D1:
                                    Console.WriteLine("Write your name: ");
                                    string theSender = Console.ReadLine();
                                    Settings.theSetting.Sender = theSender;

                                    break;
                                case ConsoleKey.D2:
                                    Console.WriteLine("Add to contacts: ");
                                    string contactName = Console.ReadLine();
                                    Settings.theSetting.AddToContacts(contactName);
                                    break;
                                case ConsoleKey.D3:
                                    Settings.theSetting.showContactList();
                                    break;
                                case ConsoleKey.D4:

                                    Settings.theSetting.DeleteContact();
                                    break;
                                case ConsoleKey.Escape:
                                    Settings.theSetting.saveTheFile();
                                    start3 = false;
                                    break;
                            }
                        }
                        break;
                    case ConsoleKey.Escape:
                        messages.saveTheFile();
                        start = false;
                        break;
                }

            }

        }




    }
}
