using System;
using System.IO;
using System.Collections;

namespace BFinterpreter
{
    class Program
    {

        static int FindLast(int from , string s)
        {
            Stack st = new Stack();
            st.Push('[');
            
            for(int i = from; i <s.Length; i++)
            {

                if(s[i] == ']')
                {
                    st.Pop();
                }
                if (s[i] == '[')
                {
                    st.Push(']');
                }
                if(st.Count == 0)
                {
                    return i;
                }
               
                
            }
            return -1;


        }

        static void Main()
        {
            Console.Title = "BrainF**K Interpreter";
           
            Console.WriteLine("Enter Path:");
            string filePath = @"" + Console.ReadLine(); 
           

            //Read file
            string fileContent ;
            try
            {
                fileContent = System.IO.File.ReadAllText(filePath);
            }
            catch
            {
                Console.WriteLine("Input file does not exsist");
                Console.ReadKey();
                return;
            }

            Console.Clear();
            Console.Title = "Output";
            Intepreter(fileContent);
            Console.ReadKey();


        }
        static void Intepreter(string FileContent)
        {
            Stack startPos = new Stack();
            long length = 10000000;
            char[] arr = new char[length];
            long  pointer = length/2;

            for (int i = 0; i < FileContent.Length; i++)
            {
            
                char c = FileContent[i];

                
                if (c == '[')
                {
                    if (arr[pointer] == 0)
                    {
                        i = FindLast(i + 1, FileContent);
                        if (i == -1)
                        {
                            Console.WriteLine("File Has some Error:");
                            return;
                        }
                        continue;
                    }
                    else
                    {
                        startPos.Push(i-1);
                        continue;
                    }
                }
                if(c == ']')
                {
                    i = Convert.ToInt32( startPos.Pop());
                    continue;
                }

                //to check every line
                switch (c)
                {
                    case '>':
                        pointer++;
                        break;
                    case '<':
                        pointer--;
                        break; 
                    case '+':
                        arr[pointer]++;
                        break; 
                    case '-':
                        try
                        {
                            arr[pointer]--;
                        }
                        catch
                        {
                            Console.WriteLine("File Has some Error:");
                            return;
                        }
                        break; 
                    case ',':
                        Console.Write("Input:");
                        try
                        {
                            arr[pointer] = Convert.ToChar(Console.ReadLine().Trim().Substring(0, 1));
                        }
                        catch
                        {
                            Console.Write("Enter Proper input");
                            i--;
                            continue;
                        }
                         break; 
                    case '.':
                        Console.Write((arr[pointer]));
                        break; 
                    default:
                        
                        break;

                }


            }


        }
    }
    
}

