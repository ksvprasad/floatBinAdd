using System;
using System.Numerics;//for Big Integer Support.
using convert;
using distinguish;
using printer;
namespace floatBinAdd
    {
        class Program
            {
            static int Main(string[] args)
                {  
                    Print pt = new Print(); 
                    Conversion cd = new Conversion();
                    Distinguish dis = new Distinguish();
                    Console.WriteLine("Enter numbers");
                    // User inputs for decimal numbers...
                    double num1 = double.Parse(Console.ReadLine()); 
                    double num2 = double.Parse(Console.ReadLine());
                    // Precision is set to compute a fixed number of digits after decimal point. More the precision, more the accuracy.                          
                    int precision = 25;            
                    // A method to convert the user's decimal input to binary representation.
                    string binaryString1 = cd.decimalToBinary(num1, precision);   
                    Console.WriteLine("The binary version of {0} is: {1}",num1, binaryString1);
                    // The output obtained is then stored in two strings(one for each input).   
                    string binaryString2 = cd.decimalToBinary(num2, precision); 
                    Console.WriteLine("The binary version of {0} is: {1}",num2, binaryString2);   
                    Console.WriteLine("The Binary Sum of {0} and {1} is:",num1, num2);
                    // A string to store the binary sum of the binary numbers obtained above.
                    String Sum;
                    // A method to distinguish between smaller and bigger numbers. 
                    Sum = dis.findOut(binaryString1, binaryString2, num1, num2);
                    // Two methods to integrate the binary results obtained and converting them back to decimal.
                    String intFracBin = pt.integrate1(Sum, precision, num1, num2);
                    double Decimal = pt.integrate2(Sum, num1, num2, precision);
                    Console.ReadKey();
                    return 0;
                }
            
            }
    }