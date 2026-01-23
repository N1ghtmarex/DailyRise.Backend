using Application.Users.Dtos;

namespace Application.Challenges.Dtos;

/// <summary>
/// Модель испытания
/// </summary>
public class ChallengeViewModel
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public required Ulid Id { get; set; }

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

    /// <summary>
    /// Модель создателя
    /// </summary>
    public UserViewModel? Author { get; set; }

    /// <summary>
    /// Статус архивности
    /// </summary>
    public required bool IsArchive { get; set; }

    /// <summary>
    /// Дата создания
    /// </summary>
    public required DateTimeOffset CreatedAt { get; set; }

    /// <summary>
    /// Дата обновления
    /// </summary>
    public required DateTimeOffset? UpdatedAt { get; set; }
}
