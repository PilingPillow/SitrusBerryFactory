using System;
using System.Collections.Generic;

namespace SitrusBerryFactory._utilities
{
    public sealed class EventBinder
    {
        private List<Action> _detachActions = new List<Action>();

        /// <summary>
        /// Binds an event and registers its removal.
        /// </summary>
        public void BindCtrl(
            Action<EventHandler> adder,
            Action<EventHandler> remover,
            EventHandler handler = null)
        {
            // Dispose this binder when no handler is provided
            if (handler == null)
            {
                handler = (_, __) => Dispose();
            }

            adder(handler);
            _detachActions.Add(() => remover(handler));
        }

        /// <summary>
        /// Binds a custom event using attach and detach actions.
        /// </summary>
        public void BindCustom(Action attachAction, Action detachAction)
        {
            attachAction();
            _detachActions.Add(detachAction);
        }

        private void Dispose()
        {
            foreach (var detach in _detachActions)
            {
                detach();
            }

            _detachActions.Clear();
        }
    }
}
