using Classes;

class Program
{
    static void Main()
    {
        Unit unit = new Unit("Knight");

        Console.WriteLine(unit.Name);
        Console.WriteLine(unit.Health);

        bool isDead = unit.SetDamage(20);

        Console.WriteLine(unit.Health);
        Console.WriteLine("Game over: " + isDead);
    }
}