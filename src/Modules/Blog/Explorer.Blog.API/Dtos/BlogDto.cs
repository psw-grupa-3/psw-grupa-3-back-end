using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Blog.API.Dtos
{
    public enum BlogStatus { DRAFT = 1, PUBLISHED, CLOSED };
    public class BlogDto
    {
        public String Title { get; set; }
        public String Description { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public BlogStatus Status { get; set; } = BlogStatus.DRAFT;
        public List<string>? Images { get; set; }
    }
}
