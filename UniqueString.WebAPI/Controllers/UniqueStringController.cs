using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UniqueString.API.ViewModel;
using UniqueString.Core.Interfaces.BLContract;

namespace UniqueString.API.Controllers
{
    [ApiController]
    [Route("api/[action]")]
    public class UniqueStringController : ControllerBase
    {
        #region Modifiers

        private readonly IUniqueStringBL _bl;

        #endregion

        public UniqueStringController(IUniqueStringBL bl)
        {
            _bl = bl;
        }

        [HttpPost]
        public IActionResult isUnique(RequestViewModel model)
        {
            var result = _bl.IsUnique(model.Text);
            return Ok(result);
        }
    }
}
