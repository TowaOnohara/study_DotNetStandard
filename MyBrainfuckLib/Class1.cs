using System;
using System.Collections.Generic;
using System.Linq;

namespace MyBrainfuckLib
{
    public static class MyBrainfuck
    {
        private static IEnumerable<(int k, int v)> GetBracketPair(string i_buf)
        {
            int i_ptr = 0;
            int loopcount = 0;
            var bracketpair = new List<(int k, int v)>();

            while (i_ptr < i_buf.Length)
            {
                switch (i_buf[i_ptr])
                {
                    case '[':
                        loopcount = 1;
                        int tmpidx = i_ptr;
                        while (loopcount != 0)
                        {
                            tmpidx++;
                            if (i_buf[tmpidx] == '[') loopcount++;
                            if (i_buf[tmpidx] == ']') loopcount--;
                        }
                        bracketpair.Add((i_ptr, tmpidx));
                        break;
                    default:
                        break;
                }
                i_ptr++;
            }
            return bracketpair;
        }

        public static string ExecuteBrainfuckCode(string i_buf)
        {
            const int MAX_BUFFER_LENGTH = 30000;
            byte[] d_buf = new byte[MAX_BUFFER_LENGTH];
            int d_ptr = 0;
            int i_ptr = 0;
            var result = new List<char>();

            var bracketpair = GetBracketPair(i_buf);

            while (i_ptr < i_buf.Length)
            {
                switch (i_buf[i_ptr])
                {
                    case '>':
                        if (d_ptr < d_buf.Length - 1)
                            d_ptr++;
                        else
                            throw new IndexOutOfRangeException("Buffer Overflow");
                        break;
                    case '<':
                        if (d_ptr > 0)
                            d_ptr--;
                        else
                            throw new IndexOutOfRangeException("Buffer Underflow");
                        break;
                    case '+':
                        d_buf[d_ptr]++;
                        break;
                    case '-':
                        d_buf[d_ptr]--;
                        break;
                    case '.':
                        result.Add(Convert.ToChar(d_buf[d_ptr]));
                        break;
                    case '[':
                        if (d_buf[d_ptr] == 0)
                            i_ptr = bracketpair.First(item => item.k == i_ptr).v;
                        break;
                    case ']':
                        if (d_buf[d_ptr] != 0)
                            i_ptr = bracketpair.First(item => item.v == i_ptr).k;
                        break;
                    default:
                        break;
                }
                i_ptr++;
            }
            return new string(result.ToArray());
        }
    }
}
