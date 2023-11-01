using System.Reflection;
using MyTemplate;

class Program
{
    static void Main()
    {
        Console.WriteLine( Mapper.Method1("leisan"));



    }

    class Student
    {
        public string name { get; set; }
        public string age { get; set; }
    }

    //"Здравствуйте @{name}, вы отчислены"
    //@name =  Лейсан
    //student
    //    F
    //    I
    //    O
    //    age
    //    temperature
    string GetMessage(string name)
    {
        return "Здравствуйте, @{name}, вы отчислены";
    }

    //2
    //"Здравствуйте, @{name}. Вы прописаны по адресу @{address}."
    //
    string method(object obj)
    {
        return "Здравствуйте, @{name}. Вы прописаны по адресу @{address}.";
    }


    //3
    //"Здравсвуйте, @{name}
    //@if(temperature >37)"
    //@then {Выздоравливайте}
    //@else {Прогульщица}
    //string(object obj)
    //


    //4)
    //"Здравсвтуйте студенты группы @{group}
    //    Ваши баллы по ОРИС:
    //    @for(item in students){
    //      @{item.FIO} баллы: @{item balls} "
    //
    //  
    //     string(object obj) 


    //      Tabel
    //      string group
    //      List<Student> students
    //      

    //Student : FIO, balls
    //



}