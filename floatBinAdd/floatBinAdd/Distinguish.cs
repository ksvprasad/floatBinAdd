using System;
using System.Numerics;
using binSum;
namespace distinguish
    {
        class Distinguish
            {
                public string findOut(string binString1, string binString2, double number1, double number2)
                    {
                        Sum s = new Sum();
                        String sumResult = "";
                        // A case for two positive numbers.
                        if ((number1 > 0) && (number2 > 0))       
                            {
                                // An addition method to actually compute the sum.
                                sumResult = s.addition(binString1, binString2);       
                            }
                            // A case for one positive and one negative number.
                        else if ((number1 > 0) && (number2 < 0))  
                            {
                                // To obtain the absolute value of the number (for easy computation).
                                if (Math.Abs(number2) > number1)      
                                    {
                                        // A subtraction method to compute the difference.
                                        sumResult = s.subtraction(binString2, binString1);    
                                    } 
                                else
                                    {
                                        // Binary strings are sent in an order. (bigger number, smaller number).
                                        sumResult = s.subtraction(binString1, binString2);    
                                    }
                            }
                            // Another case for one positive and one negative number.
                        else if ((number1 < 0) && (number2 > 0))  
                            {
                                if (Math.Abs(number1) > number2)
                                    {
                                        sumResult = s.subtraction(binString1, binString2);
                                    }
                                else
                                    {
                                        sumResult = s.subtraction(binString2, binString1);
                                    }
                            }
                        else
                            {
                                sumResult = s.addition(binString1, binString2);
                            }
                        return sumResult;
                    }
            }
    }