using System;
using System.Numerics;
namespace decToBin
    {
        class ConvertBinary
            {
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
            }
    }