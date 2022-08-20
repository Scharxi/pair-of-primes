void SieveOfEratosthenes(uint n, IList<bool> isPrime)
{
    // There are no prime numbers below one and one it self is also not a prime number
    isPrime[0] = isPrime[1] = false;
    for (var i = 2; i <= n; i++)
    {
        isPrime[i] = true;
    }
    for (var p = 2; p * p <= n; p++)
    {
        if (!isPrime[p]) continue;
        for (var i = p * p; i <= n; i += p)
            isPrime[i] = false;
    }
}


int FindPrimePair(uint n)
{
    // create an array of size n + 1
    var isPrime =  new bool[n + 1] ;
    var solutions = 0;
    SieveOfEratosthenes(n, isPrime);
    
    for (var i = 0; i < n; i++)
    {
        // Filter out all numbers that are not a prime number
        if (!isPrime[i] || !isPrime[n - i]) continue;
        solutions += 1;
        Console.WriteLine($"{solutions}: ({i};{n-i})");
    }

    return solutions;
}

Console.Write("Please input a positive number: ");
var num = Console.ReadLine();
if (num != null)
{
    uint number;
    
    try
    {
        number = uint.Parse(num);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
        return;
    }
    
    var n = FindPrimePair(number);
    
    Console.WriteLine($"\nFound {n} solutions for number {number}");
    Environment.Exit(0);
}


