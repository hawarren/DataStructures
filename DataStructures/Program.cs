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
            bool keepRunning = true;

            while (keepRunning)
            {
                Console.WriteLine("Now add your own array. 'printNodes', 'addanode'");
                string response = Console.ReadLine().ToLower();
                if (response.ToLower().Equals("q"))
                {
                    keepRunning = false;
                }
                int number;
                switch (response.ToLower())
                {
                    case "addnode":
                        Console.WriteLine("enter a number to add");
                        response = Console.ReadLine();
                        //TODO: actually pass in numbers not strings
                        bool isGoodInput = int.TryParse(response, out number);
                        myTestList.addNode(response);
                        Console.WriteLine("You have added {0} to the linkedlist", response);
                        myTestList.printNodes();
                        break;
                    case "printNodes":
                        myTestList.printNodes();
                        break;

                }
            }


        }

    }
}

