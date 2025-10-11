using System.ComponentModel.DataAnnotations;

namespace SK.Basic.Front.Configurations;

public sealed class SemanticKernelOptions
{
    public static readonly string Key = "SemanticKernel";

    [Required]
    public required string ApiKey { get; set; }

    [Required]
    [Url]
    public required string Endpoint { get; set; }
}
