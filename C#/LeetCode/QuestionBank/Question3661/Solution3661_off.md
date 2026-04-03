### [可以被机器人摧毁的最大墙壁数目](https://leetcode.cn/problems/maximum-walls-destroyed-by-robots/solutions/3941251/ke-yi-bei-ji-qi-ren-cui-hui-de-zui-da-qi-xibl/)

#### 方法一：二分查找 $+$ 动态规划

由于题目并未给出顺序的机器人以及墙壁的位置，所以我们首先需要对机器人以及墙壁进行排序，在对机器人排序之前需要建立机器人的位置与其攻击距离的映射，这里可以使用哈希表，映射为 $robotsToDistance[robots[i]]=distance[i]$。

对于每个机器人，题目给出了它的最大攻击距离，那么每个机器人向左和向右能够攻击到的范围便能够计算出来，这里要注意，如果一个机器人的子弹射到了另一个机器人上，那么子弹会立马停止，无法继续前进，这里我们预设与某机器人重合的墙壁只有这个机器人能打到，其他相邻的机器人无法打到。因此机器人的攻击范围如下：

- 向左攻击范围为：
  - 当左边有机器人时：$(max(robots[i]-robotsToDistance[robots[i]],robots[i-1]+1),robots[i]]$
  - 当左边没有机器人时：$(robots[i]-robotsToDistance[robots[i]],robots[i]]$
- 向右攻击范围为：
  - 当右边有机器人时：$[robots[i],min(robots[i]+robotsToDistance[robots[i]],robots[i+1]-1))$
  - 当右边没有机器人时：$[robots[i],robots[i]+robotsToDistance[robots[i]])$

因为排序后墙壁的位置有序，那么我们可以通过二分查找来确定每个机器人向左和向右能够攻击到的墙壁的数量。这里使用 $left[i]$ 以及 $right[i]$ 来表示第 $i$ 个机器人向左和向右能够攻击到的墙壁的数量。除此之外，还需要统计每两个机器人之间的墙壁数量，同样可以使用二分查找统计出来，这里使用 $num[i]$ 来表示第 $i$ 个机器人与第 $i-1$ 个机器人之间的墙壁数量。

接下来用动态规划来计算每个机器朝左或朝右仅射出一枪后，能够击穿墙壁的最大数量，这里使用 $dp[i][0]$ 来表示第 $i$ 个机器人向左射出一枪后，前 $i$ 个机器人总共击穿墙壁的最大数量。同样的，使用dp[i][1] 来表示第 $i$ 个机器人向右射出一枪后，前 $i$ 个机器人总共击穿墙壁的最大数量。

当 $i$ 为 $0$ 时，初始化为：$dp[i][0]=left[0],dp[i][1]=right[0]$。

假设第 $i$ 个机器人向左射击，那么递推式为：$dp[i][0]=max(dp[i-1][0]+left[i],dp[i-1][1]-right[i-1]+min(right[i-1]+left[i],num[i]))$。

假设第 $i$ 个机器人向右射击，那么递推式为：$dp[i][1]=max(dp[i-1][0]+right[i],dp[i-1][1]+right[i])$。

容易发现，在进行动态规划的过程中，当前状态仅依赖于上一个状态，那么使用滚动数组的方式，将 $dp$ 数组压缩至一维，使用 $subLeft$ 以及 $subRight$ 来代表上一个状态中的 $dp[i][0]$ 以及 $dp[i][0]$，使用 $currentLeft$ 以及 $currentRight$ 来代表当前状态中的 $dp[i][0]$ 以及 $dp[i][0]$ 即可。

最终的答案即为 $subLeft$ 以及 $subRight$ 中的较大值。

```C++
class Solution {
public:
    int maxWalls(vector<int>& robots, vector<int>& distance, vector<int>& walls) {
        int n = robots.size();
        int pos1, pos2, pos3, leftPos, rightPos;
        vector<int> left(n, 0), right(n, 0), num(n, 0);
        unordered_map<int, int> robotsToDistance;
        for (int i = 0; i < n; i++) {
            robotsToDistance[robots[i]] = distance[i];
        }
        sort(robots.begin(), robots.end());
        sort(walls.begin(), walls.end());
        for (int i = 0; i < n; i++) {
            pos1 = upper_bound(walls.begin(), walls.end(), robots[i]) - walls.begin();
            if (i >= 1) {
                leftPos = lower_bound(walls.begin(), walls.end(), max(robots[i] - robotsToDistance[robots[i]], robots[i - 1] + 1)) - walls.begin();
            }
            else {
                leftPos = lower_bound(walls.begin(), walls.end(), robots[i] - robotsToDistance[robots[i]]) - walls.begin();
            }
            left[i] = pos1 - leftPos;
            if (i < n - 1) {
                rightPos = upper_bound(walls.begin(), walls.end(), min(robots[i] + robotsToDistance[robots[i]], robots[i + 1] - 1)) - walls.begin();
            }
            else {
                rightPos = upper_bound(walls.begin(), walls.end(), robots[i] + robotsToDistance[robots[i]]) - walls.begin();
            }
            pos2 = lower_bound(walls.begin(), walls.end(), robots[i]) - walls.begin();
            right[i] = rightPos - pos2;
            if (i == 0) {
                continue;
            }
            pos3 = lower_bound(walls.begin(), walls.end(), robots[i - 1]) - walls.begin();
            num[i] = pos1 - pos3;
        }
        int subLeft, subRight, currentLeft, currentRight;
        subLeft = left[0];
        subRight = right[0];
        for (int i = 1; i < n; i++) {
            currentLeft = max(subLeft + left[i], subRight - right[i - 1] + min(left[i] + right[i - 1], num[i]));
            currentRight = max(subLeft + right[i], subRight + right[i]);
            subLeft = currentLeft;
            subRight = currentRight;
        }
        return max(subLeft, subRight);
    }
};
```

```Go
func maxWalls(robots []int, distance []int, walls []int) int {
    n := len(robots)
    left := make([]int, n)
    right := make([]int, n)
    num := make([]int, n)
    robotsToDistance := make(map[int]int)

    for i := 0; i < n; i++ {
        robotsToDistance[robots[i]] = distance[i]
    }

    sort.Ints(robots)
    sort.Ints(walls)

    for i := 0; i < n; i++ {
        pos1 := sort.SearchInts(walls, robots[i]+1)

        var leftPos int
        if i >= 1 {
            leftBound := max(robots[i]-robotsToDistance[robots[i]], robots[i-1]+1)
            leftPos = sort.SearchInts(walls, leftBound)
        } else {
            leftPos = sort.SearchInts(walls, robots[i]-robotsToDistance[robots[i]])
        }
        left[i] = pos1 - leftPos

        var rightPos int
        if i < n-1 {
            rightBound := min(robots[i]+robotsToDistance[robots[i]], robots[i+1]-1)
            rightPos = sort.SearchInts(walls, rightBound+1)
        } else {
            rightPos = sort.SearchInts(walls, robots[i]+robotsToDistance[robots[i]]+1)
        }
        pos2 := sort.SearchInts(walls, robots[i])
        right[i] = rightPos - pos2

        if i == 0 {
            continue
        }
        pos3 := sort.SearchInts(walls, robots[i-1])
        num[i] = pos1 - pos3
    }

    subLeft, subRight := left[0], right[0]
    for i := 1; i < n; i++ {
        currentLeft := max(subLeft+left[i], subRight-right[i-1]+min(left[i]+right[i-1], num[i]))
        currentRight := max(subLeft+right[i], subRight+right[i])
        subLeft, subRight = currentLeft, currentRight
    }

    return max(subLeft, subRight)
}

func max(a, b int) int {
    if a > b {
        return a
    }
    return b
}

func min(a, b int) int {
    if a < b {
        return a
    }
    return b
}
```

```Python
class Solution:
    def maxWalls(self, robots: List[int], distance: List[int], walls: List[int]) -> int:
        n = len(robots)
        left = [0] * n
        right = [0] * n
        num = [0] * n
        robots_to_distance = {}

        for i in range(n):
            robots_to_distance[robots[i]] = distance[i]

        robots.sort()
        walls.sort()

        for i in range(n):
            pos1 = bisect.bisect_right(walls, robots[i])

            if i >= 1:
                left_bound = max(robots[i] - robots_to_distance[robots[i]], robots[i - 1] + 1)
                left_pos = bisect.bisect_left(walls, left_bound)
            else:
                left_pos = bisect.bisect_left(walls, robots[i] - robots_to_distance[robots[i]])

            left[i] = pos1 - left_pos

            if i < n - 1:
                right_bound = min(robots[i] + robots_to_distance[robots[i]], robots[i + 1] - 1)
                right_pos = bisect.bisect_right(walls, right_bound)
            else:
                right_pos = bisect.bisect_right(walls, robots[i] + robots_to_distance[robots[i]])

            pos2 = bisect.bisect_left(walls, robots[i])
            right[i] = right_pos - pos2

            if i == 0:
                continue

            pos3 = bisect.bisect_left(walls, robots[i - 1])
            num[i] = pos1 - pos3

        sub_left, sub_right = left[0], right[0]
        for i in range(1, n):
            current_left = max(sub_left + left[i], sub_right - right[i - 1] + min(left[i] + right[i - 1], num[i]))
            current_right = max(sub_left + right[i], sub_right + right[i])
            sub_left, sub_right = current_left, current_right

        return max(sub_left, sub_right)
```

