using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList myTestList = new LinkedList();
            myTestList.addNode("13");
            myTestList.addNode("34");


            myTestList.printNodes();


            Console.ReadKey();
            myTestList.addHead("First in Line!");
            myTestList.printNodes();
                Console.ReadKey();
        }
    }
}
