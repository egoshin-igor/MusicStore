using Microsoft.AspNetCore.Mvc;
using MusicStore.Backend.Application.BaseEntity;

namespace MusicStore.Backend.Api.Controllers
{
    public class JsonController : ControllerBase
    {
        public static JsonResponse Success( object result = null )
        {
            return new JsonResponse( result, "Success" );
        }

        public static JsonResponse Error( string message )
        {
            return new JsonResponse( result: null, message );
        }
    }
}
