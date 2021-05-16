using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WebApi.Entities
{
    public partial class Tag:BaseEntity
    {
        public Tag()
        {
        }
        [Key]
        public int Pk { get; set; }
        [StringLength(130)]
        public string Name { get; set; }

        public ICollection<Blog> Blogs { get; set; }

    }
}
