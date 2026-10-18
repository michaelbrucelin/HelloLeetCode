using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0478
{
    public class Solution0478
    {
    }

    /// <summary>
    /// 数学
    /// 采用圆的极坐标方程的思路随机，即先随机角度，再随机距离
    /// </summary>
    public class Solution : Interface0478
    {
        public Solution(double radius, double x_center, double y_center)
        {
            random = new Random();
            this.radius = radius;
            this.x_center = x_center;
            this.y_center = y_center;
        }

        private Random random;
        private const long N = 1L << 53;                       // double 尾数精度为 53 位
        private double radius, x_center, y_center;

        public double[] RandPoint()
        {
            double angle = random.NextDouble() * Math.PI * 2;
            // double dist = this.NextDouble() * radius;       // 这样分布会集中到圆心附近
            double dist = Math.Sqrt(NextDouble()) * radius;

            return [dist * Math.Cos(angle) + x_center, dist * Math.Sin(angle) + y_center];
        }

        private double NextDouble()  // return [0,1]
        {
            return (double)random.NextInt64(0, N + 1) / N;     // [0, 1]
        }
    }
}
