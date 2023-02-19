using System.Text;

DivisionByTwo();
ModifiedNewton();
MethodSimpleIteration();

void ModifiedNewton()
{
    Console.OutputEncoding = Encoding.UTF8;

    Console.WriteLine("Введіть n, де n - наближення 10^-n");
    var pow = int.TryParse(Console.ReadLine(), out var number) && number > 0 && number < 50 ? number : 3;
    Console.WriteLine($"Знайти корінь для рівняння x^3 - 7x^2 + 7x + 15 = 0, при початковому наближенні epsilon = 10^-{pow}");
    var e = Math.Pow(10, -pow);

    double xn = 4;
    double xnminus1;
    const double x0 = 3.25;

    var iteration = 0;
    do
    {
        xnminus1 = xn;
        xn = xnminus1 - Func2(xnminus1) / Func2Derivative(x0);
        iteration++;
        Console.WriteLine($"Ітерація: {iteration}. Xn: {xn}");
    } while (Math.Abs(xn - xnminus1) > e);
    Console.WriteLine("{0:0.00000000}", xn);
}

double Func2(double x)
{
    return Math.Pow(x, 3) - Math.Pow(x, 2) * 7 + 7 * x + 15;
}

double Func2Derivative(double x)
{
    return Math.Pow(x, 2) * 3 - x * 14 + 7;
}

MethodSimpleIteration();

void MethodSimpleIteration()
{
    Console.OutputEncoding = Encoding.UTF8;

    Console.WriteLine("Введіть n, де n - наближення 10^-n");
    var pow = int.TryParse(Console.ReadLine(), out var number) && number > 0 && number < 50 ? number : 3;
    Console.WriteLine($"Знайти корінь для рівняння x^3 - 5x^2 - 4x + 20 = 0, при початковому наближенні epsilon = 10^-{pow}");
    var e = Math.Pow(10, -pow);

    double xnminus1;
    double xn = 2.2;
    
    int iteration = 0;
    
    do
    {
        iteration++;
        xnminus1 = xn;
        xn = Fi(xnminus1);
        Console.WriteLine($"Ітерація: {iteration}. Xn: {xn}");
    } while (Math.Abs(xn - xnminus1) > e);
    Console.WriteLine("{0:0.00000000}", xn);
}


double Fi(double x)
{
    return Math.Sqrt((Math.Pow(x, 3) - 4 * x + 20) / 5);
}

void DivisionByTwo()
{
    Console.OutputEncoding = Encoding.UTF8;

    Console.WriteLine("Введіть n, де n - наближення 10^-n");
    var pow = int.TryParse(Console.ReadLine(), out var number) && number > 0 && number < 50 ? number : 3;
    Console.WriteLine($"Знайти корінь для рівняння x^3 - 4x^2 - 4x + 4 = 0, при початковому наближенні epsilon = 10^-{pow}");
    var e = Math.Pow(10, -pow);
            
    double a = 1;
    double b = 3;

    double c;
    var iteration = 0;
    do
    {
        c = (a + b) / 2;
        if (Func1(a) * Func1(b) < 0)
        {
            b = c;
        }
        else
        {
            a = c;
        }

        iteration++;
        Console.WriteLine($"Ітерація: {iteration}. Min: {a}, Max: {b}");
    } 
    while (b - a >= e);

    Console.WriteLine("{0:0.00000000}", c);
}

double Func1(double x)
{
    return Math.Pow(x, 3) - 4 * Math.Pow(x, 2) - 4 * x + 16;
}