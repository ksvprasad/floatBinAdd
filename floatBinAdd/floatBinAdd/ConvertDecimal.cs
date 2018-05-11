using System;
using System.Numerics;
namespace binToDec
    {
        class ConvertDecimal
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
            }
    }
