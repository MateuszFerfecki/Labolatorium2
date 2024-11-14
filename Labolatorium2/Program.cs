// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");



void WriteEven()
{
    Console.WriteLine("Podaj n");
    var n = Console.ReadLine();

    for (var i = 0; i < int.Parse(n); i += 2) // i = i+2;
    {
        Console.WriteLine(i);
    }
}


while (true)
{
    Console.WriteLine("Wybierz");
    Console.WriteLine("1. Czy parzysta");
    Console.WriteLine("2. Liczby parzyste");
    Console.WriteLine("3. Silnia");
    Console.WriteLine("4. Gra");
    Console.WriteLine("0. Wyjście");

    var n = Console.ReadLine();

    switch (int.Parse(n))
    {
        case 1:
            CheckEven();
            break;
        case 2:
            {
                WriteEven();
                break;
            }
        case 3:
            {
                var siln = Console.ReadLine();
                Console.WriteLine(Silnia(int.Parse(siln)));
                break;
            }
        case 4:
            Game();
            break;
    }

    if (int.Parse(n) == 0) break;
}


int Silnia(int x)
{
    if (x == 0) return 1;

    return Silnia(x - 1) * x;
}

void CheckEven()
{
    Console.WriteLine("Podaj liczbę");
    var input = Console.ReadLine();

    Console.WriteLine(IsEven(int.Parse(input)) ? "Parzysta" : "Nieparzysta");
}

bool IsEven(int input)
{
    return input % 2 == 0;
}

void Game()
{
    var random = new Random();
    var numberToGuess = random.Next(100);
    var counter = 0;
    int guess;
    do
    {
        counter++;
        Console.WriteLine("Podaj liczbę od 0 do 100");
        guess = int.Parse(Console.ReadLine());

        if (guess > numberToGuess)
            Console.WriteLine("Zgadywana liczba jest mniejsza");
        if (guess < numberToGuess)
            Console.WriteLine("Zgadywana liczba jest większa");
    }
    while (guess != numberToGuess);

    Console.WriteLine($"Zadłeś za {counter}");
}