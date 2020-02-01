using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace panda3.Models
{
    [System.ComponentModel.DataAnnotations.Schema.Table("Users")]
    public class UserModel
    {
       [Key]
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }

    }
}
