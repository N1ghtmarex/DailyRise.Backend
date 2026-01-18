using System.ComponentModel;

namespace Domain.Enums;

/// <summary>
/// Перечисление категорий заданий
/// </summary>
public enum ChallengeCategory
{
    /// <summary>
    /// Не указано
    /// </summary>
    [Description("Не указано")]
    None = 0,

    /// <summary>
    /// Спорт
    /// </summary>
    [Description("Спорт")]
    Sport = 1,

    /// <summary>
    /// Изучение
    /// </summary>
    [Description("Изучение")]
    Learning = 2,

    /// <summary>
    /// Творчество
    /// </summary>
    [Description("Творчество")]
    Creative = 3,
}
