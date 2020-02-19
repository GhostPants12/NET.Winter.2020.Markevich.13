using System;
using System.Collections.Generic;

namespace ParenthesesTask
{
    public class ParenthesesChecker
    {
        private readonly Dictionary<char, char> parenthesesCheckDictionary;

        public ParenthesesChecker()
            : this(new Dictionary<char, char>
        {
            { '[', ']' },
            { '(', ')' },
            { '{', '}' },
        })
        {
        }

        public ParenthesesChecker(Dictionary<char, char> dictionary)
        {
            this.parenthesesCheckDictionary = dictionary;
        }

        public bool CheckParentheses(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException($"{nameof(text)} is null.");
            }

            var parenthesesStack = new Stack<char>();
            foreach (char symbol in text)
            {
                foreach (char key in this.parenthesesCheckDictionary.Keys)
                {
                    if (symbol == key)
                    {
                        parenthesesStack.Push(symbol);
                    }
                }

                foreach (char value in this.parenthesesCheckDictionary.Values)
                {
                    if (symbol == value)
                    {
                        if (parenthesesStack.Count == 0)
                        {
                            return false;
                        }

                        if (this.parenthesesCheckDictionary[parenthesesStack.Pop()] != value)
                        {
                            return false;
                        }
                    }
                }
            }

            return parenthesesStack.Count == 0;
        }
    }
}
