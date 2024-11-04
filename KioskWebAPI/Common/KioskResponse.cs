namespace KioskWebAPI.Common
{
    public class KioskResponse : IKioskResponse
    {
        public string StatusCode { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public KioskResponse GenerateResponseMessage(string statusCode, string message, Dictionary<string, object> dataHoldDictionary)
        {
            this.StatusCode = statusCode;
            this.Message = message;
            this.Data = dataHoldDictionary;

            return this;
        }

        public KioskResponse GenerateResponseMessage(string statusCode, string message, object data)
        {
            this.StatusCode = statusCode;
            this.Message = message;
            this.Data = data;
            return this;
        }

        public KioskResponse GenerateResponseMessage(object data)
        {
            this.Data = data;
            return this;
        }

        public KioskResponse GenerateResponseMessage(string statusCode, string message)
        {
            this.StatusCode = statusCode;
            this.Message = message;
            return this;
        }

        public KioskResponse GenerateResponseMessage(string statusCode, object data)
        {
            this.StatusCode = statusCode;
            this.Data = data;
            return this;
        }
    }
}
