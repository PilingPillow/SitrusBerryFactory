using System.Collections.Generic;
using SitrusBerryFactory._utilities;

namespace SitrusBerryFactory._helpers._matchHelper
{
    public interface IToken
    {
        int Length { get; } // The token length in bytes
        bool IsValid(byte[] buffer, int offset);
    }

    /// <summary>
    /// Needs to Match specified values.
    /// </summary>
    public sealed class ExactToken : IToken
    {
        public int Length { get; }
        public bool IsSigned { get; }

        // Values used for matching
        private HashSet<long> _exactValues;

        public ExactToken(
            int length,
            bool isSigned,
            params long[] exactValues)
        {
            Length = length;
            IsSigned = isSigned;
            _exactValues = new HashSet<long>(exactValues);
        }

        public bool IsValid(byte[] buffer, int offset)
        {
            long value = IoHelper.ReadBytesAsLong(
                buffer,
                offset,
                Length,
                isLittleEndian: true, // Always little endian
                isSigned: IsSigned);

            // Check whether the value is included
            return _exactValues.Contains(value);
        }
    }

    /// <summary>
    /// Checks whether a value can be read as a pointer.
    /// </summary>
    public sealed class PointerToken : IToken
    {
        public int Offset { get; private set; } // you can get the pointer offset
        public int Length { get; }

        public PointerToken()
        {
            Length = sizeof(uint); // 4 bytes
        }

        public bool IsValid(byte[] buffer, int offset)
        {
            // Read as a pointer
            var result = IoHelper.TryReadPointer(
                buffer,
                offset,
                out int value);

            // Store the result
            Offset = value;
            return result;
        }

        /// <summary>
        /// Checks whether the pointer is null.
        /// </summary>
        public bool IsNullPointer
            => Offset == InvalidConstants.InvalidValue;
    }

    /// <summary>
    /// Checks whether a value falls within a specified range.
    /// </summary>
    public sealed class RangeToken : IToken
    {
        public long Min { get; }
        public long Max { get; }
        public int Length { get; }
        public bool IsSigned { get; }

        public RangeToken(
            long min,
            long max,
            int length,
            bool isSigned = false)
        {
            Min = min;
            Max = max;
            Length = length;
            IsSigned = isSigned;
        }

        public bool IsValid(byte[] buffer, int offset)
        {
            long value = IoHelper.ReadBytesAsLong(
                buffer,
                offset,
                Length,
                isLittleEndian: true, // Always little endian
                isSigned: IsSigned);

            // Check the range
            return Min <= value && value <= Max;
        }
    }

    /// <summary>
    /// Always returns true. Any length can be specified.
    /// </summary>
    public sealed class WildcardToken : IToken
    {
        public int Length { get; }

        public WildcardToken(int length)
        {
            Length = length;
        }

        // Always returns true
        public bool IsValid(byte[] buffer, int offset) 
            => true;
    }
}
