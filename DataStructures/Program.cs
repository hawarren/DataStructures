using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Legacy;
using DataStructures.Practice;

namespace DataStructures
{
    class Program
    {

        static void Main(string[] args)
        {
            createHashTable();
            createHashSet();
            CheckForNoRepeatingString();
            PracticeDualQueueStackTest();
            createLinkedListQueue();
            createQueueReverser();
            createPriorityQueue();
           // printStackQueue();

           // printArrayQueue();

           // Queue<int> TestQueue1 = new Queue<int>(new int[] {1,2,3,4,5,6,7
           // });
           // reverseQueue(TestQueue1);

           // TestMinStack();
           //// TestDualStack();
           ////TestStack();

           // string testBalance = "[{adf}(adfd){asdfsad}]";
           // string testBalanceFalse = "[{}}](){}";
           // PracticeStack BalanceChecker = new();
           // Console.WriteLine(BalanceChecker.checkIfBalanced(testBalance));
           // Console.WriteLine(BalanceChecker.checkIfBalanced(testBalanceFalse));
           // //edge cases
           // Console.WriteLine(BalanceChecker.checkIfBalanced(("(")));
           // Console.WriteLine(BalanceChecker.checkIfBalanced(("(()")));
           // Console.WriteLine(BalanceChecker.checkIfBalanced((")(")));
           // Console.WriteLine(BalanceChecker.checkIfBalanced(("[)")));




           // string str = "abcd";
           // string reversed = reverseString(str);
           // string reversedNull = reverseString(null);
           // string reversedEmpty = reverseString(string.Empty);
           // Console.WriteLine(reversed);


           // TestLinkedList();



           // //test array
           // testArray();
           // //merge sort implementation
           // testMergeSort();
            Console.ReadKey();



        }

        private static void createHashTable()
        {
            PracticeHashTable practiceHashTable = new();
            practiceHashTable.mostFrequent([1,2,3,3,3,3,4 ]);
            Console.WriteLine($"The most frequent number in [1,2,3,3,3,3,4 ] is ...... {practiceHashTable.mostFrequent([1, 2, 3, 3, 3, 3, 4])}");
            practiceHashTable.put(6, "A");
            practiceHashTable.put(8, "B");
            practiceHashTable.put(11, "C");
            practiceHashTable.put(6, "A+");
            Console.WriteLine(practiceHashTable.get(6));
            practiceHashTable.put(5, "five");
            practiceHashTable.put(6, "six");
            practiceHashTable.remove(2);

            
        }

        private static void createHashSet()
        {
            HashSet<int> hashSet = new();
            int[] numbers =  { 1, 2, 3, 3, 2, 1, 4 };
            foreach (int number in numbers)
            {
                hashSet.Add(number);
            }
            Console.WriteLine(string.Join(",",hashSet));
        }

        private static void CheckForNoRepeatingString()
        {
            string testString = "a green apple";
            PracticeNonRepeatingCharacter practiceCheck = new PracticeNonRepeatingCharacter(testString);
            Console.WriteLine($"First non repeat is {practiceCheck.CheckForNonRepeat(testString)}");
            Console.WriteLine($"First non repeat is {practiceCheck.CheckForRepeat(testString)}");

            throw new NotImplementedException();
        }

        private static void PracticeDualQueueStackTest()
        {
            PracticeDualQueueStack practiceDualQueueStack = new PracticeDualQueueStack();
            practiceDualQueueStack.push(1);
            practiceDualQueueStack.push(2);
            practiceDualQueueStack.push(3);
           Console.Write($" complete queue is {practiceDualQueueStack.ToString()}");

            practiceDualQueueStack.pop();
            practiceDualQueueStack.pop();
            practiceDualQueueStack.pop();
        }

