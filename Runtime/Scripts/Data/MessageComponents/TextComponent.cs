using Kiranchy.UnityLogger.Colorizers;

namespace Kiranchy.UnityLogger.Data.MessageComponents
{
    internal class TextComponent : IMessageComponent
    {
        public string Token { get; set; }

        public TextComponent(string token)
        {
            Token = token;
        }

        public virtual void Accept(ColorizerVisitor colorizerVisitor)
        {
            colorizerVisitor.VisitTextComponent(this);
        }
    }
}
