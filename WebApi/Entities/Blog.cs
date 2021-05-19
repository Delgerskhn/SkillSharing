using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace WebApi.Entities
{
    public partial class Blog:BaseEntity
    {
        public Blog()
        {
            Comments = new HashSet<Comment>();
        }
        [Key]
        public int Pk { get; set; }
        public int Likes { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [Required]
        [StringLength(400)]
        public string Description { get; set; }
        [Required]
        [StringLength(100)]
        public string Img { get; set; }
        [Required]
        public string Content { get; set; }
        [ForeignKey("AppUser")]
        public string UserPk { get; set; }
        public int? BlogStatusPk { get; set; }


        public virtual ICollection<Tag> Tags { get; set; }
        public virtual BlogStatus BlogStatusPkNavigation { get; set; }
        public virtual AppUser AppUser { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