```Java
class Solution {
    public int maxWalls(int[] robots, int[] distance, int[] walls) {
        int n = robots.length;
        int[] left = new int[n];
        int[] right = new int[n];
        int[] num = new int[n];
        Map<Integer, Integer> robotsToDistance = new HashMap<>();

        for (int i = 0; i < n; i++) {
            robotsToDistance.put(robots[i], distance[i]);
        }

        Arrays.sort(robots);
        Arrays.sort(walls);

        for (int i = 0; i < n; i++) {
            int pos1 = upperBound(walls, robots[i]);

            int leftPos;
            if (i >= 1) {
                int leftBound = Math.max(robots[i] - robotsToDistance.get(robots[i]), robots[i - 1] + 1);
                leftPos = lowerBound(walls, leftBound);
            } else {
                leftPos = lowerBound(walls, robots[i] - robotsToDistance.get(robots[i]));
            }
            left[i] = pos1 - leftPos;

            int rightPos;
            if (i < n - 1) {
                int rightBound = Math.min(robots[i] + robotsToDistance.get(robots[i]), robots[i + 1] - 1);
                rightPos = upperBound(walls, rightBound);
            } else {
                rightPos = upperBound(walls, robots[i] + robotsToDistance.get(robots[i]));
            }
            int pos2 = lowerBound(walls, robots[i]);
            right[i] = rightPos - pos2;

            if (i == 0) {
                continue;
            }
            int pos3 = lowerBound(walls, robots[i - 1]);
            num[i] = pos1 - pos3;
        }

        int subLeft = left[0], subRight = right[0];
        for (int i = 1; i < n; i++) {
            int currentLeft = Math.max(subLeft + left[i], subRight - right[i - 1] + Math.min(left[i] + right[i - 1], num[i]));
            int currentRight = Math.max(subLeft + right[i], subRight + right[i]);
            subLeft = currentLeft;
            subRight = currentRight;
        }

        return Math.max(subLeft, subRight);
    }

    private int lowerBound(int[] arr, int target) {
        int left = 0, right = arr.length;
        while (left < right) {
            int mid = left + (right - left) / 2;
            if (arr[mid] < target) {
                left = mid + 1;
            } else {
                right = mid;
            }
        }
        return left;
    }

    private int upperBound(int[] arr, int target) {
        int left = 0, right = arr.length;
        while (left < right) {
            int mid = left + (right - left) / 2;
            if (arr[mid] <= target) {
                left = mid + 1;
            } else {
                right = mid;
            }
        }
        return left;
    }
}
```

```CSharp
public class Solution {
    public int MaxWalls(int[] robots, int[] distance, int[] walls) {
        int n = robots.Length;
        int[] left = new int[n];
        int[] right = new int[n];
        int[] num = new int[n];
        Dictionary<int, int> robotsToDistance = new Dictionary<int, int>();

        for (int i = 0; i < n; i++) {
            robotsToDistance[robots[i]] = distance[i];
        }

        Array.Sort(robots);
        Array.Sort(walls);

        for (int i = 0; i < n; i++) {
            int pos1 = UpperBound(walls, robots[i]);

            int leftPos;
            if (i >= 1) {
                int leftBound = Math.Max(robots[i] - robotsToDistance[robots[i]], robots[i - 1] + 1);
                leftPos = LowerBound(walls, leftBound);
            } else {
                leftPos = LowerBound(walls, robots[i] - robotsToDistance[robots[i]]);
            }
            left[i] = pos1 - leftPos;

            int rightPos;
            if (i < n - 1) {
                int rightBound = Math.Min(robots[i] + robotsToDistance[robots[i]], robots[i + 1] - 1);
                rightPos = UpperBound(walls, rightBound);
            } else {
                rightPos = UpperBound(walls, robots[i] + robotsToDistance[robots[i]]);
            }
            int pos2 = LowerBound(walls, robots[i]);
            right[i] = rightPos - pos2;

            if (i == 0) continue;

            int pos3 = LowerBound(walls, robots[i - 1]);
            num[i] = pos1 - pos3;
        }

        int subLeft = left[0], subRight = right[0];
        for (int i = 1; i < n; i++) {
            int currentLeft = Math.Max(subLeft + left[i], subRight - right[i - 1] + Math.Min(left[i] + right[i - 1], num[i]));
            int currentRight = Math.Max(subLeft + right[i], subRight + right[i]);
            subLeft = currentLeft;
            subRight = currentRight;
        }

        return Math.Max(subLeft, subRight);
    }

    private int LowerBound(int[] arr, int target) {
        int left = 0, right = arr.Length;
        while (left < right) {
            int mid = left + (right - left) / 2;
            if (arr[mid] < target) {
                left = mid + 1;
            } else {
                right = mid;
            }
        }
        return left;
    }

    private int UpperBound(int[] arr, int target) {
        int left = 0, right = arr.Length;
        while (left < right) {
            int mid = left + (right - left) / 2;
            if (arr[mid] <= target) {
                left = mid + 1;
            } else {
                right = mid;
            }
        }
        return left;
    }
}
```

```C
typedef struct {
    int key;
    int val;
    UT_hash_handle hh;
} HashItem;

HashItem *hashFindItem(HashItem **obj, int key) {
    HashItem *pEntry = NULL;
    HASH_FIND_INT(*obj, &key, pEntry);
    return pEntry;
}

bool hashAddItem(HashItem **obj, int key, int val) {
    if (hashFindItem(obj, key)) {
        return false;
    }
    HashItem *pEntry = (HashItem *)malloc(sizeof(HashItem));
    pEntry->key = key;
    pEntry->val = val;
    HASH_ADD_INT(*obj, key, pEntry);
    return true;
}

bool hashSetItem(HashItem **obj, int key, int val) {
    HashItem *pEntry = hashFindItem(obj, key);
    if (!pEntry) {
        hashAddItem(obj, key, val);
    } else {
        pEntry->val = val;
    }
    return true;
}

int hashGetItem(HashItem **obj, int key, int defaultVal) {
    HashItem *pEntry = hashFindItem(obj, key);
    if (!pEntry) {
        return defaultVal;
    }
    return pEntry->val;
}

void hashFree(HashItem **obj) {
    HashItem *curr = NULL, *tmp = NULL;
    HASH_ITER(hh, *obj, curr, tmp) {
        HASH_DEL(*obj, curr);
        free(curr);
    }
}

int cmp(const void* a, const void* b) {
    return (*(int*)a - *(int*)b);
}

int max(int a, int b) {
    return (a > b) ? a : b;
}

int min(int a, int b) {
    return (a < b) ? a : b;
}

int lowerBound(int* arr, int size, int target) {
    int left = 0, right = size;
    while (left < right) {
        int mid = left + (right - left) / 2;
        if (arr[mid] < target) {
            left = mid + 1;
        } else {
            right = mid;
        }
    }
    return left;
}

int upperBound(int* arr, int size, int target) {
    int left = 0, right = size;
    while (left < right) {
        int mid = left + (right - left) / 2;
        if (arr[mid] <= target) {
            left = mid + 1;
        } else {
            right = mid;
        }
    }
    return left;
}

int maxWalls(int* robots, int robotsSize, int* distance, int distanceSize, int* walls, int wallsSize) {
    int n = robotsSize;

    int* left = (int*)calloc(n, sizeof(int));
    int* right = (int*)calloc(n, sizeof(int));
    int* num = (int*)calloc(n, sizeof(int));
    HashItem* robotsToDistance = NULL;
    for (int i = 0; i < n; i++) {
        hashAddItem(&robotsToDistance, robots[i], distance[i]);
    }

    int* sortedRobots = (int*)malloc(n * sizeof(int));
    memcpy(sortedRobots, robots, n * sizeof(int));
    qsort(sortedRobots, n, sizeof(int), cmp);

    int* sortedWalls = (int*)malloc(wallsSize * sizeof(int));
    memcpy(sortedWalls, walls, wallsSize * sizeof(int));
    qsort(sortedWalls, wallsSize, sizeof(int), cmp);

    for (int i = 0; i < n; i++) {
        int pos1 = upperBound(sortedWalls, wallsSize, sortedRobots[i]);
        int leftPos;
        if (i >= 1) {
            int leftBound = max(sortedRobots[i] - hashGetItem(&robotsToDistance, sortedRobots[i], 0), sortedRobots[i - 1] + 1);
            leftPos = lowerBound(sortedWalls, wallsSize, leftBound);
        } else {
            leftPos = lowerBound(sortedWalls, wallsSize, sortedRobots[i] - hashGetItem(&robotsToDistance, sortedRobots[i], 0));
        }
        left[i] = pos1 - leftPos;

        int rightPos;
        if (i < n - 1) {
            int rightBound = min(sortedRobots[i] + hashGetItem(&robotsToDistance, sortedRobots[i], 0),
                                sortedRobots[i + 1] - 1);
            rightPos = upperBound(sortedWalls, wallsSize, rightBound);
        } else {
            rightPos = upperBound(sortedWalls, wallsSize,
                                 sortedRobots[i] + hashGetItem(&robotsToDistance, sortedRobots[i], 0));
        }

        int pos2 = lowerBound(sortedWalls, wallsSize, sortedRobots[i]);
        right[i] = rightPos - pos2;

        if (i == 0) {
            continue;
        }

        int pos3 = lowerBound(sortedWalls, wallsSize, sortedRobots[i - 1]);
        num[i] = pos1 - pos3;
    }

    int subLeft = left[0];
    int subRight = right[0];

    for (int i = 1; i < n; i++) {
        int currentLeft = max(subLeft + left[i],
                             subRight - right[i - 1] + min(left[i] + right[i - 1], num[i]));
        int currentRight = max(subLeft + right[i], subRight + right[i]);
        subLeft = currentLeft;
        subRight = currentRight;
    }


    int result = max(subLeft, subRight);

    free(left);
    free(right);
    free(num);
    free(sortedRobots);
    free(sortedWalls);
    hashFree(&robotsToDistance);

    return result;
}
```

