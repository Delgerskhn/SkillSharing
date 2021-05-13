using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WebApi.Entities
{
    public partial class Comment
    {
        [Key]
        public int Pk { get; set; }
        public int? BlogPk { get; set; }
        [StringLength(500)]
        public string Content { get; set; }

        public virtual Blog BlogPkNavigation { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}
