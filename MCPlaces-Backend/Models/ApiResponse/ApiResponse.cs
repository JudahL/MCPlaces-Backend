using MCPlaces_Backend.Models.ApiResponse.Interfaces;

namespace MCPlaces_Backend.Models.ApiResponse
{
    public class ApiResponse : IApiResponse
    {
        public bool IsSuccess { get; private set; } = true;
        public object? Data { get; private set; }

        public void Success(object? data = null) 
        {
            IsSuccess = true;
            Data = data;
        }

        public void Failure(object? data = null) 
        {
            if (data == null) 
            {
                data = "An unknown error has occured.";
            }

            IsSuccess = false;
            Data = data;
        }
    }
}
