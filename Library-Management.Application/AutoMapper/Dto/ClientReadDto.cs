namespace Library_Management.Application.AutoMapper.Dto
{
    public class ClientReadDto
    {
        public Guid Id { get; set; }
        public string Nom { get; set; } = string.Empty;
        public string NumeroTelephone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Quartier { get; set; } = string.Empty;
    }
}
