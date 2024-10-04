// CppSolveBezierCurve.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <sstream>
#include "point.h"
#include "bezier_curve.hpp"

int main() {
    point curve_points[4] = {
        point { 0, 0 },
        point { .16, .67 },
        point { .78, .39 },
        point { 1, 1 },
    };
    
    auto curve = bezier_curve<4>(curve_points);
    auto t = 0.6;
    auto p = curve.solve(t);
    auto solvedTime = curve.solve_time_for_point_x(p.x);

    std::stringstream output_stream = {};
    output_stream << "t: " << t << ", p: (" << p.x << ", " << p.y << ") solved t: " << solvedTime;

    std::cout << output_stream.str() << std::endl;
}

// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
