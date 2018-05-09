using System;
using System.Numerics;//for Big Integer Support
namespace floatBinAdd
{
    class Program
    {
    static int Main(string[] args)
        {
            BigInteger longSum;
            Console.WriteLine("Enter numbers");
            double num1 = double.Parse(Console.ReadLine());
            double num2 = double.Parse(Console.ReadLine());
            int k=8;
            Program p = new Program();
           // Console.WriteLine("The binary versions of {0} and {1} are:", num1, num2 );
            string str1 = p.decimalToBinary(num1, k);
            string str2 = p.decimalToBinary(num2, k);
          //  Console.WriteLine(str1);
          //  Console.WriteLine(str2);
            Console.WriteLine("The Binary Sum of {0} and {1} is:",num1, num2);

            //ulong longSum;
            String Sum;
            if ((num1 > 0) && (num2 > 0))
            {
                Sum = p.addition(str1, str2);
            }
            else if ((num1 > 0) && (num2 < 0))
            {
                if (Math.Abs(num2) > num1)
                {
                    Sum = p.subtraction(str2, str1);
                }
                else
                {
                    Sum = p.subtraction(str1, str2);
                }
            }
            else if ((num1 < 0) && (num2 > 0))
            {
                if (Math.Abs(num1) > num2)
                {
                    Sum = p.subtraction(str1, str2);
                }
                else
                {
                    Sum = p.subtraction(str2, str1);
                }
            }
            else
            {
                Sum = p.addition(str1, str2);
            }
            int size = Sum.Length -1;
            String intFracBin = "";
            for (int i = size; i >= 0; i--)
            {                                           //Appending Floating Point
                intFracBin = Sum[i] + intFracBin;       //Binary number with both integral and fractional parts
                if (i == ((size) - (k - 1)))
                    intFracBin = '.' + intFracBin;
            }
            if ((num1 + num2) < 0)
            {
            Console.WriteLine("-"+intFracBin);
            }
            else
            {
                Console.WriteLine(intFracBin);
            }
           // Console.WriteLine("The integer version of the sum of {0} and {1} is:",num1, num2);
            longSum = BigInteger.Parse(Sum);
           // Console.WriteLine(longSum);
            double Decimal = p.binaryToDecimal(longSum,k);
            Console.WriteLine("The decimal version of the sum of {0} and {1} is:",num1, num2);
            if((num1 + num2) < 0)
            {
            Console.WriteLine("-"+Decimal);
            }
            else
            {
                Console.WriteLine(Decimal);
            }
            Console.ReadKey();
            return 0;
        }
    string decimalToBinary(double num, int k_prec)
        {
            string Integ = "";
            string Frac = "";
            string binary = "";
            int Integral = (int)Math.Abs(num);
            double fractional = Math.Abs(num) - Integral;
            while(Integral>0)
            {

                int rem = Integral % 2;
                Integ=rem+Integ;
                Integral = Integral / 2;
            }
           // binary = binary + '.';
            while(k_prec>0)
            {

                fractional = fractional * 2;
                int bit = (int)fractional;
                if(bit == 1)
                {

                    fractional = fractional - bit;
                    Frac = Frac + 1;
                }
                else
                Frac = Frac + 0;
                k_prec--;
            }
            binary = Integ + Frac;
            return binary;
        }
    string addition(string first, string second)
         {
            string result = "";
            int length = makeEqualLength(ref first, ref second);
            int carry = 0;
 
    
         for (int i = length-1 ; i >= 0 ; i--)
            {
                int firstBit = first[i] - '0';
                int secondBit = second[i] - '0';
                int sum = (firstBit ^ secondBit ^ carry)+'0';
                result = (char)sum + result;
                carry = (firstBit & secondBit) | (secondBit & carry) | (firstBit & carry);
            }  
  
             if (carry>0)
               result = '1' + result;
 
              return result;

            }
    string subtraction(string first, string second)
        {
            string compSecond = "";//A string To find The 2's complement.
            string result ="";
            int length = makeEqualLength(ref first, ref second);
            
    for (int i = 0; i <= length-1; i++)
    {
        if(second[i] == '1')
             compSecond = compSecond + '0';
        else
             compSecond = compSecond + '1';
    }
    string compOne = "";
    compOne = compOne + '1';//A string to add 1's complement by 1 to make it a 2's complement.
    compSecond = addition(compSecond, compOne);
    result = addition(first, compSecond);
    result = result.Remove(0, 1);//First Character is the Overflow Digit occured by 2's complement and hence should be removed...
    return result;
    }


    int makeEqualLength(ref string str1, ref string str2)
        {
            int i;
            int len1 = str1.Length;
            int len2 = str2.Length;
            if(len1 < len2)
            {
                for(i = 0; i < len2 - len1; i++)
                    str1 = '0' + str1;
                    return len2;
                
            }
            else if(len1 > len2)
            {
                for(i = 0; i < len1 - len2; i++)
                    str2 = '0' + str2;
                    return len1;
                
            }
            else
            return len1;
        }
    double binaryToDecimal(BigInteger Binary,int k_prec)
        { 
            double Decimal = 0;
            double k = -k_prec;
        while(Binary != 0)
            {
                if(Binary % 10 == 1)                
                Decimal = Decimal + Math.Pow(2,k);
                
                else
                Decimal = Decimal + 0;

                Binary = Binary / 10;
                k++;
            }
            return Decimal;
        }
    }
}