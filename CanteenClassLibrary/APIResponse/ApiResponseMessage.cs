using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanteenClassLibrary.APIResponse
{
    internal class ApiResponseMessage<T>
    {
        public T Data { get; set; }

        public string Message { get; set; }

        public Boolean IsError { get; set; }
    }
}
