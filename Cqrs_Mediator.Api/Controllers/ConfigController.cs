using Cqrs_Mediator.Application.ApplicatioConfigrations;
using Cqrs_Mediator.InfraStructure.InfraStructureConfigrations.SettingSystem;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Cqrs_Mediator.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IOptionsMonitor<FileConfig> _optionMontitor;//this singleton but when make change on file will affect 

        private readonly IOptions<FileConfig> _option;//this singleton 
        private readonly IOptionsSnapshot<FileConfig> _option2;//this scoped meaning if modify on object
                                                               //will affect by this change
                                                               //read values with first line access values  and stor it  cach
                                                               //with new request first line read this value will store on it  

        public ConfigController(IConfiguration configuration,IOptions<FileConfig> options, IOptionsSnapshot<FileConfig> option2)
        {
            _configuration = configuration;
            _option = options;
            _option2 = option2;
            var value = _option2.Value;//this first value read 
        }
        [HttpGet("Configration")]
        public IActionResult GetConfig()
        {
            var config = new
            {
                _option = _option.Value,
                _option2 = _option2.Value

            };
            return Ok(config);
        }
    }

}
