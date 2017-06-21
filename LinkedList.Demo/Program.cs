using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkedList;
namespace LinkedList.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            LisT<object> list = new LisT<object>("MyList");
            char dollar = '$';
            double money = 5.99;
            string name = "Joe";
            list.Drop(money);
            list.Raise(dollar);
            list.Drop(name);
            //list.ForEach(item => Console.WriteLine(item));
            for(int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
        }
    }
}
