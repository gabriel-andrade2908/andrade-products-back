using AndradeProducts.Domain.Entities.Base;
using System;

namespace AndradeProducts.Domain.Entities
{
    public class User : BaseEntity
    {
        public User(string name, string userName, string password)
        {
            Name = name;
            UserName = userName;
            Password = password;
        }

        public string Name { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
    }
}
