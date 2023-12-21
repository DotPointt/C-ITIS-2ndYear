public static class Program
{
    static async Task Main()
    {
        AsyncKeywordMethod();
        Console.WriteLine("after main await");
    }

    static async Task AsyncKeywordMethod()
    {
        Console.WriteLine("AsyncKeywordMethodBefore");
        await AsyncKeywordMethod2();
        // Console.WriteLine(res);
        Console.WriteLine("AsyncKeywordMethodAfter");
    }

    static async Task<int> AsyncKeywordMethod2()
    {
        Console.WriteLine("AsyncKeywordMethod2Before");
        var res = await AsyncMethod();
        return res;
        Console.WriteLine("AsyncKeywordMethod2After");
    }

    static Task<int> AsyncMethod()
    {
        Console.WriteLine("AsyncMethod");
        return Task.Run(() => 3);
    }
}