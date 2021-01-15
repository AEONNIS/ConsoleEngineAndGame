using System.Collections.Generic;

namespace Engine.FunctionalTests.DisplaySystem
{
    public class CompositeMessage : IMessage
    {
        #region Fields
        private readonly List<SimpleMessage> _messages = new List<SimpleMessage>();
        #endregion

        #region Methods
        public CompositeMessage Add(SimpleMessage message)
        {
            _messages.Add(message);
            return this;
        }

        public void Write(string before = null, string after = null)
        {
            for (int i = 0; i < _messages.Count; i++)
            {
                if (i == 0)
                    _messages[i].Write(before: before);
                else if (i < _messages.Count - 1)
                    _messages[i].Write();
                else
                    _messages[i].Write(after: after);
            }
        }
        #endregion
    }
}
