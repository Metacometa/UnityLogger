using Kiranchy.UnityLogger.Data.MessageComponents;
using UnityEngine.UI;

namespace Kiranchy.UnityLogger.Colorizers
{
    internal class ColorizerVisitor
    {
        public void VisitTextComponent(TextComponent component) {}

        public void VisitVariableComponent<T>(VariableComponent<T> component)
        {
            if (component is VariableComponent<bool> boolComponent)
                VisitStringBool(boolComponent);
            else
                component.Token = Colorizer.Colorize(component.Token, "yellow");
        }

        private void VisitStringBool(VariableComponent<bool> component)
        {
            string color = component.Token == "True" ? "#31e731" : "#ff3535";
            component.Token = Colorizer.Colorize(component.Token, color);
        }
    }
}