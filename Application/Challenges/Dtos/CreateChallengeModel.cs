namespace Application.Challenges.Dtos;

/// <summary>
/// Модель добавления испытания
/// </summary>
public class CreateChallengeModel
{
    /// <summary>
    /// Наименование
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Описание
    /// </summary>
    public required string Description { get; set; }

    /// <summary>
    /// Дата начала
    /// </summary>
    public required DateTimeOffset StartDate { get; set; }

    /// <summary>
    /// Дата окончания
    /// </summary>
    public required DateTimeOffset EndDate { get; set; }
}
