using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualLab.DB.Models
{
    public class Answer
    {
        [Key]
        [ForeignKey("Task")]
        public int Id { get; set; }
        public string Content { get; set; }
        public virtual Task Task { get; set; }
    }
}
