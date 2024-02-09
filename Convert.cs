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
        if (args.Length < 2)
        {
            Console.WriteLine(Variable.testFail);
            return 1;
        }

        int num;
        bool test = int.TryParse(args[0], out num);
        if (!test)
        {
            Console.WriteLine(Variable.testFail);
            return 1;
        }

        string unit = args[1];
        double convertedValue = Conversion.ConvertInches(num, unit);

        if (convertedValue == -1)
        {
            Console.WriteLine(Variable.testFail);
            return 1;

        }
        else
        {

            Console.WriteLine(Variable.testPass);
            Console.WriteLine($"{num} inches is {convertedValue} {unit.Substring(1)}.");
        }


        return 0;
    }
}