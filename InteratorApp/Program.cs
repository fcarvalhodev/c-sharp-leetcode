using System;

namespace InteratorApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int[][] numbers = new int[3][];

            numbers[0] = new int[] { 1, 2, 3 };
            numbers[1] = new int[] { 4, 5 };
            numbers[2] = new int[] { 6, 7, 8, 9 };
            Iterator<int> arrayIterator = new Iterator<int>(numbers);
            var HasNext = arrayIterator.HasNext();
            Console.WriteLine(HasNext);
            var Next = arrayIterator.Next();
            Console.WriteLine(Next);
        }
    }

    //EREN YEAGGAR ARRAY
    public class Iterator<T>
    {
        private T[][] _IteratorList;

        public Iterator(T[][] list)
        {
            this._IteratorList = list;
        }

        public bool HasNext()
        {
            return _IteratorList.Length != 0;
        }

        public T Next()
        {
            T Next = default;

            if (!HasNext())
                throw new EntryPointNotFoundException();

            for (var i = 0; i < _IteratorList.Length; i++)
            {
                for (var j = 0; j < _IteratorList[i].Length-1; j++)
                {
                    T SelectedItem = _IteratorList[i][j + 1] != null ? _IteratorList[i][j + 1] : default;
                    if (SelectedItem.Equals(Next))
                        throw new EntryPointNotFoundException();
                    else
                        Next = SelectedItem;
                }
            }

            return Next;
        }
    }
}
