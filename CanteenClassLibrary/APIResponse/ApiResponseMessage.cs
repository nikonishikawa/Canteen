using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanteenClassLibrary.APIResponse
{
    public class ApiResponseMessage<T>
    {
        public T Data { get; set; }

        public string Message { get; set; }

        public Boolean IsSuccess { get; set; }
    }
}
