#### [�������ұ���ÿ������](https://leetcode.cn/problems/find-resultant-array-after-removing-anagrams/solutions/1496068/cong-zuo-wang-you-bian-li-by-endlesschen-pct5/)

���ڸ�������Ԫ�ص�������ɾ��Ԫ�ص���Ŀ����ջ��˼������򵥵ġ�

��ջ��ģ����Ŀ�Ĳ�����������ʱ��ÿ�κ�ջ���Ƚϣ����������ĸ��λ�ʾ���ջ��

����������ջ����������Ԫ�ؾ���Ϊ��ĸ��λ�ʣ�ջ��Ϊ�𰸡�

������Ŀ��

-   [1047\. ɾ���ַ����е����������ظ���](https://leetcode.cn/problems/remove-all-adjacent-duplicates-in-string/)
-   [2216\. �������������ɾ����](https://leetcode.cn/problems/minimum-deletions-to-make-array-beautiful/)
-   [2197\. �滻�����еķǻ�����](https://leetcode.cn/problems/replace-non-coprime-numbers-in-array/)

```go
func removeAnagrams(words []string) []string {
	ans := []string{words[0]}
	for _, word := range words[1:] {
		cnt := [26]int{}
		for _, b := range word {
			cnt[b-'a']++
		}
		for _, b := range ans[len(ans)-1] {
			cnt[b-'a']--
		}
		if cnt != [26]int{} {  // ������ĸ��λ��
			ans = append(ans, word)
		}
	}
	return ans
}
```
