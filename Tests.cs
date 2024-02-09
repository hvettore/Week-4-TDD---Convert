public class Tests
{
    private bool testsFullyPassed = true;
    public bool Run(string[] args)
    {
        TestUserConversion(args);
        return testsFullyPassed;
    }

    void TestUserConversion(string[] args)
    {
        double inchInput = double.Parse(args[0]);
        double expectedResult;
        if (args[1] == Variable.millimeter)
        {
            expectedResult = Math.Round(inchInput * Variable.inchToMillimeter, 2);
        }
        else if (args[1] == Variable.centimeter)
        {
            expectedResult = Math.Round(inchInput * Variable.inchToMillimeter / 10, 2);
        }
        else if (args[1] == Variable.meter)
        {
            expectedResult = Math.Round(inchInput * Variable.inchToMillimeter / 1000, 2);
        }
        else
        {
            TestOutcome("TestUserConversion", false);
            return;
        }

        if (expectedResult != Conversion.ConvertInches(inchInput, args[1]))
        {
            TestOutcome("TestUserConversion", false);
        }
        else
        {
            TestOutcome("TestUserConversion", true);
        }
    }


    void TestOutcome(string testName, bool isPass)
    {
        string result;
        if (isPass)
        {
            result = "Pass";
        }
        else
        {
            result = "Fail";
            testsFullyPassed = false;
        }

        string testNameIndicator = testName;
        Console.Write(testNameIndicator + " - ");

        ConsoleColor resultColor;
        if (isPass)
        {
            resultColor = ConsoleColor.Green;
        }
        else
        {
            resultColor = ConsoleColor.Red;
        }

        Console.ForegroundColor = resultColor;
        Console.WriteLine(result);
        Console.ResetColor();
    }

}