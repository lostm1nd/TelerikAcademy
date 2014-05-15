//Write a program to check if in a given
//expression the brackets are put correctly.

using System;
using System.Collections.Generic;
using System.Text;

class CheckBrackets
{
    static void ValidateParentheses(string str)
    {
        Stack<char> brackets = new Stack<char>();
        bool correctExpression = true;
        //push opening bracket onto stack then when a closing bracket is found check if the stack contains
        //the corresponding opening bracket; if not the expression must be wrong
        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] == '(')
            {
                brackets.Push('(');
            }
            else if (str[i] == ')')
            {
                if (brackets.Count > 0 && brackets.Peek() == '(')
                {
                    brackets.Pop();
                }
                else
                {
                    correctExpression = false;
                    break;
                }
            }
        }

        Console.WriteLine("The expression is {0}", correctExpression ? "correct!" : "incorrect!");
    }

    static void Main()
    {
        Console.WriteLine("Enter an expression that contains at lease one argument in parentheses:");
        string expression = Console.ReadLine();
        ValidateParentheses(expression);
    }
}
