namespace Kanbersky.Sms.Core.Settings
{
    public class TwilioSettings : ISettings
    {
        public string AccountSid { get; set; }

        public string AuthToken { get; set; }
    }
}
