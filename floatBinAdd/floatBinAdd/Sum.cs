using System;
using System.Numerics;
using distinguish;
using equateSize;
namespace binSum
    {
        class Sum
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
                public string subtraction(string first, string second)         
                {
                    SameSize ss = new SameSize();
                    // A string To find The 2's complement.
                    string compSecond = "";     
                    // A result string to store and return the computed difference.
                    string result ="";          
                    // References(pointers) of the strings are sent to balance their lengths by appending 0's at the beginning of the string which is smaller in length.                
                    int length = ss.makeEqualLength(ref first, ref second);    
                        for (int i = 0; i <= length-1; i++)                                
                            {
                                if(second[i] == '1')
                                // Finding 1's complement of the number by replacing 1 with 0 and 0 with 1.
                                    compSecond = compSecond + '0';          
                                else                                             
                                    compSecond = compSecond + '1';
                            }
                    // A string to add 1's complement by 1 to make it a 2's complement.
                    string One = "1";   
                    // Addition method is reused to add 1 to 1's complement. The obtained result is a 2's complement.
                    compSecond = addition(compSecond, One); 
                    // Performing Exclusive-OR between 2's complement of a string and another string gives the difference
                    result = addition(first, compSecond);       
                    // First Character is the Overflow Digit occured by 2's complement and hence should be removed...
                    result = result.Remove(0, 1);
                    // The subtracted result is returned.
                    return result;      
                }

            }           
    }