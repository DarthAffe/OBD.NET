using System;
using System.IO;

namespace OBD.NET.OBDData
{
    public abstract class AbstractOBDData : IOBDData
    {
        #region Properties & Fields

        public int PID { get; }
        private int _length;

        private byte[] _rawData;
        public byte[] RawData
        {
            get { return _rawData; }
            set
            {
                if (value.Length != _length)
                    throw new ArgumentException("The provided raw-data is not valid", nameof(value));
                _rawData = value;
            }
        }

        public bool IsValid => RawData.Length == _length;

        protected byte A => RawData.Length > 0 ? RawData[0] : default(byte);
        protected byte B => RawData.Length > 1 ? RawData[1] : default(byte);
        protected byte C => RawData.Length > 2 ? RawData[2] : default(byte);
        protected byte D => RawData.Length > 3 ? RawData[3] : default(byte);
        protected byte E => RawData.Length > 4 ? RawData[4] : default(byte);

        #endregion

        #region Constructors

        public AbstractOBDData(int pid, int length)
        {
            this.PID = pid;
            this._length = length;
        }

        public AbstractOBDData(int pid, int length, byte[] rawData)
            : this(pid, length)
        {
            this.RawData = rawData;

            if (rawData.Length != _length)
                throw new ArgumentException("The provided raw-data is not valid", nameof(rawData));
        }

        #endregion

        #region Methods

        public void Read(Stream stream)
        {
            try
            {
                _rawData = new byte[_length];
                if (stream.Read(_rawData, 0, _length) != _length)
                    throw new InvalidDataException("Couldn't read enough bytes from the stream");
            }
            catch
            {
                _rawData = new byte[0];
                throw;
            }
        }

        #endregion
    }
}
