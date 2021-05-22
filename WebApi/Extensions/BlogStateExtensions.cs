using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Extensions
{
    public static class BlogStateExtensions
    {
        public static int Val(this BlogState state)
        {
            return (int)state;
        }
    }
}
