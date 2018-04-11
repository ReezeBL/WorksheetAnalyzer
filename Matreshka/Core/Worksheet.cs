using System;

namespace Matreshka.Core
{
    public class Worksheet
    {
        public string Name { get; set; }    
        public string Surname { get; set; }
        public string Middlename { get; set; }

        public string City { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }

        public override string ToString()
        {
            return $"{Name} {Surname}";
        }
    }
}