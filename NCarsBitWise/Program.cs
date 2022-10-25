using System;
using System.Collections;

namespace NCarsBitWise
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }


        public int[] solution(string[] cars)
        {
            BitArray[] features = new BitArray[cars.Length];
            for (int i = 0; i < features.Length; i++)
            {
                features[i] = stringToBitSet(cars[i]);
            }

            int[] similarCars = new int[features.Length];
            for (int i = 0; i < similarCars.Length - 1; i++)
            {
                for (int j = i + 1; j < similarCars.Length; j++)
                {
                    BitArray aux = (BitArray)features[i].Clone();
                    aux.Xor(features[j]);
                    if (GetCardinality(aux) <= 1)
                    {
                        similarCars[i]++;
                        similarCars[j]++;
                    }
                }
            }
            return similarCars;
        }

        public static Int32 GetCardinality(BitArray bitArray)
        {

            Int32[] ints = new Int32[(bitArray.Count >> 5) + 1];

            bitArray.CopyTo(ints, 0);

            Int32 count = 0;

            // fix for not truncated bits in last integer that may have been set to true with SetAll()
            ints[ints.Length - 1] &= ~(-1 << (bitArray.Count % 32));

            for (Int32 i = 0; i < ints.Length; i++)
            {

                Int32 c = ints[i];

                // magic (http://graphics.stanford.edu/~seander/bithacks.html#CountBitsSetParallel)
                unchecked
                {
                    c = c - ((c >> 1) & 0x55555555);
                    c = (c & 0x33333333) + ((c >> 2) & 0x33333333);
                    c = ((c + (c >> 4) & 0xF0F0F0F) * 0x1010101) >> 24;
                }

                count += c;

            }

            return count;

        }

        public BitArray stringToBitSet(string s)
        {
            BitArray bitArray = new BitArray(s.Length);
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '1')
                {
                    bitArray.Set(i, true);
                }
            }

            return bitArray;
        }

    }
}
