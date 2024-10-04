using System.Numerics;

namespace SolveBezierCurve
{
    public class BezierCurve
    {
        private readonly Point[] _points;

        public BezierCurve(IEnumerable<Point> points)
        {
            ArgumentNullException.ThrowIfNull(points);

            _points = points.ToArray();

            if (_points.Length < 1)
            {
                throw new ArgumentException("Point count can not be less than 1");
            }
        }

        private double SolveTimeForPoint(double controlPoint1, double controlPoint2, double point)
        {
            double a = -controlPoint1 + controlPoint2;
            double b = controlPoint1  - point;


            foreach (var root in MathUtilities.SolveLinearFunction(a, b))
            {
                if (root < 0 || root > 1)
                {
                    continue;
                }

                return root;
            }

            return double.NaN;
        }

        private double SolveTimeForPoint(double controlPoint1, double controlPoint2, double controlPoint3, double point)
        {
            double a = controlPoint1 - 2 * controlPoint2 + controlPoint3;
            double b = -2 * controlPoint1 + 2 * controlPoint2;
            double c = controlPoint1 - point;

            foreach (var root in MathUtilities.SolveQuadraticFunction(a, b, c))
            {
                if (root < 0 || root > 1)
                {
                    continue;
                }

                return root;
            }

            return double.NaN;
        }

        private double SolveTimeForPoint(double controlPoint1, double controlPoint2, double controlPoint3, double controlPoint4, double point)
        {
            double a = -controlPoint1 + 3 * controlPoint2 - 3 * controlPoint3 + controlPoint4;
            double b = 3 * controlPoint1 - 6 * controlPoint2 + 3 * controlPoint3;
            double c = -3 * controlPoint1 + 3 * controlPoint2;
            double d = controlPoint1 - point;

            foreach (var root in MathUtilities.SolveCubicFunction(a, b, c, d))
            {
                if (root < 0 || root > 1)
                {
                    continue;
                }

                return root;
            }

            return double.NaN;
        }

        /// <summary>
        /// 传入进度 t 值, 求曲线上点坐标
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public Point Solve(double t)
        {
            Point[] buffer = new Point[_points.Length];
            _points.CopyTo(buffer, 0);

            int pointCount = _points.Length;
            while (pointCount > 1)
            {
                for (int i = 0; i < pointCount - 1; i++)
                {
                    buffer[i] = Point.Lerp(buffer[i], buffer[i + 1], t);
                }

                pointCount--;
            }

            return buffer[0];
        }

        /// <summary>
        /// 根据曲线上某点的 X 值求解 t 参数
        /// </summary>
        /// <param name="pointX"></param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>
        public double SolveTimeForPointX(double pointX)
        {
            if (_points.Length == 2)
            {
                return SolveTimeForPoint(_points[0].X, _points[1].X, pointX);
            }
            else if (_points.Length == 3)
            {
                return SolveTimeForPoint(_points[0].X, _points[1].X, _points[2].X, pointX);
            }
            else if (_points.Length == 4)
            {
                return SolveTimeForPoint(_points[0].X, _points[1].X, _points[2].X, _points[3].X, pointX);
            }
            else
            {
                throw new NotSupportedException();
            }
        }

        /// <summary>
        /// 根据曲线上某点的 Y 值求解 t 参数
        /// </summary>
        /// <param name="pointY"></param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>
        public double SolveTimeForPointY(double pointY)
        {
            if (_points.Length == 2)
            {
                return SolveTimeForPoint(_points[0].Y, _points[1].Y, pointY);
            }
            else if (_points.Length == 3)
            {
                return SolveTimeForPoint(_points[0].Y, _points[1].Y, _points[2].Y, pointY);
            }
            else if (_points.Length == 4)
            {
                return SolveTimeForPoint(_points[0].Y, _points[1].Y, _points[2].Y, _points[3].Y, pointY);
            }
            else
            {
                throw new NotSupportedException();
            }
        }
    }
}
