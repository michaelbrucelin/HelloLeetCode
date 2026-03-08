### [找出不同的二进制字符串](https://leetcode.cn/problems/find-unique-binary-string/solutions/951996/zhao-chu-bu-tong-de-er-jin-zhi-zi-fu-chu-0t10/)

#### 方法一：转化为整数

**思路与算法**

我们可以将长度为 $n$ 的二进制字符串看作 $[0,2^n-1]$ 闭区间内正整数的二进制表示，这样就建立起了字符串和整数之间的**一一映射**。

我们可以将 $nums$ 中所有字符串转化为对应的整数放在哈希集合中。由于该哈希集合中有 $n$ 个元素，因此根据鸽巢原理，在 $[0,n]$ **闭区间**的 $n+1$ 个整数中一定存在一个整数，它不在该哈希集合中。换言之，该整数对应的字符串一定没有在 $nums$ 中出现。

因此，在预处理哈希集合后，我们只需要遍历 $[0,n]$ 闭区间中的整数，当找到第一个不在哈希集合中的整数时，我们将它转化为对应的二进制字符串返回即可。

**代码**

```C++
class Solution {
public:
    string findDifferentBinaryString(vector<string>& nums) {
        int n = nums.size();
        // 预处理对应整数的哈希集合
        unordered_set<int> vals;
        for (const string& num : nums){
            vals.insert(stoi(num, nullptr, 2));
        }
        // 寻找第一个不在哈希集合中的整数
        int val = 0;
        while (vals.count(val)){
            ++val;
        }
        // 将整数转化为二进制字符串返回
        return bitset<16>(val).to_string().substr(16 - n, 16);
    }
};
```

```Python
class Solution:
    def findDifferentBinaryString(self, nums: List[str]) -> str:
        n = len(nums)
        # 预处理对应整数的哈希集合
        vals = {int(num, 2) for num in nums}
        # 寻找第一个不在哈希集合中的整数
        val = 0
        while val in vals:
            val += 1
        # 将整数转化为二进制字符串返回
        res = "{:b}".format(val)
        return '0' * (n - len(res)) + res
```

```Java
class Solution {
    public String findDifferentBinaryString(String[] nums) {
        int n = nums.length;
        // 预处理对应整数的哈希集合
        Set<Integer> vals = new HashSet<>();
        for (String num : nums) {
            vals.add(Integer.parseInt(num, 2));
        }
        // 寻找第一个不在哈希集合中的整数
        int val = 0;
        while (vals.contains(val)) {
            ++val;
        }
        // 将整数转化为二进制字符串返回
        StringBuilder sb = new StringBuilder(Integer.toBinaryString(val));
        // 补齐前导0
        while (sb.length() < n) {
            sb.insert(0, "0");
        }
        return sb.toString();
    }
}
```

```CSharp
public class Solution {
    public string FindDifferentBinaryString(string[] nums) {
        int n = nums.Length;
        // 预处理对应整数的哈希集合
        HashSet<int> vals = new HashSet<int>();
        foreach (string num in nums) {
            vals.Add(Convert.ToInt32(num, 2));
        }
        // 寻找第一个不在哈希集合中的整数
        int val = 0;
        while (vals.Contains(val)) {
            ++val;
        }
        // 将整数转化为二进制字符串返回
        string binary = Convert.ToString(val, 2);
        // 补齐前导0
        while (binary.Length < n) {
            binary = "0" + binary;
        }
        return binary;
    }
}
```

```Go
func findDifferentBinaryString(nums []string) string {
    n := len(nums)
    // 预处理对应整数的哈希集合
    vals := make(map[int]bool)
    for _, num := range nums {
        val, _ := strconv.ParseInt(num, 2, 32)
        vals[int(val)] = true
    }
    // 寻找第一个不在哈希集合中的整数
    val := 0
    for vals[val] {
        val++
    }
    // 将整数转化为二进制字符串返回
    binary := strconv.FormatInt(int64(val), 2)
    // 补齐前导0
    if len(binary) < n {
        binary = strings.Repeat("0", n - len(binary)) + binary
    }
    return binary
}
```

