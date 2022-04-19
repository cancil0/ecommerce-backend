using Autofac;
using Core.IoC;
using Microsoft.AspNetCore.Mvc;

namespace Core.Base.Concrete
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected static T Resolve<T>()
        {
            return Provider.Resolve<T>();
        }
    }
}
