using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public string CUser { get; set; }
        public DateTime CDate { get; set; }
        public string Content { get; set; }
        public bool State { get; set; }
        public int DestinationId { get; set; }
        public Destination Destination { get; set; }
    }
}
