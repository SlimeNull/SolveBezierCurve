#pragma once
#include <cstring>
#include "point.h"
#include "math_utilities.h"

template <size_t Size>
class bezier_curve {

    private:
    point _points[Size];
    static double solve_time_for_point(double controlPoint1, double controlPoint2, double point) {
        double a = -controlPoint1 + controlPoint2;
        double b = controlPoint1 - point;


        for (auto root : math_utilities::solve_linear_function(a, b)) {
            if (root < 0 || root > 1) {
                continue;
            }

            return root;
        }

        return NAN;
    }
    static double solve_time_for_point(double controlPoint1, double controlPoint2, double controlPoint3, double point) {
        double a = controlPoint1 - 2 * controlPoint2 + controlPoint3;
        double b = -2 * controlPoint1 + 2 * controlPoint2;
        double c = controlPoint1 - point;

        for (auto root : math_utilities::solve_quadratic_function(a, b, c)) {
            if (root < 0 || root > 1) {
                continue;
            }

            return root;
        }

        return NAN;
    }
    static double solve_time_for_point(double controlPoint1, double controlPoint2, double controlPoint3, double controlPoint4, double point) {
        double a = -controlPoint1 + 3 * controlPoint2 - 3 * controlPoint3 + controlPoint4;
        double b = 3 * controlPoint1 - 6 * controlPoint2 + 3 * controlPoint3;
        double c = -3 * controlPoint1 + 3 * controlPoint2;
        double d = controlPoint1 - point;

        for (auto root : math_utilities::solve_cubic_function(a, b, c, d)) {
            if (root < 0 || root > 1) {
                continue;
            }

            return root;
        }

        return NAN;
    }

    public:
    bezier_curve(const point points[Size]) {
        std::memcpy(_points, points, sizeof(point) * Size);
    }
    point solve(double t) {
        point buffer[Size];
        std::memcpy(buffer, _points, sizeof(point) * Size);

        size_t pointCount = Size;
        while (pointCount > 1) {
            for (size_t i = 0; i < pointCount - 1; i++) {
                buffer[i] = point::lerp(buffer[i], buffer[i + 1], t);
            }

            pointCount--;
        }

        return buffer[0];
    }
    double solve_time_for_point_x(double pointX) {
        if (Size == 2) {
            return solve_time_for_point(_points[0].x, _points[1].x, pointX);
        } else if (Size == 3) {
            return solve_time_for_point(_points[0].x, _points[1].x, _points[2].x, pointX);
        } else if (Size == 4) {
            return solve_time_for_point(_points[0].x, _points[1].x, _points[2].x, _points[3].x, pointX);
        } else {
            throw "not supported";
        }
    }
    double solve_time_for_point_y(double pointY) {
        if (Size == 2) {
            return solve_time_for_point(_points[0].y, _points[1].y, pointY);
        } else if (Size == 3) {
            return solve_time_for_point(_points[0].y, _points[1].y, _points[2].y, pointY);
        } else if (Size == 4) {
            return solve_time_for_point(_points[0].y, _points[1].y, _points[2].y, _points[3].y, pointY);
        } else {
            throw "not supported";
        }
    }
};