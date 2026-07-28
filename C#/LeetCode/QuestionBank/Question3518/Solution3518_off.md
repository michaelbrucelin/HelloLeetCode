### [最小回文排列 II](https://leetcode.cn/problems/smallest-palindromic-rearrangement-ii/solutions/4000592/zui-xiao-hui-wen-pai-lie-ii-by-leetcode-0k0b2/)

本题是 [3517\. 最小回文排列 I](https://leetcode.cn/problems/smallest-palindromic-rearrangement-i/) 的扩展，建议先完成前置题目。

#### 方法一：组合数学 + 试填法

**思路与算法**

本题求的是第 $k$ 小的回文排列，相比和前置题目，延伸到了更一般的情况。由前置题目可知，其中心对称的性质要求 $s$ 关于中心点两侧的字符构成的多重集始终一致且不变，故本题的关键其实不在于回文，我们只需要考虑左半部分（或右半部分）的子排列即可，具体证明见前置题目的官方题解。

此时问题转化为给定字符多重集，求：该集合按字典序构成的第 $k$ 个排列是什么？

首先使用试填法，对于每个位置，尝试从当前字符集取出字符填入。我们从小到大尝试填入字符，设当前已经填好的前缀为 $prefix$，试填的字符为 $c$，将该前缀能构造的排列中，字典序最大的序数设为上界 $R$，对应的下界为 $L$。

- 当 $R\ge k$ 时，由于我们是从小到大填的，说明 $k$ 第一次进入该前缀能覆盖到的区间，故第 $k$ 个排列的前缀就是 $prefix\parallel c$（$prefix$ 与 $c$ 拼接）。我们需要更新前缀 $prefix^′$ 为 $prefix\parallel c$，并继续试填下一个位置。
- 当 $R<k$ 时，说明这个前缀太小，我们需要将这个字符放回多重集，然后继续按顺序试填下一个字符，并更新 $L=R+1$。
- 如果能填的字符都填完仍有 $R<k$，说明无解，返回空字符串。

初始的时候设 $L=1$。现在的问题是，如果我们知道了某个前缀构成的最小排列的字典序 $L$，那么如何求该前缀能构成最大排列对应的字典序 $R$？

康托展开算法描述了如何通过给定的排列，求该排列在所有排列中的字典序，这里要做的其实就是康托展开的逆过程。而康托展开的思想基于组合数学，故考虑使用组合数学求解。

由于要求的排列总长度的是已知的，设去掉前缀和试填的字符 $c$ 后，还有 $rem$ 个位置，剩余能填的字符都在多重集 $W$ 中。

设多重集 $W$ 中，不同字符的种类为 $c_1,c_2,\dots ,c_{\sigma}$，且每个字符当前的剩余出现次数记为 $cnt[c_i]$，其中 $\sigma $ 是字符集的大小。显然有 $\sum cnt[c_i]=rem$。由这些剩余字符构成的合法的排列总数 $P$ 为：

$$P=\dfrac{rem!}{cnt[c_1]!\times cnt[c_2]!\times \dots \times cnt[c_{\sigma}]!}$$

简写为连乘的形式：

$$P=\dfrac{rem!}{\Pi_{c\in W}cnt[c]!}$$

于是我们得到 $R=L+P-1$。

但是，本题不支持使用高精度算法或者乘法逆元，我们无法直接使用阶乘求解，因此先将其进一步拆分为组合数相乘的形式：

1. 当前共有 $rem$ 个空位，我们先从中选出 $cnt[c_1]$ 个位置，专门用来放置字符 $c_1$，方案数为 ${\large C}_{rem}^{cnt[c_1]}$。
2. 放置完毕后，还剩下 $rem-cnt[c_1]$ 个空位。我们再从中选出 $cnt[c_2]$ 个位置，用来放置字符 $c_2$，方案数为 ${\large C}_{rem-cnt[c_1]}^{cnt[c_2]}$。
3. 以此类推，直到所有字符均被放置到对应的位置上。基于乘法原理，将各步的方案数相乘即可得到合法的排列总数 $P$。

于是得到：

$$P=\mathop{\Pi}\limits_{i=1}^{\sigma}{\Large C}_{rem-\sum_{j=1}^{i-1}cnt[c_j]}^{cnt[c_i]}$$

直接使用阶乘计算组合数仍不可行，但由于 $k$ 是一个给定的整型常数，在任何时候都需要保证 $k\ge {\large C}_n^m$，在此限制下，使用组合数的乘法展开：

$${\Large C}_n^m=\mathop{\Pi}\limits_{i=1}^{m}\dfrac{n-i+1}{i}$$

首先利用组合数的对称性，计算前令 $m=min(m,n-m)$，避免中间过程溢出。

然后在单步迭代中，维护当前的组合数结果 $res_i$。此时有 $res_i=res_{i-1}\times\frac{n-i+1}{i}$。由于连续 $i$ 个整数的乘积必然能被 $i!$ 整除，只要在实现中先乘后除，即可确保每一步的 $res_i$ 都是一个准确的整数。再根据 $k$ 的限制，在 $res_i>k$ 时**及时截断退出计算**，即可保证仅使用整数计算的情况下，安全地求出组合数。

按上述算法，使用试填法枚举构造排列，使用组合数学计算排列数，即可求出目标排列，最后按题意构造回文串即可。

**关于排列数计算的时间复杂度分析**

首先考虑组合数计算的时间复杂度。单次组合数计算要么提前退出，要么计算 $cnt[c_i]$ 次。考虑提前退出的情况，在取 $m=min(m,n-m)$ 的情况下，如果循环执行了 $x$ 次（$x\le m$）次，对组合数 ${\large c}_n^m$ 展开并重新配对有：

$${n \choose x}=\dfrac{n(n-1)\dots (n-x+1)}{x(x-1)\dots 1}=\mathop{\Pi}\limits_{j=0}^{x-1}\dfrac{n-j}{x-j}$$

因为 $n\ge 2m\ge 2x$，对于乘积中的任意一项均有：

$$\dfrac{n-j}{x-j}\ge\dfrac{2x-j}{x-j}=1+\dfrac{x}{x-j}\ge 2$$

为了满足 ${\large c}_n^m\le k$，故这种情况下的时间复杂度为 $O(\log k)$，于是我们得到单次组合数计算的时间复杂度：$O(min(cnt[c_i],\log k))$。

然后考虑计算 $P$ 所需的时间复杂度，假设对于每个有效字符，组合数内部循环分别执行了 $x_1,x_2,\dots ,x_p$ 次，那么累乘的结果至少为：

$$2^{x_1}\times 2^{x_2}\times \dots \times 2^{x_p}=2^{\sum x_j}$$

此时满足 $2^{\sum x_j}\le k$，即：

$$\sum x_j\le \log k$$

所以此时的时间复杂度应为 $O(\log k)$。

另一方面，循环也受限于剩余待填入的字符总数 $rem$，故有 $\sum x_j\le rem$。显然 rem与原串 $s$ 的长度 $N$ 呈线性相关，所以累加次数上限为 $O(N)$。综上，内层组合数迭代的总次数为 $O(min(N,\log k))$。

考虑到外层循环必须检查整个字符集，这部分有基础的遍历开销 $O(\sigma )$。

因此，求解 $P$ 所需的总时间复杂度为外层开销与内层总迭代之和，即 $O(\sigma +min(N,\log k))$。

**代码**

```C++
class Solution {
private:
    long long comb(long long n, long long m, long long k) {
        long long res = 1;
        m = std::min(m, n - m);

        for (long long i = 1; i <= m; i++) {
            res = res * (n - i + 1) / i;
            if (res > k) {
                return k + 1;
            }
        }
        return res;
    }

public:
    std::string smallestPalindrome(std::string s, long long k) {
        int partition = s.length() / 2;
        std::vector<int> bucket(26, 0);

        for (int i = 0; i < partition; i++) {
            bucket[s[i] - 'a'] += 1;
        }

        auto permutations = [&](int rem) {
            long long ways = 1;
            for (int i = 0; i < 26; i++) {
                if (bucket[i] == 0) {
                    continue;
                }

                ways *= comb(rem, bucket[i], k);
                if (ways > k) {
                    break;
                }
                rem -= bucket[i];
            }
            return ways;
        };

        std::string left = "";
        long long startIndex = 1;

        for (int pos = 0; pos < partition; pos++) {
            for (int i = 0; i < 26; i++) {
                if (bucket[i] == 0) {
                    continue;
                }

                bucket[i] -= 1;

                long long ways = permutations(partition - pos - 1);
                if (startIndex + ways > k) {
                    left += (char)(i + 'a');
                    break;
                }

                bucket[i] += 1;
                startIndex += ways;
            }
        }

        if (left.length() < partition) {
            return "";
        }

        std::string mid =
            s.length() % 2 != 0 ? std::string(1, s[partition]) : "";
        std::string right = left;
        std::reverse(right.begin(), right.end());

        return left + mid + right;
    }
};
```

```Go
func smallestPalindrome(s string, k int) string {
	partition := len(s) / 2
	bucket := make([]int, 26)

	for i := 0; i < partition; i++ {
		bucket[s[i]-'a'] += 1
	}

	comb := func(n, m, kVal int) int {
		res := 1
		if n-m < m {
			m = n - m
		}

		for i := 1; i <= m; i++ {
			res = res * (n - i + 1) / i
			if res > kVal {
				return kVal + 1
			}
		}
		return res
	}

	permutations := func(rem int) int {
		ways := 1
		for i := 0; i < 26; i++ {
			if bucket[i] == 0 {
				continue
			}

			ways *= comb(rem, bucket[i], k)
			if ways > k {
				break
			}
			rem -= bucket[i]
		}
		return ways
	}

	left := []byte{}
	startIndex := 1

	for pos := 0; pos < partition; pos++ {
		for i := 0; i < 26; i++ {
			if bucket[i] == 0 {
				continue
			}

			bucket[i] -= 1

			ways := permutations(partition - pos - 1)
			if startIndex+ways > k {
				left = append(left, byte(i+'a'))
				break
			}

			bucket[i] += 1
			startIndex += ways
		}
	}

	if len(left) < partition {
		return ""
	}

	totalLen := len(s)
	res := make([]byte, totalLen)

	for i := 0; i < partition; i++ {
		res[i] = left[i]
		res[totalLen-1-i] = left[i]
	}

	if totalLen%2 != 0 {
		res[partition] = s[partition]
	}

	return string(res)
}
```

```Python
class Solution:
    def smallestPalindrome(self, s: str, k: int) -> str:
        def comb(n: int, m: int, k_limit: int) -> int:
            res = 1
            m = min(m, n - m)

            for i in range(1, m + 1):
                res = res * (n - i + 1) // i
                if res > k_limit:
                    return k_limit + 1
            return res

        partition = len(s) // 2
        bucket = [0] * 26

        for i in range(partition):
            bucket[ord(s[i]) - 97] += 1

        def permutations(rem: int) -> int:
            ways = 1
            for i in range(26):
                if bucket[i] == 0:
                    continue

                ways *= comb(rem, bucket[i], k)
                if ways > k:
                    break
                rem -= bucket[i]
            return ways

        left_chars = []
        start_index = 1

        for pos in range(partition):
            for i in range(26):
                if bucket[i] == 0:
                    continue

                bucket[i] -= 1

                ways = permutations(partition - pos - 1)
                if start_index + ways > k:
                    left_chars.append(chr(i + 97))
                    break

                bucket[i] += 1
                start_index += ways

        if len(left_chars) < partition:
            return ""

        mid = s[partition] if len(s) % 2 != 0 else ""
        left_str = "".join(left_chars)
        right_str = left_str[::-1]

        return left_str + mid + right_str
```

```Java
class Solution {
    private long comb(long n, long m, long k) {
        long res = 1;
        m = Math.min(m, n - m);

        for (long i = 1; i <= m; i++) {
            res = res * (n - i + 1) / i;
            if (res > k) {
                return k + 1;
            }
        }
        return res;
    }

    private long permutations(int rem, int[] bucket, long k) {
        long ways = 1;
        for (int i = 0; i < 26; i++) {
            if (bucket[i] == 0) {
                continue;
            }

            ways *= comb(rem, bucket[i], k);
            if (ways > k) {
                break;
            }
            rem -= bucket[i];
        }
        return ways;
    }

    public String smallestPalindrome(String s, long k) {
        int partition = s.length() / 2;
        int[] bucket = new int[26];

        for (int i = 0; i < partition; i++) {
            bucket[s.charAt(i) - 97] += 1;
        }

        StringBuilder left = new StringBuilder();
        long startIndex = 1;

        for (int pos = 0; pos < partition; pos++) {
            for (int i = 0; i < 26; i++) {
                if (bucket[i] == 0) {
                    continue;
                }

                bucket[i] -= 1;

                long ways = permutations(partition - pos - 1, bucket, k);
                if (startIndex + ways > k) {
                    left.append((char) (i + 97));
                    break;
                }

                bucket[i] += 1;
                startIndex += ways;
            }
        }

        if (left.length() < partition) {
            return "";
        }

        if (s.length() % 2 != 0) {
            left.append(s.charAt(partition));
        }

        for (int i = partition - 1; i >= 0; i--) {
            left.append(left.charAt(i));
        }

        return left.toString();
    }
}
```

```TypeScript
const C = (n: number, m: number, k: number) => {
    let res = 1;
    m = Math.min(m, n - m);

    for (let i = 1; i <= m; i++) {
        res = res * (n - i + 1) / i;
        if (res > k) {
            return k + 1;
        }
    }
    return res;
}

function smallestPalindrome(s: string, k: number): string {
    const partition = Math.floor(s.length / 2);
    const bucket = new Int32Array(26);

    for (let i = 0; i < partition; i++) {
        bucket[s.charCodeAt(i) - 97] += 1;
    }

    const permutations = (rem: number) => {
        let ways = 1;
        for (let i = 0; i < 26; i++) {
            if (bucket[i] === 0) {
                continue;
            }

            ways *= C(rem, bucket[i], k);
            if (ways > k) {
                break;
            }
            rem -= bucket[i];
        }
        return ways;
    }

    let left = "";
    let startIndex = 1;
    for (let pos = 0; pos < partition; pos++) {
        for (let i = 0; i < 26; i++) {
            if (bucket[i] === 0) {
                continue;
            }

            bucket[i] -= 1;

            const ways = permutations(partition - pos - 1);
            if (startIndex + ways > k) {
                left += String.fromCharCode(i + 97);
                break;
            }

            bucket[i] += 1;
            startIndex += ways;
        }
    }

    if (left.length < partition) {
        return "";
    }

    const mid = s.length % 2 !== 0 ? s[partition] : "";
    const right = left.split('').reverse().join('')

    return left + mid + right;
};
```

```JavaScript
var smallestPalindrome = function(s, k) {
    const C = (n, m, kLimit) => {
        let res = 1;
        m = Math.min(m, n - m);

        for (let i = 1; i <= m; i++) {
            res = res * (n - i + 1) / i;
            if (res > kLimit) {
                return kLimit + 1;
            }
        }
        return res;
    }

    const partition = Math.floor(s.length / 2);
    const bucket = new Int32Array(26);

    for (let i = 0; i < partition; i++) {
        bucket[s.charCodeAt(i) - 97] += 1;
    }

    const permutations = (rem) => {
        let ways = 1;
        for (let i = 0; i < 26; i++) {
            if (bucket[i] === 0) {
                continue;
            }

            ways *= C(rem, bucket[i], k);
            if (ways > k) {
                break;
            }
            rem -= bucket[i];
        }
        return ways;
    }

    let left = "";
    let startIndex = 1;

    for (let pos = 0; pos < partition; pos++) {
        for (let i = 0; i < 26; i++) {
            if (bucket[i] === 0) {
                continue;
            }

            bucket[i] -= 1;

            const ways = permutations(partition - pos - 1);
            if (startIndex + ways > k) {
                left += String.fromCharCode(i + 97);
                break;
            }

            bucket[i] += 1;
            startIndex += ways;
        }
    }

    if (left.length < partition) {
        return "";
    }

    const mid = s.length % 2 !== 0 ? s[partition] : "";
    const right = left.split('').reverse().join('');

    return left + mid + right;
};
```

```CSharp
public class Solution {
    public string SmallestPalindrome(string s, long k) {
        int partition = s.Length / 2;
        int[] bucket = new int[26];

        for (int i = 0; i < partition; i++) {
            bucket[s[i] - 97] += 1;
        }

        long C(long n, long m) {
            long res = 1;
            m = Math.Min(m, n - m);

            for (long i = 1; i <= m; i++) {
                res = res * (n - i + 1) / i;
                if (res > k) {
                    return k + 1;
                }
            }
            return res;
        }

        long Permutations(int rem) {
            long ways = 1;
            for (int i = 0; i < 26; i++) {
                if (bucket[i] == 0) {
                    continue;
                }

                ways *= C(rem, bucket[i]);
                if (ways > k) {
                    break;
                }
                rem -= bucket[i];
            }
            return ways;
        }

        var left = new StringBuilder();
        long startIndex = 1;

        for (int pos = 0; pos < partition; pos++) {
            for (int i = 0; i < 26; i++) {
                if (bucket[i] == 0) {
                    continue;
                }

                bucket[i] -= 1;

                long ways = Permutations(partition - pos - 1);
                if (startIndex + ways > k) {
                    left.Append((char)(i + 97));
                    break;
                }

                bucket[i] += 1;
                startIndex += ways;
            }
        }

        if (left.Length < partition) {
            return "";
        }

        if (s.Length % 2 != 0) {
            left.Append(s[partition]);
        }

        for (int i = partition - 1; i >= 0; i--) {
            left.Append(left[i]);
        }

        return left.ToString();
    }
}
```

```C
long long comb(long long n, long long m, long long k) {
    long long res = 1;
    if (n - m < m) {
        m = n - m;
    }

    for (long long i = 1; i <= m; i++) {
        res = res * (n - i + 1) / i;
        if (res > k) {
            return k + 1;
        }
    }
    return res;
}

long long permutations(int rem, int* bucket, long long k) {
    long long ways = 1;
    for (int i = 0; i < 26; i++) {
        if (bucket[i] == 0) {
            continue;
        }

        ways *= comb(rem, bucket[i], k);
        if (ways > k) {
            break;
        }
        rem -= bucket[i];
    }
    return ways;
}

char* smallestPalindrome(char* s, long long k) {
    int len = strlen(s);
    int partition = len / 2;
    int bucket[26] = {0};

    for (int i = 0; i < partition; i++) {
        bucket[s[i] - 'a'] += 1;
    }

    char* left = (char*)malloc(partition + 1);
    int left_idx = 0;
    long long start_index = 1;

    for (int pos = 0; pos < partition; pos++) {
        for (int i = 0; i < 26; i++) {
            if (bucket[i] == 0) {
                continue;
            }

            bucket[i] -= 1;

            long long ways = permutations(partition - pos - 1, bucket, k);
            if (start_index + ways > k) {
                left[left_idx++] = i + 'a';
                break;
            }

            bucket[i] += 1;
            start_index += ways;
        }
    }
    left[left_idx] = '\0';

    if (left_idx < partition) {
        char* empty_res = (char*)malloc(1);
        empty_res[0] = '\0';
        free(left);
        return empty_res;
    }

    char* result = (char*)malloc(len + 1);
    int res_idx = 0;

    for (int i = 0; i < partition; i++) {
        result[res_idx++] = left[i];
    }

    if (len % 2 != 0) {
        result[res_idx++] = s[partition];
    }

    for (int i = partition - 1; i >= 0; i--) {
        result[res_idx++] = left[i];
    }
    result[res_idx] = '\0';

    free(left);
    return result;
}
```

```Rust
impl Solution {
    pub fn smallest_palindrome(s: String, k: i32) -> String {
        let partition = s.len() / 2;
        let mut bucket = [0_i32; 26];
        let s_bytes = s.as_bytes();

        for i in 0..partition {
            bucket[(s_bytes[i] - b'a') as usize] += 1;
        }

        let comb = |n: i32, mut m: i32, k_val: i32| -> i64 {
            let mut res = 1_i64;
            if n - m < m {
                m = n - m;
            }

            for i in 1..=m {
                res = res * (n as i64 - i as i64 + 1) / (i as i64);
                if res > k_val as i64 {
                    return (k_val + 1) as i64;
                }
            }
            res
        };

        let mut left = String::with_capacity(partition);
        let mut start_index = 1_i64;
        let k_i64 = k as i64;

        for pos in 0..partition {
            for i in 0..26 {
                if bucket[i] == 0 {
                    continue;
                }

                bucket[i] -= 1;

                let mut ways = 1_i64;
                let mut rem = (partition - pos - 1) as i32;

                for j in 0..26 {
                    if bucket[j] == 0 {
                        continue;
                    }

                    ways *= comb(rem, bucket[j], k);
                    if ways > k_i64 {
                        break;
                    }
                    rem -= bucket[j];
                }

                if start_index + ways > k_i64 {
                    left.push((i as u8 + b'a') as char);
                    break;
                }

                bucket[i] += 1;
                start_index += ways;
            }
        }

        if left.len() < partition {
            return String::new();
        }

        let total_len = s.len();
        let mut res = vec![0_u8; total_len];
        let left_bytes = left.as_bytes();

        for i in 0..partition {
            res[i] = left_bytes[i];
            res[total_len - 1 - i] = left_bytes[i];
        }

        if total_len % 2 != 0 {
            res[partition] = s_bytes[partition];
        }

        String::from_utf8(res).unwrap()
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n\cdot \sigma \cdot (\sigma +min(n,\log k)))$，其中 $n$ 是回文串 $s$ 的长度，$\sigma$ 是字符集的大小，本题中是 $26$。遍历每一个候选位置需要 $O(n)$，遍历字符集需要 $O(\sigma)$，然后计算排列数需要 $O(\sigma +min(n,\log k))$。故总时间复杂度是 $O(n\cdot \sigma \cdot (\sigma +min(n,\log k)))$。计算排列数 $P$ 的时间复杂度分析见题解正文部分。
- 空间复杂度：$O(1)$ 或 $O(n)$，取决于拼接字符串时是原地修改还是额外开辟空间。辅助数组 $bucket$ 占用空间 $O(\sigma)$，可以看作常数。
