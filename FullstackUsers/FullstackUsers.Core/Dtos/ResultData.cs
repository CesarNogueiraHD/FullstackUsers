namespace FullstackUsers.Core.Dtos
{
    public class ResultData<T>(T? data = default, bool isSuccess = true, string? error = null) where T : class
    {
        private ResultData(string error) : this(null, false, error) { }
        private ResultData() : this(null, true, null) { }


        public T? Data { get; private set; } = data;
        public string? Error { get; private set; } = error;
        public bool IsSuccess { get; private set; } = isSuccess;

        public static ResultData<T> Success(T data) => new(data);
        public static ResultData<T> Success() => new();
        public static ResultData<T> Failure(string error) => new(error);
    }
}
