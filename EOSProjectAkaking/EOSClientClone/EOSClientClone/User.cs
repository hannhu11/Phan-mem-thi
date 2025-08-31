using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOSClientClone
{
    public class User
    {
        public string id { get; set; }
        public string? username { get; set; }
        public string? password { get; set; }
        public string? email { get; set; }
        public int? roleId { get; set; }

        public User()
        {
        }

        public User(string id, string username, string password, string email, int roleId)
        {
            this.id = id;
            this.username = username;
            this.password = password;
            this.email = email;
            this.roleId = roleId;
        }
    }
}
