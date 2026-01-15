using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TailorManagementSystems.Application.Common
{
    public class Response<T> : ResponseBase
    {
        public T? Data { get; private set; }
        public static Response<T> Ok(T data, string message = "")
        {
            var response = new Response<T>();
            response.Data = data;
            response.SetSuccess(message);
            return response;
        }

        public static Response<T> Fail(string message, List<string>? errors = null)
        {
            var response = new Response<T>();
            response.SetFailure(message, errors);
            return response;
        }
    }
}
