public class Conversion
{
    public static double ConvertInches(double inchInput, string unit)
    {
        switch (unit.ToLower())
        {
            case "-mm":
                return Math.Round(inchInput * Variable.inchToMillimeter, 2);
            case "-cm":
                return Math.Round(inchInput * Variable.inchToMillimeter / 10, 2);
            case "-m":
                return Math.Round(inchInput * Variable.inchToMillimeter / 1000, 2);
            default:
                return -1;
        }
    }
}

class MainClass
{
    static int Main(string[] args)
    {
        Console.Clear();
        int num;
        string unit = args[1];
        bool test = int.TryParse(args[0], out num);
        double convertedValue = Conversion.ConvertInches(num, unit);

        Tests tests = new Tests();
        if (!tests.Run(args))
        {
            Console.WriteLine(Variable.testFail);

        }
        else
        {
            Console.WriteLine(Variable.testPass);
            Console.WriteLine($"{num} inches is {convertedValue} {unit.Substring(1)}.");
        }

        return 0;
    }
}


