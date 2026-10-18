using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0478
{
    public class Solution0478_2
    {
    }

    /// <summary>
    /// 拒绝采样
    /// 在圆的外切正方形中采样，如果采用的点圆外，就重新采样，这个方法更通用
    /// </summary>
    public class Solution_2 : Interface0478
    {
        public Solution_2(double radius, double x_center, double y_center)
        {
            random = new Random();
            this.radius = radius;
            this.x_center = x_center;
            this.y_center = y_center;
            radius2 = radius * radius;
        }

        private Random random;
        private const long N = 1L << 53;                     // double 尾数精度为 53 位
        private double radius, x_center, y_center, radius2;

        public double[] RandPoint()
        {
            double x, y;
            do
            {
                x = NextDouble() * radius; y = NextDouble() * radius;
            } while (x * x + y * y > radius2);

            return [((random.Next(0, 2) << 1) - 1) * x + x_center, ((random.Next(0, 2) << 1) - 1) * y + y_center];
        }

        private double NextDouble()  // return [0,1]
        {
            return (double)random.NextInt64(0, N + 1) / N;  // [0, 1]
        }
    }
}
