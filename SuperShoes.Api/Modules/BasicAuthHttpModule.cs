namespace SuperShoes.Api.Modules
{
    using System;
    using System.Net.Http.Headers;
    using System.Security.Principal;
    using System.Text;
    using System.Threading;
    using System.Web;

    /// <summary>
    /// Represents the authentication class.
    /// </summary>
    public class BasicAuthHttpModule : IHttpModule
    {
        /// <summary>
        /// Represent the basic realm name. 
        /// </summary>
        private const string Realm = "WebAPI Authentication";

        /// <summary>
        /// Represent the init event.
        /// </summary>
        /// <param name="context"></param>
        public void Init(HttpApplication context)
        {
            context.AuthenticateRequest += OnApplicationAuthenticateRequest;
            context.EndRequest += OnApplicationEndRequest;
        }

        /// <summary>
        /// Set the principal to the current thread.
        /// </summary>
        /// <param name="principal">Principal object.</param>
        private static void SetPrincipal(IPrincipal principal)
        {
            Thread.CurrentPrincipal = principal;
            if (HttpContext.Current != null)
            {
                HttpContext.Current.User = principal;
            }
        }

        /// <summary>
        /// Validate the credentials of the an user.
        /// </summary>
        /// <param name="credentials">Credentials to validate.</param>
        /// <returns></returns>
        private static bool AuthenticateUser(string credentials)
        {
            var encoding = Encoding.GetEncoding("iso-8859-1");
            credentials = encoding.GetString(Convert.FromBase64String(credentials));

            var credentialsArray = credentials.Split(':');
            var username = credentialsArray[0];
            var password = credentialsArray[1];

            if (!(username == "my_user" && password == "my_password"))
            {
                return false;
            }

            var identity = new GenericIdentity(username);
            SetPrincipal(new GenericPrincipal(identity, null));

            return true;
        }

        /// <summary>
        /// Represent the ApplicationAuthenticateRequest event.
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e">Parameters of the event.</param>
        private static void OnApplicationAuthenticateRequest(object sender, EventArgs e)
        {
            var request = HttpContext.Current.Request;
            var authHeader = request.Headers["Authorization"];
            if (authHeader != null)
            {
                var authHeaderVal = AuthenticationHeaderValue.Parse(authHeader);
                if (authHeaderVal.Scheme.Equals("basic", StringComparison.OrdinalIgnoreCase) && authHeaderVal.Parameter != null)
                {
                    AuthenticateUser(authHeaderVal.Parameter);
                }
            }
        }

        /// <summary>
        /// Represent the ApplicationEndRequest event.
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e">Parameters of the event.</param>
        private static void OnApplicationEndRequest(object sender, EventArgs e)
        {
            var response = HttpContext.Current.Response;
            if (response.StatusCode == 401)
            {
                response.Headers.Add("WWW-Authenticate", string.Format("Basic realm=\"{0}\"", Realm));
            }
        }

        /// <summary>
        /// Dispose the object.
        /// </summary>
        public void Dispose()
        {
        }
    }
}