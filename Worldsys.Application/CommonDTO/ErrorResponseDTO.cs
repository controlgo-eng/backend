namespace Worldsys.Application.CommonDTO
{
    public class ErrorResponseDTO
    {
        public List<ErrorDetailDTO> Errors { get; set; } = [];
        public ErrorResponseDTO()
        {
        }

        public ErrorResponseDTO(List<ErrorDetailDTO> errors)
        {
            Errors = errors;
        }
    }

    public class ErrorDetailDTO
    {
        public int ErrorCode { get; set; }
        public string Message { get; set; }

        public ErrorDetailDTO(int errorCode, string message)
        {
            ErrorCode = errorCode;
            Message = message;
        }
    }
}
