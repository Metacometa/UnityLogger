using Kiranchy.UnityLogger.Colorizers;

namespace Kiranchy.UnityLogger.Data.MessageComponents
{
    internal interface IMessageComponent
    {
        public string Token { get; set; }
        public void Accept(ColorizerVisitor colorizerVisitor);
    }
}
