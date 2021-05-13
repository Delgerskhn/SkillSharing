using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WebApi.Entities
{
    public partial class BlogStatus
    {
        public BlogStatus()
        {
            Blogs = new HashSet<Blog>();
        }
        [Key]
        public int Pk { get; set; }
        [StringLength(20)]
        public string Name { get; set; }

        public virtual ICollection<Blog> Blogs { get; set; }
    }
}
