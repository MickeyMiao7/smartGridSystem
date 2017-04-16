using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
//the namespace must be PAT.Lib, the class and method names can be arbitrary
namespace PAT.Lib
{
    /// <summary>
    /// The math library that can be used in your model.
    /// all methods should be declared as public static.
    /// 
    /// The parameters must be of type "int", or "int array"
    /// The number of parameters can be 0 or many
    /// 
    /// The return type can be bool, int or int[] only.
    /// 
    /// The method name will be used directly in your model.
    /// e.g. call(max, 10, 2), call(dominate, 3, 2), call(amax, [1,3,5]),
    /// 
    /// Note: method names are case sensetive
    /// </summary>
    public class Toolkit
    {
    	public static int RandNumGenerator()
        {
        	Random ro = new Random();  
        	int iResult;  
　　		    int iUp = 100;  
　　		    iResult = ro.Next(iUp);
　　		    return iResult;
        }

        // // extend calculate/ accept/ reject and seal, return hashvalue.        
        // public static string HashFunction(string old_hash, string operation)
        // {
        //     // extend calculate price
        //     if (operation == "calculate"){
        //         // calculate *7 hash
        //         String toHash = old_hash + "*7";
        //         MD5 md5 = new MD5CryptoServiceProvider();
        //         byte[] data = System.Text.Encoding.Default.GetBytes(toHash);   
        //         byte[] md5data = md5.ComputeHash(data);  
        //         md5.Clear();  
        //         string mid = "";  
        //         for (int i = 0; i < md5data.Length - 1; ++i)  
        //         {  
        //             mid += md5data[i].ToString("x").PadLeft(2, '0');  
        //         }  
        //         // calculate +12 hash
        //         mid += "+12";
        //         data = System.Text.Encoding.Default.GetBytes(mid); 
        //         md5data = md5.ComputeHash(data);  
        //         md5.Clear();  
        //         string ans = "";  
        //         for (int i = 0; i < md5data.Length - 1; ++i)  
        //         {  
        //             ans += md5data[i].ToString("x").PadLeft(2, '0');  
        //         } 
        //         return ans;
        //     }
        //     // other operations
        //     // seal / accept / reject
        //     else {
        //         String toHash = old_hash + operation;
        //         MD5 md5 = new MD5CryptoServiceProvider();
        //         byte[] data = System.Text.Encoding.Default.GetBytes(toHash);   
        //         byte[] md5data = md5.ComputeHash(data);  
        //         md5.Clear();  
        //         string ans = "";  
        //         for (int i = 0; i < md5data.Length - 1; ++i)  
        //         {  
        //             ans += md5data[i].ToString("x").PadLeft(2, '0');  
        //         }  
        //         return ans;
        //     }
        // }

        // // extend nonce, return the first hash value
        // public static string HashFunction(int nonce)
        // {
        //     MD5 md5 = new MD5CryptoServiceProvider();  
        //     byte[] data = System.Text.Encoding.Default.GetBytes(nonce.ToString());   
        //     byte[] md5data = md5.ComputeHash(data);  
        //     md5.Clear();  
        //     string ans = "";  
        //     for (int i = 0; i < md5data.Length - 1; ++i)  
        //     {  
        //         ans += md5data[i].ToString("x").PadLeft(2, '0');  
        //     }  
        //     return ans;
        // }

        // Simplified extend function. Using by TPM.
        public static int Extend(int old_hash, int operation){
            int ans = old_hash;
            ans = old_hash*10 + operation;
            return ans;
        }
        
        // Simplified extend function using by power supplier
        // Each operation is represent by a distinct number in {1 - 9}. Hash value is represented by a integer.
        public static int HashFunction1(int nounce, int seal, int accept, int cal_1, int cal_2)
        {
            int ans = nounce;
            ans = (ans)*10 + seal;
            ans = (ans)*10 + accept;
            ans = (ans)*10 + cal_1;
            ans = (ans)*10 + cal_2;
            return ans;
        }

        //Simplified extend function using by power supplier
        public static int HashFunction2(int nounce, int seal, int reject)
        {
            int ans = nounce;
            ans = (ans)*10 + seal;
            ans = (ans)*10 + reject;
            return ans;
        }
        
        // calculate the price 
        public static int CalculatePrice(int usage)
        {
        	int price = 1;
        	price = usage * 7 + 12;	
        	return price;
        }

    }
}
