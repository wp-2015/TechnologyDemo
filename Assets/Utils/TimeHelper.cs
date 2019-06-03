using System;

public class TimeHelper
{
    public static int GetCurrentMillisecond()
    {
        return DateTime.UtcNow.Millisecond;
    }
}
