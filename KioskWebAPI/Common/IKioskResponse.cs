namespace KioskWebAPI.Common
{
    public interface IKioskResponse
    {
        KioskResponse GenerateResponseMessage(string statusCode, string message, Dictionary<string, object> dataHoldDictionary);
        KioskResponse GenerateResponseMessage(string statusCode, string message, object data);
        KioskResponse GenerateResponseMessage(string statusCode, object data);
        KioskResponse GenerateResponseMessage(string statusCode, string message);
        KioskResponse GenerateResponseMessage(object data);
    }
}
