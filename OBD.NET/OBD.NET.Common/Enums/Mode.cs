namespace OBD.NET.Common.Enums
{
    /// <summary>
    /// https://en.wikipedia.org/wiki/OBD-II_PIDs#Modes
    /// </summary>
    public enum Mode
    {
        ShowCurrentData = 0x01,
        ShowFreezeFrameData = 0x02,
        ShowStoredDiagnosticTroubleCodes = 0x03,
        ClearDiagnosticTroubleCodesAndStoredValues = 0x04,
        TestResults_OxygenSensorMonitoring = 0x05,
        TestResults_OtherComponentMonitoring = 0x06,
        ShowPendingDiagnosticTroubleCodes = 0x07,
        ControlOperationOfOnboardComponent = 0x08,
        RequestVehicleInformation = 0x09,
        PermanentDiagnosticTroubleCodes = 0x0A
    }
}
