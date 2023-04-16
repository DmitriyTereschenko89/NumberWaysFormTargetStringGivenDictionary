namespace NumberWaysFormTargetStringGivenDictionary
{
    internal class Program
    {
        public class NumberWaysFormTargetStringGivenDictionary
        {
            private int alphabet = 26;
            private int modulo = 1000000007;
            private int targetLength;
            private int wordLength;
            private long[,] dp;

            private long DFS(int i, int k, int[,] cnt, string target)
            {
                if (i == targetLength)
                {
                    return 1;
                }
                if (k == wordLength)
                {
                    return 0;
                }
                if (dp[i, k] != -1)
                {
                    return dp[i, k];
                }
                dp[i, k] = DFS(i, k + 1, cnt, target);
                dp[i, k] += cnt[target[i] - 'a', k] * DFS(i + 1, k + 1, cnt, target);
                dp[i, k] %= modulo;
                return dp[i, k];
            }

            public int NumWays(string[] words, string target)
            {
                targetLength = target.Length;
                wordLength = words[0].Length;
                int[,] cnt = new int[alphabet, wordLength];
                for (int i = 0; i < wordLength; ++i)
                {
                    foreach (string word in words)
                    {
                        ++cnt[word[i] - 'a', i];
                    }
                }
                dp = new long[targetLength + 1, wordLength + 1];
                for (int i = 0; i <= targetLength; ++i)
                {
                    for (int j = 0; j <= wordLength; ++j)
                    {
                        dp[i, j] = -1;
                    }
                }
                return (int)DFS(0, 0, cnt, target);
            }
        }

        static void Main(string[] args)
        {
            NumberWaysFormTargetStringGivenDictionary numberWaysFormTargetStringGivenDictionary = new();
            Console.WriteLine(numberWaysFormTargetStringGivenDictionary.NumWays(new string[] { "acca", "bbbb", "caca" }, "aba"));
            Console.WriteLine(numberWaysFormTargetStringGivenDictionary.NumWays(new string[] { "abba", "baab" }, "bab"));
            Console.WriteLine(numberWaysFormTargetStringGivenDictionary.NumWays(new string[] { "kidbjae", "bfchgfb", "gaaehef", "agjakgg", "abkkdjc", "bahgbig", "fedidah" }, "fd"));
        }
    }
}