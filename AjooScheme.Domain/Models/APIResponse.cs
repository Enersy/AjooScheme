using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AjooScheme.Domain.Models
{
    public class APIResponse<T> where T : class
    {
        public string Description { get; set; }
        public string Code { get; set; }
        public T Data { get; set; }
    }

    public class APIResponse2<T> where T : class
    {
        public string Description { get; set; }
        public string Code { get; set; }
        public string Data { get; set; }
    }
}
