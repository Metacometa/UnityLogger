using System.Collections.Generic;
using UnityEngine.UI;

namespace Kiranchy.UnityLogger.Data.Message
{
    internal class Message : IMessageComponent
    {
        public string Token => BuildMessage();

        private List<IMessageComponent> _components = new();

        public void Add(string token)
        {
            IMessageComponent component = new TextComponent(token);
            _components.Add(component);
        } 

        private string BuildMessage()
        {
            string message = "";

            foreach (IMessageComponent component in _components)
            {
                message += " " + component.Token;
            }

            return message;
        }
    }
}
