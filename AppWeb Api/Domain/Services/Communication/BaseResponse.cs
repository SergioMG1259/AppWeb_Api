using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppWeb_Api.Domain.Services.Communication
{
    public abstract class BaseResponse<T>
    {
        public bool Succes { get; protected set; }
        public string Message { get; protected set; }
        public T Resource { get; private set; }
        protected BaseResponse(string message)
        {
            Succes = false;
            Message = message;
        }
        protected BaseResponse(T resource)
        {
            Succes = true;
            Resource = resource;
        }


    }
}
