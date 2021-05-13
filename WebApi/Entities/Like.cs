using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WebApi.Entities
{
    public partial class Like
    {
        [Key]
        public int Pk { get; set; }
        public int? BlogPk { get; set; }

        public virtual Blog BlogPkNavigation { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}
