using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0306
{
    /// <summary>
    /// Your AnimalShelf object will be instantiated and called as such:
    /// AnimalShelf obj = new AnimalShelf();
    /// obj.Enqueue(animal);
    /// int[] param_2 = obj.DequeueAny();
    /// int[] param_3 = obj.DequeueDog();
    /// int[] param_4 = obj.DequeueCat();
    /// </summary>
    public interface Interface0306
    {
        // public AnimalShelf();

        public void Enqueue(int[] animal);

        public int[] DequeueAny();

        public int[] DequeueDog();

        public int[] DequeueCat();
    }
}
