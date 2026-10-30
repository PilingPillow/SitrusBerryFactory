using System.Collections.Generic;
using SitrusBerryFactory._utilities;

namespace SitrusBerryFactory._helpers._matchHelper
{
    public static class PatternMatcher
    {
        /// <summary>
        /// Attempts a single pattern match.
        /// </summary>
        public static bool TryMatch(
            List<TokenData> tokens,
            byte[] buffer,
            int offset = 0,
            bool allowNullPointer = false)
        {
            int currentPos = offset;

            for (int i = 0; i < tokens.Count; i++)
            {
                var token = tokens[i];

                // Number of bytes occupied
                int length = token.GetLength();

                // Check buffer bounds
                if (currentPos + length > buffer.Length)
                {
                    return false;
                }

                // Validate the token
                if (!token.IsMatch(buffer, currentPos))
                {
                    return false;
                }

                // Reject null pointers if not allowed
                if (!allowNullPointer &&
                    token.Def is PointerToken pToken &&
                    pToken.IsNullPointer)
                {
                    return false;
                }

                // Move to the next token
                currentPos += length;
            }

            return true;
        }

        /// <summary>
        /// Counts consecutive pattern matches.
        /// </summary>
        public static int TryCountByPattern(
            List<TokenData> tokens,
            byte[] buffer,
            int baseOffset = 0,
            bool allowNullPointer = false)
        {
            int patternLength = GetPatternLength(tokens);

            int count = 0;
            int currentPos = baseOffset;

            while (currentPos + patternLength <= buffer.Length)
            {
                // Stop when a match fails
                if (!TryMatch(tokens, buffer, currentPos, allowNullPointer))
                {
                    break;
                }

                count++;
                currentPos += patternLength;
            }

            return count;
        }

        /// <summary>
        /// Calculates the total length of the tokens.
        /// </summary>
        public static int GetPatternLength(List<TokenData> tokens)
        {
            int length = 0;
            for (int i = 0; i < tokens.Count; i++)
            {
                length += tokens[i].GetLength();
            }

            return length;
        }

        /// <summary>
        /// Checks whether an entry contains at least one terminator byte
        /// followed by zero or more padding bytes.
        /// In other words, checks whether the entry is a text string.
        /// </summary>
        public static bool TryCheck(
            byte[] buffer,
            int entryLength,
            byte terminatorByte = BinaryConstants.StrTerminatorByte,
            byte paddingByte = BinaryConstants.PaddingByte,
            int offset = 0)
        {
            // Calculate the starting position for backward scanning
            int endPos = offset + entryLength - 1;
            int currentPos = endPos;

            while (offset <= currentPos && buffer[currentPos] == paddingByte)
            {
                currentPos--;
            }

            // Check whether the current position is valid and contains the terminator
            if (currentPos < offset || buffer[currentPos] != terminatorByte)
            {
                return false;
            }

            // Succeed if the terminator is at the start of the search range
            if (currentPos == offset)
            {
                return true;
            }

            // Reject if the preceding byte is invalid
            if (InvalidBytes.Contains(buffer[currentPos - 1]))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Defines invalid preceding bytes.
        /// </summary>
        private static HashSet<byte> InvalidBytes = new HashSet<byte>()
        {
            BinaryConstants.StrTerminatorByte,
            BinaryConstants.PaddingByte,
            BinaryConstants.StrNewlineByte
        };

        /// <summary>
        /// Counts consecutive entries ending with a terminator
        /// followed by padding bytes.
        /// </summary>
        public static int TryCountByTerminator(
            byte[] buffer,
            int entryLength,
            int baseOffset = 0,
            byte terminatorByte = BinaryConstants.StrTerminatorByte,
            byte paddingByte = BinaryConstants.PaddingByte)
        {
            int count = 0;
            int currentPos = baseOffset;

            while (currentPos + entryLength <= buffer.Length)
            {
                // Stop when a check fails
                if (!TryCheck(buffer, entryLength, terminatorByte, paddingByte, currentPos))
                {
                    break;
                }

                count++;
                currentPos += entryLength;
            }

            return count;
        }

        /// <summary>
        /// Checks whether a byte pattern occurs at least the specified number of times.
        /// </summary>
        public static bool TrySearch(
            byte[] buffer,
            byte[] pattern,
            int offset,
            int length,
            int expectedCount = 1)
        {
            // Calculate the end position of the search range
            int endPos = offset + length;

            int count = 0;
            int currentPos = offset;

            // Start searching
            while (currentPos + pattern.Length <= endPos)
            {
                bool isMatch = true;

                // Check for a byte-by-byte match
                for (int i = 0; i < pattern.Length; i++)
                {
                    if (buffer[currentPos + i] != pattern[i])
                    {
                        isMatch = false;
                        break;
                    }
                }

                if (isMatch)
                {
                    // Increment the match count
                    count++;
                    // Advance past the matched pattern to avoid overlapping matches
                    currentPos += pattern.Length;
                }
                else
                {
                    currentPos++;
                }
            }

            // Check whether the match count meets the expected count
            return count >= expectedCount;
        }
    }
}
