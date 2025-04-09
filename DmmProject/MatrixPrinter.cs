namespace DmmProject;

public static class MatrixPrinter
{
    public static void PrintMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
                Console.Write(matrix[i, j].ToString().PadLeft(4));
            Console.WriteLine();
        }
    }
}