        private static void createLinkedListQueue()
        {
            PracticeLinkedListQueue practiceLinkedListQueue = new PracticeLinkedListQueue();
            practiceLinkedListQueue.enqueue(1); // O(1) since we know where the last item is
            practiceLinkedListQueue.enqueue(2); 
            practiceLinkedListQueue.enqueue(3);
            practiceLinkedListQueue.enqueue(4);
            practiceLinkedListQueue.peek(); //O(1) since we know where first item is
            practiceLinkedListQueue.dequeue(); 
            practiceLinkedListQueue.size();
        }

        private static void createQueueReverser()
        {
            PracticeQueueReverser practiceQueueReverser = new();            
            Console.WriteLine(practiceQueueReverser.ToString());
            practiceQueueReverser.reverse(3);
            Console.WriteLine(practiceQueueReverser.ToString());
        }

        private static void createPriorityQueue()
        {
            PracticePriorityQueue priorityQueue = new PracticePriorityQueue();
            priorityQueue.enqueue(5);
            priorityQueue.enqueue(3);
            priorityQueue.enqueue(6);
            priorityQueue.enqueue(1);
            priorityQueue.enqueue(4);
            priorityQueue.dequeue();

        }

        private static void printStackQueue()
        {
            StackQueue stackQueue = new();
            stackQueue.enqueue(10);
            stackQueue.enqueue(20);
            stackQueue.enqueue(30);
            stackQueue.enqueue(40);
            Console.WriteLine($"The stack contains these values: {stackQueue.ToString()}");
            stackQueue.dequeue();
            stackQueue.enqueue(50);
            Console.WriteLine($"The stack contains these values: {stackQueue.ToString()}");

        }

        private static void printArrayQueue()
        {
            ArrayQueue practiceArrayQueue = new();

            practiceArrayQueue.enqueue(10);
            practiceArrayQueue.enqueue(20);
            practiceArrayQueue.enqueue(30);
            
            Console.WriteLine($"Removing {practiceArrayQueue.dequeue()}");
            Console.WriteLine($"Removing {practiceArrayQueue.dequeue()}");
            practiceArrayQueue.enqueue(40);
            practiceArrayQueue.enqueue(50);
            Console.WriteLine(practiceArrayQueue.ToString());
            practiceArrayQueue.enqueue(60);
            Console.WriteLine(practiceArrayQueue.ToString());
            practiceArrayQueue.enqueue(2);
            practiceArrayQueue.enqueue(3);
            Console.WriteLine(practiceArrayQueue.ToString());
            practiceArrayQueue.dequeue();
            practiceArrayQueue.enqueue(5);
            practiceArrayQueue.enqueue(4);
            Console.WriteLine(practiceArrayQueue.ToString());

        }

        private static void reverseQueue(Queue<int> queue)
        {
            var tempStack = new Stack<int>();
            while (queue.Count() > 0)
            {
                tempStack.Push(queue.Dequeue());
            }
            while (tempStack.Count > 0)
            {
                queue.Enqueue(tempStack.Pop());
            }
            Console.WriteLine(string.Join(',', queue.ToArray()));


        }


        private static void TestMinStack()
        {
            PracticeMinStack practiceMinStack = new();
            practiceMinStack.push(5);
            practiceMinStack.push(2);
            practiceMinStack.push(10);
            practiceMinStack.push(1);
            practiceMinStack.min();
            practiceMinStack.pop();
            practiceMinStack.min();
        }
        private static void TestDualStack()
        {


            PracticeDualStack practiceStack = new();
            Console.WriteLine($"Is stack empty? {practiceStack.isEmpty1()}");
            Console.WriteLine($"Is stack empty? {practiceStack.isEmpty2()}");
            practiceStack.push1(10);
            practiceStack.push2(20);
            practiceStack.push1(30);
            practiceStack.push2(40);
            practiceStack.printStack();
            Console.WriteLine($" Peeking at {practiceStack.peek1()}");
            Console.WriteLine($"Popped {practiceStack.pop1()} from the stack");
            Console.WriteLine($"Now Is stack empty? {practiceStack.isEmpty1()}");
            practiceStack.printStack();
            practiceStack.pop1();
            practiceStack.pop2();
            Console.WriteLine($"Now Is stack empty? {practiceStack.isEmpty1()}");
            Console.WriteLine($"Now Is stack empty? {practiceStack.isEmpty2()}");
            practiceStack.pop1();


        }

