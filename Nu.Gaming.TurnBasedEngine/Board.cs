using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Nu.Gaming.TurnedBasedEngine
{
    class Subscription
    {
        public Guid Guid { get; set; }
        public object Callback { get; set; }

        public Subscription(Guid guid, Object callback)
        {
            Guid = guid;
            Callback = callback;
        }
    }

    class Subscriptions
    {
        readonly Dictionary<Type, List<Subscription>> subs = new Dictionary<Type, List<Subscription>>();
        public Guid Subscribe<T>(Action<T> callback)
        {
            var guid = Guid.NewGuid();
            var t = typeof (T);
            if(!subs.ContainsKey(t)) subs[t] = new List<Subscription>();

            subs[t].Add(new Subscription(guid, callback));
            return guid;
        }

        public void Unsubscribe<T>(Guid guid)
        {
            var t = typeof (T);
            if(!subs.ContainsKey(t)) subs[t] = new List<Subscription>();
            var fod = subs[t].FirstOrDefault(x => x.Guid == guid);
            if (fod != null)
            {
                subs[t].Remove(fod);
            }
        }

        public void Publish<T>(T evt)
        {
            var t = typeof (T);
            if(!subs.ContainsKey(t)) subs[t] = new List<Subscription>();
            foreach (var s in subs[t])
            {
                var cb = (Action<T>) s.Callback;
                Task.Factory.StartNew(() => cb(evt));
                // TODO: Store for saftey so we can check for dead lock?
            }
        }
    }

    public class Board : IGameObject
    {
        private readonly Subscriptions subscriptions = new Subscriptions();

        public Guid Subscribe<T>(Action<T> callback) where T : GameEvent
        {
            return subscriptions.Subscribe(callback);
        }

        public void Unsubscribe<T>(Guid guid) where T : GameEvent
        {
            subscriptions.Unsubscribe<T>(guid);
        }

        public void Publish<T>(T evt) where T : GameEvent
        {
            subscriptions.Publish<T>(evt);
        }
    }
}