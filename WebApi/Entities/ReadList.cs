using System;
using System.Collections.Generic;

#nullable disable

namespace WebApi.Entities
{
    public partial class ReadList
    {
        public int? BlogPk { get; set; }

        public virtual Blog BlogPkNavigation { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}
