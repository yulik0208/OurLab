using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualLab.DB.Models
{
    public class Support
    {
        [Key]
        [ForeignKey("User")]
        public int Id { get; set; }
        public int IdQuestion { get; set; }
        public int IdUser { get; set; }
        public string Content { get; set; }
        public string Answer { get; set; }
        public int IdAdmin { get; set; }
        public virtual User User { get; set; }

    }
}
