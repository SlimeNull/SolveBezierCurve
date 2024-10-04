# Solve Bezier Curve

���������߳������ڹ��ɶ�����, �����������ߺ����Ĳ��� t ���䷵�صĽ���� X ���겻������.

����, һ��ʹ��ʱ, �����ȸ��� x ������ʵ� t, ��ȥ���� t ���� y.

����ֿ�����˱��������ߵĳ���, �Լ�����, ���ױ���������ͨ�� x ��� t �ķ���.

> ����ԭ���ǽⷽ��, ������ѭ���ƽ�����ַ�

---

B��zier curves are often used in transition animations, but the parameter t of the B��zier function is not proportional to the X-coordinate of the result it returns.

Therefore, it is usually used to find the appropriate t from x, and then compute y from t.

This repository contains abstractions of B��zier curves, and methods for solving t from x for second- and third-order B��zier curves.

> The basic principle is to solve equations, not loop approximations or dichotomies.