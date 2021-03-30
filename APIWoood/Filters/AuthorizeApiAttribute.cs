using APIWoood.Logic.Models;
using APIWoood.Logic.Repositories;
using APIWoood.Logic.Services;
using APIWoood.Logic.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace APIWoood.Filters
{
    public class AuthorizeApiAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private readonly UserRepository userRepository = new UserRepository();
        private readonly SystemLogger logger = new SystemLogger();

        public override Task OnAuthorizationAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            HttpRequestMessage request = actionContext.Request;
            base.OnAuthorizationAsync(actionContext, cancellationToken);

            var user = userRepository.GetByUsername(actionContext.RequestContext.Principal.Identity.Name);

            // Check IP Address
            // var sourceIP = "172.18.3.10";
            var sourceIP = GetIPAddress();
            if (CheckIPAddress(user, sourceIP))
            {
                // Check url
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                if (!CheckUrl(user, url))
                {
                    // Invalid url.
                    logger.Log(ErrorType.ALERT, "Authorization", actionContext.RequestContext.Principal.Identity.Name, "Your are not allowed to access url " + url, "authorization");
                    actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                    actionContext.Response.ReasonPhrase = "Your are not allowed to access this url";
                    
                }
            }
            else
            {
                logger.Log(ErrorType.ALERT, "Authorization", actionContext.RequestContext.Principal.Identity.Name, "Your IP Address is not allowed", "authorization");
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                actionContext.Response.ReasonPhrase =  "Your IP Address is not allowed";
            }

            return Task.FromResult(true);
        }

        private static string GetIPAddress()
        {
            return GetIPAddress(new HttpRequestWrapper(HttpContext.Current.Request));
        }


        private static bool CheckUrl(User user, string destinationUrl)
        {
            if (user.Urls.Count > 0)
            {
                foreach (var url in user.Urls)
                {
                    if (destinationUrl.ToLower().Contains(url.Name.ToLower()))
                    {
                        return true;
                    }
                }

                return false;
            }
            else
            {
                return true;
            }
        }

        private static bool CheckIPAddress(User user, string sourceIP)
        {
            if (sourceIP != "::1")
            {
                var ips = user.AllowedIP.Split(',');
                foreach (var ip in ips)
                {
                    // is ip range?
                    if (ip.Contains('-'))
                    {
                        var range = ip.Split('-');
                        var ipRange = new IPAddressRange(range[0], range[1]);
                        if (ipRange.IsInRange(sourceIP))
                        {
                            return true;
                        }
                    }
                    else
                    {
                        if (sourceIP == ip)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            else // local address, alway allow
            {
                return true;
            }

        }
        internal static string GetIPAddress(HttpRequestBase request)
        {
            // handle standardized 'Forwarded' header
            string forwarded = request.Headers["Forwarded"];
            if (!String.IsNullOrEmpty(forwarded))
            {
                foreach (string segment in forwarded.Split(',')[0].Split(';'))
                {
                    string[] pair = segment.Trim().Split('=');
                    if (pair.Length == 2 && pair[0].Equals("for", StringComparison.OrdinalIgnoreCase))
                    {
                        string ip = pair[1].Trim('"');

                        // IPv6 addresses are always enclosed in square brackets
                        int left = ip.IndexOf('['), right = ip.IndexOf(']');
                        if (left == 0 && right > 0)
                        {
                            return ip.Substring(1, right - 1);
                        }

                        // strip port of IPv4 addresses
                        int colon = ip.IndexOf(':');
                        if (colon != -1)
                        {
                            return ip.Substring(0, colon);
                        }

                        // this will return IPv4, "unknown", and obfuscated addresses
                        return ip;
                    }
                }
            }

            // handle non-standardized 'X-Forwarded-For' header
            string xForwardedFor = request.Headers["X-Forwarded-For"];
            if (!String.IsNullOrEmpty(xForwardedFor))
            {
                return xForwardedFor.Split(',')[0];
            }

            return request.UserHostAddress;
        }
    }
}