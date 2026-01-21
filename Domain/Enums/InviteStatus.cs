using System.ComponentModel;

namespace Domain.Enums;

/// <summary>
/// Перечисление статусов приглашений
/// </summary>
public enum InviteStatus
{
    /// <summary>
    /// Отправлено
    /// </summary>
    [Description("Отправлено")]
    Pending = 0,

    /// <summary>
    /// Принято
    /// </summary>
    [Description("Принято")]
    Accepted = 1,

    /// <summary>
    /// Отклонено
    /// </summary>
    [Description("Отклонено")]
    Rejected = 2,
}
