
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace APIWoood.Filters
{
    public class JsonExceptionFilter : IExceptionFilter
    {
        public bool AllowMultiple => throw new System.NotImplementedException();

        public Task ExecuteExceptionFilterAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}