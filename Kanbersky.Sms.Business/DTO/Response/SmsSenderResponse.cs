namespace Kanbersky.Sms.Business.DTO.Response
{
    public class SmsSenderResponse
    {
        public bool Success { get; set; }

        public string MessageId { get; set; }

        public int? ErrorCode { get; set; }

        public string ErrorMessage { get; set; }
    }
}
