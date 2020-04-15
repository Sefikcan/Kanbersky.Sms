using Kanbersky.Sms.Business.Abstract;
using Kanbersky.Sms.Business.DTO.Request;
using Kanbersky.Sms.Business.DTO.Response;
using Kanbersky.Sms.Core.Settings;
using Microsoft.Extensions.Options;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Kanbersky.Sms.Business.Concrete
{
    public class TwilioSmsSenderService : ISmsSenderService
    {
        private readonly IOptions<TwilioSettings> _settings;
        private readonly string _accountSid;
        private readonly string _authToken;

        public TwilioSmsSenderService(IOptions<TwilioSettings> settings)
        {
            _settings = settings;
            _accountSid = _settings.Value.AccountSid;
            _authToken = _settings.Value.AuthToken;
        }

        public SmsSenderResponse Send(SmsSenderRequest request)
        {
            TwilioClient.Init(_accountSid, _authToken);

            //body content gibi bir tablodan gelebilir

            var message = MessageResource.Create(
                body: request.Body,
                from: new Twilio.Types.PhoneNumber(request.From),
                to: new Twilio.Types.PhoneNumber(request.To)
            );

            return new SmsSenderResponse
            {
                MessageId = message.Sid,
                Success = message.ErrorCode == null ? true  : false, //test et burası değişsin
                ErrorCode = message.ErrorCode,
                ErrorMessage = message.ErrorMessage
            };
        }
    }
}