```JavaScript
function maxWalls(robots, distance, walls) {
    const n = robots.length;
    const left = new Array(n).fill(0);
    const right = new Array(n).fill(0);
    const num = new Array(n).fill(0);
    const robotsToDistance = new Map();

    for (let i = 0; i < n; i++) {
        robotsToDistance.set(robots[i], distance[i]);
    }

    robots.sort((a, b) => a - b);
    walls.sort((a, b) => a - b);

    const lowerBound = (arr, target) => {
        let left = 0, right = arr.length;
        while (left < right) {
            const mid = Math.floor((left + right) / 2);
            if (arr[mid] < target) {
                left = mid + 1;
            } else {
                right = mid;
            }
        }
        return left;
    };

    const upperBound = (arr, target) => {
        let left = 0, right = arr.length;
        while (left < right) {
            const mid = Math.floor((left + right) / 2);
            if (arr[mid] <= target) {
                left = mid + 1;
            } else {
                right = mid;
            }
        }
        return left;
    };

    for (let i = 0; i < n; i++) {
        const pos1 = upperBound(walls, robots[i]);

        let leftPos;
        if (i >= 1) {
            const leftBound = Math.max(robots[i] - robotsToDistance.get(robots[i]), robots[i - 1] + 1);
            leftPos = lowerBound(walls, leftBound);
        } else {
            leftPos = lowerBound(walls, robots[i] - robotsToDistance.get(robots[i]));
        }
        left[i] = pos1 - leftPos;

        let rightPos;
        if (i < n - 1) {
            const rightBound = Math.min(robots[i] + robotsToDistance.get(robots[i]), robots[i + 1] - 1);
            rightPos = upperBound(walls, rightBound);
        } else {
            rightPos = upperBound(walls, robots[i] + robotsToDistance.get(robots[i]));
        }
        const pos2 = lowerBound(walls, robots[i]);
        right[i] = rightPos - pos2;

        if (i === 0) continue;

        const pos3 = lowerBound(walls, robots[i - 1]);
        num[i] = pos1 - pos3;
    }

    let subLeft = left[0], subRight = right[0];
    for (let i = 1; i < n; i++) {
        const currentLeft = Math.max(subLeft + left[i], subRight - right[i - 1] + Math.min(left[i] + right[i - 1], num[i]));
        const currentRight = Math.max(subLeft + right[i], subRight + right[i]);
        subLeft = currentLeft;
        subRight = currentRight;
    }

    return Math.max(subLeft, subRight);
}
```

```TypeScript
function maxWalls(robots: number[], distance: number[], walls: number[]): number {
    const n = robots.length;
    const left = new Array(n).fill(0);
    const right = new Array(n).fill(0);
    const num = new Array(n).fill(0);
    const robotsToDistance = new Map<number, number>();

    for (let i = 0; i < n; i++) {
        robotsToDistance.set(robots[i], distance[i]);
    }

    robots.sort((a, b) => a - b);
    walls.sort((a, b) => a - b);

    const lowerBound = (arr: number[], target: number): number => {
        let left = 0, right = arr.length;
        while (left < right) {
            const mid = Math.floor((left + right) / 2);
            if (arr[mid] < target) {
                left = mid + 1;
            } else {
                right = mid;
            }
        }
        return left;
    };

    const upperBound = (arr: number[], target: number): number => {
        let left = 0, right = arr.length;
        while (left < right) {
            const mid = Math.floor((left + right) / 2);
            if (arr[mid] <= target) {
                left = mid + 1;
            } else {
                right = mid;
            }
        }
        return left;
    };

    for (let i = 0; i < n; i++) {
        const pos1 = upperBound(walls, robots[i]);

        let leftPos: number;
        if (i >= 1) {
            const leftBound = Math.max(robots[i] - robotsToDistance.get(robots[i])!, robots[i - 1] + 1);
            leftPos = lowerBound(walls, leftBound);
        } else {
            leftPos = lowerBound(walls, robots[i] - robotsToDistance.get(robots[i])!);
        }
        left[i] = pos1 - leftPos;

        let rightPos: number;
        if (i < n - 1) {
            const rightBound = Math.min(robots[i] + robotsToDistance.get(robots[i])!, robots[i + 1] - 1);
            rightPos = upperBound(walls, rightBound);
        } else {
            rightPos = upperBound(walls, robots[i] + robotsToDistance.get(robots[i])!);
        }
        const pos2 = lowerBound(walls, robots[i]);
        right[i] = rightPos - pos2;

        if (i === 0) continue;

        const pos3 = lowerBound(walls, robots[i - 1]);
        num[i] = pos1 - pos3;
    }

    let subLeft = left[0], subRight = right[0];
    for (let i = 1; i < n; i++) {
        const currentLeft = Math.max(subLeft + left[i], subRight - right[i - 1] + Math.min(left[i] + right[i - 1], num[i]));
        const currentRight = Math.max(subLeft + right[i], subRight + right[i]);
        subLeft = currentLeft;
        subRight = currentRight;
    }

    return Math.max(subLeft, subRight);
}
```

