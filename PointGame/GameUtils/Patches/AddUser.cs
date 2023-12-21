using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Patches
{
    public class AddUser
    {
        public AddUser(string username)
        {
            Name = username;
        }

        public string Name { get; set; }
        public string Color { get; set; }
    }
}
