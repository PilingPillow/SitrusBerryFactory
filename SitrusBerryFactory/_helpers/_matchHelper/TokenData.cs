namespace SitrusBerryFactory._helpers._matchHelper
{
    /*
        example:

        var pattern = new List<TokenData>()
        {
            TokenData.Exact(sizeof(byte), exactValues: 0xFF),
            TokenData.Pointer(),
            TokenData.Range(byte.MinValue, byte.MaxValue, sizeof(byte)),
            TokenData.Wildcard(2)
        };
    */

    public sealed class TokenData
    {
        public IToken Definition { get; }

        /// <summary>
        /// This constructor is private.
        /// Use the static factory methods instead.
        /// </summary>
        private TokenData(IToken definition)
        {
            Definition = definition;
        }

        public static TokenData Exact(
            int length,
            bool isSigned = false,
            params long[] exactValues)
        {
            var tokenDef = new ExactToken(length, isSigned, exactValues);
            return new TokenData(tokenDef);
        }

        public static TokenData Pointer()
        {
            var tokenDef = new PointerToken();
            return new TokenData(tokenDef);
        }

        public static TokenData Range(
            long min,
            long max,
            int length,
            bool isSigned = false)
        {
            var tokenDef = new RangeToken(min, max, length, isSigned);
            return new TokenData(tokenDef);
        }

        public static TokenData Wildcard(int length)
        {
            var tokenDef = new WildcardToken(length);
            return new TokenData(tokenDef);
        }

        /// <summary>
        /// Checks whether the token meets the conditions.
        /// </summary>
        public bool IsMatch(byte[] buffer, int offset)
            => Definition.IsValid(buffer, offset);

        /// <summary>
        /// Gets the byte length of the token.
        /// </summary>
        public int GetLength()
            => Definition.Length;
    }
}
