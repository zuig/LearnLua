using System;
using LuaInterface;

public class DemoWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("Echo", Echo),
			new LuaMethod("Method", Method),
			new LuaMethod("New", _CreateDemo),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
		};

		LuaScriptMgr.RegisterLib(L, "Demo", typeof(Demo), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateDemo(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			Demo obj = new Demo();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Demo.New");
		}

		return 0;
	}

	static Type classType = typeof(Demo);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Echo(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		Demo.Echo();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Method(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Demo obj = (Demo)LuaScriptMgr.GetNetObjectSelf(L, 1, "Demo");
		obj.Method();
		return 0;
	}
}