```C
typedef struct {
    int key;
    UT_hash_handle hh;
} HashItem;

HashItem *hashFindItem(HashItem **obj, int key) {
    HashItem *pEntry = NULL;
    HASH_FIND_INT(*obj, &key, pEntry);
    return pEntry;
}

bool hashAddItem(HashItem **obj, int key) {
    if (hashFindItem(obj, key)) {
        return false;
    }
    HashItem *pEntry = (HashItem *)malloc(sizeof(HashItem));
    pEntry->key = key;
    HASH_ADD_INT(*obj, key, pEntry);
    return true;
}

void hashFree(HashItem **obj) {
    HashItem *curr = NULL, *tmp = NULL;
    HASH_ITER(hh, *obj, curr, tmp) {
        HASH_DEL(*obj, curr);
        free(curr);
    }
}


char* findDifferentBinaryString(char** nums, int numsSize) {
    int n = numsSize;
    // 预处理对应整数的哈希集合
    HashItem *vals = NULL;
    for (int i = 0; i < numsSize; i++) {
        int val = 0;
        for (int j = 0; j < n; j++) {
            val = (val << 1) | (nums[i][j] - '0');
        }
        hashAddItem(&vals, val);
    }

    // 寻找第一个不在哈希集合中的整数
    int val = 0;
    while (hashFindItem(&vals, val)) {
        ++val;
    }

    // 将整数转化为二进制字符串
    char* result = (char*)malloc((n + 1) * sizeof(char));
    result[n] = '\0';
    for (int i = n - 1; i >= 0; i--) {
        result[i] = (val & 1) ? '1' : '0';
        val >>= 1;
    }

    hashFree(&vals);
    return result;
}
```

```JavaScript
var findDifferentBinaryString = function(nums) {
    const n = nums.length;
    // 预处理对应整数的哈希集合
    const vals = new Set();
    for (const num of nums) {
        vals.add(parseInt(num, 2));
    }
    // 寻找第一个不在哈希集合中的整数
    let val = 0;
    while (vals.has(val)) {
        ++val;
    }
    // 将整数转化为二进制字符串返回
    let binary = val.toString(2);
    // 补齐前导0
    while (binary.length < n) {
        binary = '0' + binary;
    }
    return binary;
};
```

```TypeScript
function findDifferentBinaryString(nums: string[]): string {
    const n = nums.length;
    // 预处理对应整数的哈希集合
    const vals = new Set<number>();
    for (const num of nums) {
        vals.add(parseInt(num, 2));
    }
    // 寻找第一个不在哈希集合中的整数
    let val = 0;
    while (vals.has(val)) {
        ++val;
    }
    // 将整数转化为二进制字符串返回
    let binary = val.toString(2);
    // 补齐前导0
    while (binary.length < n) {
        binary = '0' + binary;
    }
    return binary;
}
```

```Rust
use std::collections::HashSet;

impl Solution {
    pub fn find_different_binary_string(nums: Vec<String>) -> String {
        let n = nums.len();
        // 预处理对应整数的哈希集合
        let mut vals: HashSet<i32> = HashSet::new();
        for num in &nums {
            let val = i32::from_str_radix(num, 2).unwrap();
            vals.insert(val);
        }
        // 寻找第一个不在哈希集合中的整数
        let mut val = 0;
        while vals.contains(&val) {
            val += 1;
        }
        // 将整数转化为二进制字符串返回
        let mut binary = format!("{:b}", val);
        // 补齐前导0
        while binary.len() < n {
            binary = format!("0{}", binary);
        }
        binary
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n^2)$，其中 $n$ 为 $nums$ 的长度。预处理哈希集合的时间复杂度为 $O(n^2)$，寻找第一个不在哈希表中的整数与生成答案字符串的时间复杂度为 $O(n)$。
- 空间复杂度：$O(n)$，即为哈希集合的空间复杂度。
