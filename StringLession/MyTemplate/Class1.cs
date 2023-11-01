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
            return "Здравствуйте, @{name}. Вы прописаны по адресу @{address}.".Replace("@{name}", (string)name);
        }

        
    }
}