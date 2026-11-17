namespace SitrusBerryFactory._utilities
{
    public ref struct ArraySlicer<T>
    {
        private readonly T[] _array;
        private readonly int _start;
        private readonly int _length;

        public ArraySlicer(T[] array, int start, int length)
        {
            _array = array;
            _start = start;
            _length = length;
        }

        public ref T this[int index]
        {
            get => ref _array[_start + index];
        }

        public int Length => _length;

        /// <summary>
        /// Can call this recursively.
        /// </summary>
        public ArraySlicer<T> Slice(int relStart, int relLength) =>
            new ArraySlicer<T>(_array, _start + relStart, relLength);
    }
}
