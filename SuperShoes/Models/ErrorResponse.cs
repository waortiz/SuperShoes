using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperShoes.Api.Models
{
    public enum ErrorResponse
    {
        BadRequest = 400,
        NotAuthorized = 401,
        RecordNotFound = 404,
        ServerError = 500
    }
}