using System.Collections.Generic;

namespace CoreGularCommerce.WebApi.Errors
{
    public class ApiValidationResponseError : ApiResponse
    {
        public ApiValidationResponseError() : base(400)
        {
        }

        public IEnumerable<string> Errors { get; set; }
        
    }
}