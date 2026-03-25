namespace Kiranchy.UnityLogger.Data
{
    internal record LogData
    {
        public string Class { get; set; }
        public string Callback { get; set; }
        public string Method { get; set; }
        public string Message { get; set; }
    }
}
