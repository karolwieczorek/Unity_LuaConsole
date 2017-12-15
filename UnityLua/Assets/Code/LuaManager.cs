using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using System;
using MoonSharp.Interpreter;

namespace UnityLuaConsole.Assets.Code {
    public class LuaManager : MonoBehaviour {
        [SerializeField] LuaConsole luaConsole;
        [SerializeField] UnityMethodsEvents unityMethodsEvents;
        Script luaEngine;

        string script = @"    
		-- defines a factorial function
		function fact (n)
			if (n == 0) then
				return 1
			else
				return n*fact(n - 1)
			end
        func(""n"")
		end
        
		return fact(5)";

        private void Awake() {
            MoonSharpFactorial();
            luaConsole.SetExecuteAction(ExecuteInputCommand);
        }

        private void ExecuteInputCommand(string expression) {
            luaEngine.DoString(expression);
        }

        void MoonSharpFactorial() {
            UserData.RegisterAssembly();

            UserData.RegisterType<Vector3>();
            UserData.RegisterType<KeyCode>();
            UserData.RegisterType<Input>();
            UserData.RegisterType<GameObject>();

            UserData.RegisterType<Transform>();

            //UserData.RegisterProxyType<TransformProxy, Transform>(r => new TransformProxy(r));
            

            UserData.RegisterType<EventArgs>();
            UserData.RegisterType<UnityMethodsEvents.Events>();

            luaEngine = new Script();
            luaEngine.Globals["Vector3"] = UserData.CreateStatic<Vector3>();
            luaEngine.Globals["KeyCode"] = UserData.CreateStatic<KeyCode>();
            luaEngine.Globals["Input"] = UserData.CreateStatic<Input>();
            luaEngine.Globals["GameObject"] = UserData.CreateStatic<GameObject>();

            luaEngine.Globals["unityEvents"] = unityMethodsEvents.events;
            luaEngine.Globals["Circle"] = GameObject.Find("Circle").transform;
            
            luaEngine.Options.DebugPrint = s => { luaConsole.AddLuaLog(s); };
        }
    }
}