```Rust
use std::collections::HashMap;

impl Solution {
    pub fn max_walls(robots: Vec<i32>, distance: Vec<i32>, walls: Vec<i32>) -> i32 {
        let n = robots.len();

        let mut robots_to_distance: HashMap<i32, i32> = HashMap::new();
        for i in 0..n {
            robots_to_distance.insert(robots[i], distance[i]);
        }

        let mut sorted_robots = robots.clone();
        sorted_robots.sort();
        let mut sorted_walls = walls.clone();
        sorted_walls.sort();

        let mut left = vec![0; n];
        let mut right = vec![0; n];
        let mut num = vec![0; n];

        for i in 0..n {
            let pos1 = sorted_walls.partition_point(|&x| x <= sorted_robots[i]);

            let left_pos = if i >= 1 {
                sorted_walls.partition_point(|&x|
                    x < (sorted_robots[i] - robots_to_distance[&sorted_robots[i]]).max(sorted_robots[i - 1] + 1))
            } else {
                sorted_walls.partition_point(|&x|
                    x < sorted_robots[i] - robots_to_distance[&sorted_robots[i]])
            };
            left[i] = pos1 - left_pos;

            let right_pos = if i < n - 1 {
                sorted_walls.partition_point(|&x|
                    x <= (sorted_robots[i] + robots_to_distance[&sorted_robots[i]]).min(sorted_robots[i + 1] - 1))
            } else {
                sorted_walls.partition_point(|&x|
                    x <= sorted_robots[i] + robots_to_distance[&sorted_robots[i]])
            };

            let pos2 = sorted_walls.partition_point(|&x| x < sorted_robots[i]);
            right[i] = right_pos - pos2;

            if i == 0 {
                continue;
            }

            let pos3 = sorted_walls.partition_point(|&x| x < sorted_robots[i - 1]);
            num[i] = pos1 - pos3;
        }

        let mut sub_left = left[0];
        let mut sub_right = right[0];

        for i in 1..n {
            let current_left = (sub_left + left[i]).max(
                sub_right - right[i - 1] + (left[i] + right[i - 1]).min(num[i])
            );
            let current_right = (sub_left + right[i]).max(sub_right + right[i]);
            sub_left = current_left;
            sub_right = current_right;
        }

        sub_left.max(sub_right) as i32
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n\log m+n\log n+m\log m)$。当 $n$ 远大于 $m$ 时，时间复杂度为 $O(n\log n)$；当 $m$ 远大于 $n$ 时，时间复杂度为 $O(m\log m)$。其中 $n$ 为 $robots$ 数组的长度，$m$ 为 $walls$ 数组的长度。
- 空间复杂度：$O(n+\log m)$，当 $n$ 远大于 $m$ 时，空间复杂度为 $O(n)$；当 $\log m$ 远大于 $n$ 时，空间复杂度为 $O(\log m)$。其中 $n$ 为 $robots$ 数组的长度，$m$ 为 $walls$ 数组的长度，$\log m$ 为 $walls$ 数组排序的栈开销。

#### 方法二：双指针 $+$ 动态规划

方法二在方法一的基础上，使用双指针替代二分查找，由于两个机器人之间的墙壁位置递增，并且机器人以及墙壁数组已经排好序，指针只需要向右移动即可，不会回退。

对于第 $i$ 个机器人，我们设置如下指针：

- $rightPtr$：指向第一个大于 $robots[i]$ 的墙 (对应 $upper\_bound)$。
- $leftPtr:$ 指向第一个大于等于左边界的墙 (对应 $lower\_bound)$。
- $curPtr:$ 指向第一个大于等于 $robots[i]$ 的墙 (对应 $lower\_bound$，用于计算 $right[i])$。
- $robotPtr:$ 指向第一个大于等于 $robots[i-1]$ 的墙。

```C++
class Solution {
public:
    int maxWalls(vector<int>& robots, vector<int>& distance, vector<int>& walls) {
        int n = robots.size();
        vector<int> left(n, 0), right(n, 0), num(n, 0);
        unordered_map<int, int> robotsToDistance;

        for (int i = 0; i < n; i++) {
            robotsToDistance[robots[i]] = distance[i];
        }

        sort(robots.begin(), robots.end());
        sort(walls.begin(), walls.end());

        int m = walls.size();
        int rightPtr = 0, leftPtr = 0, curPtr = 0, robotPtr = 0;

        for (int i = 0; i < n; i++) {
            // rightPtr 找到第一个 > robots[i] 的位置 (对应 upper_bound)
            while (rightPtr < m && walls[rightPtr] <= robots[i]) {
                rightPtr++;
            }
            int pos1 = rightPtr;

            // curPtr 找到第一个 >= robots[i] 的位置 (对应 lower_bound，用于计算 right[i])
            while (curPtr < m && walls[curPtr] < robots[i]) {
                curPtr++;
            }
            int pos2 = curPtr;

            // leftPtr 找到第一个 >= 左边界的墙
            int leftBound = (i >= 1) ? max(robots[i] - robotsToDistance[robots[i]], robots[i - 1] + 1) : robots[i] - robotsToDistance[robots[i]];
            while (leftPtr < m && walls[leftPtr] < leftBound) {
                leftPtr++;
            }
            int leftPos = leftPtr;
            left[i] = pos1 - leftPos;

            // 计算右边可达的墙的数量
            // 右边界需要考虑与后一个机器人之间的重叠区域
            int rightBound = (i < n - 1) ? min(robots[i] + robotsToDistance[robots[i]], robots[i + 1] - 1) : robots[i] + robotsToDistance[robots[i]];
            // 找到第一个 > 右边界的墙
            while (rightPtr < m && walls[rightPtr] <= rightBound) {
                rightPtr++;
            }
            int rightPos = rightPtr;
            right[i] = rightPos - pos2;

            if (i == 0) {
                continue;
            }
            // robotPtr 找到上一个机器人的位置
            while (robotPtr < m && walls[robotPtr] < robots[i - 1]) {
                robotPtr++;
            }
            int pos3 = robotPtr;
            num[i] = pos1 - pos3;
        }

        int subLeft = left[0], subRight = right[0];
        for (int i = 1; i < n; i++) {
            int currentLeft = max(subLeft + left[i], subRight - right[i - 1] + min(left[i] + right[i - 1], num[i]));
            int currentRight = max(subLeft + right[i], subRight + right[i]);
            subLeft = currentLeft;
            subRight = currentRight;
        }
        return max(subLeft, subRight);
    }
};
```

```Go
func maxWalls(robots []int, distance []int, walls []int) int {
    n := len(robots)
    left := make([]int, n)
    right := make([]int, n)
    num := make([]int, n)
    robotsToDistance := make(map[int]int)

    for i := 0; i < n; i++ {
        robotsToDistance[robots[i]] = distance[i]
    }

    sort.Ints(robots)
    sort.Ints(walls)

    m := len(walls)
    rightPtr, leftPtr, curPtr, robotPtr := 0, 0, 0, 0

    for i := 0; i < n; i++ {
        for rightPtr < m && walls[rightPtr] <= robots[i] {
            rightPtr++
        }
        pos1 := rightPtr

        for curPtr < m && walls[curPtr] < robots[i] {
            curPtr++
        }
        pos2 := curPtr

        leftBound := robots[i] - robotsToDistance[robots[i]]
        if i >= 1 {
            leftBound = max(robots[i]-robotsToDistance[robots[i]], robots[i-1]+1)
        }
        for leftPtr < m && walls[leftPtr] < leftBound {
            leftPtr++
        }
        leftPos := leftPtr
        left[i] = pos1 - leftPos

        rightBound := robots[i] + robotsToDistance[robots[i]]
        if i < n-1 {
            rightBound = min(robots[i]+robotsToDistance[robots[i]], robots[i+1]-1)
        }
        for rightPtr < m && walls[rightPtr] <= rightBound {
            rightPtr++
        }
        rightPos := rightPtr
        right[i] = rightPos - pos2

        if i == 0 {
            continue
        }

        for robotPtr < m && walls[robotPtr] < robots[i-1] {
            robotPtr++
        }
        pos3 := robotPtr
        num[i] = pos1 - pos3
    }

    subLeft, subRight := left[0], right[0]
    for i := 1; i < n; i++ {
        currentLeft := max(subLeft+left[i], subRight-right[i-1]+min(left[i]+right[i-1], num[i]))
        currentRight := max(subLeft+right[i], subRight+right[i])
        subLeft, subRight = currentLeft, currentRight
    }

    return max(subLeft, subRight)
}

func max(a, b int) int {
    if a > b {
        return a
    }
    return b
}

func min(a, b int) int {
    if a < b {
        return a
    }
    return b
}
```

```Python
class Solution:
    def maxWalls(self, robots: List[int], distance: List[int], walls: List[int]) -> int:
        n = len(robots)
        left = [0] * n
        right = [0] * n
        num = [0] * n
        robots_to_distance = {}

        for i in range(n):
            robots_to_distance[robots[i]] = distance[i]

        robots.sort()
        walls.sort()

        m = len(walls)
        right_ptr = left_ptr = cur_ptr = robot_ptr = 0

        for i in range(n):
            while right_ptr < m and walls[right_ptr] <= robots[i]:
                right_ptr += 1
            pos1 = right_ptr

            while cur_ptr < m and walls[cur_ptr] < robots[i]:
                cur_ptr += 1
            pos2 = cur_ptr

            if i >= 1:
                left_bound = max(robots[i] - robots_to_distance[robots[i]], robots[i - 1] + 1)
            else:
                left_bound = robots[i] - robots_to_distance[robots[i]]

            while left_ptr < m and walls[left_ptr] < left_bound:
                left_ptr += 1
            left_pos = left_ptr
            left[i] = pos1 - left_pos

            if i < n - 1:
                right_bound = min(robots[i] + robots_to_distance[robots[i]], robots[i + 1] - 1)
            else:
                right_bound = robots[i] + robots_to_distance[robots[i]]

            while right_ptr < m and walls[right_ptr] <= right_bound:
                right_ptr += 1
            right_pos = right_ptr
            right[i] = right_pos - pos2

            if i == 0:
                continue

            while robot_ptr < m and walls[robot_ptr] < robots[i - 1]:
                robot_ptr += 1
            pos3 = robot_ptr
            num[i] = pos1 - pos3

        sub_left, sub_right = left[0], right[0]
        for i in range(1, n):
            current_left = max(sub_left + left[i], sub_right - right[i - 1] + min(left[i] + right[i - 1], num[i]))
            current_right = max(sub_left + right[i], sub_right + right[i])
            sub_left, sub_right = current_left, current_right

        return max(sub_left, sub_right)
```

```Java
class Solution {
    public int maxWalls(int[] robots, int[] distance, int[] walls) {
        int n = robots.length;
        int[] left = new int[n];
        int[] right = new int[n];
        int[] num = new int[n];
        Map<Integer, Integer> robotsToDistance = new HashMap<>();

        for (int i = 0; i < n; i++) {
            robotsToDistance.put(robots[i], distance[i]);
        }

        Arrays.sort(robots);
        Arrays.sort(walls);

        int m = walls.length;
        int rightPtr = 0, leftPtr = 0, curPtr = 0, robotPtr = 0;

        for (int i = 0; i < n; i++) {
            while (rightPtr < m && walls[rightPtr] <= robots[i]) {
                rightPtr++;
            }
            int pos1 = rightPtr;

            while (curPtr < m && walls[curPtr] < robots[i]) {
                curPtr++;
            }
            int pos2 = curPtr;

            int leftBound = robots[i] - robotsToDistance.get(robots[i]);
            if (i >= 1) {
                leftBound = Math.max(robots[i] - robotsToDistance.get(robots[i]), robots[i - 1] + 1);
            }
            while (leftPtr < m && walls[leftPtr] < leftBound) {
                leftPtr++;
            }
            int leftPos = leftPtr;
            left[i] = pos1 - leftPos;

            int rightBound = robots[i] + robotsToDistance.get(robots[i]);
            if (i < n - 1) {
                rightBound = Math.min(robots[i] + robotsToDistance.get(robots[i]), robots[i + 1] - 1);
            }
            while (rightPtr < m && walls[rightPtr] <= rightBound) {
                rightPtr++;
            }
            int rightPos = rightPtr;
            right[i] = rightPos - pos2;

            if (i == 0) {
                continue;
            }
            while (robotPtr < m && walls[robotPtr] < robots[i - 1]) {
                robotPtr++;
            }
            int pos3 = robotPtr;
            num[i] = pos1 - pos3;
        }

        int subLeft = left[0], subRight = right[0];
        for (int i = 1; i < n; i++) {
            int currentLeft = Math.max(subLeft + left[i], subRight - right[i - 1] + Math.min(left[i] + right[i - 1], num[i]));
            int currentRight = Math.max(subLeft + right[i], subRight + right[i]);
            subLeft = currentLeft;
            subRight = currentRight;
        }

        return Math.max(subLeft, subRight);
    }
}
```

```CSharp
public class Solution {
    public int MaxWalls(int[] robots, int[] distance, int[] walls) {
        int n = robots.Length;
        int[] left = new int[n];
        int[] right = new int[n];
        int[] num = new int[n];
        Dictionary<int, int> robotsToDistance = new Dictionary<int, int>();

        for (int i = 0; i < n; i++) {
            robotsToDistance[robots[i]] = distance[i];
        }

        Array.Sort(robots);
        Array.Sort(walls);

        int m = walls.Length;
        int rightPtr = 0, leftPtr = 0, curPtr = 0, robotPtr = 0;

        for (int i = 0; i < n; i++) {
            while (rightPtr < m && walls[rightPtr] <= robots[i]) {
                rightPtr++;
            }
            int pos1 = rightPtr;

            while (curPtr < m && walls[curPtr] < robots[i]) {
                curPtr++;
            }
            int pos2 = curPtr;

            int leftBound = robots[i] - robotsToDistance[robots[i]];
            if (i >= 1) {
                leftBound = Math.Max(robots[i] - robotsToDistance[robots[i]], robots[i - 1] + 1);
            }
            while (leftPtr < m && walls[leftPtr] < leftBound) {
                leftPtr++;
            }
            int leftPos = leftPtr;
            left[i] = pos1 - leftPos;

            int rightBound = robots[i] + robotsToDistance[robots[i]];
            if (i < n - 1) {
                rightBound = Math.Min(robots[i] + robotsToDistance[robots[i]], robots[i + 1] - 1);
            }
            while (rightPtr < m && walls[rightPtr] <= rightBound) {
                rightPtr++;
            }
            int rightPos = rightPtr;
            right[i] = rightPos - pos2;

            if (i == 0) {
                continue;
            }
            while (robotPtr < m && walls[robotPtr] < robots[i - 1]) {
                robotPtr++;
            }
            int pos3 = robotPtr;
            num[i] = pos1 - pos3;
        }

        int subLeft = left[0], subRight = right[0];
        for (int i = 1; i < n; i++) {
            int currentLeft = Math.Max(subLeft + left[i], subRight - right[i - 1] + Math.Min(left[i] + right[i - 1], num[i]));
            int currentRight = Math.Max(subLeft + right[i], subRight + right[i]);
            subLeft = currentLeft;
            subRight = currentRight;
        }

        return Math.Max(subLeft, subRight);
    }
}
```

```C
int compare(const void* a, const void* b) {
    return (*(int*)a - *(int*)b);
}

