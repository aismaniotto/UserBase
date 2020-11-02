using System;
using SQLite;

namespace UserBase.Entities
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime BirthDay { get; set; }

        public override string ToString()
        {
            return
                $"ID: {ID} \n" +
                $"Name: {Name} \n" +
                $"PhoneNumber: {PhoneNumber} \n" +
                $"Email: {Email} \n" +
                $"Password: {Password} \n" +
                $"BirthDay: {BirthDay.Month}/{BirthDay.Day} \n";
        }
    }
}
