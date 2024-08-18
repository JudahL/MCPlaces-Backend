using MCPlaces_Backend.Models.ApiResponse.Interfaces;

namespace MCPlaces_Backend.Models.ApiResponse
{
    public class ApiResponse : IApiResponse
    {
        public bool IsSuccess { get; private set; } = true;
        public object? Data { get; private set; }
        public List<string> ErrorMessages { get; private set; } = new List<string>();   

        public void Success(object? data = null) 
        {
            IsSuccess = true;
            Data = data;
        }

        public void Failure(string? errorMessage = null) 
        {
            if (errorMessage == null) 
            {
                errorMessage = "An unknown error has occured.";
            }

            IsSuccess = false;
            ErrorMessages.Add(errorMessage);
        }
    }
}
