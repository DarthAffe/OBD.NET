using System;
using OBD.NET.Common.Extensions;

namespace OBD.NET.Common.OBDData
{
    public abstract class AbstractOBDData : IOBDData
    {
        #region Properties & Fields

        public byte PID { get; }
        private readonly int _length;

        private byte[] _rawData;
        public byte[] RawData
        {
            get => _rawData;
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

        protected AbstractOBDData(byte pid, int length)
        {
            this.PID = pid;
            this._length = length;
        }

        protected AbstractOBDData(byte pid, int length, byte[] rawData)
            : this(pid, length)
        {
            this.RawData = rawData;
        }

        #endregion

        #region Methods

        public void Load(string data)
        {
            try
            {
                if (((data.Length % 2) == 1) || ((data.Length / 2) != _length))
                    throw new ArgumentException("The provided data is not valid", nameof(data));

                _rawData = new byte[_length];
                for (int i = 0; i < _length; ++i)
                    _rawData[i] = (byte)((data[i << 1].GetHexVal() << 4) + (data[(i << 1) + 1].GetHexVal()));
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
