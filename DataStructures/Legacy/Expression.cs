using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Legacy
{
    class Expression
    {
        public bool isBalanced(string input)
        {
            //push each left parentheses on the stack. iterate through the expression and when you find a matching right, pop the left off.
            //todo refactor the checks into booleans isMatching
            Stack<char> stack = new Stack<char>();
            foreach (var item in input.ToCharArray())
            {
                if (item == '(' ||
                    item == '<' ||
                    item == '{' ||
                        item == '['
                    )
                {
                    stack.Push(item);
                }

                if (item == ')' ||
                    item == '>' ||
                    item == '}' ||
                        item == ']'
                    )
                {
                    if (stack.Count == 0)
                    { return false; } //stack is empty but we have a right bracket


                    var top = stack.Pop();
                    if (
                        item == ')' && top != '(' ||
                        item == '>' && top != '<' ||
                        item == '}' && top != '{' ||
                        item == ']' && top != '['
                        )
                        return false; //don't just blindly pop. make sure the top symbol on the stack matches it's left symbol
                }
            }
            return stack.Count == 0 ? true : false;

        }

    }
}
