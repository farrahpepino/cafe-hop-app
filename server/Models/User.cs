namespace server.Models{
    public class User{
        [Key]
        [Column(TypeName="varchar(36)")]
        public required string Id {get;set;}= Guid.NewGuid.ToString();

        [Required]
        [MaxLength(70)]
        public string Name {get;set;}

        [Required]
        [MaxLength(254)]
        public string Email {get;set;}

        [Required]
        [MaxLength(64)]
        public string Password {get;set;}

        [Required]
        public DateTime CreatedAt {get;set;}= DateTime.Now;
    }
}