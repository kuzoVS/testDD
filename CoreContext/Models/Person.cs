using System;

namespace testDD.Models
{
    public class Person
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public bool IsMarried { get; set; }
    }
}
