using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1801
{
    public class Solution1801_2 : Interface1801
    {
        /// <summary>
        /// 与Solution1801一样，但是将重复的代码合并为一段代码
        /// </summary>
        /// <param name="orders"></param>
        /// <returns></returns>
        public int GetNumberOfBacklogOrders(int[][] orders)
        {
            PriorityQueue<(int price, int amount), int> queue_buy = new PriorityQueue<(int price, int amount), int>(Comparer<int>.Create((i, j) => j - i));
            PriorityQueue<(int price, int amount), int> queue_sell = new PriorityQueue<(int price, int amount), int>();

            PriorityQueue<(int price, int amount), int> producer, consumer;
            Func<int, int, bool> comparer, le = (i, j) => i <= j, ge = (i, j) => i >= j;
            for (int i = 0; i < orders.Length; i++)
            {
                int price = orders[i][0], amount = orders[i][1], type = orders[i][2];

                if (type == 0)  // buy
                {
                    producer = queue_sell; consumer = queue_buy; comparer = le;
                }
                else            // sell
                {
                    producer = queue_buy; consumer = queue_sell; comparer = ge;
                }

                while (amount > 0 && producer.Count > 0)
                {
                    if (comparer(producer.Peek().price, price))
                    {
                        var order = producer.Dequeue();
                        if (order.amount >= amount)
                        {
                            if (order.amount > amount) producer.Enqueue((order.price, order.amount - amount), order.price);
                            amount = 0;
                            break;
                        }
                        else
                            amount -= order.amount;
                    }
                    else break;
                }
                if (amount > 0) consumer.Enqueue((price, amount), price);
            }

            long result = 0;
            const int MOD = 1000000007;
            while (queue_buy.Count > 0) { var order = queue_buy.Dequeue(); result = (result + order.amount) % MOD; }
            while (queue_sell.Count > 0) { var order = queue_sell.Dequeue(); result = (result + order.amount) % MOD; }

            return (int)result;
        }
    }
}
