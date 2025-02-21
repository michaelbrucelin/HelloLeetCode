using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3235
{
    public class Solution3235 : Interface3235
    {
        /// <summary>
        /// 分组，类并查集
        /// 1. 丢弃掉与矩形没有交集的圆
        /// 2. 将相交的圆分组，List<(HashSet<(int x, int y, int r)> Group, int xmin, int xmax, int ymin, int ymax)>
        ///     每一个HashSet是一组相交的圆
        ///     假定前N个圆已经分好组，那么第N+1圆，从前向后遍历每一组圆中的每一个圆，如果相交，加入，并记录id
        ///                                         从后向前遍历每一组圆中的每一个圆，如果相交，就这组圆合并到List[id].group中，然后删除这组圆
        ///                                         如果第N+1个圆不属于任何一个组，则自成一个组
        /// 3. 将矩形的左边+上边当成起点，下边+右边当成终点，问题等价于有没有一个组圆组成区域连接了起点与终点
        ///     每一组中维护int xmin, int xmax, int ymin, int ymax是为了剪枝，提前终止循环
        ///     如果一组圆连接了起点与终点，则 (xmin <= 0 || ymax >= yCorner） && (ymin <= 0 || xmax >= xCorner)
        ///                                 且 这组圆至少有一点与线段 {(0, 0) -> (xCorner, yCorner)} 相交
        /// 时间复杂度：O(N^2)
        /// 
        /// 思路是正确的，但是特殊情况没处理完，例如TestCase09，先不写了
        /// </summary>
        /// <param name="xCorner"></param>
        /// <param name="yCorner"></param>
        /// <param name="_circles"></param>
        /// <returns></returns>
        public bool CanReachCorner(int xCorner, int yCorner, int[][] circles)
        {
            // 移除与矩形没有交集的圆
            List<(int x, int y, int r)> list = new List<(int x, int y, int r)>();
            foreach (var c in circles)
            {
                if ((c[0] - c[2] <= 0 || c[1] + c[2] >= yCorner) && (c[0] + c[2] >= xCorner || c[1] - c[2] <= 0) && IsCircleIntersectLineSegment((c[0], c[1], c[2]), 0, 0, xCorner, yCorner)) return false;
                if (IsCircleIntersectRect((c[0], c[1], c[2]), 0, 0, xCorner, yCorner)) list.Add((c[0], c[1], c[2]));
            }
            if (list.Count == 0) return true;

            // 将圆分组
            List<(HashSet<(int x, int y, int r)> groups, int[] border)> groups = new List<(HashSet<(int x, int y, int r)> groups, int[] border)>();  // border: [xmin, xmax, ymin, ymax, 是否与中线相交]
            groups.Add((new HashSet<(int x, int y, int r)>() { (list[0].x, list[0].y, list[0].r) }, [list[0].x - list[0].r, list[0].x + list[0].r, list[0].y - list[0].r, list[0].y + list[0].r, 0]));
            if (IsCircleIntersectLineSegment(list[0], 0, 0, xCorner, yCorner)) groups[0].border[4] = 1;
            (int x, int y, int r) circle;
            for (int i = 1, pl = 0, pr = 0; i < list.Count; i++)
            {
                circle = (list[i].x, list[i].y, list[i].r);
                for (pl = 0; pl < groups.Count; pl++)
                {
                    foreach (var groug in groups[pl].groups) if (IsCircleIntersectCircle(circle, groug))
                        {
                            groups[pl].groups.Add(circle);
                            groups[pl].border[0] = Math.Min(groups[pl].border[0], circle.x - circle.r);
                            groups[pl].border[1] = Math.Max(groups[pl].border[1], circle.x + circle.r);
                            groups[pl].border[2] = Math.Min(groups[pl].border[2], circle.y - circle.r);
                            groups[pl].border[3] = Math.Max(groups[pl].border[3], circle.y + circle.r);
                            if (IsCircleIntersectLineSegment(circle, 0, 0, xCorner, yCorner)) groups[pl].border[4] = 1;
                            if ((groups[pl].border[0] <= 0 || groups[pl].border[3] >= yCorner) && (groups[pl].border[1] >= xCorner || groups[pl].border[2] <= 0) && groups[pl].border[4] == 1) return false;
                            goto FOUND;
                        }
                }
            FOUND:;
                if (pl == groups.Count)  // 不属于任何当前组
                {
                    groups.Add((new HashSet<(int x, int y, int r)>() { (circle.x, circle.y, circle.r) }, [circle.x - circle.r, circle.x + circle.r, circle.y - circle.r, circle.y + circle.r, 0]));
                    if (IsCircleIntersectLineSegment(circle, 0, 0, xCorner, yCorner)) groups[^1].border[4] = 1;
                    continue;
                }
                for (pr = groups.Count - 1; pr > pl; pr--)
                {
                    foreach (var groug in groups[pr].groups) if (IsCircleIntersectCircle(circle, groug))
                        {
                            groups[pl].groups.UnionWith(groups[pr].groups);
                            groups[pl].border[0] = Math.Min(groups[pl].border[0], groups[pr].border[0]);
                            groups[pl].border[1] = Math.Max(groups[pl].border[1], groups[pr].border[1]);
                            groups[pl].border[2] = Math.Min(groups[pl].border[2], groups[pr].border[2]);
                            groups[pl].border[3] = Math.Max(groups[pl].border[3], groups[pr].border[3]);
                            if (groups[pr].border[4] == 1) groups[pl].border[4] = 1;
                            if ((groups[pl].border[0] <= 0 || groups[pl].border[3] >= yCorner) && (groups[pl].border[1] >= xCorner || groups[pl].border[2] <= 0) && groups[pl].border[4] == 1) return false;
                            groups.RemoveAt(pr);
                            break;
                        }
                }
            }

            return true;

            // 如果两个圆有交集（包括外相切），返回true，否则，返回false
            bool IsCircleIntersectCircle((long x, long y, long r) c1, (long x, long y, long r) c2)
            {
                return (c1.x - c2.x) * (c1.x - c2.x) + (c1.y - c2.y) * (c1.y - c2.y) <= (c1.r + c2.r) * (c1.r + c2.r);
            }

            // 如果一个圆与一个矩形有交集（不包括外相切），返回true，否则，返回false
            bool IsCircleIntersectRect((long x, long y, long r) circle, long x1, long y1, long x2, long y2)
            {
                long dist = 0;
                if (circle.x < x1 || circle.x > x2)
                {
                    dist += Math.Min((x1 - circle.x) * (x1 - circle.x), (x2 - circle.x) * (x2 - circle.x));
                }
                if (circle.y < y1 || circle.y > y2)
                {
                    dist += Math.Min((y1 - circle.y) * (y1 - circle.y), (y2 - circle.y) * (y2 - circle.y));
                }

                return dist < circle.r * circle.r;
            }

            // 如果一个圆与一个线段有交集（包括外相切），返回true，否则，返回false
            bool IsCircleIntersectLineSegment((long x, long y, long r) circle, long x1, long y1, long x2, long y2)
            {
                if ((circle.x - x1) * (circle.x - x1) + (circle.y - y1) * (circle.y - y1) <= circle.r * circle.r ||
                    (circle.x - x2) * (circle.x - x2) + (circle.y - y2) * (circle.y - y2) <= circle.r * circle.r) return true;

                // 计算线段的方向向量
                double dx = x2 - x1;
                double dy = y2 - y1;

                // 计算从 P1 到圆心的向量
                double v1x = circle.x - x1;
                double v1y = circle.y - y1;

                // 计算投影系数 t
                double t = (v1x * dx + v1y * dy) / (dx * dx + dy * dy);

                // 判断投影点的位置
                if (t < 0)
                {
                    // 最近点是 P1
                    return (Math.Pow(circle.x - x1, 2) + Math.Pow(circle.y - y1, 2)) <= (circle.r * circle.r);
                }
                else if (t > 1)
                {
                    // 最近点是 P2
                    return (Math.Pow(circle.x - x2, 2) + Math.Pow(circle.y - y2, 2)) <= (circle.r * circle.r);
                }
                else
                {
                    // 最近点是投影点
                    double nearestX = x1 + t * dx;
                    double nearestY = y1 + t * dy;
                    return (Math.Pow(circle.x - nearestX, 2) + Math.Pow(circle.y - nearestY, 2)) <= (circle.r * circle.r);
                }
            }
        }
    }
}
