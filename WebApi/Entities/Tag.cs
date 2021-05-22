using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

#nullable disable

namespace WebApi.Entities
{
    public partial class Tag:BaseEntity
    {
        public Tag()
        {
        }
        [StringLength(130)]
        public string Name { get; set; }

        public ICollection<Blog> Blogs { get; set; }
    }
}
