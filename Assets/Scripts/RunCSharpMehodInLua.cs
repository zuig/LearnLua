using UnityEngine;
using System.Collections;
using LuaInterface;

public class RunCSharpMehodInLua : MonoBehaviour
{
    string source = @"
        Demo = luanet.import_type('Demo')
        Demo.Echo()
        demo = Demo()
        demo:Method()
    ";

    // Use this for initialization
    void Start()
    {
        LuaScriptMgr luaMgr = new LuaScriptMgr();
        luaMgr.Start();
        LuaState l = luaMgr.lua;
        l.DoString(source);
    }
}
