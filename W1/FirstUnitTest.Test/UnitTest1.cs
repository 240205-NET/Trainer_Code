namespace FirstUnitTest.Test;

public class UnitTest1
{
    // Common Arrangement
    public string[] conditions = {};


    [Fact]
    public void test()
    {
        //arrange
        string expected = "hello";
        //act
        string actual = Console.ReadLine();  // Console ReadLine and WriteLine depend 
                    // on the Standard Input and Output data streams, and are not accessible during unit testing
        //assert
        Assert.Equal(expected, actual);
    }






    // Functionality
    public int method(int value = 0)
    {
        return 9;
    }

    // Unit Test
    [Fact]
    public void Test1()
    {
        // Arrange

        // Act
        int result = method();

        // Assert
        Assert.IsType<int>(result);
    }

    [Fact]
    public void Test2()
    {
        // Arrange
        int expected = 9;
        // Act
        int actual = method(3);

        // Assert
        // Assert.IsType<int>(actual);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Test3()
    {
        // Arrange
        int expected = 9;
        // Act
        int actual = method(3);

        // Assert
        Assert.IsType<int>(actual);
        Assert.Equal(expected, actual);
    }
}