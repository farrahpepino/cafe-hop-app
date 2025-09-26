namespace server.Models{
    public class PostDto{
        public string Id {get;set;}
        public string CafeName {get;set;}
        public string Name {get;set;}
        public string Location {get;set;}
        public string Content {get;set;}
        public DateTime CreatedAt {get;set;}
    }
}