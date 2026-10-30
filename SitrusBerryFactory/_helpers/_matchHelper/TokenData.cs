namespace SitrusBerryFactory._helpers._matchHelper
{
    public sealed class TokenData
    {
        public TokenType Type { get; }
        public IToken Def { get; }

        private TokenData(TokenType type, IToken def)
        {
            Type = type;
            Def = def;
        }

        public static TokenData Exact(
            int length,
            bool isSigned = false,
            params long[] exactValues)
        {
            var tokenDef = new ExactToken(length, isSigned, exactValues);
            return new TokenData(TokenType.Exact, tokenDef);
        }

        public static TokenData Pointer()
        {
            var tokenDef = new PointerToken();
            return new TokenData(TokenType.Pointer, tokenDef);
        }

        public static TokenData Range(
            long min,
            long max,
            int length,
            bool isSigned = false)
        {
            var tokenDef = new RangeToken(min, max, length, isSigned);
            return new TokenData(TokenType.Range, tokenDef);
        }

        public static TokenData Wildcard(int length)
        {
            var tokenDef = new WildcardToken(length);
            return new TokenData(TokenType.Wildcard, tokenDef);
        }

        /// <summary>
        /// Checks whether the token matches its configured values.
        /// </summary>
        public bool IsMatch(byte[] buffer, int offset)
            => Def.IsValid(buffer, offset);

        /// <summary>
        /// Gets the token length.
        /// </summary>
        public int GetLength()
            => Def.Length;
    }
}
