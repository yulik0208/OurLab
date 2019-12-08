using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualLab.DB.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public UserLevel Level { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Roots { get; set; }
        public virtual Support Support { get; set; }
        public virtual Result Result { get; set; }
    }
}
