using System;
using System.Numerics;
using floatBinAdd;
using binToDec;
namespace printer
    {
        class Print
            {
                // A method to print the binary version of the sum.
                public string integrate1(string Sum, int precision, double num1, double num2)
                    {
                        int size = Sum.Length -1;
                    // A variable to store both the integral and fractional part of a binary number.
                    String intFracBin = "";                         
                    for (int i = size; i >= 0; i--)
                        {     
                            // Appending Floating Point.                                      
                            intFracBin = Sum[i] + intFracBin;       
                            if (i == ((size) - (precision - 1)))
                                {
                                // Binary number with both integral and fractional parts.
                                intFracBin = '.' + intFracBin;
                                }
                        }
                            if ((num1 + num2) < 0)
                                {
                                    Console.WriteLine("-"+intFracBin);
                                }
                            else
                                {
                                    // Printing the binary sum.
                                    Console.WriteLine(intFracBin);  
                                }
                            return intFracBin;
                    }
                // A method to print the decimal version of the sum.
                public double integrate2(string Sum, double num1, double num2, int precision)
                    {
                        ConvertDecimal cd = new ConvertDecimal();
                        // Storing the binary string in the form of Big integer.
                        BigInteger longSum = BigInteger.Parse(Sum);    
                        // A method to convert binary string to decimal.
                        double Decimal = cd.binaryToDecimal(longSum,precision);
                        Console.WriteLine("The decimal version of the sum of {0} and {1} is:",num1, num2);
                        // To findout whether the sum is positive or negative.
                            if((num1 + num2) < 0)   
                                {
                                    // Appending - sign while printing.
                                    Console.WriteLine("-"+Decimal); 
                                }
                            else
                                {
                                    Console.WriteLine(Decimal);
                                }
                        return Decimal;
                    }
            }
    }