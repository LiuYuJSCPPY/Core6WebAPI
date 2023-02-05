using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using aspnetWebApi.Data;
using aspnetWebApi.Model;
using aspnetWebApi.Interface;

namespace aspnetWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostAPIController : ControllerBase 
    {
        private readonly IPost _IPost;

        public PostAPIController(IPost post)
        {
            _IPost = post;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Post>> AllGetPost()
        {
            var AllPosts = _IPost.GetAllPost();

            if(AllPosts == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(AllPosts);
            }
        }

        [HttpGet("{Id}")]
        public ActionResult<Post> GetPost(int Id)
        {
            Post GetPost = _IPost.GetIDbyPost(Id);
            if(GetPost == null)
            {
                return NotFound();
            }

            return Ok(GetPost);
        }

        [HttpPost]
        public ActionResult<Post> SavePost(Post post)
        {
            bool Result = false;
            Result = _IPost.Create(post);

            if (Result)
            {
                return Ok(post);
            }
            else
            {
                return NotFound();
            }
            
        }

        [HttpPut]
        public ActionResult<Post> UpdatePost(Post post)
        {
            Post IdGetPost = new Post();
            bool Result = false;
            if(IdGetPost == null)
            {
                return NotFound();
            }
            IdGetPost.Id = post.Id;
            IdGetPost.Title = post.Title;
            IdGetPost.Content = post.Content;
            Result=_IPost.Update(IdGetPost);

            if (Result)
            {
            return Ok(IdGetPost);

            }
            else
            {
                return BadRequest();
            }
           
    
           
        }

        [HttpDelete("{Id}")]
        public ActionResult<Post> DeletePost(int Id)
        {
            Post IdPost = _IPost.GetIDbyPost(Id);
            if (IdPost == null)
            {
                return NotFound();
            }
            bool Result = false;
            Result = _IPost.Delete(IdPost);
            if (Result)
            {
                return Ok();

            }
            else
            {
                return NotFound();
            }
        }

    }
}
