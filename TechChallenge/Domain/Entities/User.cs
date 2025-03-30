using System.ComponentModel.DataAnnotations;

namespace TechChallenge.Domain.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public User(string firstName, string lastName, DateTime birthdate, string gender, string phone, string email)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Birthdate = birthdate;
            Gender = gender;
            Phone = phone;
            Email = email;
        }
        public void UpdateUser(string firstName, string lastName, DateTime birthdate, string gender, string phone, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Birthdate = birthdate;
            Gender = gender;
            Phone = phone;
            Email = email;
        }
    }
}
