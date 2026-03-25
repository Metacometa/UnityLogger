using Kiranchy.UnityLogger.Data.MessageComponents;
using UnityEngine.UI;

namespace Kiranchy.UnityLogger.Colorizers
{
    internal class ColorizerVisitor
    {
        public void VisitTextComponent(TextComponent component) {}

        public void VisitVariableComponent(VariableComponent component)
        {
            component.Token = LogColorizer.Colorize(component.Token, "yellow");
        }
    }
}