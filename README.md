# parallel-for-mutlithreading

## Week 7 \* Multithreading: Understand the `Parallel.For` callback

**Time**: 30-45 minutes
**Dependencies**: .NET SDK; no external packages.

This revisits the callback syntax from Week 2. The main concept is passing a function for `Parallel.For` to call.

## Coding task

Build a console app that calculates the squares of an array's values, placing each result at the corresponding index.

### Minimal working checkpoint -- first 10-15 minutes

Run this small example:

```cs
using System.Threading.Tasks;

Parallel.For(0, 3, PrintIndex);
// 0 is inclusive; 3 is exclusive.
// PrintIndex passes the method itself, without calling it here.

static void PrintIndex(int index)
{
    Console.WriteLine(index); // Parallel.For supplies this argument.
}
```

Confirm that `0`, `1`, and `2` each appear once. Their printed order can vary.

The third argument is an `Action<int>`: a callback that accepts one integer and returns nothing. The equivalent lambda syntax is:

```cs
Parallel.For(0, 3, index =>
{
    Console.WriteLine(index);
});
// "index => ..." defines the callback; it does not execute it immediately.
```

### Complete the project -- remaining 20-30 minutes

Use these fixed inputs:

```cs
int[] values = {2, 4, 6, 8};
int[] squares = new int[values.Length];
```

Replace the printing callback with a lambda that calculates and stores one square. After `Parallel.For` returns, print the results in array order.

Keep the task synchronous. Use the simple callback overload shown above; shared counters, timing, and error handling can wait.

## Acceptance criteria

- Output after the loop is `4, 16, 36, 64`.
- Changing the inputs to `{ 3, 1, 5 }` produces `9, 1, 25`.
- You can explain what supplies `index` and why `PrintIndex` has no parentheses when passed as an argument.

## Underlying concept

`Parallel.For` controls when and where callback invocations execute. Each iteration writes to a distinct array element, avoiding competing updates to the same location. The call waits for its iterations to finish before your final printing loop runs.

**Optional stretch question**: Why can printing inside the callback produce a different order while storing by index and printing afterward preserves input order?
