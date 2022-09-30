using System;
using System.Collections.Generic;

namespace MinimalSubstring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var result = solution("pwwkew");
            Console.WriteLine(result);
        }

        //public int lengthOfLongestSubstring(String s)
        //{
        //    int n = s.length(), ans = 0;
        //    Map<Character, Integer> map = new HashMap<>(); // current index of character
        //                                                   // try to extend the range [i, j]
        //    for (int j = 0, i = 0; j < n; j++)
        //    {
        //        if (map.containsKey(s.charAt(j)))
        //        {
        //            i = Math.max(map.get(s.charAt(j)), i);
        //        }
        //        ans = Math.max(ans, j - i + 1);
        //        map.put(s.charAt(j), j + 1);
        //    }
        //    return ans;
        //}

        //O(n)2 - OK
        static int solution(string str)
        {
            int n = str.Length;

            // Result
            int res = 0;

            for (int i = 0; i < n; i++)
            {

                // Note : Default values in visited are false
                bool[] visited = new bool[256];

                // visited = visited.Select(i => false).ToArray();
                for (int j = i; j < n; j++)
                {

                    // If current character is visited
                    // Break the loop
                    if (visited[str[j]] == true)
                        break;

                    // Else update the result if
                    // this window is larger, and mark
                    // current character as visited.
                    else
                    {
                        res = Math.Max(res, j - i + 1);
                        visited[str[j]] = true;
                    }
                }

                // Remove the first character of previous
                // window
                visited[str[i]] = false;
            }
            return res;
        }

        //O(n)2
        //public static int lengthOfLongestSubstring(string s)
        //{
        //    int[] chars = new int[128];
        //    int left = 0;
        //    int right = 0;

        //    int res = 0;
        //    while (right < s.Length)
        //    {
        //        char r = s[right];
        //        chars[r]++;

        //        while (chars[r] > 1)
        //        {
        //            char l = s[left];
        //            chars[l]--;
        //        }

        //        //resizing the window
        //        res = Math.Max(res, right - left + 1);

        //        right++;
        //    }

        //    return res;
        //}

        //O(n)
        //public static int lengthOfLongestSubstring(string s)
        //{
        //    int[] chars = new int[128];
        //    int left = 0;
        //    int right = 0;

        //    int res = 0;
        //    while (right < s.Length)
        //    {
        //        char r = s[right];
        //        chars[r]++;

        //        int index = chars[r];
        //        if (index >= left && index < right)
        //            left = index + 1;

        //        //resizing the window
        //        res = Math.Max(res, right - left + 1);

        //        right++;
        //    }

        //    return res;
        //}
    }
}
