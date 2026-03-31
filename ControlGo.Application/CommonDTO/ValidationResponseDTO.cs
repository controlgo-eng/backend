namespace ControlGo.Application.CommonDTO
{
    public class ValidationResponseDTO
    {
        public List<ValidationDetailDTO> Errors { get; set; } = [];
        public ValidationResponseDTO()
        {
        }

        public ValidationResponseDTO(List<ValidationDetailDTO> errors)
        {
            Errors = errors;
        }
    }

    public class ValidationDetailDTO
    {
        public string Property { get; set; }
        public string Message { get; set; }

        public ValidationDetailDTO(string property, string message)
        {
            Property = property;
            Message = message;
        }
    }
}
