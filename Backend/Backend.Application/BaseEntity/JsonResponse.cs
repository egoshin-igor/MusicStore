using Newtonsoft.Json;

namespace MusicStore.Backend.Application.BaseEntity
{
    public class JsonResponse
    {
        public object Result { get; private set; }
        public string Message { get; private set; }
        public bool IsSuccess { get; private set; }

        public JsonResponse( object result, string message, bool isSuccess )
        {
            Result = result;
            Message = message;
            IsSuccess = isSuccess;
        }
    }
}
