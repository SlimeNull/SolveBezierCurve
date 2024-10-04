#include <vector>
#include "math_utilities.h"

namespace math_utilities {
    /// <summary>
    /// 解一元一次方程 (标准形式)
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    std::vector<double> solve_linear_function(double a, double b) {
        std::vector<double> result = std::vector<double>();
        result.push_back(-b / a);

        return result;
    }

    /// <summary>
    /// 解一元二次方程 (标准形式)
    /// </summary>
    /// <param name="a">二次项系数</param>
    /// <param name="b">一次项系数</param>
    /// <param name="c">常数项</param>
    /// <returns></returns>
    std::vector<double> solve_quadratic_function(double a, double b, double c) {
        if (a == 0) {
            return solve_linear_function(b, c);
        }

        std::vector<double> result = std::vector<double>();

        auto delta = b * b - 4 * a * c;
        if (delta < 0) {
            // 没有实数根
            return result;
        }

        auto x1 = (-b + sqrt(delta)) / (2 * a);
        result.push_back(x1);

        if (delta == 0) {
            return result;
        }

        auto x2 = (-b - sqrt(delta)) / (2 * a);
        result.push_back(x2);
        return result;
    }

    /// <summary>
    /// 解一元三次方程 (标准形式)
    /// </summary>
    /// <param name="a">三次项系数</param>
    /// <param name="b">二次项系数</param>
    /// <param name="c">一次项系数</param>
    /// <param name="d">常数项</param>
    /// <returns></returns>
    std::vector<double> solve_cubic_function(double a, double b, double c, double d) {
        if (a == 0) {
            return solve_quadratic_function(b, c, d);
        }

        // 盛金公式法
        std::vector<double> result = std::vector<double>();

        double bigA = b * b - 3 * a * c;
        double bigB = b * c - 9 * a * d;
        double bigC = c * c - 3 * b * d;

        double delta = bigB * bigB - 4 * bigA * bigC;

        if (bigA == bigB && bigA == 0) {
            // 三个相同的实数根
            result.push_back(-c / b);
            return result;
        } else if (delta > 0) {
            auto bigY1 = bigA * b + 3 * a * ((-bigB + sqrt(delta)) / 2);
            auto bigY2 = bigA * b + 3 * a * ((-bigB - sqrt(delta)) / 2);

            // 只有一个实数根, 剩下两个是虚的
            result.push_back((-b - (pow(bigY1, 1.0 / 3.0) + pow(bigY2, 1.0 / 3.0))) / (3 * a));
        } else if (delta == 0) {
            auto bigK = bigB / bigA;

            result.push_back(-b / a + bigK);

            // 两个相同的实数根
            result.push_back(-bigK / 2);
        } else {
            auto bigT = (2 * bigA * b - 3 * a * bigB) / (2 * pow(bigA, 3.0 / 2.0));
            auto theta = acos(bigT);

            // 三个根
            auto x1 = (-b - 2 * sqrt(bigA) * cos(theta / 3)) / (3 * a);
            auto x2 = (-b + sqrt(bigA) * (cos(theta / 3) + sqrt(3) * sin(theta / 3))) / (3 * a);
            auto x3 = (-b + sqrt(bigA) * (cos(theta / 3) - sqrt(3) * sin(theta / 3))) / (3 * a);

            result.push_back(x1);
            result.push_back(x2);
            result.push_back(x3);
        }

        return result;
    }
}