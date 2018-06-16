using Microsoft.AspNetCore.Mvc;

namespace MyStore.Api.Controllers
{
    [Route("[controller]")]
    public abstract class BaseController : Controller
    {
    }
}