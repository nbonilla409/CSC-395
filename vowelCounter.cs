using System;


namespace somethingSomething
{
    public class vowelCounter
    {

        public static void Main(string[] args)
        {
            while (true)
            {
                string input = "";
                int count = 0;
                Console.WriteLine("Enter a string: ");
                input = Console.ReadLine();
                count = 0;
                for (int i = 0; i < input.Length; i++)
                {
                    if (Char.ToLower(input[i]) == 'a' || Char.ToLower(input[i]) == 'e' ||
                        Char.ToLower(input[i]) == 'i' || Char.ToLower(input[i]) == 'o' ||
                        Char.ToLower(input[i]) == 'u')
                        count++;
                }
                Console.WriteLine("Your string was '{0}'. \nNumber of vowels in string = {1}", input, count);
                Console.WriteLine("Enter another string? (y/n)");
                if (Console.ReadLine().ToLower() != "y")
                    break;
            }
        }
    }
}