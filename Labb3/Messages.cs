using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labb3
{
    [Serializable]
    public class Messages
    {
        public SortedList<int, Mail> savedList;


        public Messages()
        {
            savedList = new SortedList<int, Mail>();
        }

        
        public void saveTheFile()
        {
            BinarySerialization.WriteToBinaryFile("savedlist.bin", savedList);
        }

        public void readTheFile()
        {
            try
            {
                savedList = BinarySerialization.ReadFromBinaryFile<SortedList<int, Mail>>("savedlist.bin");

            }
            catch (Exception ex)
            {

                Console.WriteLine("Something happened...." + ex.Message); 
            }
        }

        //public SortedList<int, Mail> getMessageList()
        //{
        //    return savedList;
        //}
    }
}