using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using System;
using MoonSharp.Interpreter;
using UnityLua.Assets.Code;

namespace UnityPythonConsole.Assets.Code {
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
            UserData.RegisterProxyType<TransformProxy, Transform>(r => new TransformProxy(r));
            UserData.RegisterAssembly();
            UserData.RegisterType<LuaVector3>();

            luaEngine = new Script();
            luaEngine.Globals["Circle"] = GameObject.Find("Circle").transform;

            luaEngine.Options.DebugPrint = s => { luaConsole.AddLuaLog(s); };
            

//            luaEngine.Globals["func"] = (Action<string>)pyConsole.AddLuaLog;
//            luaEngine.DoString(@"
//func(""wow"");
//            ");

//            DynValue res = luaEngine.DoString(script);
//            Debug.Log(res.Number);
        }

        /*
        Microsoft.Scripting.Hosting.ScriptEngine engine;
        Microsoft.Scripting.Hosting.ScriptScope scope;

        string pythonScript;
        private void Awake() {
            StartCoroutine(GetPythonScript());
            pyConsole.SetExecuteAction(ExecuteInputCommand);
        }

        private void ExecuteInputCommand(string expression) {
            engine.Execute(expression, scope);
        }

        private void Start() {
            engine = Python.CreateEngine();
            engine.Runtime.LoadAssembly(typeof(GameObject).Assembly);

            scope = engine.CreateScope();
            scope.SetVariable("pyConsole", pyConsole);
            scope.SetVariable("unityEvents", unityMethodsEvents);
            engine.Execute(pythonScript, scope);
        }
        
        IEnumerator GetPythonScript() {
            string filePath = System.IO.Path.Combine(Application.streamingAssetsPath, "python.py");

            string result;
            if (filePath.Contains("://") || filePath.Contains(":///")) {
                UnityEngine.Networking.UnityWebRequest www = UnityEngine.Networking.UnityWebRequest.Get(filePath);
                yield return www.SendWebRequest();
                result = www.downloadHandler.text;
            } else
                result = System.IO.File.ReadAllText(filePath);

            pythonScript = result;
        }
        */
    }
}
