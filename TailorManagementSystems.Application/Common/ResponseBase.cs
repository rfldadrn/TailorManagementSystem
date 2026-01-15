using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TailorManagementSystems.Application.Common
{
    public abstract class ResponseBase
    {
        public bool Success { get; protected set; }
        public string Message { get; protected set; } = string.Empty;
        public List<string> Errors { get; protected set; } = new();

        protected void SetSuccess(string message = "")
        {
            Success = true;
            Message = message;
        }

        protected void SetFailure(string message, List<string>? errors = null)
        {
            Success = false;
            Message = message;
            Errors = errors ?? new();
        }
    }
}
