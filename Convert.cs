public class Functions
{
    public static double ConvertInches(double inches, string unit)
    {
        switch (unit.ToLower())
        {
            case "-mm":
                return inches * 25.4;
            case "-cm":
                return inches * 2.54;
            case "-m":
                return inches * 0.0254;
            default:
                return -1;
        }
    }
}

class MainClass
{
    static int Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Please enter both a numeric argument and a unit.");
            Console.WriteLine("Example: Converter <num> <-unit>");
            return 1;
        }

        int num;
        bool test = int.TryParse(args[0], out num);
        if (!test)
        {
            Console.WriteLine("Please enter a numeric argument.");
            Console.WriteLine("Example: Converter <num> <-unit>");
            return 1;
        }

        string unit = args[1];
        double convertedValue = Functions.ConvertInches(num, unit);

        if (convertedValue == -1)
            Console.WriteLine("Invalid unit. Use -mm, -cm, or -m.");
        else
            Console.WriteLine($"{num} inches is {convertedValue} {unit.Substring(1)}.");

        return 0;
    }
}