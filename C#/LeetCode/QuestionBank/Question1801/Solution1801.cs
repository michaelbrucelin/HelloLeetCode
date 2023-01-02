using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1801
{
    public class Solution1801 : Interface1801
    {
        public int GetNumberOfBacklogOrders(int[][] orders)
        {
            PriorityQueue<(int price, int amount), int> queue_buy = new PriorityQueue<(int price, int amount), int>(Comparer<int>.Create((i, j) => j - i));
            PriorityQueue<(int price, int amount), int> queue_sell = new PriorityQueue<(int price, int amount), int>();

            for (int i = 0; i < orders.Length; i++)
            {
                int price = orders[i][0], amount = orders[i][1], type = orders[i][2];
                if (type == 0)  // buy
                {
                    while (amount > 0 && queue_sell.Count > 0)
                    {
                        if (queue_sell.Peek().price <= price)
                        {
                            var order = queue_sell.Dequeue();
                            if (order.amount >= amount)
                            {
                                if (order.amount > amount) queue_sell.Enqueue((order.price, order.amount - amount), order.price);
                                amount = 0;
                                break;
                            }
                            else
                                amount -= order.amount;
                        }
                        else break;
                    }
                    if (amount > 0) queue_buy.Enqueue((price, amount), price);
                }
                else            // sell
                {
                    while (amount > 0 && queue_buy.Count > 0)
                    {
                        if (queue_buy.Peek().price >= price)
                        {
                            var order = queue_buy.Dequeue();
                            if (order.amount > amount)
                            {
                                if (order.amount > amount) queue_buy.Enqueue((order.price, order.amount - amount), order.price);
                                amount = 0;
                                break;
                            }
                            else
                                amount -= order.amount;
                        }
                        else break;
                    }
                    if (amount > 0) queue_sell.Enqueue((price, amount), price);
                }
            }

            long result = 0;
            const int MOD = 1000000007;
            while (queue_buy.Count > 0) { var order = queue_buy.Dequeue(); result = (result + order.amount) % MOD; }
            while (queue_sell.Count > 0) { var order = queue_sell.Dequeue(); result = (result + order.amount) % MOD; }

            return (int)result;
        }
    }
}