int maxInt(int a, int b) {
    return a > b ? a : b;
}

int minInt(int a, int b) {
    return a < b ? a : b;
}

int maxWalls(int* robots, int robotsSize, int* distance, int distanceSize, int* walls, int wallsSize) {
    int n = robotsSize;
    int* left = (int*)calloc(n, sizeof(int));
    int* right = (int*)calloc(n, sizeof(int));
    int* num = (int*)calloc(n, sizeof(int));

    int* robotsCopy = (int*)malloc(n * sizeof(int));
    memcpy(robotsCopy, robots, n * sizeof(int));

    int* robotsToDistance = (int*)malloc(n * sizeof(int));
    for (int i = 0; i < n; i++) {
        int robotPos = robotsCopy[i];
        for (int j = 0; j < n; j++) {
            if (robots[j] == robotPos) {
                robotsToDistance[i] = distance[j];
                break;
            }
        }
    }

    qsort(robotsCopy, n, sizeof(int), compare);
    qsort(walls, wallsSize, sizeof(int), compare);

    int m = wallsSize;
    int rightPtr = 0, leftPtr = 0, curPtr = 0, robotPtr = 0;

    for (int i = 0; i < n; i++) {
        while (rightPtr < m && walls[rightPtr] <= robotsCopy[i]) {
            rightPtr++;
        }
        int pos1 = rightPtr;

        while (curPtr < m && walls[curPtr] < robotsCopy[i]) {
            curPtr++;
        }
        int pos2 = curPtr;

        int leftBound = robotsCopy[i] - robotsToDistance[i];
        if (i >= 1) {
            leftBound = maxInt(robotsCopy[i] - robotsToDistance[i], robotsCopy[i - 1] + 1);
        }
        while (leftPtr < m && walls[leftPtr] < leftBound) {
            leftPtr++;
        }
        int leftPos = leftPtr;
        left[i] = pos1 - leftPos;

        int rightBound = robotsCopy[i] + robotsToDistance[i];
        if (i < n - 1) {
            rightBound = minInt(robotsCopy[i] + robotsToDistance[i], robotsCopy[i + 1] - 1);
        }
        while (rightPtr < m && walls[rightPtr] <= rightBound) {
            rightPtr++;
        }
        int rightPos = rightPtr;
        right[i] = rightPos - pos2;

        if (i == 0) {
            continue;
        }
        while (robotPtr < m && walls[robotPtr] < robotsCopy[i - 1]) {
            robotPtr++;
        }
        int pos3 = robotPtr;
        num[i] = pos1 - pos3;
    }

    int subLeft = left[0], subRight = right[0];
    for (int i = 1; i < n; i++) {
        int currentLeft = maxInt(subLeft + left[i], subRight - right[i - 1] + minInt(left[i] + right[i - 1], num[i]));
        int currentRight = maxInt(subLeft + right[i], subRight + right[i]);
        subLeft = currentLeft;
        subRight = currentRight;
    }

    int result = maxInt(subLeft, subRight);

    free(left);
    free(right);
    free(num);
    free(robotsCopy);
    free(robotsToDistance);

    return result;
}
```

```JavaScript
function maxWalls(robots, distance, walls) {
    const n = robots.length;
    const left = new Array(n).fill(0);
    const right = new Array(n).fill(0);
    const num = new Array(n).fill(0);
    const robotsToDistance = new Map();

    for (let i = 0; i < n; i++) {
        robotsToDistance.set(robots[i], distance[i]);
    }

    robots.sort((a, b) => a - b);
    walls.sort((a, b) => a - b);

    const m = walls.length;
    let rightPtr = 0, leftPtr = 0, curPtr = 0, robotPtr = 0;

    for (let i = 0; i < n; i++) {
        while (rightPtr < m && walls[rightPtr] <= robots[i]) {
            rightPtr++;
        }
        const pos1 = rightPtr;

        while (curPtr < m && walls[curPtr] < robots[i]) {
            curPtr++;
        }
        const pos2 = curPtr;

        let leftBound = robots[i] - robotsToDistance.get(robots[i]);
        if (i >= 1) {
            leftBound = Math.max(robots[i] - robotsToDistance.get(robots[i]), robots[i - 1] + 1);
        }
        while (leftPtr < m && walls[leftPtr] < leftBound) {
            leftPtr++;
        }
        const leftPos = leftPtr;
        left[i] = pos1 - leftPos;

        let rightBound = robots[i] + robotsToDistance.get(robots[i]);
        if (i < n - 1) {
            rightBound = Math.min(robots[i] + robotsToDistance.get(robots[i]), robots[i + 1] - 1);
        }
        while (rightPtr < m && walls[rightPtr] <= rightBound) {
            rightPtr++;
        }
        const rightPos = rightPtr;
        right[i] = rightPos - pos2;

        if (i === 0) {
            continue;
        }
        while (robotPtr < m && walls[robotPtr] < robots[i - 1]) {
            robotPtr++;
        }
        const pos3 = robotPtr;
        num[i] = pos1 - pos3;
    }

    let subLeft = left[0], subRight = right[0];
    for (let i = 1; i < n; i++) {
        const currentLeft = Math.max(subLeft + left[i], subRight - right[i - 1] + Math.min(left[i] + right[i - 1], num[i]));
        const currentRight = Math.max(subLeft + right[i], subRight + right[i]);
        subLeft = currentLeft;
        subRight = currentRight;
    }

    return Math.max(subLeft, subRight);
}
```

```TypeScript
function maxWalls(robots: number[], distance: number[], walls: number[]): number {
    const n = robots.length;
    const left = new Array(n).fill(0);
    const right = new Array(n).fill(0);
    const num = new Array(n).fill(0);
    const robotsToDistance = new Map<number, number>();

    for (let i = 0; i < n; i++) {
        robotsToDistance.set(robots[i], distance[i]);
    }

    robots.sort((a, b) => a - b);
    walls.sort((a, b) => a - b);

    const m = walls.length;
    let rightPtr = 0, leftPtr = 0, curPtr = 0, robotPtr = 0;

    for (let i = 0; i < n; i++) {
        while (rightPtr < m && walls[rightPtr] <= robots[i]) {
            rightPtr++;
        }
        const pos1 = rightPtr;

        while (curPtr < m && walls[curPtr] < robots[i]) {
            curPtr++;
        }
        const pos2 = curPtr;

        let leftBound = robots[i] - robotsToDistance.get(robots[i])!;
        if (i >= 1) {
            leftBound = Math.max(robots[i] - robotsToDistance.get(robots[i])!, robots[i - 1] + 1);
        }
        while (leftPtr < m && walls[leftPtr] < leftBound) {
            leftPtr++;
        }
        const leftPos = leftPtr;
        left[i] = pos1 - leftPos;

        let rightBound = robots[i] + robotsToDistance.get(robots[i])!;
        if (i < n - 1) {
            rightBound = Math.min(robots[i] + robotsToDistance.get(robots[i])!, robots[i + 1] - 1);
        }
        while (rightPtr < m && walls[rightPtr] <= rightBound) {
            rightPtr++;
        }
        const rightPos = rightPtr;
        right[i] = rightPos - pos2;

        if (i === 0) {
            continue;
        }
        while (robotPtr < m && walls[robotPtr] < robots[i - 1]) {
            robotPtr++;
        }
        const pos3 = robotPtr;
        num[i] = pos1 - pos3;
    }

    let subLeft = left[0], subRight = right[0];
    for (let i = 1; i < n; i++) {
        const currentLeft = Math.max(subLeft + left[i], subRight - right[i - 1] + Math.min(left[i] + right[i - 1], num[i]));
        const currentRight = Math.max(subLeft + right[i], subRight + right[i]);
        subLeft = currentLeft;
        subRight = currentRight;
    }

    return Math.max(subLeft, subRight);
}
```

```Rust
impl Solution {
    pub fn max_walls(mut robots: Vec<i32>, distance: Vec<i32>, mut walls: Vec<i32>) -> i32 {
        let n = robots.len();
        let mut left = vec![0; n];
        let mut right = vec![0; n];
        let mut num = vec![0; n];
        let mut robots_to_distance: HashMap<i32, i32> = HashMap::new();

        for i in 0..n {
            robots_to_distance.insert(robots[i], distance[i]);
        }

        robots.sort();
        walls.sort();

        let m = walls.len();
        let mut right_ptr = 0;
        let mut left_ptr = 0;
        let mut cur_ptr = 0;
        let mut robot_ptr = 0;

        for i in 0..n {
            while right_ptr < m && walls[right_ptr] <= robots[i] {
                right_ptr += 1;
            }
            let pos1 = right_ptr;

            while cur_ptr < m && walls[cur_ptr] < robots[i] {
                cur_ptr += 1;
            }
            let pos2 = cur_ptr;

            let mut left_bound = robots[i] - robots_to_distance[&robots[i]];
            if i >= 1 {
                left_bound = std::cmp::max(robots[i] - robots_to_distance[&robots[i]], robots[i - 1] + 1);
            }
            while left_ptr < m && walls[left_ptr] < left_bound {
                left_ptr += 1;
            }
            let left_pos = left_ptr;
            left[i] = (pos1 - left_pos) as i32;

            let mut right_bound = robots[i] + robots_to_distance[&robots[i]];
            if i < n - 1 {
                right_bound = std::cmp::min(robots[i] + robots_to_distance[&robots[i]], robots[i + 1] - 1);
            }
            while right_ptr < m && walls[right_ptr] <= right_bound {
                right_ptr += 1;
            }
            let right_pos = right_ptr;
            right[i] = (right_pos - pos2) as i32;

            if i == 0 {
                continue;
            }

            while robot_ptr < m && walls[robot_ptr] < robots[i - 1] {
                robot_ptr += 1;
            }
            let pos3 = robot_ptr;
            num[i] = (pos1 - pos3) as i32;
        }

        let mut sub_left = left[0];
        let mut sub_right = right[0];
        for i in 1..n {
            let current_left = std::cmp::max(
                sub_left + left[i],
                sub_right - right[i - 1] + std::cmp::min(left[i] + right[i - 1], num[i])
            );
            let current_right = std::cmp::max(sub_left + right[i], sub_right + right[i]);
            sub_left = current_left;
            sub_right = current_right;
        }

        std::cmp::max(sub_left, sub_right)
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n\log n+m\log m)$。当 $n$ 远大于 $m$ 时，时间复杂度为 $O(n\log n)$；当 $m$ 远大于 $n$ 时，时间复杂度为 $O(m\log m)$。其中 $n$ 为 $robots$ 数组的长度，$m$ 为 $walls$ 数组的长度。
- 空间复杂度：$O(n+\log m)$，当 $n$ 远大于 $m$ 时，空间复杂度为 $O(n)$；当 $\log m$ 远大于 $n$ 时，空间复杂度为 $O(\log m)$。其中 $n$ 为 $robots$ 数组的长度，$m$ 为 $walls$ 数组的长度，$\log m$ 为 $walls$ 数组排序的栈开销。

#### 方法三：双指针 $+$ 动态规划 $+$ 空间优化

在方法二中，可以发现用于记录机器人左边/右边能打到墙壁数量的数组以及用于记录两个机器人中间墙壁数量的数组，实际在进行动态规划计算的过程中，当前状态只需要上一个状态中的信息，那么这三个数组同样可以优化掉，只使用当前状态和上一个状态中的 left、right、num 来进行计算即可。

这里使用 prevLeft、prevRight，$prevNum$ 来保存上一个状态中的信息，使用 currentLeft、currentRight，$currentNum$ 来保存当前状态中的信息。

除此之外，我们还可以使用 $pair$ 来保存机器人与其射击距离之间的关系，避免了哈希表的额外消耗。

```C++
class Solution {
public:
    int maxWalls(vector<int>& robots, vector<int>& distance, vector<int>& walls) {
        int n = robots.size();
        vector<pair<int, int>> robotDist;
        for (int i = 0; i < n; i++) {
            robotDist.push_back({robots[i], distance[i]});
        }
        sort(robotDist.begin(), robotDist.end());
        sort(walls.begin(), walls.end());

        int m = walls.size();
        int rightPtr = 0, leftPtr = 0, curPtr = 0, robotPtr = 0;

        // DP 变量：只保存前一个值
        int prevLeft = 0, prevRight = 0, prevNum = 0;
        int subLeft = 0, subRight = 0;

        for (int i = 0; i < n; i++) {
            int robotPos = robotDist[i].first;
            int robotDistVal = robotDist[i].second;

            // rightPtr 找到第一个 > robotPos 的位置 (对应 upper_bound)
            while (rightPtr < m && walls[rightPtr] <= robotPos) {
                rightPtr++;
            }
            int pos1 = rightPtr;

            // curPtr 找到第一个 >= robotPos 的位置 (对应 lower_bound)
            while (curPtr < m && walls[curPtr] < robotPos) {
                curPtr++;
            }
            int pos2 = curPtr;

            // leftPtr 找到第一个 >= 左边界的墙
            int leftBound = (i >= 1) ? max(robotPos - robotDistVal, robotDist[i - 1].first + 1) : robotPos - robotDistVal;
            while (leftPtr < m && walls[leftPtr] < leftBound) {
                leftPtr++;
            }
            int leftPos = leftPtr;
            int currentLeft = pos1 - leftPos;

            // 计算右边可达的墙的数量
            int rightBound = (i < n - 1) ? min(robotPos + robotDistVal, robotDist[i + 1].first - 1) : robotPos + robotDistVal;
            while (rightPtr < m && walls[rightPtr] <= rightBound) {
                rightPtr++;
            }
            int rightPos = rightPtr;
            int currentRight = rightPos - pos2;

            // robotPtr 找到上一个机器人的位置
            int currentNum = 0;
            if (i > 0) {
                while (robotPtr < m && walls[robotPtr] < robotDist[i - 1].first) {
                    robotPtr++;
                }
                int pos3 = robotPtr;
                currentNum = pos1 - pos3;
            }

            if (i == 0) {
                subLeft = currentLeft;
                subRight = currentRight;
            } else {
                int newsubLeft = max(subLeft + currentLeft, subRight - prevRight + min(currentLeft + prevRight, currentNum));
                int newsubRight = max(subLeft + currentRight, subRight + currentRight);
                subLeft = newsubLeft;
                subRight = newsubRight;
            }

            prevLeft = currentLeft;
            prevRight = currentRight;
            prevNum = currentNum;
        }

        return max(subLeft, subRight);
    }
};
```

```Go
func maxWalls(robots []int, distance []int, walls []int) int {
    n := len(robots)
    type RobotDist struct {
        pos   int
        dist  int
    }
    robotDist := make([]RobotDist, n)
    for i := 0; i < n; i++ {
        robotDist[i] = RobotDist{robots[i], distance[i]}
    }

    sort.Slice(robotDist, func(i, j int) bool {
        return robotDist[i].pos < robotDist[j].pos
    })
    sort.Ints(walls)

    m := len(walls)
    rightPtr, leftPtr, curPtr, robotPtr := 0, 0, 0, 0

    var prevLeft, prevRight, prevNum int
    var subLeft, subRight int

    for i := 0; i < n; i++ {
        robotPos := robotDist[i].pos
        robotDistVal := robotDist[i].dist

        for rightPtr < m && walls[rightPtr] <= robotPos {
            rightPtr++
        }
        pos1 := rightPtr

        for curPtr < m && walls[curPtr] < robotPos {
            curPtr++
        }
        pos2 := curPtr

        leftBound := robotPos - robotDistVal
        if i >= 1 {
            leftBound = max(robotPos-robotDistVal, robotDist[i-1].pos+1)
        }
        for leftPtr < m && walls[leftPtr] < leftBound {
            leftPtr++
        }
        leftPos := leftPtr
        currentLeft := pos1 - leftPos

        rightBound := robotPos + robotDistVal
        if i < n-1 {
            rightBound = min(robotPos+robotDistVal, robotDist[i+1].pos-1)
        }
        for rightPtr < m && walls[rightPtr] <= rightBound {
            rightPtr++
        }
        rightPos := rightPtr
        currentRight := rightPos - pos2

        currentNum := 0
        if i > 0 {
            for robotPtr < m && walls[robotPtr] < robotDist[i-1].pos {
                robotPtr++
            }
            pos3 := robotPtr
            currentNum = pos1 - pos3
        }

        if i == 0 {
            subLeft = currentLeft
            subRight = currentRight
        } else {
            newsubLeft := max(subLeft+currentLeft, subRight-prevRight+min(currentLeft+prevRight, currentNum))
            newsubRight := max(subLeft+currentRight, subRight+currentRight)
            subLeft = newsubLeft
            subRight = newsubRight
        }

        prevLeft = currentLeft
        prevRight = currentRight
        prevNum = currentNum
    }

    return max(subLeft, subRight)
}

func max(a, b int) int {
    if a > b {
        return a
    }
    return b
}

func min(a, b int) int {
    if a < b {
        return a
    }
    return b
}
```

```Python
class Solution:
    def maxWalls(self, robots: List[int], distance: List[int], walls: List[int]) -> int:
        n = len(robots)
        robot_dist = list(zip(robots, distance))
        robot_dist.sort(key=lambda x: x[0])
        walls.sort()

        m = len(walls)
        right_ptr = left_ptr = cur_ptr = robot_ptr = 0

        prev_left = prev_right = prev_num = 0
        sub_left = sub_right = 0

        for i in range(n):
            robot_pos, robot_dist_val = robot_dist[i]

            while right_ptr < m and walls[right_ptr] <= robot_pos:
                right_ptr += 1
            pos1 = right_ptr

            while cur_ptr < m and walls[cur_ptr] < robot_pos:
                cur_ptr += 1
            pos2 = cur_ptr

            if i >= 1:
                left_bound = max(robot_pos - robot_dist_val, robot_dist[i - 1][0] + 1)
            else:
                left_bound = robot_pos - robot_dist_val

            while left_ptr < m and walls[left_ptr] < left_bound:
                left_ptr += 1
            left_pos = left_ptr
            current_left = pos1 - left_pos

            if i < n - 1:
                right_bound = min(robot_pos + robot_dist_val, robot_dist[i + 1][0] - 1)
            else:
                right_bound = robot_pos + robot_dist_val

            while right_ptr < m and walls[right_ptr] <= right_bound:
                right_ptr += 1
            right_pos = right_ptr
            current_right = right_pos - pos2

            current_num = 0
            if i > 0:
                while robot_ptr < m and walls[robot_ptr] < robot_dist[i - 1][0]:
                    robot_ptr += 1
                pos3 = robot_ptr
                current_num = pos1 - pos3

            if i == 0:
                sub_left = current_left
                sub_right = current_right
            else:
                new_sub_left = max(sub_left + current_left, sub_right - prev_right + min(current_left + prev_right, current_num))
                new_sub_right = max(sub_left + current_right, sub_right + current_right)
                sub_left = new_sub_left
                sub_right = new_sub_right

            prev_left = current_left
            prev_right = current_right
            prev_num = current_num

        return max(sub_left, sub_right)
```

```Java
class Solution {
    public int maxWalls(int[] robots, int[] distance, int[] walls) {
        int n = robots.length;
        int[][] robotDist = new int[n][2];
        for (int i = 0; i < n; i++) {
            robotDist[i][0] = robots[i];
            robotDist[i][1] = distance[i];
        }
        Arrays.sort(robotDist, (a, b) -> a[0] - b[0]);
        Arrays.sort(walls);

        int m = walls.length;
        int rightPtr = 0, leftPtr = 0, curPtr = 0, robotPtr = 0;

        int prevLeft = 0, prevRight = 0, prevNum = 0;
        int subLeft = 0, subRight = 0;

        for (int i = 0; i < n; i++) {
            int robotPos = robotDist[i][0];
            int robotDistVal = robotDist[i][1];

            while (rightPtr < m && walls[rightPtr] <= robotPos) {
                rightPtr++;
            }
            int pos1 = rightPtr;

            while (curPtr < m && walls[curPtr] < robotPos) {
                curPtr++;
            }
            int pos2 = curPtr;

            int leftBound = robotPos - robotDistVal;
            if (i >= 1) {
                leftBound = Math.max(robotPos - robotDistVal, robotDist[i - 1][0] + 1);
            }
            while (leftPtr < m && walls[leftPtr] < leftBound) {
                leftPtr++;
            }
            int leftPos = leftPtr;
            int currentLeft = pos1 - leftPos;

            int rightBound = robotPos + robotDistVal;
            if (i < n - 1) {
                rightBound = Math.min(robotPos + robotDistVal, robotDist[i + 1][0] - 1);
            }
            while (rightPtr < m && walls[rightPtr] <= rightBound) {
                rightPtr++;
            }
            int rightPos = rightPtr;
            int currentRight = rightPos - pos2;

            int currentNum = 0;
            if (i > 0) {
                while (robotPtr < m && walls[robotPtr] < robotDist[i - 1][0]) {
                    robotPtr++;
                }
                int pos3 = robotPtr;
                currentNum = pos1 - pos3;
            }

            if (i == 0) {
                subLeft = currentLeft;
                subRight = currentRight;
            } else {
                int newsubLeft = Math.max(subLeft + currentLeft, subRight - prevRight + Math.min(currentLeft + prevRight, currentNum));
                int newsubRight = Math.max(subLeft + currentRight, subRight + currentRight);
                subLeft = newsubLeft;
                subRight = newsubRight;
            }

            prevLeft = currentLeft;
            prevRight = currentRight;
            prevNum = currentNum;
        }

        return Math.max(subLeft, subRight);
    }
}
```

```CSharp
public class Solution {
    public int MaxWalls(int[] robots, int[] distance, int[] walls) {
        int n = robots.Length;
        int[][] robotDist = new int[n][];
        for (int i = 0; i < n; i++) {
            robotDist[i] = new int[] { robots[i], distance[i] };
        }
        Array.Sort(robotDist, (a, b) => a[0].CompareTo(b[0]));
        Array.Sort(walls);

        int m = walls.Length;
        int rightPtr = 0, leftPtr = 0, curPtr = 0, robotPtr = 0;

        int prevLeft = 0, prevRight = 0, prevNum = 0;
        int subLeft = 0, subRight = 0;

        for (int i = 0; i < n; i++) {
            int robotPos = robotDist[i][0];
            int robotDistVal = robotDist[i][1];

            while (rightPtr < m && walls[rightPtr] <= robotPos) {
                rightPtr++;
            }
            int pos1 = rightPtr;

            while (curPtr < m && walls[curPtr] < robotPos) {
                curPtr++;
            }
            int pos2 = curPtr;

            int leftBound = robotPos - robotDistVal;
            if (i >= 1) {
                leftBound = Math.Max(robotPos - robotDistVal, robotDist[i - 1][0] + 1);
            }
            while (leftPtr < m && walls[leftPtr] < leftBound) {
                leftPtr++;
            }
            int leftPos = leftPtr;
            int currentLeft = pos1 - leftPos;

            int rightBound = robotPos + robotDistVal;
            if (i < n - 1) {
                rightBound = Math.Min(robotPos + robotDistVal, robotDist[i + 1][0] - 1);
            }
            while (rightPtr < m && walls[rightPtr] <= rightBound) {
                rightPtr++;
            }
            int rightPos = rightPtr;
            int currentRight = rightPos - pos2;

            int currentNum = 0;
            if (i > 0) {
                while (robotPtr < m && walls[robotPtr] < robotDist[i - 1][0]) {
                    robotPtr++;
                }
                int pos3 = robotPtr;
                currentNum = pos1 - pos3;
            }

            if (i == 0) {
                subLeft = currentLeft;
                subRight = currentRight;
            } else {
                int newsubLeft = Math.Max(subLeft + currentLeft, subRight - prevRight + Math.Min(currentLeft + prevRight, currentNum));
                int newsubRight = Math.Max(subLeft + currentRight, subRight + currentRight);
                subLeft = newsubLeft;
                subRight = newsubRight;
            }

            prevLeft = currentLeft;
            prevRight = currentRight;
            prevNum = currentNum;
        }

        return Math.Max(subLeft, subRight);
    }
}
```

```C
int compare(const void* a, const void* b) {
    return (*(int*)a - *(int*)b);
}

int comparePair(const void* a, const void* b) {
    int* pairA = (int*)a;
    int* pairB = (int*)b;
    return pairA[0] - pairB[0];
}

int maxInt(int a, int b) {
    return a > b ? a : b;
}

int minInt(int a, int b) {
    return a < b ? a : b;
}

int maxWalls(int* robots, int robotsSize, int* distance, int distanceSize, int* walls, int wallsSize) {
    int n = robotsSize;

    int(*robotDist)[2] = malloc(n * sizeof(int[2]));
    for (int i = 0; i < n; i++) {
        robotDist[i][0] = robots[i];
        robotDist[i][1] = distance[i];
    }
    qsort(robotDist, n, sizeof(int[2]), comparePair);
    qsort(walls, wallsSize, sizeof(int), compare);

    int m = wallsSize;
    int rightPtr = 0, leftPtr = 0, curPtr = 0, robotPtr = 0;

    int prevLeft = 0, prevRight = 0, prevNum = 0;
    int subLeft = 0, subRight = 0;

    for (int i = 0; i < n; i++) {
        int robotPos = robotDist[i][0];
        int robotDistVal = robotDist[i][1];

        while (rightPtr < m && walls[rightPtr] <= robotPos) {
            rightPtr++;
        }
        int pos1 = rightPtr;

        while (curPtr < m && walls[curPtr] < robotPos) {
            curPtr++;
        }
        int pos2 = curPtr;

        int leftBound = robotPos - robotDistVal;
        if (i >= 1) {
            leftBound = maxInt(robotPos - robotDistVal, robotDist[i - 1][0] + 1);
        }
        while (leftPtr < m && walls[leftPtr] < leftBound) {
            leftPtr++;
        }
        int leftPos = leftPtr;
        int currentLeft = pos1 - leftPos;

        int rightBound = robotPos + robotDistVal;
        if (i < n - 1) {
            rightBound = minInt(robotPos + robotDistVal, robotDist[i + 1][0] - 1);
        }
        while (rightPtr < m && walls[rightPtr] <= rightBound) {
            rightPtr++;
        }
        int rightPos = rightPtr;
        int currentRight = rightPos - pos2;

        int currentNum = 0;
        if (i > 0) {
            while (robotPtr < m && walls[robotPtr] < robotDist[i - 1][0]) {
                robotPtr++;
            }
            int pos3 = robotPtr;
            currentNum = pos1 - pos3;
        }

        if (i == 0) {
            subLeft = currentLeft;
            subRight = currentRight;
        } else {
            int newsubLeft = maxInt(subLeft + currentLeft, subRight - prevRight + minInt(currentLeft + prevRight, currentNum));
            int newsubRight = maxInt(subLeft + currentRight, subRight + currentRight);
            subLeft = newsubLeft;
            subRight = newsubRight;
        }

        prevLeft = currentLeft;
        prevRight = currentRight;
        prevNum = currentNum;
    }

    int result = maxInt(subLeft, subRight);
    free(robotDist);
    return result;
}
```

```JavaScript
function maxWalls(robots, distance, walls) {
    const n = robots.length;
    const robotDist = robots.map((r, i) => [r, distance[i]]);
    robotDist.sort((a, b) => a[0] - b[0]);
    walls.sort((a, b) => a - b);

    const m = walls.length;
    let rightPtr = 0, leftPtr = 0, curPtr = 0, robotPtr = 0;

    let prevLeft = 0, prevRight = 0, prevNum = 0;
    let subLeft = 0, subRight = 0;

    for (let i = 0; i < n; i++) {
        const [robotPos, robotDistVal] = robotDist[i];

        while (rightPtr < m && walls[rightPtr] <= robotPos) {
            rightPtr++;
        }
        const pos1 = rightPtr;

        while (curPtr < m && walls[curPtr] < robotPos) {
            curPtr++;
        }
        const pos2 = curPtr;

        let leftBound = robotPos - robotDistVal;
        if (i >= 1) {
            leftBound = Math.max(robotPos - robotDistVal, robotDist[i - 1][0] + 1);
        }
        while (leftPtr < m && walls[leftPtr] < leftBound) {
            leftPtr++;
        }
        const leftPos = leftPtr;
        const currentLeft = pos1 - leftPos;

        let rightBound = robotPos + robotDistVal;
        if (i < n - 1) {
            rightBound = Math.min(robotPos + robotDistVal, robotDist[i + 1][0] - 1);
        }
        while (rightPtr < m && walls[rightPtr] <= rightBound) {
            rightPtr++;
        }
        const rightPos = rightPtr;
        const currentRight = rightPos - pos2;

        let currentNum = 0;
        if (i > 0) {
            while (robotPtr < m && walls[robotPtr] < robotDist[i - 1][0]) {
                robotPtr++;
            }
            const pos3 = robotPtr;
            currentNum = pos1 - pos3;
        }

        if (i === 0) {
            subLeft = currentLeft;
            subRight = currentRight;
        } else {
            const newsubLeft = Math.max(subLeft + currentLeft, subRight - prevRight + Math.min(currentLeft + prevRight, currentNum));
            const newsubRight = Math.max(subLeft + currentRight, subRight + currentRight);
            subLeft = newsubLeft;
            subRight = newsubRight;
        }

        prevLeft = currentLeft;
        prevRight = currentRight;
        prevNum = currentNum;
    }

    return Math.max(subLeft, subRight);
}
```

```TypeScript
function maxWalls(robots: number[], distance: number[], walls: number[]): number {
    const n = robots.length;
    const robotDist: [number, number][] = robots.map((r, i) => [r, distance[i]]);
    robotDist.sort((a, b) => a[0] - b[0]);
    walls.sort((a, b) => a - b);

    const m = walls.length;
    let rightPtr = 0, leftPtr = 0, curPtr = 0, robotPtr = 0;

    let prevLeft = 0, prevRight = 0, prevNum = 0;
    let subLeft = 0, subRight = 0;

    for (let i = 0; i < n; i++) {
        const [robotPos, robotDistVal] = robotDist[i];

        while (rightPtr < m && walls[rightPtr] <= robotPos) {
            rightPtr++;
        }
        const pos1 = rightPtr;

        while (curPtr < m && walls[curPtr] < robotPos) {
            curPtr++;
        }
        const pos2 = curPtr;

        let leftBound = robotPos - robotDistVal;
        if (i >= 1) {
            leftBound = Math.max(robotPos - robotDistVal, robotDist[i - 1][0] + 1);
        }
        while (leftPtr < m && walls[leftPtr] < leftBound) {
            leftPtr++;
        }
        const leftPos = leftPtr;
        const currentLeft = pos1 - leftPos;

        let rightBound = robotPos + robotDistVal;
        if (i < n - 1) {
            rightBound = Math.min(robotPos + robotDistVal, robotDist[i + 1][0] - 1);
        }
        while (rightPtr < m && walls[rightPtr] <= rightBound) {
            rightPtr++;
        }
        const rightPos = rightPtr;
        const currentRight = rightPos - pos2;

        let currentNum = 0;
        if (i > 0) {
            while (robotPtr < m && walls[robotPtr] < robotDist[i - 1][0]) {
                robotPtr++;
            }
            const pos3 = robotPtr;
            currentNum = pos1 - pos3;
        }

        if (i === 0) {
            subLeft = currentLeft;
            subRight = currentRight;
        } else {
            const newsubLeft = Math.max(subLeft + currentLeft, subRight - prevRight + Math.min(currentLeft + prevRight, currentNum));
            const newsubRight = Math.max(subLeft + currentRight, subRight + currentRight);
            subLeft = newsubLeft;
            subRight = newsubRight;
        }

        prevLeft = currentLeft;
        prevRight = currentRight;
        prevNum = currentNum;
    }

    return Math.max(subLeft, subRight);
}
```

```Rust
use std::cmp;

impl Solution {
    pub fn max_walls(robots: Vec<i32>, distance: Vec<i32>, walls: Vec<i32>) -> i32 {
        let n = robots.len();

        let mut robot_dist: Vec<(i32, i32)> = robots.into_iter().zip(distance.into_iter()).collect();
        robot_dist.sort_by_key(|&(pos, _)| pos);

        let mut walls = walls;
        walls.sort();
        let m = walls.len();

        let mut right_ptr = 0;
        let mut left_ptr = 0;
        let mut cur_ptr = 0;
        let mut robot_ptr = 0;

        let mut prev_left = 0;
        let mut prev_right = 0;
        let mut prev_num = 0;
        let mut sub_left = 0;
        let mut sub_right = 0;

        for i in 0..n {
            let (robot_pos, robot_dist_val) = robot_dist[i];
            while right_ptr < m && walls[right_ptr] <= robot_pos {
                right_ptr += 1;
            }

            let pos1 = right_ptr;
            while cur_ptr < m && walls[cur_ptr] < robot_pos {
                cur_ptr += 1;
            }
            let pos2 = cur_ptr;

            let mut left_bound = robot_pos - robot_dist_val;
            if i >= 1 {
                left_bound = cmp::max(robot_pos - robot_dist_val, robot_dist[i - 1].0 + 1);
            }

            while left_ptr < m && walls[left_ptr] < left_bound {
                left_ptr += 1;
            }
            let left_pos = left_ptr;
            let current_left = (pos1 - left_pos) as i32;

            let mut right_bound = robot_pos + robot_dist_val;
            if i < n - 1 {
                right_bound = cmp::min(robot_pos + robot_dist_val, robot_dist[i + 1].0 - 1);
            }

            while right_ptr < m && walls[right_ptr] <= right_bound {
                right_ptr += 1;
            }
            let right_pos = right_ptr;
            let current_right = (right_pos - pos2) as i32;

            let current_num = if i > 0 {
                while robot_ptr < m && walls[robot_ptr] < robot_dist[i - 1].0 {
                    robot_ptr += 1;
                }
                let pos3 = robot_ptr;
                (pos1 - pos3) as i32
            } else {
                0
            };

            if i == 0 {
                sub_left = current_left;
                sub_right = current_right;
            } else {
                let new_sub_left = cmp::max(
                    sub_left + current_left,
                    sub_right - prev_right + cmp::min(current_left + prev_right, current_num)
                );
                let new_sub_right = cmp::max(
                    sub_left + current_right,
                    sub_right + current_right
                );
                sub_left = new_sub_left;
                sub_right = new_sub_right;
            }

            prev_left = current_left;
            prev_right = current_right;
            prev_num = current_num;
        }

        cmp::max(sub_left, sub_right)
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n\log n+m\log m)$。当 $n$ 远大于 $m$ 时，时间复杂度为 $O(n\log n)$；当 $m$ 远大于 $n$ 时，时间复杂度为 $O(m\log m)$。其中 $n$ 为 $robots$ 数组的长度，$m$ 为 $walls$ 数组的长度。
- 空间复杂度：$O(n+\log m)$，当 $n$ 远大于 $\log m$ 时，空间复杂度为 $O(n)$；当 $\log m$ 远大于 $n$ 时，空间复杂度为 $O(\log m)$。其中 $n$ 为 $robots$ 数组的长度，$m$ 为 $walls$ 数组的长度，$\log m$ 为 $walls$ 数组排序的栈开销。
