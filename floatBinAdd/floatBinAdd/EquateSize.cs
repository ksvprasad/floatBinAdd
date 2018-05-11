using System;
using System.Numerics;
namespace equateSize
    {
        class SameSize
            {
                // An important method to bring both the strings to equal length by appending 0's at the beginning of the string which is smaller in length.
                public int makeEqualLength(ref string binary1, ref string binary2)       
                {                                                          
                    int i;                                              
                    // Initially the lengths of both the strings are obtained and stored in len1 and len2.
                    int len1 = binary1.Length;                                
                    int len2 = binary2.Length;
                        if(len1 < len2)                         
                            {
                                // len2-len1 obtains the difference in lengths if string1's length is less than that of string 2.
                                for(i = 0; i < len2 - len1; i++)                
                                    {
                                        // Adds 0 at the beginning if string 1 is smaller in length.   
                                        binary1 = '0' + binary1;                          
                                    }    
                                // Returns the integer containing the length of the bigger string(in this case len2).
                                return len2;                                
                            }
                        else if(len1 > len2)
                            {
                                // len1-len2 obtains the difference in lengths if string2's length is less than that of string 1.
                                for(i = 0; i < len1 - len2; i++)                
                                    {
                                        // Adds 0 at the beginning if string1 is smaller in length.
                                        binary2 = '0' + binary2;                          
                                    }
                                // Returns the integer containing the length of the bigger string(in this case len1).
                                return len1;                                
                            }
                        else
                            {
                        // Returns the length of string1 if both strings are of the same size.
                            return len1;                                        
                            }
                }
            }
    }