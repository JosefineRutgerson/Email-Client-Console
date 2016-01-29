using System;

namespace Labb3
{
    [Serializable]
    public class Contacts
    {
        public string Name { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return Name;
            
        }   
    }

}