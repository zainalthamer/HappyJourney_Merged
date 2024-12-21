using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyJourney.observers
{
    public class UserObserver
    {
        private static List<Action> subscribers = new List<Action>();

        public static void Subscribe(Action callback)
        {
            if (!subscribers.Contains(callback))
            {
                subscribers.Add(callback);
            }
        }

        public static void Publish()
        {
            foreach (var callback in subscribers)
            {
                callback.Invoke();
            }
        }

        // Optional: Method to clear subscribers
        public static void ClearSubscribers()
        {
            subscribers.Clear();
        }
    }
}
