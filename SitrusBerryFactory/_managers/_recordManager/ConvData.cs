using SitrusBerryFactory._utilities;

namespace SitrusBerryFactory._managers._recordManager
{
    /// <summary>
    /// Includes bit values.
    /// </summary>
    public sealed class ConvData<T> : DynamicAccessor<long>
    {
        public T PrimaryData { get; }

        public ConvData(T primaryData)
        {
            PrimaryData = primaryData;
        }

        public static explicit operator T(ConvData<T> convData)
            => convData.PrimaryData;
    }
}
