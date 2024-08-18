namespace MCPlaces_Backend.Models.ApiResponse.Interfaces
{
    public interface IApiResponse
    {
        bool IsSuccess { get; }
        object? Data { get; }
        List<string> ErrorMessages { get; }
        void Success(object? data = null);
        void Failure(string? errorMessage = null);
    }
}
