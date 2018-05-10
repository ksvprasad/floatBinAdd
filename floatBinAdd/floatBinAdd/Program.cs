using System;
using System.Numerics;//for Big Integer Support.
namespace floatBinAdd
    {
        class Program
            {
            static int Main(string[] args)
                {   
                    BigInteger longSum;//To support longer decimal values than a tradtional integer can support.
                    Console.WriteLine("Enter numbers");
                    double num1 = double.Parse(Console.ReadLine()); //User inputs for decimal numbers...
                    double num2 = double.Parse(Console.ReadLine());
                    int precision=8;            //Precision is set to compute a fixed number of digits after decimal point.                          
                    Program p = new Program(); //A constructor to actually be able to access the methods within "Program" class
                    string str1 = p.decimalToBinary(num1, precision);   //A method to convert the user's decimal input to binary representation.
                    string str2 = p.decimalToBinary(num2, precision);   //The output obtained is then stored in two strings(one for each input).   
                    Console.WriteLine("The Binary Sum of {0} and {1} is:",num1, num2);
                    String Sum; //A string to store the binary sum of the binary numbers obtained above.
                    if ((num1 > 0) && (num2 > 0))       //A case for two positive numbers.
                        {
                            Sum = p.addition(str1, str2);     //An addition method to actually compute the sum.  
                        }
                    else if ((num1 > 0) && (num2 < 0))  //A case for one positive and one negative number.
                        {
                            if (Math.Abs(num2) > num1)      //To obtain the absolute value of the number (for easy computation).
                                {
                                    Sum = p.subtraction(str2, str1);    //A subtraction method to compute the difference.
                                } 
                            else
                                {
                                    Sum = p.subtraction(str1, str2);    //Binary strings are sent in an order. (bigger number, smaller number).
                                }
                        }
                    else if ((num1 < 0) && (num2 > 0))  //Another case for one positive and one negative number.
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
                        {                                           //Appending Floating Point.
                            intFracBin = Sum[i] + intFracBin;       //Binary number with both integral and fractional parts.
                            if (i == ((size) - (precision - 1)))
                                intFracBin = '.' + intFracBin;
                        }
                            if ((num1 + num2) < 0)
                                {
                                    Console.WriteLine("-"+intFracBin);
                                }
                            else
                                {
                                    Console.WriteLine(intFracBin);  //Printing the binary sum.
                                }
                    longSum = BigInteger.Parse(Sum);    //Storing the binary string in the form of Big integer.
                    double Decimal = p.binaryToDecimal(longSum,precision);//A method to convert binary string to decimal.
                    Console.WriteLine("The decimal version of the sum of {0} and {1} is:",num1, num2);
                        if((num1 + num2) < 0)   //To findout whether the sum is positive or negative.
                            {
                                Console.WriteLine("-"+Decimal); //Appending - sign while printing.
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
                    string Integ = "";                    //Separate strings for integral and fractional parts of the number.
                    string Frac = "";
                    string binary = "";                           //A string to store the binary output.
                    int Integral = (int)Math.Abs(num);              //Explicit integer conversion of double to retrieve only the integral part and not the fractional part.
                    double fractional = Math.Abs(num) - Integral;   //Subtracting the integral part from the original number gives the fractional part.
                        while(Integral>0)               
                            {
                                int rem = Integral % 2;             //Performing the mod operation to obtain individual digits
                                Integ=rem+Integ;                        //and adding them to the integral string.
                                Integral = Integral / 2;
                            }
                        while(k_prec>0)                     //A set precedence is used to denote the number of digits after the decimal point.
                            {
                                fractional = fractional * 2;        //Mathematical method to compute the binary version of a fractional part.
                                int bit = (int)fractional;          //Obtains the carried bit.
                                    if(bit == 1)
                                        {
                                            fractional = fractional - bit;      //Separates the carried bit from the rest of the fraction.
                                            Frac = Frac + 1;                    //Adds the carried bit to the "frac" string.
                                        }
                                    else
                                        Frac = Frac + 0;
                                k_prec--;
                            }
                    binary = Integ + Frac;                     //finally collaborates integral and fractional parts of the binary number obtained.
                    return binary;
                }
            string addition(string first, string second)            //A method to add the binary numbers obtained previously.
                {
                    string result = "";                             //A string to store the result.
                    int length = makeEqualLength(ref first, ref second);    //A method to ensure both the strings are of equal length.
                    int carry = 0;                                          //A carry bit.
                        for (int i = length-1 ; i >= 0 ; i--)
                            {
                                int firstBit = first[i] - '0';  //Retrieves individual bits.
                                int secondBit = second[i] - '0';
                                int sum = (firstBit ^ secondBit ^ carry)+'0';       //Exclusive-OR Operation to perform Addition.
                                result = (char)sum + result;                        //Retrieves character representaion of sum.                  
                                carry = (firstBit & secondBit) | (secondBit & carry) | (firstBit & carry);
                            }
                        if (carry>0)
                            result = '1' + result;      //Appends 1 if carry bit is present at the end of traversal.
                    return result;      //Sends back the sum obtained.
                }
            string subtraction(string first, string second)         //A method to compute the difference of the binary strings obtained.
                {
                    string compSecond = "";     //A string To find The 2's complement.
                    string result ="";          //A result string to store and return the computed difference.
                    int length = makeEqualLength(ref first, ref second);    //References(pointers) of the strings are sent to balance their lengths.
                        for (int i = 0; i <= length-1; i++)                                //by appending 0's at the beginning of the string which is smaller in length.                
                            {
                                if(second[i] == '1')
                                    compSecond = compSecond + '0';          //Finding 1's complement of the number 
                                else                                             //by replacing 1 with 0 and 0 with 1.
                                    compSecond = compSecond + '1';
                            }
                    string compOne = "1";   //A string to add 1's complement by 1 to make it a 2's complement.
                    compSecond = addition(compSecond, compOne); //Addition method is reused to add 1 to 1's complement. The obtained result is a 2's complement.
                    result = addition(first, compSecond);       //Performing Exclusive-OR between 2's complement of a string and another string gives the difference
                    result = result.Remove(0, 1);//First Character is the Overflow Digit occured by 2's complement and hence should be removed...
                    return result;      //The subtracted result is returned.
                }
            int makeEqualLength(ref string str1, ref string str2)       //An important method to bring both the strings to equal length
                {                                                          //by appending 0's at the beginning of the string which is smaller in length.
                    int i;                                              
                    int len1 = str1.Length;                                //Initially the lengths of both the strings are obtained and stored in len1 and len2.
                    int len2 = str2.Length;
                        if(len1 < len2)                         
                            {
                                for(i = 0; i < len2 - len1; i++)                //len2-len1 obtains the difference in lengths if string1's length is less than that of string 2.
                                    str1 = '0' + str1;                          //Adds 0 at the beginning if string 1 is smaller in length.   
                                return len2;                                //Returns the integer containing the length of the bigger string(in this case len2).
                            }
                        else if(len1 > len2)
                            {
                                for(i = 0; i < len1 - len2; i++)                //len1-len2 obtains the difference in lengths if string2's length is less than that of string 1.
                                    str2 = '0' + str2;                          //Adds 0 at the beginning if string1 is smaller in length.
                                return len1;                                //Returns the integer containing the length of the bigger string(in this case len1).
                            }
                        else
                            return len1;                                        //Returns the length of string1 if both strings are of the same size.
                }
            double binaryToDecimal(BigInteger Binary,int k_prec)        //A method to finally convert back the binary sum to a decimal format.
                { 
                    double Decimal = 0;                                 //A variable to store the result.                        
                    double kprecision = -k_prec;                        //As fractional bits hold powers in negative exponents.
                        while(Binary != 0)                                      // Hence, they are initiated to the maximum precision value with negative exponents.
                            {
                                if(Binary % 10 == 1)                
                                    Decimal = Decimal + Math.Pow(2,kprecision);     //Digits should only be considered for computation if they are equal to 1.   
                                else
                                    Decimal = Decimal + 0;
                                Binary = Binary / 10;
                                kprecision++;
                            }
                    return Decimal;     
                }
            }
    }