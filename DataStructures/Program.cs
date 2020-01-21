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
            //check brackets
            string str = "(1 + 1) )";

            Expression exp = new Expression();
            Console.WriteLine(exp.isBalanced(str));
            Console.ReadKey();















            Stack demoStack = new Stack();
            Console.WriteLine("Now adding 'abcd' to the stack");
            demoStack.push("abcd");
            Console.WriteLine("The reversed string is {0}", demoStack.pop());
            StringReverser tryIt = new StringReverser("efgh");
            Console.WriteLine("The reverse of efgh is {0}", tryIt.newString);

            Console.ReadKey();
            //linkedlist
            var list = new hwLinkedList();
            list.addFirst(8);
            list.addLast(16);
            list.addFirst(24);
            list.printNodes();
            Console.ReadKey();
            list.indexOf(16);
            list.indexOf(24);
            list.indexOf(8);
            list.indexOf(9);
            list.deleteFirst();
            list.deleteLast();
            Console.ReadKey();
            list.addLast(32);
            list.addLast(64);
            list.addLast(128);
            list.addLast(256);
            list.printNodes();
            Console.WriteLine("\r\n Now to reverse the nodes and print");
            Console.ReadKey();
            list.reverse();
            list.printNodes();
            list.getKthFromtheEnd(4);
            list.PrintMiddle();
            list.createLoop(3);
            Console.ReadKey();
            Console.WriteLine("Does this list have a loop: {0}",list.hasLoop());
            Console.ReadKey();
            Console.WriteLine("\r\n Next up are dynamic array tests");
            Console.ReadKey();

            HWArray myDynamicArray = new HWArray();
            myDynamicArray.insert(1);
            myDynamicArray.insert(37);
            myDynamicArray.insert(5);
            myDynamicArray.insert(25);
            myDynamicArray.insert(7);
            myDynamicArray.insert(41);
            myDynamicArray.insert(52);
            myDynamicArray.insert(99);
            myDynamicArray.insert(8);
            myDynamicArray.insert(6);

            Console.WriteLine("\r\nmyDynamicArray's values are ");

            myDynamicArray.print();
            Console.Write("The Index of {0} is {1}", 25, myDynamicArray.indexOf(25));
            Console.Write("\r\n Now removing the 3rd item (aka index 2)...");
            myDynamicArray.removeAt(2);

            Console.Write("\r\nmyDynamicArray's value is ");
            myDynamicArray.print();
            myDynamicArray.indexOf(25);
            Console.WriteLine("\r\nThe largest value in the array is {0}", myDynamicArray.max());
            Console.ReadKey();
            HWArray otherArray = new HWArray(new int[] { 7, 18, 9, 6, 8 });
            Console.WriteLine("\r\nNow printing the second array...");
            otherArray.print();
            Console.WriteLine(" (press any key to see the common items in the array)");
            Console.ReadKey();
            Console.Write("\r\nthe common items in the array are... ");
            myDynamicArray.intersect(otherArray).print();
            Console.ReadKey();
            Console.Write("\r\nNow reversing the array... ");
            myDynamicArray.reverse();
            myDynamicArray.insertAt(38, 3);

            myDynamicArray.print();




            Console.ReadKey();
            Console.WriteLine("\r\nNow testing a mergesorted array");
            hwMergeSort myMergelist = new hwMergeSort();
            int[] testArray = { 9, 7, 2, 5, 4, 3, 6, 1, 8 };
            Console.WriteLine("\r\nStarting node list is");
            for (int i = 0; i < testArray.Length; i++)
            {
                Console.WriteLine(testArray[i]);

            }
            Console.WriteLine("\r\nSorting the array now");
            myMergelist.MergeSort(testArray, 0, testArray.Length - 1);
            Console.WriteLine("\r\nThe newly merge sorted array is");
            for (int i = 0; i < testArray.Length; i++)
            {
                Console.WriteLine(testArray[i]);

            }




        //LinkedList myTestList = new LinkedList();
        //myTestList.addNode("13");
        //myTestList.addNode("34");


        //myTestList.printNodes();

        //Console.WriteLine("\r\nPress any key to see an example node added");
        //Console.ReadKey();
        //myTestList.addHead("\r\nFirst in Line!");

        //myTestList.printNodes();
        ////Console.ReadKey();
        //bool keepRunning = true;

        //while (keepRunning)
        //{
        //    Console.WriteLine("\r\nNow add your own array. Type the name or the number 'printNodes', 'addnode', 'myArrayTest', (press 'q' to quit");
        //    string response = Console.ReadLine().ToLower();
        //    if (response.ToLower().Equals("q"))
        //    {
        //        keepRunning = false;
        //    }
        //    int number;
        //    switch (response.ToLower())
        //    {
        //        case "1":
        //        case "addnode":
        //            Console.WriteLine("enter a number to add");
        //            response = Console.ReadLine();
        //            //TODO: actually pass in numbers not strings
        //            bool isGoodInput = int.TryParse(response, out number);
        //            myTestList.addNode(response);
        //            Console.WriteLine("You have added {0} to the linkedlist", response);
        //            myTestList.printNodes();
        //            break;
        //        case "2":
        //        case "printnodes":
        //            myTestList.printNodes();
        //            break;
        //            //                case "myarraytest":
        //            //    myArrayTest();
        //            //break;

        //            //case "3":
        //            //case "removenode":

        //            //    myTestList.removeNode();


        //    }



        //}

    }
}
}

