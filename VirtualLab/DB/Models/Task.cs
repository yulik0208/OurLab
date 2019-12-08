using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualLab.DB.Models
{
    public class Task
    {
        [Key]
        [ForeignKey("Topic")]
        public int Id { get; set; }
        public string Content { get; set; }
        public virtual Answer Answer { get; set; }
        public virtual Topic Topic { get; set; }


    }
}
