using System;

namespace Products.api.Models
{
    public class PersonDto
    {
        public Guid PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string PhotoUrl { get; set; }
    }
}