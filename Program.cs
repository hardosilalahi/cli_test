using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Globalization;
using System;
using McMaster.Extensions.CommandLineUtils;
using System.Linq;
using System.Collections;
using System.Text;
using System.Collections.Generic;

namespace cli_test
{
    [HelpOption("--hlp")]
    [Subcommand(
        typeof(UpperCase),
        typeof(LowerCase),
        typeof(Capitalize),
        typeof(IsPalindrome)
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

        // public void Obfuscator(){
        //     var subject = Subject ?? "no string assigned";
        //     var charSubject = subject.ToCharArray();

        //     var Obfusing = new List<string>();

        //     for(int i = 0; i < charSubject.Length; i++){
        //         Obfusing.Add($"&#{Convert.ToString(Convert.ToInt32(charSubject[i]))}");
        //     }

        //     Console.WriteLine(String.Join(";",Obfusing));
        // }
}
