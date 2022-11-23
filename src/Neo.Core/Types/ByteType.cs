using Neo.Core.Interfaces;

namespace Neo.Core.Types
{
    public class ByteType : IType<byte>
    {
        public static readonly ByteType Instance = new();

        #region Constructors

        private ByteType()
        {
        }

        #endregion

        #region Implementation of IType<byte>

        public byte Get(byte[] buffer)
        {
            return buffer[0];
        }

        public void Set(byte[] buffer, byte value)
        {
            buffer[0] = value;
        }

        public int Size()
        {
            return sizeof(byte);
        }

        #endregion
    }
}