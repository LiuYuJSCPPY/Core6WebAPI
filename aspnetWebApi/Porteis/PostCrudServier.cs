using aspnetWebApi.Interface;
using aspnetWebApi.Model;
using aspnetWebApi.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace aspnetWebApi.Porteis
{
    public class PostCrudServier : IPost
    {

        private readonly ASPWewbApiContext _aSPWewbApiContext;

        public PostCrudServier(ASPWewbApiContext aSPWewbApiContext)
        {
            _aSPWewbApiContext = aSPWewbApiContext;
        }

        public bool Create(Post post)
        {

            _aSPWewbApiContext.Add(post);
            return _aSPWewbApiContext.SaveChanges() > 0;

        }

        public bool Delete(Post post)
        {
            _aSPWewbApiContext.Remove(post);
            return _aSPWewbApiContext.SaveChanges() > 0;

        }

        public IEnumerable<Post> GetAllPost()
        {
            return _aSPWewbApiContext.posts.ToList();
        }

        public Post GetIDbyPost(int Id)
        {
            return _aSPWewbApiContext.posts.FirstOrDefault(m => m.Id == Id);
        }

        public bool Update(Post post)
        {
            
               
            _aSPWewbApiContext.Entry(post).State = EntityState.Modified;
            return _aSPWewbApiContext.SaveChanges() > 0;
            

           
        }
    }
}
