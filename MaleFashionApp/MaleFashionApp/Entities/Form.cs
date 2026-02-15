using System.ComponentModel.DataAnnotations;

namespace MaleFashionApp.Entities;

public enum ClientMessageStatuses
{
    /// <summary>
    /// The message has been created but not yet read.
    /// </summary>
    New = 0,

    /// <summary>
    /// The message has been read.
    /// </summary>
    Read = 1,

    /// <summary>
    /// A response has been sent to the client.
    /// </summary>
    Answered = 2,

    /// <summary>
    /// The message has been archived.
    /// </summary>
    Archived = 3
}

/// <summary>
/// Represents a contact form submitted by a client.
/// </summary>
public class Form
{
    /// <summary>
    /// Gets or sets the unique identifier of the form.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the title of the message.
    /// </summary>
    [Required(ErrorMessage = "Title is required.")]
    [StringLength(128, MinimumLength = 3,
        ErrorMessage = "Title must be between 3 and 128 characters.")]
    [RegularExpression(@"^[a-zA-Zа-яА-ЯіІїЇєЄ0-9\s\-]+$",
        ErrorMessage = "Title contains invalid characters.")]
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the email address of the sender.
    /// </summary>
    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email format.")]
    [StringLength(256)]
    [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$",
        ErrorMessage = "Email format is invalid.")]
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the message content.
    /// </summary>
    [Required(ErrorMessage = "Message is required.")]
    [StringLength(4096, MinimumLength = 8,
        ErrorMessage = "Message must be between 10 and 4096 characters.")]
    [RegularExpression(@"^[a-zA-Z0-9\s\.\,\!\?\-\@\#\(\)]+$",
        ErrorMessage = "Message contains invalid special characters.")]
    public string Message { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the creation date of the form.
    /// Defaults to current UTC time.
    /// </summary>
    [DataType(DataType.DateTime)]
    public DateTime DateOfCreation { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Gets or sets the current status of the message.
    /// Default value is New.
    /// </summary>
    [EnumDataType(typeof(ClientMessageStatuses))]
    public ClientMessageStatuses Status { get; set; } = ClientMessageStatuses.New;
}