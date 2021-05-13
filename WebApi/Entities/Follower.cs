using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WebApi.Entities
{
    public partial class Follower
    {
        [Key]
        public int Pk { get; set; }

        public virtual AppUser FollowerUser { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}
