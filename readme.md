# Solve Bezier Curve

贝塞尔曲线常被用于过渡动画中, 但贝塞尔曲线函数的参数 t 与其返回的结果的 X 坐标不成正比.

所以, 一般使用时, 都是先根据 x 求出合适的 t, 再去根据 t 计算 y.

这个仓库包含了贝塞尔曲线的抽象, 以及二阶, 三阶贝塞尔曲线通过 x 求解 t 的方法.

> 基本原理是解方程, 而不是循环逼近或二分法

---

Bézier curves are often used in transition animations, but the parameter t of the Bézier function is not proportional to the X-coordinate of the result it returns.

Therefore, it is usually used to find the appropriate t from x, and then compute y from t.

This repository contains abstractions of Bézier curves, and methods for solving t from x for second- and third-order Bézier curves.

> The basic principle is to solve equations, not loop approximations or dichotomies.