        private static void TestStack()
        {
            Stack<int> classicStack = new();
            classicStack.Push(10);
            classicStack.Push(20);
            classicStack.Push(30);
            Console.WriteLine(string.Join(",", classicStack));
            classicStack.ToString();

            PracticeStack practiceStack = new();
            Console.WriteLine($"Is stack empty? {practiceStack.isEmpty()}");
            practiceStack.push(10);
            practiceStack.push(20);
            practiceStack.push(30);
            practiceStack.printStack();
            Console.WriteLine($" Peeking at {practiceStack.peek()}");
            Console.WriteLine($"Popped {practiceStack.pop()} from the stack");
            Console.WriteLine($"Now Is stack empty? {practiceStack.isEmpty()}");
            practiceStack.printStack();
            practiceStack.pop();
            practiceStack.pop();
            practiceStack.pop();
            Console.WriteLine($"Now Is stack empty? {practiceStack.isEmpty()}");




        }

        private static void TestLinkedList()
        {
            PracticeLinkedList reverseList = new PracticeLinkedList();
            reverseList.addLast(2);
            reverseList.addLast(4);
            reverseList.addLast(6);
            reverseList.addLast(8);
            reverseList.addLast(10);
            Console.WriteLine($"Before reverse: {string.Join(",", reverseList.ToArray())}");
            reverseList.reverse();
            Console.WriteLine($"After reverse: {string.Join(",", reverseList.ToArray())}");

            reverseList.hasLoop();
            reverseList.AddLoop();
            reverseList.hasLoop();
            reverseList.RemoveLoop();
            Console.WriteLine($"After adding and removing loop: {string.Join(",", reverseList.ToArray())}");


            Console.WriteLine(reverseList.getKthFromTheEnd(4));
            //Console.WriteLine(reverseList.getKthFromTheEnd(6));
            //Console.WriteLine(reverseList.getKthFromTheEnd(0));
            Console.WriteLine(reverseList.getKthFromTheEnd(1));
            Console.WriteLine($" The middle is {string.Join(",", reverseList.printMiddle())}");

            reverseList.addLast(10);
            Console.WriteLine($" The middle is {string.Join(",", reverseList.printMiddle())}");

            PracticeLinkedList test1 = new([1]);
            test1.AddLoop();
            bool ans1 = test1.hasLoop();

            Console.WriteLine($" test1 has loop? {ans1}");
            PracticeLinkedList test2 = new([]);
            test2.AddLoop();
            bool ans2 = test2.hasLoop();
            Console.WriteLine($" test2 has loop? {ans2}");
            PracticeLinkedList test3 = new([1, 2]);
            test3.AddLoop();
            bool ans3 = test3.hasLoop();
            Console.WriteLine($" test1 has loop? {ans3}");

            LinkedList<string> test = new LinkedList<string>();

            PracticeLinkedList practiceLinkedList = new PracticeLinkedList();
            Console.WriteLine(practiceLinkedList.size());
            practiceLinkedList.addFirst(76);
            Console.WriteLine(practiceLinkedList.size());
            practiceLinkedList.deleteFirst();
            Console.WriteLine(practiceLinkedList.size());

            practiceLinkedList.addFirst(81);
            Console.WriteLine(practiceLinkedList.size());
            practiceLinkedList.deleteLast();
            Console.WriteLine(practiceLinkedList.size());

            practiceLinkedList.addFirst(8);
            Console.WriteLine(practiceLinkedList.size());
            practiceLinkedList.addLast(3);
            Console.WriteLine(practiceLinkedList.size());
            practiceLinkedList.addLast(4);
            Console.WriteLine(practiceLinkedList.size());
            practiceLinkedList.addLast(5);
            Console.WriteLine(practiceLinkedList.size());
            practiceLinkedList.deleteFirst();
            Console.WriteLine(practiceLinkedList.size());
            practiceLinkedList.deleteLast();
            Console.WriteLine(practiceLinkedList.size());

            Console.WriteLine(practiceLinkedList.contains(4));
            Console.WriteLine(practiceLinkedList.indexOf(4));
            Console.WriteLine(practiceLinkedList.indexOf(57));
            Console.WriteLine(string.Join(",", practiceLinkedList.ToArray()));

            Console.ReadKey();
        }

