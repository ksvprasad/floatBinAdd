using System;
using System.Numerics;
namespace convert
    {
        class Conversion
            {
                // A method to finally convert back the binary sum to a decimal format.
                public double binaryToDecimal(BigInteger Binary,int k_precision)        
                    { 
                        // A variable to store the result.                        
                        double Decimal = 0;                                 
                        // Fractional bits hold powers in negative exponents.
                        double kprecision = -k_precision;                        
                        // Hence, they are initiated to the maximum precision value with negative exponents.
                        while(Binary != 0)                                      
                            {
                                if(Binary % 10 == 1)                
                                {
                                // Digits should only be considered for computation if they are equal to 1.   
                                    Decimal = Decimal + Math.Pow(2,kprecision);     
                                }
                                else
                                    {
                                        Decimal = Decimal + 0;
                                    }
                                Binary = Binary / 10;
                                kprecision++;
                            }
                        return Decimal;     
                    }
                public string decimalToBinary(double num, int k_precision)
                    {
                        // Separate strings for integral and fractional parts of the number.
                        string Integ = "";                    
                        string Frac = "";
                        // A string to store the binary output.
                        string binary = "";                           
                        // Explicit integer conversion of double to retrieve only the integral part and not the fractional part.
                        int Integral = (int)Math.Abs(num);              
                        // Subtracting the integral part from the original number gives the fractional part.
                        double fractional = Math.Abs(num) - Integral;   
                        while(Integral>0)               
                            {
                                // Performing the mod operation to obtain individual digits and adding them to the integral string.
                                int rem = Integral % 2;             
                                Integ=rem+Integ;                        
                                Integral = Integral / 2;
                            }
                        // A set precedence is used to denote the number of digits after the decimal point.
                        while(k_precision>0)                     
                            {
                                // Mathematical method to compute the binary version of a fractional part.
                                fractional = fractional * 2;        
                                // Obtains the carried bit.
                                int bit = (int)fractional;          
                                    if(bit == 1)
                                        {
                                            // Separates the carried bit from the rest of the fraction.
                                            fractional = fractional - bit;      
                                            // Adds the carried bit to the "frac" string.
                                            Frac = Frac + 1;                    
                                        }
                                    else
                                        Frac = Frac + 0;
                                k_precision--;
                            }
                        // finally collaborates integral and fractional parts of the binary number obtained.
                        binary = Integ + Frac;                     
                        return binary;
                    }
                // A method to append the floating point before finding out the sum.    
                public string append(string binaryNumber,int precision)
                    {
                        int size = binaryNumber.Length - 1;
                        string result ="";
                        for(int i = size; i >= 0; i--)
                            {
                                result = binaryNumber[i] + result;
                                if(i == (size - (precision - 1)))
                                    {
                                        result = "." + result;
                                    }
                            }
                        return result;
                    }    
            }
    }
