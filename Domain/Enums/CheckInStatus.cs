using System.ComponentModel;

namespace Domain.Enums;

/// <summary>
/// Перечисление статусов отметок
/// </summary>
public enum CheckInStatus
{
    /// <summary>
    /// Пропущено
    /// </summary>
    [Description("Пропущено")]
    Missed = 0,

    /// <summary>
    /// Выполнено
    /// </summary>
    [Description("Выполнено")]
    Completed = 1,
}
