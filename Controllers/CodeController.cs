using Microsoft.AspNetCore.Mvc;
using LicenseSalesApp.DTOs;
using LicenseSalesApp.Services;
using System.Threading.Tasks;

namespace LicenseSalesApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CodesController : ControllerBase
    {
        private readonly ICodeService _codeService;

        public CodesController(ICodeService codeService)
        {
            _codeService = codeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCodes()
        {
            var response = await _codeService.GetCodesAsync();
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }
            return Ok(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> AddCode(CodeDto codeDto)
        {
            var response = await _codeService.AddCodeAsync(codeDto);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }
            return Ok(response.Data);
        }

        // Additional methods for managing codes
    }
}
