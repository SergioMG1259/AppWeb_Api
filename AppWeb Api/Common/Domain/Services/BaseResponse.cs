namespace AppWeb_Api.Common.Domain.Services
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
