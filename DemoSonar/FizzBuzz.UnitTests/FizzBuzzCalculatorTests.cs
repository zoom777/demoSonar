namespace FizzBuzz.UnitTests;
public class FizzBuzzCalculatorTests
{
    [Theory]
    [InlineData(1, "1")]
    [InlineData(2, "2")]
    [InlineData(4, "4")]
    public void Calculate_Should_Return_StringRepresentation_When_Number_IsNot_MultipleOf3_Or_Is_MultipleOf5(int number, string expectedOuput)
    {
        //Arrange
        var sut = new FizzBuzzCalculator();

        //Act
        string otuput = sut.Calculate(number);

        //Assert
        Assert.Equal(expectedOuput, otuput);
    }

    [Fact]
    public void Calculate_Should_Return_Fizz_When_Number_Is_3()
    {
        //Arrange
        var sut = new FizzBuzzCalculator();

        //Act
        string otuput = sut.Calculate(3);

        //Assert
        Assert.Equal("Fizz", otuput);
    }
}
