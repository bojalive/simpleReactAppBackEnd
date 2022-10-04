using Microsoft.EntityFrameworkCore;

namespace ReactApi.Data
{
    internal static class PostsRepository
    {


        internal async static Task<List<Post>> GetPostData()
        {
            using (var db = new AppDBContext())
            {
                return await db.Posts.ToListAsync();
            }
        }

        internal async static Task<Post> GetPostById(int Post_Id)
        {
            using (var db = new AppDBContext())
            {
                return await db.Posts.FirstOrDefaultAsync(p => p.PostId == Post_Id);
            }
        }

        internal async static Task<bool> CreatePostByID(Post PostToAdd)
        {
            using (var db = new AppDBContext())
            {
                try
                {
                    await db.AddAsync(PostToAdd);
                    await db.SaveChangesAsync();
                    return true;
                }
                catch (Exception e)
                {
                    return false;

                }
            }
        }

        internal async static Task<bool> DeletePostById(int PostIdToDelete)
        {
            using (var db = new AppDBContext())
            {
                Post PostToDelete = await db.Posts.FindAsync(PostIdToDelete);
                db.Remove(PostToDelete);
                await db.SaveChangesAsync();
                return true;
            }
        }
    }
}
