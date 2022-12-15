#### [�������������������](https://leetcode.cn/problems/average-of-levels-in-binary-tree/solutions/410522/er-cha-shu-de-ceng-ping-jun-zhi-by-leetcode-soluti/)

Ҳ����ʹ�ù��������������������Ĳ�ƽ��ֵ���Ӹ��ڵ㿪ʼ������ÿһ�ֱ���ͬһ���ȫ���ڵ㣬����ò�Ľڵ����Լ��ò�Ľڵ�ֵ֮�ͣ�Ȼ�����ò��ƽ��ֵ��

���ȷ��ÿһ�ֱ�������ͬһ���ȫ���ڵ��أ����ǿ��Խ����α����������������������ʹ�ö��д洢�����ʽڵ㣬ֻҪȷ����ÿһ�ֱ���ʱ�������еĽڵ���ͬһ���ȫ���ڵ㼴�ɡ������������£�
-   ��ʼʱ�������ڵ������У�
-   ÿһ�ֱ���ʱ���������еĽڵ�ȫ��ȡ����������Щ�ڵ�������Լ����ǵĽڵ�ֵ֮�ͣ���������Щ�ڵ��ƽ��ֵ��Ȼ����Щ�ڵ��ȫ���ǿ��ӽڵ������У��ظ���������ֱ������Ϊ�գ�����������

���ڳ�ʼʱ������ֻ�и��ڵ㣬��������еĽڵ���ͬһ���ȫ���ڵ㣬ÿһ�ֱ���ʱ���Ὣ�����еĵ�ǰ��ڵ�ȫ��ȡ����������һ���ȫ���ڵ������У���˿���ȷ��ÿһ�ֱ�������ͬһ���ȫ���ڵ㡣

����ʵ�ַ��棬������ÿһ�ֱ���֮ǰ��ö����еĽڵ����� size������ʱֻ���� size ���ڵ㣬��������ÿһ�ֱ�������ͬһ���ȫ���ڵ㡣

![](./assets/img/Solution0637_3_01.png)
![](./assets/img/Solution0637_3_02.png)
![](./assets/img/Solution0637_3_03.png)
![](./assets/img/Solution0637_3_04.png)
![](./assets/img/Solution0637_3_05.png)
![](./assets/img/Solution0637_3_06.png)
![](./assets/img/Solution0637_3_07.png)
![](./assets/img/Solution0637_3_08.png)
![](./assets/img/Solution0637_3_09.png)
![](./assets/img/Solution0637_3_10.png)
![](./assets/img/Solution0637_3_11.png)
![](./assets/img/Solution0637_3_12.png)
![](./assets/img/Solution0637_3_13.png)
![](./assets/img/Solution0637_3_14.png)

```java
class Solution {
    public List<Double> averageOfLevels(TreeNode root) {
        List<Double> averages = new ArrayList<Double>();
        Queue<TreeNode> queue = new LinkedList<TreeNode>();
        queue.offer(root);
        while (!queue.isEmpty()) {
            double sum = 0;
            int size = queue.size();
            for (int i = 0; i < size; i++) {
                TreeNode node = queue.poll();
                sum += node.val;
                TreeNode left = node.left, right = node.right;
                if (left != null) {
                    queue.offer(left);
                }
                if (right != null) {
                    queue.offer(right);
                }
            }
            averages.add(sum / size);
        }
        return averages;
    }
}
```

```go
func averageOfLevels(root *TreeNode) (averages []float64) {
    nextLevel := []*TreeNode{root}
    for len(nextLevel) > 0 {
        sum := 0
        curLevel := nextLevel
        nextLevel = nil
        for _, node := range curLevel {
            sum += node.Val
            if node.Left != nil {
                nextLevel = append(nextLevel, node.Left)
            }
            if node.Right != nil {
                nextLevel = append(nextLevel, node.Right)
            }
        }
        averages = append(averages, float64(sum)/float64(len(curLevel)))
    }
    return
}
```

```cpp
class Solution {
public:
    vector<double> averageOfLevels(TreeNode* root) {
        auto averages = vector<double>();
        auto q = queue<TreeNode*>();
        q.push(root);
        while (!q.empty()) {
            double sum = 0;
            int size = q.size();
            for (int i = 0; i < size; i++) {
                auto node = q.front();
                q.pop();
                sum += node->val;
                auto left = node->left, right = node->right;
                if (left != nullptr) {
                    q.push(left);
                }
                if (right != nullptr) {
                    q.push(right);
                }
            }
            averages.push_back(sum / size);
        }
        return averages;
    }
};
```

```python
class Solution:
    def averageOfLevels(self, root: TreeNode) -> List[float]:
        averages = list()
        queue = collections.deque([root])
        while queue:
            total = 0
            size = len(queue)
            for _ in range(size):
                node = queue.popleft()
                total += node.val
                left, right = node.left, node.right
                if left:
                    queue.append(left)
                if right:
                    queue.append(right)
            averages.append(total / size)
        return averages
```

```c
double* averageOfLevels(struct TreeNode* root, int* returnSize) {
    double* averages = malloc(sizeof(double) * 1001);
    struct TreeNode** q = malloc(sizeof(struct TreeNode*) * 10001);
    *returnSize = 0;

    int qleft = 0, qright = 0;
    q[qright++] = root;
    while (qleft < qright) {
        double sum = 0;
        int size = qright - qleft;
        for (int i = 0; i < size; i++) {
            struct TreeNode* node = q[qleft++];
            sum += node->val;
            struct TreeNode *left = node->left, *right = node->right;
            if (left != NULL) {
                q[qright++] = left;
            }
            if (right != NULL) {
                q[qright++] = right;
            }
        }
        averages[(*returnSize)++] = sum / size;
    }
    return averages;
}
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(n)$������ $n$ �Ƕ������еĽڵ������ �������������Ҫ��ÿ���ڵ����һ�Σ�ʱ�临�Ӷ��� $O(n)$�� ��Ҫ�Զ�������ÿһ�����ƽ��ֵ��ʱ�临�Ӷ��� $O(h)$������ $h$ �Ƕ������ĸ߶ȣ��κ�����¶����� $h \le n$�� �����ʱ�临�Ӷ��� $O(n)$��
-   �ռ临�Ӷȣ�$O(n)$������ $n$ �Ƕ������еĽڵ�������ռ临�Ӷ�ȡ���ڶ��п����������еĽڵ�������ᳬ�� $n$��
