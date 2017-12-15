using MoonSharp.Interpreter;
using UnityEngine;

namespace UnityLua.Assets.Code
{
    public class TransformProxy
    {
        Transform target;

        [MoonSharpHidden]
        public TransformProxy(Transform p) {
            this.target = p;
        }

        public LuaVector3 posiiton {
            get {
                return new LuaVector3(target.position);
            }
            set {
                target.position = value.ToVector3();
            }
        }

        public void Move(float x, float y, float z) {
            target.position += new Vector3(x, y, z);
        }

        public LuaVector3 GetPosition() {
            return new LuaVector3(target.position);
        }
    }
}
