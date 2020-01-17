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

            HWArray myDynamicArray = new HWArray();
            myDynamicArray.insert(1);
            myDynamicArray.insert(37);
            myDynamicArray.insert(5);
            myDynamicArray.insert(25);
            myDynamicArray.insert(7);

            Console.WriteLine("myDynamicArray's values are ");

            myDynamicArray.print();
            myDynamicArray.indexOf(25);
            myDynamicArray.removeAt(2);

            Console.WriteLine("myDynamicArray's value is ");
            myDynamicArray.print();
            myDynamicArray.indexOf(25);
            Console.WriteLine("The largest value in the array is {0}", myDynamicArray.max());
            Console.ReadKey();
            HWArray otherArray = new HWArray(new int[] { 7, 18, 9, 6, 8 });
            Console.WriteLine("Now printing the second array");
            otherArray.print();
            Console.WriteLine("press any key to see the common items in the array");
                       Console.ReadKey();
            Console.WriteLine("the common items in the array are... ");
            myDynamicArray.intersect(otherArray).print();

            hwMergeSort myMergelist = new hwMergeSort();
            int[] testArray = { 9,7, 2, 5, 4, 3, 6, 1, 8 };
            Console.WriteLine("Starting node list is");
                for (int i = 0; i < testArray.Length; i++)
            {
                Console.WriteLine(testArray[i]);

            }
            Console.WriteLine("Sorting the array now");
            myMergelist.MergeSort(testArray, 0, testArray.Length - 1);
            Console.WriteLine("The newly merge sorted array is");
                for (int i = 0; i < testArray.Length; i++)
            {
                Console.WriteLine(testArray[i]);

            }



            LinkedList myTestList = new LinkedList();
            myTestList.addNode("13");
            myTestList.addNode("34");


            myTestList.printNodes();

            Console.WriteLine("Press any key to see an example node added");
            Console.ReadKey();
            myTestList.addHead("First in Line!");

            myTestList.printNodes();
            //Console.ReadKey();
            bool keepRunning = true;

            while (keepRunning)
            {
                Console.WriteLine("Now add your own array. Type the name or the number 'printNodes', 'addnode'");
                string response = Console.ReadLine().ToLower();
                if (response.ToLower().Equals("q"))
                {
                    keepRunning = false;
                }
                int number;
                switch (response.ToLower())
                {
                    case "1":
                    case "addnode" :
                        Console.WriteLine("enter a number to add");
                        response = Console.ReadLine();
                        //TODO: actually pass in numbers not strings
                        bool isGoodInput = int.TryParse(response, out number);
                        myTestList.addNode(response);
                        Console.WriteLine("You have added {0} to the linkedlist", response);
                        myTestList.printNodes();
                        break;
                    case "2":
                    case "printnodes":
                        myTestList.printNodes();
                        break;

                    //case "3":
                    //case "removenode":

                    //    myTestList.removeNode();


                }
            }


        }

    }
}

