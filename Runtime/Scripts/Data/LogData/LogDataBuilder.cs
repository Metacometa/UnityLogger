using Kiranchy.UnityLogger.Data.MessageComponents;

namespace Kiranchy.UnityLogger.Data.LogData
{
    internal class LogDataBuilder
    {
        private LogData _data = new();

        public LogData Build() => _data;

        public LogDataBuilder WithClass(string value)
        {
            _data.Class = value;
            return this;
        }

        public LogDataBuilder WithCallback(string value)
        {
            _data.Callback = value;
            return this;
        } 

        public LogDataBuilder WithMethod(string value)
        {
            _data.Method = value;
            return this;
        } 

        public LogDataBuilder WithMessage(Message value)
        {
            _data.Message = value;
            return this;
        } 
    }
}
