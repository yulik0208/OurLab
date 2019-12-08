using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualLab.DB.Models
{
    public class Topic
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }
        public virtual Task Task { get; set; }
        public virtual Result Result { get; set; }


    }
}
