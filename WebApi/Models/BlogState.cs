using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public enum BlogState
    {
        Draft = 4,
        Pending = 1,
        Approved = 2,
        Declined = 3
    }
}
