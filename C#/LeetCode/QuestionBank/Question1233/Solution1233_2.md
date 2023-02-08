#### [方法一：排序](https://leetcode.cn/problems/remove-sub-folders-from-the-filesystem/solutions/2097563/shan-chu-zi-wen-jian-jia-by-leetcode-sol-0x8d/)

**思路与算法**

我们可以将字符串数组 $folder$ 按照字典序进行排序。在排序完成后，对于每一个 $folder[i]$，如果 $folder[i-1]$ 恰好是它的前缀，并且 $folder[i]$ 第一个多出的字符是 $/$，那么我们就可以把 $folder[i]$ 删除。

> 注意当 $folder[i]$ 被删除后，后续的所有字符串都需要向前移动一个位置。例如 $[“/a”,“/a/b”,“/a/c”]$ 中，$“/a/b”$ 被删除后，数组会变为 $[“/a”,“/a/c”]$，$“/a/c”$ 也会被删除。

这样做的必要性是显然的，因为如果上述条件满足，就说明 $folder[i]$ 是 $folder[i-1]$ 的子文件夹。对于充分性，我们可以使用反证法：

> 假设 $folder[i]$ 是某个 $folder[j]~(j \neq i-1)$ 的子文件夹但不是 $folder[i-1]$ 的子文件夹，那么在排序后，$folder[j]$ 一定出现在 $folder[i]$ 的前面，也就是有 $j < i$。如果有多个满足要求的 $j$，我们选择最早出现的那个。这样就保证了 $folder[j]$ 本身不会是其它文件夹的子文件夹。
> 
> 由于 $“/”$ 的字典序小于所有的小写字母，并且 $folder[i]$ 是由 $folder[j]$ 加上 $“/”$ 再加上后续字符组成，因此在 $folder[i]$ 和 $folder[j]$ 之间的所有字符串也都一定是由 $folder[j]$ 加上 $“/”$ 再加上后续字符组成。这些字符串都是 $folder[i]$ 的子文件夹，它们会依次被删除。当遍历到 $folder[i]$ 时，它的上一个元素恰好是 $folder[j]$，因此它一定会被删除。

**代码**

```cpp
class Solution {
public:
    vector<string> removeSubfolders(vector<string>& folder) {
        sort(folder.begin(), folder.end());
        vector<string> ans = {folder[0]};
        for (int i = 1; i < folder.size(); ++i) {
            if (int pre = ans.end()[-1].size(); !(pre < folder[i].size() && ans.end()[-1] == folder[i].substr(0, pre) && folder[i][pre] == '/')) {
                ans.push_back(folder[i]);
            }
        }
        return ans;
    }
};
```

```java
class Solution {
    public List<String> removeSubfolders(String[] folder) {
        Arrays.sort(folder);
        List<String> ans = new ArrayList<String>();
        ans.add(folder[0]);
        for (int i = 1; i < folder.length; ++i) {
            int pre = ans.get(ans.size() - 1).length();
            if (!(pre < folder[i].length() && ans.get(ans.size() - 1).equals(folder[i].substring(0, pre)) && folder[i].charAt(pre) == '/')) {
                ans.add(folder[i]);
            }
        }
        return ans;
    }
}
```

```csharp
public class Solution {
    public IList<string> RemoveSubfolders(string[] folder) {
        Array.Sort(folder);
        IList<string> ans = new List<string>();
        ans.Add(folder[0]);
        for (int i = 1; i < folder.Length; ++i) {
            int pre = ans[ans.Count - 1].Length;
            if (!(pre < folder[i].Length && ans[ans.Count - 1].Equals(folder[i].Substring(0, pre)) && folder[i][pre] == '/')) {
                ans.Add(folder[i]);
            }
        }
        return ans;
    }
}
```

```python
class Solution:
    def removeSubfolders(self, folder: List[str]) -> List[str]:
        folder.sort()
        ans = [folder[0]]
        for i in range(1, len(folder)):
            if not ((pre := len(ans[-1])) < len(folder[i]) and ans[-1] == folder[i][:pre] and folder[i][pre] == "/"):
                ans.append(folder[i])
        return ans
```

```c
static int cmp(const int *pa, const int *pb) {
    return strcmp(*(char **)pa, *(char **)pb);
}

char ** removeSubfolders(char ** folder, int folderSize, int* returnSize) {
    qsort(folder, folderSize, sizeof(char *), cmp);
    char **ans = (char **)malloc(sizeof(char *) * folderSize);
    int pos = 0;
    ans[pos++] = folder[0];
    for (int i = 1; i < folderSize; ++i) {
        int pre = strlen(ans[pos - 1]);
        if (!(pre < strlen(folder[i]) && !strncmp(ans[pos - 1], folder[i], pre) && folder[i][pre] == '/')) {
            ans[pos++] = folder[i];
        }
    }
    *returnSize = pos;
    return ans;
}
```

```go
func removeSubfolders(folder []string) (ans []string) {
    sort.Strings(folder)
    ans = append(ans, folder[0])
    for _, f := range folder[1:] {
        last := ans[len(ans)-1]
        if !strings.HasPrefix(f, last) || f[len(last)] != '/' {
            ans = append(ans, f)
        }
    }
    return
}
```

```javascript
var removeSubfolders = function(folder) {
    folder.sort();
    const ans = [folder[0]];
    for (let i = 1; i < folder.length; ++i) {
        const pre = ans[ans.length - 1].length;
        if (!(pre < folder[i].length && ans[ans.length - 1] === (folder[i].substring(0, pre)) && folder[i].charAt(pre) === '/')) {
            ans.push(folder[i]);
        }
    }
    return ans;
};
```

**复杂度分析**

-   时间复杂度：$O(nl \cdot \log n)$，其中 $n$ 和 $l$ 分别是数组 $folder$ 的长度和文件夹的平均长度。$O(nl \cdot \log n)$ 为排序需要的时间，后续构造答案需要的时间为 $O(nl)$，在渐进意义下小于前者。
-   空间复杂度：$O(l)$。在构造答案比较前缀时，我们使用了字符串的截取子串操作，因此需要 $O(l)$ 的临时空间。我们也可以使用一个递增的指针依次对两个字符串的每个相同位置进行比较，省去这一部分的空间，使得空间复杂度降低至排序需要的栈空间 $O(\log n)$。但空间优化并不是本题的重点，因此上述的代码中仍然采用空间复杂度为 $O(l)$ 的写法。注意这里不计入返回值占用的空间。
