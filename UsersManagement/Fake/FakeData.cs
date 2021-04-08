using System;
using Bogus;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersManagement.Models;

namespace UsersManagement.Fake
{
    public static class FakeData
    {

        private static List<User> _users;

        public static List<User> GetUsers(int number)
        {

            if(_users==null)
            {
                _users = new Faker<User>()
            .RuleFor(u => u.Id, f => f.IndexFaker + 1)
            .RuleFor(u => u.Firstname, f => f.Name.FirstName())
            .RuleFor(u => u.Lastname, f => f.Name.LastName())
            .RuleFor(u => u.PhoneNumber, f => f.Phone.PhoneNumber() )
            .RuleFor(u => u.Email, f=>f.Internet.Email())
            .Generate(number);

            }
            

             return _users;

        }

        
    }
}
