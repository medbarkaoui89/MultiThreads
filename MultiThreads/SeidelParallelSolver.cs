using System;
using System.Linq;
using System.Threading.Tasks;

public class SeidelParallelSolver
{
    public double[] Solve(LinearSystemData data)
    {
        // Validate input data
        int n = data.B.Length;
        if (data.A.Length != n || data.A.Any(row => row.Length != n))
        {
            throw new ArgumentException("Matrix A must be square and match the length of vector B.");
        }

        double[] x = new double[n];
        int k = 0;
        double currentError;

        do
        {
            double[] xOld = (double[])x.Clone();

            // Parallel computation for each element in x
            Parallel.For(0, n, i =>
            {
                double sum = 0;
                for (int j = 0; j < n; j++)
                {
                    if (i != j)
                        sum += data.A[i][j] * xOld[j];
                }
                x[i] = (data.B[i] - sum) / data.A[i][i]; // Calculate new value for x
            });

            currentError = CalculateError(x, xOld);
            k++;

        } while (currentError > data.Epsilon && k < data.MaxIterations);

        return x;
    }

    private double CalculateError(double[] xNew, double[] xOld)
    {
        return xNew.Zip(xOld, (n, o) => Math.Abs(n - o)).Max();
    }
}

public class LinearSystemData
{
    public double[][] A { get; set; } // Coefficient matrix
    public double[] B { get; set; }    // Constants vector
    public double Epsilon { get; set; } // Error tolerance
    public int MaxIterations { get; set; } // Maximum iterations
}

class Program
{
    static void Main(string[] args)
    {
        var solver = new SeidelParallelSolver();
        var data = new LinearSystemData
        {
            A = new double[][]
            {
                new double[] { 4, -1, 0, 0 },
                new double[] { -1, 4, -1, 0 },
                new double[] { 0, -1, 4, -1 },
                new double[] { 0, 0, -1, 3 }
            },
            B = new double[] { 15, 10, 10, 10 },
            Epsilon = 1e-10,
            MaxIterations = 1000
        };

        var solution = solver.Solve(data);
        Console.WriteLine(string.Join(", ", solution));
    }
}