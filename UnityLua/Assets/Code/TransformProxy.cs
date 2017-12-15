using MoonSharp.Interpreter;
using MoonSharp.Interpreter.Interop;
using UnityEngine;

namespace UnityLuaConsole.Assets.Code
{
    public class TransformProxy
    {
        Transform target;

        [MoonSharpHidden]
        public TransformProxy(Transform p) {
            this.target = p;
        }
        
        public Vector3 posiiton {
            get {
                return target.position;
            }
            set {
                target.position = value;
            }
        }
        

        //public Vector3 GetPos() {
        //    return target.position;
        //}

        public void Move(float x, float y, float z) {
            target.position += new Vector3(x, y, z);
        }

        //public LuaVector3 GetPosition() {
        //    return new LuaVector3(target.position);
        //}
    }
}
