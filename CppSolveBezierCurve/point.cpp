#pragma once
#include "point.h"

point point::lerp(point a, point b, double t) {
    return point{
        a.x * (1 - t) + b.x * t,
        a.y * (1 - t) + b.y * t,
    };
}
