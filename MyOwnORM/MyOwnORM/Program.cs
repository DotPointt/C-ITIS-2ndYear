//using System.ComponentModel

using System.Data;

public class Program
{
    void Main()
    {

    }

    public class Database
    {
        public IDbConnection _connection = null;
        public IDbCommand _cmd = null;

        public Database()
        {

        }
    }
}













//using System.ComponentModel;

//namespace MyDataContext
//{
//    public interface MYDataCOntext
//    {
//        bool Add<T>(T);
//        bool Update<T>(T);//можно сделать int id,T t

//        bool Delete<Task>(id);

//        List<T> Select<T>();

//        T SelectById<T>();
//    }
//}
