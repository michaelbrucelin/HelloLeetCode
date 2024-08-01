### [心算挑战](https://leetcode.cn/problems/uOAnQW/solutions/2861193/xin-suan-tiao-zhan-by-leetcode-solution-two1/)

#### 方法一：一次遍历

**思路**

将 $cards$ 从大到小排序后，先贪心的将后 $cnt$ 个数字加起来，若此时 $sum$ 为偶数，直接返回即可。

若此时答案为奇数，有两种方案:

- 在数组前面找到一个最大的奇数与后 $cnt$ 个数中最小的偶数进行替换；
- 在数组前面找到一个最大的偶数与后 $cnt$ 个数中最小的奇数进行替换。

两种方案选最大值即可。

**代码**

```C++
class Solution {
public:
    int maxmiumScore(vector<int>& cards, int cnt) {
        sort(cards.begin(), cards.end());
        
        int ans = 0;
        int tmp = 0;
        int odd, even = -1;
        int end = cards.size() - cnt;
        for (int i = cards.size() - 1; i >= end; i--) {
            tmp += cards[i];
            if (cards[i] & 1) {
                odd = cards[i];
            } else {
                even = cards[i];
            }
        }

        if (!(tmp & 1)) {
            return tmp;
        }

        for (int i = cards.size() - cnt - 1; i >= 0; i--) {
            if (cards[i] & 1) {
                if (even != -1) {
                    ans = max(ans, tmp - even + cards[i]);
                }
            } else {
                if (odd != -1) {
                    ans = max(ans, tmp - odd + cards[i]);
                }
            }
        }
        return ans;
    }
};
```

```Java
class Solution {
    public int maxmiumScore(int[] cards, int cnt) {
        Arrays.sort(cards);
        
        int ans = 0;
        int tmp = 0;
        int odd = -1, even = -1;
        int end = cards.length - cnt;
        for (int i = cards.length - 1; i >= end; i--) {
            tmp += cards[i];
            if ((cards[i] & 1) != 0) {
                odd = cards[i];
            } else {
                even = cards[i];
            }
        }

        if ((tmp & 1) == 0) {
            return tmp;
        }

        for (int i = cards.length - cnt - 1; i >= 0; i--) {
            if ((cards[i] & 1) != 0) {
                if (even != -1) {
                    ans = Math.max(ans, tmp - even + cards[i]);
                    break;
                }
            }
        }

        for (int i = cards.length - cnt - 1; i >= 0; i--) {
            if ((cards[i] & 1) == 0) {
                if (odd != -1) {
                    ans = Math.max(ans, tmp - odd + cards[i]);
                    break;
                }
            }
        }

        return ans;
    }
}
```

```CSharp
public class Solution {
    public int MaxmiumScore(int[] cards, int cnt) {
        Array.Sort(cards);
        
        int ans = 0;
        int tmp = 0;
        int odd = -1, even = -1;
        int end = cards.Length - cnt;
        for (int i = cards.Length - 1; i >= end; i--) {
            tmp += cards[i];
            if ((cards[i] & 1) != 0) {
                odd = cards[i];
            } else {
                even = cards[i];
            }
        }

        if ((tmp & 1) == 0) {
            return tmp;
        }

        for (int i = cards.Length - cnt - 1; i >= 0; i--) {
            if ((cards[i] & 1) != 0) {
                if (even != -1) {
                    ans = Math.Max(ans, tmp - even + cards[i]);
                    break;
                }
            }
        }

        for (int i = cards.Length - cnt - 1; i >= 0; i--) {
            if ((cards[i] & 1) == 0) {
                if (odd != -1) {
                    ans = Math.Max(ans, tmp - odd + cards[i]);
                    break;
                }
            }
        }

        return ans;
    }
}
```

