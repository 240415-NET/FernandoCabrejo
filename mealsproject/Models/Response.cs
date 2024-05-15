namespace MealsProject.Models
{
    internal class Response
    {
        public bool Success { get; set; } = true;

        public object ObjectResponse { get; set; }

        public string? Message { get; set; }
    }
}