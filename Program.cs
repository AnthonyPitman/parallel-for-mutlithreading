using System.Threading.Tasks;

// Parallel.For(0, 3, PrintIndex);
// 0 is inclusive, 3 is exclusive
// PrintIndex passes the method itself, without calling it here.

int[] values = { 3, 1, 5 };
int[] squares = new int[values.Length];

Parallel.For(0, values.Length, index =>
{
    squares[index] = values[index] * values[index];
});

foreach (var s in squares)
{
    Console.WriteLine(s);
}
// "index => ..." defines the callback; it does not execute it immediately

static void PrintIndex(int index)
{
    Console.WriteLine(index); // Parallel.For supplies this argument
}