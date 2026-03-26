using Kiranchy.UnityLogger.Colorizers;

namespace Kiranchy.UnityLogger.Data.MessageComponents
{
    internal class VariableComponent<T> : TextComponent
    {
        public VariableComponent(string token) : base(token) {}

        public override void Accept(ColorizerVisitor colorizerVisitor)
        {
            colorizerVisitor.VisitVariableComponent(this);
        }
    }
}
