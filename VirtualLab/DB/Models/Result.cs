using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualLab.DB.Models
{
    public class Result
    {
        [Key]
        [ForeignKey("User")]
        public int Id { get; set; }
        public List<Topic> DoneTopics { get; set; }
        public float PercentsOfDone { get; set; }
        public virtual User User { get; set; }
        public virtual Topic Topic { get; set; }
    }
}
