using Kanbersky.Sms.Business.Abstract;
using Kanbersky.Sms.Business.DTO.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kanbersky.Sms.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmsSendersController : ControllerBase
    {
        #region fields

        private readonly ISmsSenderService _smsSenderService;

        #endregion

        #region ctor

        public SmsSendersController(ISmsSenderService smsSenderService)
        {
            _smsSenderService = smsSenderService;
        }

        #endregion

        #region methods

        /// <summary>
        /// Sms Gönderme işlemini yapar
        /// </summary>
        /// <param name="uploadContentRequestModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("send-message")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult SendMessage([FromBody] SmsSenderRequest smsSenderRequest)
        {
            var response = _smsSenderService.Send(smsSenderRequest);
            return Ok(response);
        }

        #endregion
    }
}