        static void testArray()
        {
            //testing custom array
            PracticeArray numbers = new PracticeArray(3);
            numbers.insert(10);
            numbers.insert(200);
            numbers.insert(30);
            numbers.insert(40);
            numbers.print();

            numbers.insert(50);
            numbers.removeAt(3);
            numbers.insert(60);

            Console.WriteLine("Index of 30 is {0} ", numbers.IndexOf(30));
            Console.WriteLine("Index of 999 is {0} ", numbers.IndexOf(999));
            numbers.print();
            Console.WriteLine("Max value: {0}", numbers.max());

            Console.WriteLine("getting common items");
            int[] sampleArray = new int[] { 55, 60, 200 };
            int[] commonItems = numbers.intersect(sampleArray);
            Console.WriteLine(string.Join(", ", commonItems));
            numbers.reverse();
            numbers.print();

            numbers.InsertAt(99, 2);
            numbers.InsertAt(7681, 0);
            numbers.InsertAt(555, 6);


            // Console.ReadKey();

            //End testing custom array
        }

        public static void reverse(Queue<int> queue)
        {//reverse the queue using only
         //add (enqueue)
         //remove (dequeue)
         //isEmpty (.count ==0)
         //Solution:  put queue in array the size of the queue. enqueue from the back of th array to the front
            int[] tempQueue = new int[queue.Count];
            while (queue.Count != 0)
            {
                tempQueue[queue.Count - 1] = queue.Dequeue(); //dequeue from front, but replace in back of array

            }
            foreach (int item in tempQueue)
            {
                queue.Enqueue(item);
            }

        }
        public static void reverse2(Queue<int> queue)
        {//reverse the queue using only
         //add (enqueue)
         //remove (dequeue)
         //isEmpty (.count ==0)
         //Solution:  put queue in array the size of the queue. enqueue from the back of th array to the front
            Stack<int> stack = new Stack<int>();

            while (queue.Count != 0)
            {
                stack.Push(queue.Dequeue()); //dequeue from front, but replace in back of array

            }
            while (stack.Count != 0)
            {
                queue.Enqueue(stack.Pop());
            }

        }
        public static void testMergeSort()
        {
            //Testing mergesort reimplementation
            Console.WriteLine("\r\nNow testing a mergesorted array");
            MergeSortArray myMergeSort = new MergeSortArray();
            int[] testArray = { 9, 7, 2, 5, 4, 3, 6, 1, 8, 7, 5, 5, 3, 5, 8, 11 };
            Console.WriteLine("\r\nStarting node list is");
            Console.ReadKey();
            for (int i = 0; i < testArray.Length; i++)
            {
                Console.WriteLine(testArray[i]);

            }
            Console.WriteLine("\r\nSorting the array now");
            myMergeSort.MergeSort(testArray, 0, testArray.Length - 1);
            Console.WriteLine("\r\nThe newly merge sorted array is");
            for (int i = 0; i < testArray.Length; i++)
            {
                Console.WriteLine(testArray[i]);

            }

            //sort testArray and print it out
            Array.Sort(testArray);
            Console.WriteLine("\r\nThe sorted array is");
            for (int i = 0; i < testArray.Length; i++)
            {
                Console.WriteLine(testArray[i]);
            }
            Console.ReadKey();

        }

