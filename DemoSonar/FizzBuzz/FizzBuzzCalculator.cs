namespace FizzBuzz;
public class FizzBuzzCalculator
{
    public string Calculate(int number)
    {
        if (number == 3)
            return "Fizz";
        return number.ToString();
    }
}