```C
int cmp(const void *a, const void *b) {
    return *(int *)b - *(int *)a;
}

int maxmiumScore(int* cards, int cardsSize, int cnt){
    qsort(cards, cardsSize, sizeof(int), cmp);
    int ans = 0;
    int tmp = 0;
    int odd = -1, even = -1;
    int end = cardsSize - cnt;
    for (int i = 0; i < cnt; i++) {
        tmp += cards[i];
        if (cards[i] & 1) {
            odd = cards[i];
        } else {
            even = cards[i];
        }
    }
    if (!(tmp & 1)) {
        return tmp;
    }

    for (int i = cnt; i < cardsSize; i++) {
        if (cards[i] & 1) {
            if (even != -1) {
                ans = fmax(ans, tmp - even + cards[i]);
            }
        } else {
            if (odd != -1) {
                ans = fmax(ans, tmp - odd + cards[i]);
            }
        }
    }
    return ans;
}
```

```Python
class Solution:
    def maxmiumScore(self, cards: List[int], cnt: int) -> int:
        cards.sort(reverse=True)
        ans = 0
        tmp = 0
        odd = even = -1
        end = len(cards) - cnt
        for i in range(cnt):
            tmp += cards[i]
            if cards[i] % 2 == 1:
                odd = cards[i]
            else:
                even = cards[i]
        if tmp % 2 == 0:
            return tmp
        for i in range(cnt, len(cards)):
            if cards[i] % 2 == 1:
                if even != -1:
                    ans = max(ans, tmp - even + cards[i])
            else:
                if odd != -1:
                    ans = max(ans, tmp - odd + cards[i])

        return ans
```

```Go
func maxmiumScore(cards []int, cnt int) int {
    sort.Sort(sort.Reverse(sort.IntSlice(cards)))
    ans := 0
    tmp := 0
    odd, even := -1, -1
    for i := 0; i < cnt; i++ {
        tmp += cards[i]
        if cards[i] % 2 == 1 {
            odd = cards[i]
        } else {
            even = cards[i]
        }
    }
    if tmp % 2 == 0 {
        return tmp
    }
    for i := cnt; i < len(cards); i++ {
        if cards[i] % 2 == 1 {
            if even != -1 {
                ans = max(ans, tmp - even + cards[i])
            }
        } else {
            if odd != -1 {
                ans = max(ans, tmp - odd + cards[i])
            }
        }
    }

    return ans
}
```

```JavaScript
var maxmiumScore = function(cards, cnt) {
    cards.sort((a, b) => b - a);
    let ans = 0;
    let tmp = 0;
    let odd = -1, even = -1;
    for (let i = 0; i < cnt; i++) {
        tmp += cards[i];
        if (cards[i] % 2 === 1) {
            odd = cards[i];
        } else {
            even = cards[i];
        }
    }

    if (tmp % 2 === 0) {
        return tmp;
    }
    for (let i = cnt; i < cards.length; i++) {
        if (cards[i] % 2 === 1) {
            if (even !== -1) {
                ans = Math.max(ans, tmp - even + cards[i]);
            }
        } else {
            if (odd !== -1) {
                ans = Math.max(ans, tmp - odd + cards[i]);
            }
        }
    }
    return ans;
};
```

```TypeScript
function maxmiumScore(cards: number[], cnt: number): number {
    cards.sort((a, b) => b - a);
    let ans = 0;
    let tmp = 0;
    let odd: number = -1, even: number = -1;
    for (let i = 0; i < cnt; i++) {
        tmp += cards[i];
        if (cards[i] % 2 === 1) {
            odd = cards[i];
        } else {
            even = cards[i];
        }
    }
    if (tmp % 2 === 0) {
        return tmp;
    }
    for (let i = cnt; i < cards.length; i++) {
        if (cards[i] % 2 === 1) {
            if (even !== -1) {
                ans = Math.max(ans, tmp - even + cards[i]);
            }
        } else {
            if (odd !== -1) {
                ans = Math.max(ans, tmp - odd + cards[i]);
            }
        }
    }
    return ans;
};
```

