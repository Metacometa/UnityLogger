namespace Kiranchy.UnityLogger.Data.Message
{
    internal class TextComponent : IMessageComponent
    {
        public string Token { get; }

        public TextComponent(string token)
        {
            Token = token;
        }
    }
}
