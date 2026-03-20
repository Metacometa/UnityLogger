namespace Kiranchy.UnityLogger
{
    internal class LogDataBuilder
    {
        private LogData _data;

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

        public LogDataBuilder WithMessage(string value)
        {
            _data.Message = value;
            return this;
        } 
    }
}
