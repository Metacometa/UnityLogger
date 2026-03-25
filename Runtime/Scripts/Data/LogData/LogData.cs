using Kiranchy.UnityLogger.Data.MessageComponents;

namespace Kiranchy.UnityLogger.Data.LogData
{
    internal record LogData
    {
        public string Class { get; set; }
        public string Callback { get; set; }
        public string Method { get; set; }
        public Message Message { get; set; }
    }
}
