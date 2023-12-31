using System;
class Program
{
    static void Main(){
        bool upper=GetUserInput("Include uppercase? (Y/N)");
        bool lower=GetUserInput("Include lowercase? (Y/N)");
        bool number=GetUserInput("Include number? (Y/N)");
        bool special=GetUserInput("Include special characters? (Y/N)");
int length = GetUserInt("Write the length of the password", "Invalid input. Please enter a valid number");
        string password=GeneratePassword(upper,lower,number,special,length);
Console.WriteLine($"Password?: {password}");

    }
    static bool GetUserInput(string message){
        Console.WriteLine(message);
        string input=Console.ReadLine().Trim().ToUpper();
        if(input=="Y"){
            return true;
        }else if(input=="N"){
            return false;
        }else Console.WriteLine("Invalid input. Please enter Y/N only.");
         return false;    }
    static int GetUserInt(string message, string error){
       int result;
       while(true){
        Console.WriteLine(message);
        string input=Console.ReadLine();
        if(int.TryParse(input,out result)&&result>0)return result;
        else Console.WriteLine(error);
       }
    }
    static string GeneratePassword(bool upper,bool lower,bool numbers,bool special,int length){
     const string upperc = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string lowerc = "abcdefghijklmnopqrstuvwxyz";
        const string numbersc = "0123456789";
        const string specialc = "!@#$%^&*()-_=+[]{}|;:'\",.<>/?";
        string validchar=string.Empty;
        validchar+=upper?upperc:"";
        validchar+=lower?lowerc:"";
        validchar+=numbers?numbersc:"";
        validchar+=special?specialc:"";
        if(string.IsNullOrEmpty(validchar)){
            Console.WriteLine("You must select at least one character");
            Environment.Exit(1);
        }
        Random random=new Random();
        return new string(Enumerable.Repeat(validchar, length).Select(s => s[random.Next(s.Length)]).ToArray());
    }
}