```Rust
impl Solution {
    pub fn maxmium_score(cards: Vec<i32>, cnt: i32) -> i32 {
        let mut cards = cards;
        cards.sort_by(|a, b| b.cmp(a));
        let mut ans = 0;
        let mut tmp = 0;
        let mut odd = -1;
        let mut even = -1;
        for i in 0..cnt as usize {
            tmp += cards[i];
            if cards[i] % 2 == 1 {
                odd = cards[i];
            } else {
                even = cards[i];
            }
        }
        if tmp % 2 == 0 {
            return tmp;
        }
        for i in cnt as usize..cards.len() {
            if cards[i] % 2 == 1 {
                if even != -1 {
                    ans = ans.max(tmp - even + cards[i]);
                }
            } else {
                if odd != -1 {
                    ans = ans.max(tmp - odd + cards[i]);
                }
            }
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(nlogn)$，其中 $n$ 为数组的长度，主要开销在排序。
- 空间复杂度：$O(1)$。

#### 方法二：哈希

**思路**

和上种方法思路一致，但时间复杂度的开销主要在排序上还可以进一步优化。注意到 $cards[i]$ 的取值范围为 $[1,1000]$，因此可以开辟一个 $val$ 数组，$val[k]$ 表示值为 $k$ 的元素个数。将遍历 $cards$ 改为遍历 $val$，处理思路与方案一一致不再赘述。

**代码**

```C++
class Solution {
public:
    int maxmiumScore(vector<int>& cards, int cnt) {
        int val[1005];
        for (int i = 0; i < cards.size(); i++) {
            val[cards[i]]++;
        }

        int ans = 0;
        int tmp = 0;
        int ed = -1;
        int odd, even = -1;
        for (int i = 1000; i >= 1; i--) {
            if (val[i] == 0) {
                continue;
            }

            if (val[i] > cnt) {
                tmp += cnt * i;
                cnt = 0;
            } else {
                tmp += val[i] * i;
                cnt -= val[i];
                val[i] = 0;
            }

            if (i & 1) {
                odd = i;
            } else {
                even = i;
            }

            if (!cnt) {
                if (val[i] > 0) {
                    ed = i;
                } else {
                    ed = i - 1;
                }
                break;
            }
        }

        if (!(tmp & 1)) {
            return tmp;
        }

        for (int i = ed; i >= 1; i--) {
            if (val[i] == 0) {
                continue;
            }

            if (i & 1) {
                if (even != -1) {
                    ans = max(ans, tmp - even + i);
                }
            } else {
                if (odd != -1) {
                    ans = max(ans, tmp - odd + i);
                }
            }
        }

        return ans;
    }
};
```

```Java
class Solution {
    public int maxmiumScore(int[] cards, int cnt) {
        int[] val = new int[1001];
        for (int i = 0; i < cards.length; i++) {
            val[cards[i]]++;
        }

        int ans = 0;
        int tmp = 0;
        int ed = -1;
        int odd = -1, even = -1;
        for (int i = 1000; i >= 1; i--) {
            if (val[i] == 0) {
                continue;
            }

            if (val[i] > cnt) {
                tmp += cnt * i;
                cnt = 0;
            } else {
                tmp += val[i] * i;
                cnt -= val[i];
                val[i] = 0;
            }

            if ((i & 1) != 0) {
                odd = i;
            } else {
                even = i;
            }

            if (cnt == 0) {
                if (val[i] > 0) {
                    ed = i;
                } else {
                    ed = i - 1;
                }
                break;
            }
        }

        if ((tmp & 1) == 0) {
            return tmp;
        }

        for (int i = ed; i >= 1; i--) {
            if (val[i] == 0) {
                continue;
            }

            if ((i & 1) != 0) {
                if (even != -1) {
                    ans = Math.max(ans, tmp - even + i);
                }
            } else {
                if (odd != -1) {
                    ans = Math.max(ans, tmp - odd + i);
                }
            }
        }

        return ans;
    }
}
```

```CSharp
public class Solution {
    public int MaxmiumScore(int[] cards, int cnt) {
        int[] val = new int[1001];
        for (int i = 0; i < cards.Length; i++) {
            val[cards[i]]++;
        }

        int ans = 0;
        int tmp = 0;
        int ed = -1;
        int odd = -1, even = -1;
        for (int i = 1000; i >= 1; i--) {
            if (val[i] == 0) {
                continue;
            }

            if (val[i] > cnt) {
                tmp += cnt * i;
                cnt = 0;
            } else {
                tmp += val[i] * i;
                cnt -= val[i];
                val[i] = 0;
            }

            if ((i & 1) != 0) {
                odd = i;
            } else {
                even = i;
            }

            if (cnt == 0) {
                if (val[i] > 0) {
                    ed = i;
                } else {
                    ed = i - 1;
                }
                break;
            }
        }

        if ((tmp & 1) == 0) {
            return tmp;
        }

        for (int i = ed; i >= 1; i--) {
            if (val[i] == 0) {
                continue;
            }

            if ((i & 1) != 0) {
                if (even != -1) {
                    ans = Math.Max(ans, tmp - even + i);
                }
            } else {
                if (odd != -1) {
                    ans = Math.Max(ans, tmp - odd + i);
                }
            }
        }

        return ans;
    }
}
```

```C
int maxmiumScore(int* cards, int cardsSize, int cnt){
    int val[1005] = {0};
    for (int i = 0; i < cardsSize; i++) {
        val[cards[i]]++;
    }
    int ans = 0;
    int tmp = 0;
    int ed = -1;
    int odd = -1, even = -1;
    for (int i = 1000; i >= 1; i--) {
        if (val[i] == 0) {
            continue;
        }
        if (val[i] > cnt) {
            tmp += cnt * i;
            cnt = 0;
        } else {
            tmp += val[i] * i;
            cnt -= val[i];
            val[i] = 0;
        }

        if (i & 1) {
            odd = i;
        } else {
            even = i;
        }

        if (!cnt) {
            if (val[i] > 0) {
                ed = i;
            } else {
                ed = i - 1;
            }
            break;
        }
    }

    if (!(tmp & 1)) {
        return tmp;
    }

    for (int i = ed; i >= 1; i--) {
        if (val[i] == 0) {
            continue;
        }
        if (i & 1) {
            if (even != -1) {
                ans = fmax(ans, tmp - even + i);
            }
        } else {
            if (odd != -1) {
                ans = fmax(ans, tmp - odd + i);
            }
        }
    }

    return ans;
}
```

```Python
class Solution:
    def maxmiumScore(self, cards: List[int], cnt: int) -> int:
        val = [0] * 1005
        for card in cards:
            val[card] += 1

        ans, tmp, ed = 0, 0, -1
        odd = even = -1
        for i in range(1000, 0, -1):
            if val[i] == 0:
                continue
            if val[i] > cnt:
                tmp += cnt * i
                cnt = 0
            else:
                tmp += val[i] * i
                cnt -= val[i]
                val[i] = 0
            if i % 2 == 1:
                odd = i
            else:
                even = i
            if cnt == 0:
                if val[i] > 0:
                    ed = i
                else:
                    ed = i - 1
                break

        if tmp % 2 == 0:
            return tmp
        for i in range(ed, 0, -1):
            if val[i] == 0:
                continue
            if i % 2 == 1:
                if even != -1:
                    ans = max(ans, tmp - even + i)
            else:
                if odd != -1:
                    ans = max(ans, tmp - odd + i)

        return ans
