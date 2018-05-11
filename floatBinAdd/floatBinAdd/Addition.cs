using System;
using System.Numerics;
using distinguish;
using equateSize;
namespace binAddition
    {
        class Addition
            {
                // A method to add the binary numbers obtained previously.
                 public string addition(string first, string second)            
                {
                    // A string to store the result.
                    string result = "";                             
                    SameSize ss = new SameSize();
                    // A method to ensure both the strings are of equal length.
                    int length = ss.makeEqualLength(ref first, ref second);    
                    // A carry bit.
                    int carry = 0;                                          
                        for (int i = length-1 ; i >= 0 ; i--)
                            {
                                int firstBit = first[i] - '0';  
                                // Retrieves individual bits.
                                int secondBit = second[i] - '0';
                                // Exclusive-OR Operation to perform Addition.
                                int sum = (firstBit ^ secondBit ^ carry)+'0';       
                                // Exclusive-OR Operation to perform Addition.
                                // Retrieves character representaion of sum.                  
                                result = (char)sum + result;                        
                                carry = (firstBit & secondBit) | (secondBit & carry) | (firstBit & carry);
                            }
                        if (carry>0)
                            {
                        // Appends 1 if carry bit is present at the end of traversal.
                                result = '1' + result;
                            }      
                     // Sends back the sum obtained.
                    return result;      
                }

            }           
    }