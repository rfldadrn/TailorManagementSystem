using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TailorManagementSystems.Application.Common
{
    public class ResponseList<T> : ResponseBase 
    {
        public IReadOnlyList<T> Data { get; private set; } = Array.Empty<T>();

        public static ResponseList<T> Ok(IEnumerable<T> data, string message = "")
        {
            var response = new ResponseList<T>();
            response.Data = data.ToList();
            response.SetSuccess(message);
            return response;
        }

        public static ResponseList<T> Fail(string message, List<string>? errors = null)
        {
            var response = new ResponseList<T>();
            response.SetFailure(message, errors);
            return response;
        }
    }
}