```

```Go
func maxmiumScore(cards []int, cnt int) int {
    val := make([]int, 1005)
    for _, card := range cards {
        val[card]++
    }
    ans := 0
    tmp := 0
    ed := -1
    odd, even := -1, -1
    for i := 1000; i >= 1; i-- {
        if val[i] == 0 {
            continue
        }
        if val[i] > cnt {
            tmp += cnt * i
            cnt = 0
        } else {
            tmp += val[i] * i
            cnt -= val[i]
            val[i] = 0
        }
        if i%2 == 1 {
            odd = i
        } else {
            even = i
        }
        if cnt == 0 {
            if val[i] > 0 {
                ed = i
            } else {
                ed = i - 1
            }
            break
        }
    }

    if tmp % 2 == 0 {
        return tmp
    }
    for i := ed; i >= 1; i-- {
        if val[i] == 0 {
            continue
        }
        if i % 2 == 1 {
            if even != -1 {
                ans = max(ans, tmp - even + i)
            }
        } else {
            if odd != -1 {
                ans = max(ans, tmp - odd + i)
            }
        }
    }
    return ans
}
```

```JavaScript
var maxmiumScore = function(cards, cnt) {
    const val = new Array(1005).fill(0);
    for (let card of cards) {
        val[card]++;
    }
    let ans = 0;
    let tmp = 0;
    let ed = -1;
    let odd = -1, even = -1;
    for (let i = 1000; i >= 1; i--) {
        if (val[i] === 0) {
            continue;
        }

        if (val[i] > cnt) {
            tmp += cnt * i;
            cnt = 0;
        } else {
            tmp += val[i] * i;
            cnt -= val[i];
            val[i] = 0;
        }
        if (i % 2 === 1) {
            odd = i;
        } else {
            even = i;
        }
        if (cnt === 0) {
            if (val[i] > 0) {
                ed = i;
            } else {
                ed = i - 1;
            }
            break;
        }
    }

    if (tmp % 2 === 0) {
        return tmp;
    }
    for (let i = ed; i >= 1; i--) {
        if (val[i] === 0) {
            continue;
        }
        if (i % 2 === 1) {
            if (even !== -1) {
                ans = Math.max(ans, tmp - even + i);
            }
        } else {
            if (odd !== -1) {
                ans = Math.max(ans, tmp - odd + i);
            }
        }
    }

    return ans;
};
```

```TypeScript
function maxmiumScore(cards: number[], cnt: number): number {
    const val: number[] = new Array(1005).fill(0);
    for (let card of cards) {
        val[card]++;
    }
    let ans = 0;
    let tmp = 0;
    let ed = -1;
    let odd: number = -1, even: number = -1;
    for (let i = 1000; i >= 1; i--) {
        if (val[i] === 0) {
            continue;
        }

        if (val[i] > cnt) {
            tmp += cnt * i;
            cnt = 0;
        } else {
            tmp += val[i] * i;
            cnt -= val[i];
            val[i] = 0;
        }
        if (i % 2 === 1) {
            odd = i;
        } else {
            even = i;
        }
        if (cnt === 0) {
            if (val[i] > 0) {
                ed = i;
            } else {
                ed = i - 1;
            }
            break;
        }
    }
    if (tmp % 2 === 0) {
        return tmp;
    }
    for (let i = ed; i >= 1; i--) {
        if (val[i] === 0) {
            continue;
        }

        if (i % 2 === 1) {
            if (even !== -1) {
                ans = Math.max(ans, tmp - even + i);
            }
        } else {
            if (odd !== -1) {
                ans = Math.max(ans, tmp - odd + i);
            }
        }
    }
    return ans;
};
```

```Rust
impl Solution {
    pub fn maxmium_score(cards: Vec<i32>, cnt: i32) -> i32 {
        let mut cnt = cnt;
        let mut val = vec![0; 1005];
        for &card in &cards {
            val[card as usize] += 1;
        }
        let mut ans = 0;
        let mut tmp = 0;
        let mut ed = -1;
        let mut odd = -1;
        let mut even = -1;
        for i in (1..=1000).rev() {
            if val[i] == 0 {
                continue;
            }
            if val[i] > cnt {
                tmp += cnt * i as i32;
                cnt = 0;
            } else {
                tmp += val[i] * i as i32;
                cnt -= val[i];
                val[i] = 0;
            }
            if i % 2 == 1 {
                odd = i as i32;
            } else {
                even = i as i32;
            }
            if cnt == 0 {
                if val[i] > 0 {
                    ed = i as i32;
                } else {
                    ed = (i - 1) as i32;
                }
                break;
            }
        }
        if tmp % 2 == 0 {
            return tmp;
        }
        for i in (1..=ed as usize).rev() {
            if val[i] == 0 {
                continue;
            }
            if i % 2 == 1 {
                if even != -1 {
                    ans = ans.max(tmp - even + i as i32);
                }
            } else {
                if odd != -1 {
                    ans = ans.max(tmp - odd + i as i32);
                }
            }
        }

        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 为数组的长度。
- 空间复杂度：$O(C)$，其中 $C=1000$ 表示 $cards[i]$ 的取值范围。
