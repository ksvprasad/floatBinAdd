using System;
using System.Numerics;
using floatBinAdd;
using binAddition;
using equateSize;
namespace binSubtraction
    {   
        class Subtraction
            {
                // A method to compute the difference of the binary strings obtained.
                public string subtraction(string first, string second)         
                {
                    SameSize ss = new SameSize();
                    Addition add = new Addition();
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
                    compSecond = add.addition(compSecond, One); 
                    // Performing Exclusive-OR between 2's complement of a string and another string gives the difference
                    result = add.addition(first, compSecond);       
                    // First Character is the Overflow Digit occured by 2's complement and hence should be removed...
                    result = result.Remove(0, 1);
                    // The subtracted result is returned.
                    return result;      
                }
            }   
    }