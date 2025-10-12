using System;
using Microsoft.SemanticKernel;

namespace SK.Basic.Front.Plugins;

/// <summary>
/// Date plugin.
/// </summary>
/// <remarks>
/// A SK plugin contains functions.
/// </remarks>
internal class DatePlugin
{
    public static readonly string Key = "DateTools";

    [KernelFunction("get_utc_now_date")]
    public static string GetUtcNow()
    {
        return DateTime.UtcNow.ToString("F");
    }
}
