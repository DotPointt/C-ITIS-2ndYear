namespace MyTemplate
{
    public static class Mapper
    {
        public static string Method1(string name)
        {
            return "Здравсвтуйте @{name}, вы отчислены".Replace("@{name}", name);
        }

        public static string Method2(object obj)
        {
            var name = obj.GetType().GetProperty("name").GetValue(obj);
            var address = obj.GetType().GetProperty("address").GetValue(obj);
            return "Здравствуйте, @{name}. Вы прописаны по адресу @{address}.".Replace("@{name}", (string)name).Replace("@{address}", (string)address);
        }

        //3
        //"Здравсвуйте, @{name}
        //@if(temperature >37)"
        //@then {Выздоравливайте}
        //@else {Прогульщица}
        //string(object obj)
        public static void Method3(object obj)
        {
            var str = "Здравсвуйте, @{name} @if(temperature >37) @then{Выздоравливайте} @else{Прогульщица} string(object obj)";
            var name = obj.GetType().GetProperty("name").GetValue(obj);
            var temperature = obj.GetType().GetProperty("temperature");

            var condition = str.Split("@if(");
            Console.WriteLine(condition[1]);
        }
    }
}