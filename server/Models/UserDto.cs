namespace server.Models{
    public class UserDto{
        public string Id {get;set;}
        public string Name {get;set;}
        public string Email {get;set;}
        public DateTime CreatedAt {get;set;}= DateTime.Now;
    }
}