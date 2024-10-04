namespace SolveBezierCurve
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var curve = new BezierCurve([new Point(0, 0), new Point(.16, .67), new Point(.78, .39), new Point(1, 1)]);
            var t = 0.6;
            var p = curve.Solve(t);
            var solvedTime = curve.SolveTimeForPointX(p.X);

            Console.WriteLine($"t: {t}, p: {p}, solved t: {solvedTime}");
        }
    }
}
