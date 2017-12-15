using System;
using UnityEngine;

namespace UnityLuaConsole.Assets.Code {
    public class UnityMethodsEvents : MonoBehaviour {
        public Events events = new Events();
        
        private void Update() {
            events.RaiseUpdate();
        }

        private void FixedUpdate() {
            events.RaiseFixedUpdate();
        }

        public class Events {
            public event EventHandler update;
            public event EventHandler fixedUpdate;

            public Events() {
            }

            public void RaiseUpdate() {
                if (update != null)
                    update(this, EventArgs.Empty);
            }

            public void RaiseFixedUpdate() {
                if (fixedUpdate != null)
                    fixedUpdate(this, EventArgs.Empty);
            }
        }
    }
}
