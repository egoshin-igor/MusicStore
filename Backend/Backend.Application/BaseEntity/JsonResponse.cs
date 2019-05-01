using Newtonsoft.Json;

namespace MusicStore.Backend.Application.BaseEntity
{
    public class JsonResponse
    {
        public object Result { get; private set; }
        public string Message { get; private set; }

        public JsonResponse( object result, string message )
        {
            Result = result;
            Message = message;
        }
    }
}
