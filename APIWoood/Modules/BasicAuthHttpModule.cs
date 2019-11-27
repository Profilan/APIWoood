using APIWoood.Logic.Models;
using APIWoood.Logic.Repositories;
using APIWoood.Logic.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;

namespace APIWoood.Modules
{
    public class BasicAuthHttpModule : IHttpModule
    {
        private const string Realm = "Woood";

        public void Init(HttpApplication context)
        {
            // Register event handlers
            context.AuthenticateRequest += OnApplicationAuthenticateRequest;
            context.EndRequest += OnApplicationEndRequest;
        }

        private static void SetPrincipal(IPrincipal principal)
        {
            Thread.CurrentPrincipal = principal;
            if (HttpContext.Current != null)
            {
                HttpContext.Current.User = principal;
            }
        }

        // TODO: Here is where you would validate the username and password.
        private static bool CheckPassword(User user, string password)
        {
            if (user == null)
            {
                return false;
            }

            var passwordHasher = new PasswordHasher();

            var temp = passwordHasher.HashPassword(password);

            if (passwordHasher.HashPassword(password) == user.HashedPassword)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static void AuthenticateUser(string credentials)
        {
            try
            {
                
                var userRepository = new UserRepository();
                
                var encoding = Encoding.GetEncoding("iso-8859-1");
                credentials = encoding.GetString(Convert.FromBase64String(credentials));

                int separator = credentials.IndexOf(':');
                string name = credentials.Substring(0, separator);
                string password = credentials.Substring(separator + 1);

                var user = userRepository.GetByUsername(name);

                // Check IP Address
                // var sourceIP = "172.18.3.10";
                var sourceIP = GetIPAddress();
                if (CheckIPAddress(user, sourceIP))
                {
                    // Check url
                    string url = HttpContext.Current.Request.Url.AbsoluteUri;
                    if (CheckUrl(user, url))
                    {
                        // Check credentials
                        if (CheckPassword(user, password))
                        {
                            var identity = new GenericIdentity(name);
                            SetPrincipal(new GenericPrincipal(identity, null));
                        }
                        else
                        {
                            // Invalid username or password.
                            HttpContext.Current.Response.StatusCode = 401;
                            HttpContext.Current.Response.StatusDescription = "Your username or password is invalid";
                        }

                    }
                    else
                    {
                        // Invalid url.
                        HttpContext.Current.Response.StatusCode = 401;
                        HttpContext.Current.Response.StatusDescription = "Your are not allowed to access this url";
                    }
                }
                else
                {
                    HttpContext.Current.Response.StatusCode = 401;
                    HttpContext.Current.Response.StatusDescription = "Your IP Address is not allowed";
                }

            }
            catch (FormatException)
            {
                // Credentials were not formatted correctly.
                HttpContext.Current.Response.StatusCode = 401;
            }
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

        private static void OnApplicationAuthenticateRequest(object sender, EventArgs e)
        {
            var request = HttpContext.Current.Request;
            var authHeader = request.Headers["Authorization"];
            if (authHeader != null)
            {
                var authHeaderVal = AuthenticationHeaderValue.Parse(authHeader);

                // RFC 2617 sec 1.2, "scheme" name is case-insensitive
                if (authHeaderVal.Scheme.Equals("basic",
                        StringComparison.OrdinalIgnoreCase) &&
                    authHeaderVal.Parameter != null)
                {
                    AuthenticateUser(authHeaderVal.Parameter);
                }
            }
        }

        // If the request was unauthorized, add the WWW-Authenticate header 
        // to the response.
        private static void OnApplicationEndRequest(object sender, EventArgs e)
        {
            var response = HttpContext.Current.Response;
            if (response.StatusCode == 401)
            {
                response.Headers.Add("WWW-Authenticate",
                    string.Format("Basic realm=\"{0}\"", Realm));
            }
        }

        public static string GetIPAddress()
        {
            return GetIPAddress(new HttpRequestWrapper(HttpContext.Current.Request));
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

        public void Dispose()
        {
        }
    }
}