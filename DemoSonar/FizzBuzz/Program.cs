namespace FizzBuzz;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Input:");

        var inputString = Console.ReadLine();
        var intputNumber = Convert.ToInt32(inputString);

        var fizzBuzzCalulator = new FizzBuzzCalculator();

        try
        {
            Console.WriteLine($"Output: {fizzBuzzCalulator.Calculate(intputNumber)}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }


        Console.ReadKey();
    }
}
