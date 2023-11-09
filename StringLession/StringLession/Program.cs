using System.Reflection;
using System;
using MyTemplate;


class Program
{
    static void Main()
    {
        //Console.WriteLine( Mapper.Method1("leisan"));
        //Console.WriteLine(Mapper.Method2(new Student()
        //{
        //    name = "les",
        //    address = "Fuchika 30"
        //})) ;

        var stud = new Student(){
            name = "Venera",
            address = "Kadirovo"
        };
        
        //System.Console.WriteLine(Mapper.Method2(stud));
        Mapper.Method3(new Student());

    }


    //3
    //"Здравсвуйте, @{name}
    //@if(temperature >37)"
    //@then {Выздоравливайте}
    //@else {Прогульщица}
    //string(object obj)
    


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