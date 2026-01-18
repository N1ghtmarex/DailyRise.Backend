using System.ComponentModel;

namespace Domain.Enums;

/// <summary>
/// Перечисление статусов задания пользователя
/// </summary>
public enum UserChallengeStatus
{
    /// <summary>
    /// Приглашен
    /// </summary>
    [Description("Приглашен")]
    Invited = 0,

    /// <summary>
    /// В процессе
    /// </summary>
    [Description("В процессе")]
    InProgress = 1,

    /// <summary>
    /// Отменено
    /// </summary>
    [Description("Отменено")]
    Cancelled = 2,

    /// <summary>
    /// Провалено
    /// </summary>
    [Description("Провалено")]
    Failed = 3,

    /// <summary>
    /// Выполнено
    /// </summary>
    [Description("Выполнено")]
    Completed = 4,
}
