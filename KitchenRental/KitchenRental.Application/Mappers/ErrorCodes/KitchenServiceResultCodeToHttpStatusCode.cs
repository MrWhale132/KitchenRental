using KitchenRental.BusinessLogic.Contracts;
using System;
using System.Net;

namespace KitchenRental.Application.Mappers.ErrorCodes
{
    public class KitchenServiceResultCodeToHttpStatusCode
    {
        public HttpStatusCode Map(RentalKitchenResultCode resultCode)
        {
            switch (resultCode)
            {
                case RentalKitchenResultCode.Success:
                    return HttpStatusCode.OK;
                case RentalKitchenResultCode.NoContent:
                    return HttpStatusCode.NoContent;
                case RentalKitchenResultCode.Generic:
                case RentalKitchenResultCode.BadRequest:
                    return HttpStatusCode.BadRequest;
                case RentalKitchenResultCode.NotFound:
                    return HttpStatusCode.NotFound;
                case RentalKitchenResultCode.Internal:
                    return HttpStatusCode.InternalServerError;
                default: throw new ArgumentException("Unknown error code");
            }
        }
    }
}