using System;
using System.ComponentModel.DataAnnotations;

namespace idValidation
{
    class Program
    {
        public static int GetControlDigit(String idNumber)
        {
            int d = -1;
            try
            {
                int a = 0;
                for (int i = 0; i < 6; i++)
                {
                    a += int.Parse(idNumber[2 * i].ToString());
                }
                int b = 0;
                for (int i = 0; i < 6; i++)
                {
                    b = b * 10 + int.Parse(idNumber[2 * i + 1].ToString());
                }
                b *= 2;
                int c = 0;
                do
                {
                    c += b % 10;
                    b = b / 10;
                }
                while (b > 0);
                c += a;
                d = 10 - (c % 10);
                if (d == 10) d = 0;
            }
            catch {/*ignore*/}
            return d;
        }
        static void Main(string[] args)
        {
            String idNumber = args[0]; 
            int lastDigit = int.Parse(idNumber[idNumber.Length - 1].ToString()); 
            if(GetControlDigit(idNumber) == lastDigit){
                Console.WriteLine("Valid");
            }else{
                Console.WriteLine("Invalid");
            }

            Console.WriteLine(GetControlDigit(args[0]));
        }




    }
}
