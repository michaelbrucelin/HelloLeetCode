### 矩阵快速幂

递推关系为：
$$F(n) = F(n-1) + F(n-2) + F(n-3)$$
即
$$\begin{array}{lllll} \begin{bmatrix} F(n) \\ F(n-1) \\ F(n-2) \end{bmatrix} & = & \begin{bmatrix} 1 & 1 & 1 \\ 1 & 0 & 0 \\ 0 & 1 & 0 \end{bmatrix} & \times & \begin{bmatrix} F(n-1) \\ F(n-2) \\ F(n-3) \end{bmatrix} \\ & = & \begin{bmatrix} 1 & 1 & 1 \\ 1 & 0 & 0 \\ 0 & 1 & 0 \end{bmatrix}^{n-3} & \times & \begin{bmatrix} F(3) \\ F(2) \\ F(1) \end{bmatrix} \end{array}$$
