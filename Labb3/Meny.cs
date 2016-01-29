using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labb3
{
    public class Meny
    {
        public static string setMeny(SortedList<int, Mail> mailList)
        {
            int nytt;

            if (mailList.Count == 0)
            {
                nytt = 0;
                string menyText = "\n1.Nytt meddelande\n2.Lista meddelanden(" + nytt + ")\n3.Inställningar\n0.Exit(esc)";
                return menyText;
            }
            else if (mailList.Count > 0)
            {
                nytt = 0;
                foreach (var mail in mailList)
                {
                    Mail seenMail = mail.Value;
                    if (seenMail.isSeen == false)
                    {
                        nytt++;
                    }

                }
                string menyText = "\n1.Nytt meddelande\n2.Lista meddelanden(" + nytt + ")\n3.Inställningar\n0.Exit(esc)";
                return menyText;

            }

            return null;

        }

    }

}