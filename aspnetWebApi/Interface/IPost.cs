using aspnetWebApi.Model;
using Microsoft.AspNetCore.Mvc;


namespace aspnetWebApi.Interface
{
    public interface IPost
    {
        public Post GetIDbyPost(int Id);
        public IEnumerable<Post> GetAllPost();
        public bool Create(Post post);
        public bool Update(Post post);
        public bool Delete(Post post);
    }
}
