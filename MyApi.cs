namespace MyApi;

using System;
using System.Collections.Generic;
using Global;
using static Global.EasyObject;

//public class Class1
//{
//    [DllExport]
//    public static int add2(int a, int b)
//    {
//        return a + b;
//    }
//}

static class APIHandler
{
    [DllExport]
    public static IntPtr Call(IntPtr nameAddr, IntPtr inputAddr)
    {
        JsonApiServer jsonAPI = new JsonApiServer();
        return jsonAPI.HandleNativeCall(typeof(JsonApi), nameAddr, inputAddr);
    }
}

static class JsonApi
{
    public static int add2(EasyObject args)
    {
        if (args.Count != 2) throw new Exception("add2に" + args.Count + "個の引数が指定されました");
        return Api.Add2(args[0].Cast<int>(), args[1].Cast<int>());
    }
    public static int sum(EasyObject args)
    {
        int result = 0;
        for (int i = 0; i < args.Count; i++)
        {
            result += args[i].Cast<int>();
        }
        return result;
    }
    public static int system(EasyObject args)
    {
        if (args.Count < 1) return -1;
        string exe = args[0].Cast<string>();
        List<string> cmdArgs = new List<string>();
        for (int i = 1; i < args.Count; i++)
        {
            cmdArgs.Add(args[i].Cast<string>());
        }
        return Sys.RunCommand(exe, cmdArgs.ToArray());
    }
    public static int echo(EasyObject args)
    {
        if (args.Count < 1) return -1;
        var x = args[0];
        string? title = (args.Count >= 2 ? args[1].Cast<string>() : null);
        Echo(x, title);
        return 0;
    }
    public static int log(EasyObject args)
    {
        if (args.Count < 1) return -1;
        var x = args[0];
        string? title = (args.Count >= 2 ? args[1].Cast<string>() : null);
        Log(x, title);
        return 0;
    }
}

public static class Api
{
    public static int Add2(int a, int b)
    {
        return a + b;
    }
    public static string Greeting(string name)
    {
        return $"Helloハロー© {name}";
    }
    public static string Call(string name, string input)
    {
        JsonApiServer jsonAPI = new JsonApiServer();
        return jsonAPI.HandleDotNetCall(typeof(JsonApi), name, input);
    }
}
