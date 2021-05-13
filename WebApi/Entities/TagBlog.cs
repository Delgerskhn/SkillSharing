using System;
using System.Collections.Generic;

#nullable disable

namespace WebApi.Entities
{
    public partial class TagBlog
    {
        public int? TagPk { get; set; }
        public int? BlogPk { get; set; }

        public virtual Blog BlogPkNavigation { get; set; }
        public virtual Tag TagPkNavigation { get; set; }
    }
}
