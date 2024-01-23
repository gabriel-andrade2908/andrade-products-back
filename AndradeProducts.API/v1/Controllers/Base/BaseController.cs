using AndradeProducts.API.Tools.ExceptionHandler;
using Microsoft.AspNetCore.Mvc;

namespace AndradeProducts.API.v1.Controllers.Base
{
    [ApiController]
    [ValidateModelStateAttribute]
    public class BaseController : ControllerBase
    {
    }
}
