using System.Text.Json;

namespace SuperLandscapes_Blog.Application.Exceptions.Handling
{
    public class ErrorResponse
    {
        public string Message { get; set; } = string.Empty;

        public bool Success { get; set; }
        public override string ToString() => JsonSerializer.Serialize(this);
    }
}
