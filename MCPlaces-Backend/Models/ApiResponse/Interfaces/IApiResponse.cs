namespace MCPlaces_Backend.Models.ApiResponse.Interfaces
{
    public interface IApiResponse
    {
        bool IsSuccess { get; }
        object? Data { get; }
        void Success(object? data = null);
        void Failure(object? data = null);
    }
}
