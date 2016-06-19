using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Pi
{
    class Program
    {
        static void Main(string[] args)
        {
            bool GoodOpen = false;
            try
            {
                System.IO.FileStream fs = new System.IO.FileStream(@"pi-billion.txt", System.IO.FileMode.Open, System.IO.FileAccess.Read, FileShare.Read);
                StreamReader sr = new StreamReader(fs);
                char[] b = new char[1000001537];
                sr.ReadBlock(b, 0, 1000001537);
                GoodOpen = true;
            }
            catch (Exception)
            {
                Console.WriteLine("error opening \"pi-billion.txt\"");
            }
            
            while (GoodOpen)
            {
                Console.WriteLine("Enter the date in the format DDMMYY");
                string strRead = Console.ReadLine();
                List<char> BuffList = new List<char>();
                for (int i = 0; i < strRead.Length; i++)
                {
                    BuffList.Add(strRead[i]);
                }
                string BuffString = "";
                for (int i = 0; i < BuffList.Count; i++)
                {
                    BuffString += Convert.ToString(BuffList[i]);
                }
                decimal BuffLong = Convert.ToDecimal(BuffString);
                for (long i = 2; i < 1000001537; i++)
                {
                    string str = "";
                    for (long j = i; j < i + BuffList.Count; j++)
                    {
                        str += Convert.ToString(b[j]);
                    }
                    decimal strLong = Convert.ToDecimal(str);
                    if (strLong == BuffLong)
                    {
                        Console.WriteLine(i - 1);
                        break;
                    }
                    else if (i == 1000001536)
                    {
                        Console.WriteLine("No matches found");
                    }
                }
                System.Threading.Thread.Sleep(2000);
            }
        }
        public static Int32 AsciiBytesToInt32(byte[] bytes, int start, int length)
        {
            Int32 Temp = 0;
            Int32 Result = 0;
            Int32 j = 1;

            for (int i = start + length - 1; i >= start; i--)
            {
                Temp = ((Int32)bytes[i]) - 48;

                if (Temp < 0 || Temp > 9)
                {
                    throw new Exception("Bytes In AsciiBytesToInt32 Are Not An Int32");
                }

                Result += Temp * j;
                j *= 10;
            }

            return Result;
        }
    }
}
