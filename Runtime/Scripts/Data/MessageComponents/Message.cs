using System;
using System.Collections.Generic;
using Kiranchy.UnityLogger.Colorizers;


namespace Kiranchy.UnityLogger.Data.MessageComponents
{
    internal class Message : IMessageComponent
    {
        public string Token { 
            get => BuildMessage(); 
            set => throw new NotImplementedException(); 
        }

        private List<IMessageComponent> _components = new();

        public Message() {}

        public Message(string token)
        {
            Add<TextComponent>(token);
        }

        public void Accept(ColorizerVisitor colorizerVisitor)
        {
            foreach (IMessageComponent component in _components)
                component.Accept(colorizerVisitor);
        }

        public void Add<TComponent>(string token)
            where TComponent : TextComponent
        {
            IMessageComponent component = (IMessageComponent)Activator.CreateInstance(typeof(TComponent), token);
            _components.Add(component);
        } 

        public string BuildMessage()
        {
            string message = "";

            for (int i = 0; i < _components.Count; ++i)
            {
                string space = i == 0 ? "" : " ";    
                message += space + _components[i].Token;
            }

            return message;
        }
    }
}