        private static string reverseString(string str)
        {
            Stack<char> stringStack = new();
            StringBuilder reversedString = new();
            if (String.IsNullOrEmpty(str))
                return "";

            foreach (var item in str)
            {
                stringStack.Push(item);
            }

            while (stringStack.Count > 0)
            {
                reversedString.Append(stringStack.Pop());
            }
            return reversedString.ToString();
        }
        private static void legacyTests()
        {




            //Populating binary search tree
            int[] myBSTArray = { 10, 5, 15, 6, 1, 8, 12, 18, 17 };
            hwTree myBSTree = new hwTree(myBSTArray);
            hwTree hwBSTree = new hwTree();
            hwBSTree.addNode(7);
            hwBSTree.addNode(4);
            hwBSTree.addNode(9);
            hwBSTree.addNode(1);
            hwBSTree.addNode(6);
            hwBSTree.addNode(8);
            hwBSTree.addNode(10);

            hwTree hwBSTClone = new hwTree();
            hwBSTClone.addNode(10);
            hwBSTClone.addNode(7);
            hwBSTClone.addNode(4);
            hwBSTClone.addNode(9);
            hwBSTClone.addNode(1);
            hwBSTClone.addNode(6);
            hwBSTClone.addNode(8);

            Console.WriteLine("Is 10 in the tree? {0}", hwBSTree.find(10));
            hwBSTree.traversePreOrder();
            Console.WriteLine("Height is {0}", hwBSTree.height());
            Console.WriteLine("Are the 2 trees equal? {0}", hwBSTree.equals(hwBSTClone.root));
            Console.ReadKey();

            //priority queue exercise 12
            hwPQueue myOwnPQueue = new hwPQueue(5);
            myOwnPQueue.enqueue(25);
            myOwnPQueue.enqueue(10);
            myOwnPQueue.enqueue(20);
            myOwnPQueue.enqueue(5);
            myOwnPQueue.enqueue(15);
            myOwnPQueue.enqueue(30); //should fail
            myOwnPQueue.dequeue(); //remove 25

            Console.WriteLine("Now printing the queue, which should have 5,10,15, and 20 \r\n");
            while (myOwnPQueue.isEmpty() == false)
            {
                Console.WriteLine(myOwnPQueue.dequeue());
            }
            Console.ReadKey();


            //my own queue implementation (exercise 6)
            hwQueue myOwnQueue = new hwQueue(5);
            myOwnQueue.enqueue(5);
            myOwnQueue.enqueue(10);
            myOwnQueue.enqueue(15);
            myOwnQueue.enqueue(20);
            myOwnQueue.enqueue(25);
            myOwnQueue.enqueue(30); //should fail
            myOwnQueue.dequeue(); //remove 25

            Console.WriteLine("Now printing the queue, which should have 5,10,15, and 20 \r\n");
            while (myOwnQueue.isEmpty() == false)
            {
                Console.WriteLine(myOwnQueue.dequeue());
            }
            Console.ReadKey();

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);
            queue.Enqueue(40);
            reverse2(queue);
            Console.WriteLine("The reversed queue is ");
            while (queue.Count != 0)
            {
                Console.Write(" {0}, ", queue.Dequeue());
            }
            Console.ReadKey();
            /*stack implementation*/
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
            Console.WriteLine("Does this list have a loop: {0}", list.hasLoop());
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






            //LinkedList myTestList = new LinkedList();
            //myTestList.addNode("13");
            //myTestList.addNode("34");


            //myTestList.printNodes();

            //Console.WriteLine("\r\nPress any key to see an example node added");
            //Console.ReadKey();
            //myTestList.addHead("\r\nFirst in Line!");

            //myTestList.printNodes();
            //Console.ReadKey();
            bool keepRunning = true;

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

