using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models{
     [Table("Posts")]
    public class Post{
        [Key]
        [Column(TypeName="varchar(36)")]
        public string Id {get;set;}= Guid.NewGuid().ToString();

        [Required]
        [MaxLength(70)]
        public string CafeName {get;set;}

        [Required]
        public string UserId {get;set;}
        
        public User user {get;set;}

        [Required]
        [MaxLength(360)]
        public string Location {get;set;}

        [Required]
        [MaxLength(1000)]
        public string Content {get;set;}

        [Required]
        public DateTime CreatedAt {get;set;}= DateTime.Now;
    }
}


// add userid for foreign key