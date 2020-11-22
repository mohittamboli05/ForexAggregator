using Microsoft.AspNetCore.Http;
using System;

namespace ForexAggregator.Web.Helper
{
    public static class AjaxCheck
    {
        private const string XmlHttpRequest = "XMLHttpRequest";
        public static bool IsAjaxRequest(this HttpRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            if (request.Headers != null)
                return request.Headers["X-Requested-With"] == XmlHttpRequest;
            return false;
        }
    }
}
