using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Globalization;
using System;
using McMaster.Extensions.CommandLineUtils;
using System.Linq;
using System.Collections;
using System.Text;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace cli_test
{
    [HelpOption("--hlp")]
    [Subcommand(
        typeof(UpperCase),
        typeof(LowerCase),
        typeof(Capitalize),
        typeof(IsPalindrome),
        typeof(Obfuscator),
        typeof(RandomString),
        typeof(SumNumber),
        typeof(SubtractNumber),
        typeof(MultiplyNumber),
        typeof(DivideNumber),
        typeof(LocalIP),
        typeof(ExternalIP)

    )]
    class Program
    {
        public static int Main(string[] args)
        {
            return CommandLineApplication.Execute<Program>(args);
        }
    }

    [Command(Description = "Command to uppercase string", Name = "uppercase")]
    class UpperCase
    {
        [Argument(0)]
        public string text { get; set; }
        public void OnExecute(CommandLineApplication app)
        {
            Console.WriteLine($"{text.ToUpper()}");
        }
    }

    [Command(Description = "Command to lowercase string", Name = "lowercase")]
    class LowerCase
    {
        [Argument(0)]
        public string text { get; set; }
        public void OnExecute(CommandLineApplication app)
        {
            Console.WriteLine($"{text.ToLower()}");
        }
    }

    [Command(Description = "Command to Capitalize String", Name = "capitalize")]
    class Capitalize{

        [Argument(0)]
        public string text {get;set;}
        public void OnExecute(CommandLineApplication app)
        {
            Console.WriteLine($"{CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower())}");
        }
    }

    [Command(Description = "Command to return a boolean of palindrome string", Name = "palindrome")]
    class IsPalindrome{

        [Argument(0)]
        public string text {get; set;}

        public void OnExecute(CommandLineApplication app)
        {
            text.ToLower();
            text.Replace(" ", "");
            text.Replace(",", "");
            text.Replace(".", "");

            Console.WriteLine(text.SequenceEqual(text.Reverse()));        }
    }

    [Command(Description = "Command to obfuscate a string", Name = "obfuscate")]
    class Obfuscator{

        [Argument(0)]
        public string text {get; set;}

        public void OnExecute(CommandLineApplication app)
        {
            var charSubject = text.ToCharArray();

            var Obfusing = new List<string>();

            for(int i = 0; i < charSubject.Length; i++){
                Obfusing.Add($"&#{Convert.ToString(Convert.ToInt32(charSubject[i]))}");
            }

            Console.WriteLine(String.Join(";",Obfusing));
        }
    }

    [Command(Description = "Command to output a random Alphanumeric", Name = "random")]
    class RandomString{

        [Option(LongName = "panjang")]
        public string Panjang{get; set;}

        [Option(LongName = "letters")]
        public string Letters {get; set;}

        [Option(LongName = "numbers")]
        public string Numbers {get; set;}

        [Option(LongName = "hurufkecil")]
        public string HurufKecil {get; set;}

        [Option(LongName = "uppercase")]
        public string Upper {get; set;}

        public void OnExecute(CommandLineApplication app)
        {
            var lengthText = Panjang ?? "32";
            var intLengthText = Convert.ToInt32(lengthText);

            var includeLetters = Letters ?? "true";
            var boolLetters = Convert.ToBoolean(includeLetters);
            
            var includeNumbers = Numbers ?? "true";
            var boolNumbers = Convert.ToBoolean(includeNumbers);

            var onlyLower = HurufKecil ?? "true";
            var boolLower = Convert.ToBoolean(onlyLower);

            var onlyUpper = Upper ?? "true";
            var boolUpper = Convert.ToBoolean(onlyUpper);


            var charsComplete = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var charsNumber = "0123456789";
            var charsText = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            var charsLower = "abcdefghijklmnopqrstuvwxyz";
            var charsUpper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";


            var allChars = new char[intLengthText];
            var random = new Random();
            
            if(intLengthText == 32){

                if(boolLetters == false){
                    for (int i = 0; i < allChars.Length; i++){
                        allChars[i] = charsNumber[random.Next(charsNumber.Length)];
                    }
                }

                else if(boolNumbers == false){

                    if(boolLower == false){
                        for (int i = 0; i < allChars.Length; i++){
                            allChars[i] = charsUpper[random.Next(charsUpper.Length)];
                        }
                    }
                    else if(boolUpper == false){
                        for (int i = 0; i < allChars.Length; i++){
                            allChars[i] = charsComplete[random.Next(charsComplete.Length)];
                        }
                    }
                    else{
                        for (int i = 0; i < allChars.Length; i++){
                            allChars[i] = charsLower[random.Next(charsLower.Length)];
                        }
                    }

                }
                else{
                    for (int i = 0; i < allChars.Length; i++){
                        allChars[i] = charsComplete[random.Next(charsComplete.Length)];
                    }
                }
            }
            else{

                if(boolLetters == false){
                    for (int i = 0; i < allChars.Length; i++){
                        allChars[i] = charsNumber[random.Next(charsNumber.Length)];
                    }
                }

                else if(boolNumbers == false){

                    if(boolLower == false){
                        for (int i = 0; i < allChars.Length; i++){
                            allChars[i] = charsUpper[random.Next(charsUpper.Length)];
                        }
                    }
                    else if(boolUpper == false){
                        for (int i = 0; i < allChars.Length; i++){
                            allChars[i] = charsComplete[random.Next(charsComplete.Length)];
                        }
                    }
                    else{
                        for (int i = 0; i < allChars.Length; i++){
                            allChars[i] = charsLower[random.Next(charsLower.Length)];
                        }
                    }

                }
                else{
                    for (int i = 0; i < allChars.Length; i++){
                        allChars[i] = charsComplete[random.Next(charsComplete.Length)];
                    }
                }
            }

            var finalString = new String(allChars);
            Console.WriteLine(finalString);
        }
    }

    [Command(Description = "Command to sum integers", Name = "add")]
    class SumNumber{

        [Argument(0)]
        public int[] numbers {get; set;}

        public void OnExecute(CommandLineApplication app)
        {
            Console.WriteLine(numbers.Sum());
        }
    }

    [Command(Description = "Command to subtract integers", Name = "subtract")]
    class SubtractNumber{

        [Argument(0)]
        public int[] numbers {get; set;}

        public void OnExecute(CommandLineApplication app)
        {
            int result = 0;
            for(int i = 1; i < numbers.Length; i++){
                result -= numbers[i];
            }
            Console.WriteLine(result);
        }
    }

    [Command(Description = "Command to multiply integers", Name = "multiply")]
    class MultiplyNumber{

        [Argument(0)]
        public int[] numbers {get; set;}

        public void OnExecute(CommandLineApplication app)
        {
            int result = numbers[0];
            for(int i = 1; i < numbers.Length; i++){
                result *= numbers[i];
            }
            Console.WriteLine(result);
        }
    }

    [Command(Description = "Command to divide integers", Name = "divide")]
    class DivideNumber{

        [Argument(0)]
        public int[] numbers {get; set;}

        public void OnExecute(CommandLineApplication app)
        {
            var result = numbers[0];
            for(int i = 1; i < numbers.Length; i++){
                result /= numbers[i];
            }
            Console.WriteLine((double)result);
        }
    }

    [Command(Description = "Command to get IP address", Name = "ip")]
    class LocalIP{

        public void OnExecute(CommandLineApplication app)
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    Console.WriteLine(ip.ToString());
                }
            }
        }
    }

    [Command(Description = "Command to get External IP address", Name = "external-ip")]
    class ExternalIP{

        public void OnExecute(CommandLineApplication app)
        {
            string externalip = new WebClient().DownloadString("http://icanhazip.com");
            Console.WriteLine(externalip);
        }
    }

    [Command(Description = "Command to add numbers until last input is empty", Name = "sum")]
    class SumUnlimited
    {
        public void OnExecute(CommandLineApplication app){
            long result = 0;
            string Empty = "";
            while (Empty != null){
                Console.Write("Insert number : ");
                Empty = Console.ReadLine();
                if (Empty == "")
                {
                    break;
                }
                else
                {
                    long integerInput = Convert.ToInt32(Empty);
                    result += integerInput;
                }
            }
            Console.WriteLine(result);

            
        }
    }
}
