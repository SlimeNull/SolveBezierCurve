#pragma once
class point {
    public:
    double x;
    double y;

    static point lerp(point a, point b, double t);
};