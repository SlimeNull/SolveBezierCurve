using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SolveBezierCurve
{
    internal static class MathUtilities
    {
        /// <summary>
        /// 解一元一次方程 (标准形式)
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static IEnumerable<double> SolveLinearFunction(double a, double b)
        {
            yield return -b / a;
        }

        /// <summary>
        /// 解一元二次方程 (标准形式)
        /// </summary>
        /// <param name="a">二次项系数</param>
        /// <param name="b">一次项系数</param>
        /// <param name="c">常数项</param>
        /// <returns></returns>
        public static IEnumerable<double> SolveQuadraticFunction(double a, double b, double c)
        {
            if (a == 0)
            {
                foreach (var root in SolveLinearFunction(b, c))
                {
                    yield return root;
                }

                yield break;
            }

            var delta = b * b - 4 * a * c;
            if (delta < 0)
            {
                // 没有实数根
                yield break;
            }

            var x1 = (-b + Math.Sqrt(delta)) / (2 * a);
            yield return x1;

            if (delta == 0)
            {
                yield break;
            }

            var x2 = (-b - Math.Sqrt(delta)) / (2 * a);
            yield return x2;
        }

        /// <summary>
        /// 解一元三次方程 (标准形式)
        /// </summary>
        /// <param name="a">三次项系数</param>
        /// <param name="b">二次项系数</param>
        /// <param name="c">一次项系数</param>
        /// <param name="d">常数项</param>
        /// <returns></returns>
        public static IEnumerable<double> SolveCubicFunction(double a, double b, double c, double d)
        {
            if (a == 0)
            {
                foreach (var root in SolveQuadraticFunction(b, c, d))
                {
                    yield return root;
                }

                yield break;
            }

            // 盛金公式法

            double bigA = b * b - 3 * a * c;
            double bigB = b * c - 9 * a * d;
            double bigC = c * c - 3 * b * d;

            double delta = bigB * bigB - 4 * bigA * bigC;

            if (bigA == bigB && bigA == 0)
            {
                // 三个相同的实数根
                yield return -c / b;
                yield break;
            }
            else if (delta > 0)
            {
                var bigY1 = bigA * b + 3 * a * ((-bigB + Math.Sqrt(delta)) / 2);
                var bigY2 = bigA * b + 3 * a * ((-bigB - Math.Sqrt(delta)) / 2);

                // 只有一个实数根, 剩下两个是虚的
                yield return (-b - (Math.Pow(bigY1, 1.0 / 3.0) + Math.Pow(bigY2, 1.0 / 3.0))) / (3 * a);
            }
            else if (delta == 0)
            {
                var bigK = bigB / bigA;

                yield return -b / a + bigK;

                // 两个相同的实数根
                yield return -bigK / 2;
            }
            else
            {
                var bigT = (2 * bigA * b - 3 * a * bigB) / (2 * Math.Pow(bigA, 3.0 / 2.0));
                var theta = Math.Acos(bigT);

                // 三个根
                yield return (-b - 2 * Math.Sqrt(bigA) * Math.Cos(theta / 3)) / (3 * a);
                yield return (-b + Math.Sqrt(bigA) * (Math.Cos(theta / 3) + Math.Sqrt(3) * Math.Sin(theta / 3))) / (3 * a);
                yield return (-b + Math.Sqrt(bigA) * (Math.Cos(theta / 3) - Math.Sqrt(3) * Math.Sin(theta / 3))) / (3 * a);
            }
        }
    }
}
