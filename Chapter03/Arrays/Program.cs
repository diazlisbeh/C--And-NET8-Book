
string[,] grid1 =
{
     { "Alpha", "Beta", "Gamma", "Delta" },
  { "Anne", "Ben", "Charlie", "Doug" },
  { "Aardvark", "Bear", "Cat", "Dog" }
};

WriteLine($"1st dimension, lower bound: {grid1.GetLowerBound(0)}");
WriteLine($"1st dimension, upper bound: {grid1.GetUpperBound(0)}");
WriteLine($"2st dimension, lower bound: {grid1.GetLowerBound(1)}");
WriteLine($"2st dimension, upper bound: {grid1.GetUpperBound(1)}");

for(int row = 0; row < grid1.GetUpperBound(0); row++)
{
    for(int col = 0; col < grid1.GetUpperBound(1); col++)
    {
        WriteLine($"Row {row}, Column {col}: {grid1[row, col]}");
    }
}
