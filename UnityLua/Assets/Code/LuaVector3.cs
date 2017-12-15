using MoonSharp.Interpreter;
using UnityEngine;


namespace UnityLuaConsole.Assets.Code {
    [MoonSharpUserData]
    public class LuaVector3 {
        public float x;
        public float y;
        public float z;

        public LuaVector3() {
        }

        public LuaVector3(float x, float y, float z) {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public LuaVector3(Vector3 vector3) {
            x = vector3.x;
            y = vector3.y;
            z = vector3.z;

        }

        public void Add(LuaVector3 v3) {
            x += v3.x;
            y += v3.y;
            z += v3.z;
        }

        public void Multiply(float v) {
            x *= v;
            y *= v;
            z *= v;
        }

        public Vector3 ToVector3() {
            return new Vector3(x, y, z);
        }

        public override string ToString() {
            return ToVector3().ToString();
        }
    }
}