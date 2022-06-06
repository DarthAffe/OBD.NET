﻿using OBD.NET.Util;

namespace OBD.NET.Devices;

public class CommandResult
{
    #region Properties & Fields

    public object? Result { get; set; }
    public AsyncManualResetEvent WaitHandle { get; }

    #endregion

    #region Constructors

    public CommandResult()
    {
        WaitHandle = new AsyncManualResetEvent();
    }

    #endregion
}