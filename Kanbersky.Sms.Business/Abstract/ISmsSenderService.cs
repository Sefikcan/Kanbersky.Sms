using Kanbersky.Sms.Business.DTO.Request;
using Kanbersky.Sms.Business.DTO.Response;

namespace Kanbersky.Sms.Business.Abstract
{
    public interface ISmsSenderService
    {
        SmsSenderResponse Send(SmsSenderRequest request);
    }
}
