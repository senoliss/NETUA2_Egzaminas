namespace NETUA2_Egzaminas.API.DTOs
{
    public class ResponseDTO
    {
        /// <summary>
        /// Boolean value to check if the operation is sucessfull
        /// </summary>
        public bool IsSuccess { get; set; }
        /// <summary>
        /// string for the operation message either it is good or bad
        /// </summary>
        public string Message { get; set; }

        public ResponseDTO(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }

        public ResponseDTO(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }
    }
}
