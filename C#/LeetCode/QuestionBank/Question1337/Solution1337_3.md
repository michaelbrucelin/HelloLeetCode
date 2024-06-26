#### [方法二：二分查找 + 快速选择](https://leetcode.cn/problems/the-k-weakest-rows-in-a-matrix/solutions/130589/fang-zhen-zhong-zhan-dou-li-zui-ruo-de-k-xing-by-l/)

**思路与算法**

我们也可以通过快速选择算法，在平均 $O(m)$ 的时间内不计顺序地内找出 $k$ 个最小的元素，再使用排序算法在 $O(k \log k)$ 的时间对这 $k$ 个最小的元素进行升序排序，就可以得到最终的答案。读者可以参考[「剑指 Offer 40. 最小的k个数」官方题解](https://leetcode-cn.com/problems/zui-xiao-de-kge-shu-lcof/solution/zui-xiao-de-kge-shu-by-leetcode-solution/)的方法三或者[「215. 数组中的第K个最大元素」的官方题解](https://leetcode-cn.com/problems/kth-largest-element-in-an-array/solution/shu-zu-zhong-de-di-kge-zui-da-yuan-su-by-leetcode-/)中的方法一了解快速选择算法，下面的代码将上述题解中的快速选择算法封装成一个 $Helper$ 类进行使用。

```cpp
template<typename T>
class Helper {
    static int partition(vector<T>& nums, int l, int r) {
        T pivot = nums[r];
        int i = l - 1;
        for (int j = l; j <= r - 1; ++j) {
            if (nums[j] <= pivot) {
                i = i + 1;
                swap(nums[i], nums[j]);
            }
        }
        swap(nums[i + 1], nums[r]);
        return i + 1;
    }

    // 基于随机的划分
    static int randomized_partition(vector<T>& nums, int l, int r) {
        int i = rand() % (r - l + 1) + l;
        swap(nums[r], nums[i]);
        return partition(nums, l, r);
    }

    static void randomized_selected(vector<T>& arr, int l, int r, int k) {
        if (l >= r) {
            return;
        }
        int pos = randomized_partition(arr, l, r);
        int num = pos - l + 1;
        if (k == num) {
            return;
        } else if (k < num) {
            randomized_selected(arr, l, pos - 1, k);
        } else {
            randomized_selected(arr, pos + 1, r, k - num);
        }
    }

public:
    static vector<T> getLeastNumbers(vector<T>& arr, int k) {
        srand((unsigned)time(NULL));
        randomized_selected(arr, 0, (int)arr.size() - 1, k);
        vector<T> vec;
        for (int i = 0; i < k; ++i) {
            vec.push_back(arr[i]);
        }
        return vec;
    }
};

class Solution {
public:
    vector<int> kWeakestRows(vector<vector<int>>& mat, int k) {
        int m = mat.size(), n = mat[0].size();
        vector<pair<int, int>> power;
        for (int i = 0; i < m; ++i) {
            int l = 0, r = n - 1, pos = -1;
            while (l <= r) {
                int mid = (l + r) / 2;
                if (mat[i][mid] == 0) {
                    r = mid - 1;
                }
                else {
                    pos = mid;
                    l = mid + 1;
                }
            }
            power.emplace_back(pos + 1, i);
        }

        vector<pair<int, int>> minimum = Helper<pair<int, int>>::getLeastNumbers(power, k);
        sort(minimum.begin(), minimum.begin() + k);
        vector<int> ans;
        for (int i = 0; i < k; ++i) {
            ans.push_back(minimum[i].second);
        }
        return ans;
    }
};
```

```java
class Solution {
    public int[] kWeakestRows(int[][] mat, int k) {
        int m = mat.length, n = mat[0].length;
        int[][] power = new int[m][2];
        for (int i = 0; i < m; ++i) {
            int l = 0, r = n - 1, pos = -1;
            while (l <= r) {
                int mid = (l + r) / 2;
                if (mat[i][mid] == 0) {
                    r = mid - 1;
                } else {
                    pos = mid;
                    l = mid + 1;
                }
            }
            power[i][0] = pos + 1;
            power[i][1] = i;
        }

        int[][] minimum = Helper.getLeastNumbers(power, k);
        Arrays.sort(minimum, new Comparator<int[]>() {
            public int compare(int[] pair1, int[] pair2) {
                if (pair1[0] != pair2[0]) {
                    return pair1[0] - pair2[0];
                } else {
                    return pair1[1] - pair2[1];
                }
            }
        });
        int[] ans = new int[k];
        for (int i = 0; i < k; ++i) {
            ans[i] = minimum[i][1];
        }
        return ans;
    }
}

class Helper {
    public static int[][] getLeastNumbers(int[][] arr, int k) {
        randomizedSelected(arr, 0, arr.length - 1, k);
        int[][] vec = new int[k][2];
        for (int i = 0; i < k; ++i) {
            vec[i][0] = arr[i][0];
            vec[i][1] = arr[i][1];
        }
        return vec;
    }

    private static void randomizedSelected(int[][] arr, int l, int r, int k) {
        if (l >= r) {
            return;
        }
        int pos = randomizedPartition(arr, l, r);
        int num = pos - l + 1;
        if (k == num) {
            return;
        } else if (k < num) {
            randomizedSelected(arr, l, pos - 1, k);
        } else {
            randomizedSelected(arr, pos + 1, r, k - num);
        }
    }

    // 基于随机的划分
    private static int randomizedPartition(int[][] nums, int l, int r) {
        int i = (int) (Math.random() * (r - l + 1)) + l;
        swap(nums, r, i);
        return partition(nums, l, r);
    }

    private static int partition(int[][] nums, int l, int r) {
        int[] pivot = nums[r];
        int i = l - 1;
        for (int j = l; j <= r - 1; ++j) {
            if (compare(nums[j], pivot) <= 0) {
                i = i + 1;
                swap(nums, i, j);
            }
        }
        swap(nums, i + 1, r);
        return i + 1;
    }

    private static void swap(int[][] nums, int i, int j) {
        int[] temp = new int[nums[i].length];
        System.arraycopy(nums[i], 0, temp, 0, nums[i].length);
        System.arraycopy(nums[j], 0, nums[i], 0, nums[i].length);
        System.arraycopy(temp, 0, nums[j], 0, nums[i].length);
    }

    private static int compare(int[] pair, int[] pivot) {
        if (pair[0] != pivot[0]) {
            return pair[0] - pivot[0];
        } else {
            return pair[1] - pivot[1];
        }
    }
}
```

```csharp
public class Solution {
    public int[] KWeakestRows(int[][] mat, int k) {
        int m = mat.Length, n = mat[0].Length;
        Tuple<int, int>[] power = new Tuple<int, int>[m];
        for (int i = 0; i < m; ++i) {
            int l = 0, r = n - 1, pos = -1;
            while (l <= r) {
                int mid = (l + r) / 2;
                if (mat[i][mid] == 0) {
                    r = mid - 1;
                } else {
                    pos = mid;
                    l = mid + 1;
                }
            }
            power[i] = new Tuple<int, int>(pos + 1, i);
        }

        Tuple<int, int>[] minimum = Helper.GetLeastNumbers(power, k);
        Array.Sort(minimum);
        int[] ans = new int[k];
        for (int i = 0; i < k; ++i) {
            ans[i] = minimum[i].Item2;
        }
        return ans;
    }
}

class Helper {
    static Random random = new Random();
    
    public static Tuple<int, int>[] GetLeastNumbers(Tuple<int, int>[] arr, int k) {
        RandomizedSelected(arr, 0, arr.Length - 1, k);
        Tuple<int, int>[] vec = new Tuple<int, int>[k];
        for (int i = 0; i < k; ++i) {
            vec[i] = arr[i];
        }
        return vec;
    }

    static void RandomizedSelected(Tuple<int, int>[] arr, int l, int r, int k) {
        if (l >= r) {
            return;
        }
        int pos = RandomizedPartition(arr, l, r);
        int num = pos - l + 1;
        if (k == num) {
            return;
        } else if (k < num) {
            RandomizedSelected(arr, l, pos - 1, k);
        } else {
            RandomizedSelected(arr, pos + 1, r, k - num);
        }
    }

    // 基于随机的划分
    static int RandomizedPartition(Tuple<int, int>[] nums, int l, int r) {
        int i = random.Next(r - l + 1) + l;
        Swap(nums, r, i);
        return Partition(nums, l, r);
    }

    static int Partition(Tuple<int, int>[] nums, int l, int r) {
        Tuple<int, int> pivot = nums[r];
        int i = l - 1;
        for (int j = l; j <= r - 1; ++j) {
            if (Compare(nums[j], pivot) <= 0) {
                i = i + 1;
                Swap(nums, i, j);
            }
        }
        Swap(nums, i + 1, r);
        return i + 1;
    }

    static void Swap(Tuple<int, int>[] nums, int i, int j) {
        Tuple<int, int> temp = nums[i];
        nums[i] = nums[j];
        nums[j] = temp;
    }

    static int Compare(Tuple<int, int> pair, Tuple<int, int> pivot) {
        if (pair.Item1 != pivot.Item1) {
            return pair.Item1 - pivot.Item1;
        } else {
            return pair.Item2 - pivot.Item2;
        }
    }
}
```

```python
class Helper:
    @staticmethod
    def partition(nums: List, l: int, r: int) -> int:
        pivot = nums[r]
        i = l - 1
        for j in range(l, r):
            if nums[j] <= pivot:
                i += 1
                nums[i], nums[j] = nums[j], nums[i]
        nums[i + 1], nums[r] = nums[r], nums[i + 1]
        return i + 1

    @staticmethod
    def randomized_partition(nums: List, l: int, r: int) -> int:
        i = random.randint(l, r)
        nums[r], nums[i] = nums[i], nums[r]
        return Helper.partition(nums, l, r)

    @staticmethod
    def randomized_selected(arr: List, l: int, r: int, k: int) -> None:
        pos = Helper.randomized_partition(arr, l, r)
        num = pos - l + 1
        if k < num:
            Helper.randomized_selected(arr, l, pos - 1, k)
        elif k > num:
            Helper.randomized_selected(arr, pos + 1, r, k - num)

    @staticmethod
    def getLeastNumbers(arr: List, k: int) -> List:
        Helper.randomized_selected(arr, 0, len(arr) - 1, k)
        return arr[:k]


class Solution:
    def kWeakestRows(self, mat: List[List[int]], k: int) -> List[int]:
        m, n = len(mat), len(mat[0])
        power = list()
        for i in range(m):
            l, r, pos = 0, n - 1, -1
            while l <= r:
                mid = (l + r) // 2
                if mat[i][mid] == 0:
                    r = mid - 1
                else:
                    pos = mid
                    l = mid + 1
            power.append((pos + 1, i))

        minimum = Helper.getLeastNumbers(power, k)[:k]
        minimum.sort()
        ans = [entry[1] for entry in minimum]
        return ans
```

```go
type pair struct{ pow, idx int }

func kWeakestRows(mat [][]int, k int) []int {
    m := len(mat)
    pairs := make([]pair, m)
    for i, row := range mat {
        pow := sort.Search(len(row), func(j int) bool { return row[j] == 0 })
        pairs[i] = pair{pow, i}
    }
    rand.Seed(time.Now().UnixNano())
    randomizedSelected(pairs, 0, m-1, k)
    pairs = pairs[:k]
    sort.Slice(pairs, func(i, j int) bool {
        a, b := pairs[i], pairs[j]
        return a.pow < b.pow || a.pow == b.pow && a.idx < b.idx
    })
    ans := make([]int, k)
    for i, p := range pairs {
        ans[i] = p.idx
    }
    return ans
}

func randomizedSelected(a []pair, l, r, k int) {
    if l >= r {
        return
    }
    pos := randomPartition(a, l, r)
    num := pos - l + 1
    if k == num {
        return
    }
    if k < num {
        randomizedSelected(a, l, pos-1, k)
    } else {
        randomizedSelected(a, pos+1, r, k-num)
    }
}

func randomPartition(a []pair, l, r int) int {
    i := rand.Intn(r-l+1) + l
    a[i], a[r] = a[r], a[i]
    return partition(a, l, r)
}

func partition(a []pair, l, r int) int {
    pivot := a[r]
    i := l - 1
    for j := l; j < r; j++ {
        if a[j].pow < pivot.pow || a[j].pow == pivot.pow && a[j].idx <= pivot.idx {
            i++
            a[i], a[j] = a[j], a[i]
        }
    }
    a[i+1], a[r] = a[r], a[i+1]
    return i + 1
}
```

**复杂度分析**

-   时间复杂度：$O(m \log n + k \log k)$：
    -   我们需要 $O(m \log n)$ 的时间对每一行进行二分查找。
    -   我们需要 $O(m)$ 的时间完成快速选择算法。
    -   我们需要 $O(k \log k)$ 的时间对这 $k$ 个最小的元素进行升序排序。
-   空间复杂度：$O(m)$，即为快速选择算法中的数组需要使用的空间。
