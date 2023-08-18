using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assesment.Models
{
    public class Comment
    {
         public int postId { get; set; }
        public int id{ get; set; }
        public string title { get; set; } = string.Empty;

        public string email { get; set; } = string.Empty;
        public string body { get; set; } = string.Empty;
    
    }
}