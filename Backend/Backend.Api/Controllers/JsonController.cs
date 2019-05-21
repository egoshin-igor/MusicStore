using Microsoft.AspNetCore.Mvc;
using MusicStore.Backend.Application.BaseEntity;

namespace MusicStore.Backend.Api.Controllers
{
    public class JsonController : ControllerBase
    {
        public string Email => User.Identity.Name;

        public static JsonResponse Success( object result = null, string message = "Success" )
        {
            return new JsonResponse( result, message, isSuccess: true );
        }

        public static JsonResponse JsonResult( string message, bool isSuccess, object result = null )
        {
            return new JsonResponse( result, message, isSuccess );
        }

        public static JsonResponse Error( string message )
        {
            return new JsonResponse( result: null, message, isSuccess: false );
        }
    }
}
