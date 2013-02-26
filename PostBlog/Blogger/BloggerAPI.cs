using System;
using CookComputing.XmlRpc;

namespace PostBlog
{
    /// <summary>
    /// 参考自(BloggerAPI 支持 WordPress)：
    /// http://codex.wordpress.org/XML-RPC_Blogger_API
    /// </summary>
    public class BloggerAPI : XmlRpcClientProtocol
    {
        /// <summary>
        /// Returns information about all the blogs a given user is a member of
        /// </summary>
        /// <param name="appKey">Not applicable for WordPress, can be any value and will be ignored.</param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>BloggerEntity.UserBlog Array</returns>
        [XmlRpcMethod("blogger.getUsersBlogs")]
        public BloggerEntity.UserBlog[] getUsersBlogs(String appKey, String username, String password)
        {
            return (BloggerEntity.UserBlog[])this.Invoke("getUsersBlogs", new object[] { appKey, username, password });
        }


        /// <summary>
        /// Authenticates and returns basic information about the requesting user.
        /// This method does not return an email value as specified in the original Blogger API spec.
        /// 
        /// Error:
        /// 401 - If the user does not have the edit_posts cap.
        /// </summary>
        /// <param name="appKey"> Not applicable for WordPress, can be any value and will be ignored</param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>BloggerEntity.UserInfo</returns>
        [XmlRpcMethod("blogger.getUserInfo")]
        public BloggerEntity.UserInfo getUserInfo(String appKey, String username, String password)
        {
            return (BloggerEntity.UserInfo)this.Invoke("getUserInfo", new object[] { appKey, username, password });
        }


        /// <summary>
        /// Retrieve information about a post.
        /// 
        /// Error:
        /// 401 - If the user does not have the edit_posts cap.
        /// </summary>
        /// <param name="appkey">Not applicable for WordPress, can be any value and will be ignored.</param>
        /// <param name="postid"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>BloggerEntity.Post</returns>
        [XmlRpcMethod("blogger.getPost")]
        public BloggerEntity.Post getPost(String appkey, int postid, String username, String password)
        {
            return (BloggerEntity.Post)this.Invoke("getPost", new object[] { appkey, postid, username, password });
        }


        /// <summary>
        /// Retrieve list of recent posts.
        /// 
        /// Error:
        /// If a user cannot edit a post that would be included in the result set, it will be omitted from the response. 
        /// Therefore, the total number of posts returned may be less than the requested quantity.
        /// </summary>
        /// <param name="appkey">Not applicable for WordPress, can be any value and will be ignored.</param>
        /// <param name="blogid">Not applicable for WordPress, can be any value and will be ignored.</param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="numberOfPosts">Optional.</param>
        /// <returns></returns>
        [XmlRpcMethod("blogger.getRecentPosts")]
        public BloggerEntity.Post[] getRecentPosts(String appkey, int blogid, String username, String password, int numberOfPosts)
        {
            return (BloggerEntity.Post[])this.Invoke("getRecentPosts", new object[] { appkey, blogid, username, password, numberOfPosts });
        }


        /// <summary>
        /// Create a new post.
        /// 
        /// Error:
        /// 401 - If publish is false and the user lacks the edit_posts cap.
        /// 401 - If publish is true and the user lacks the publish_posts cap.
        /// </summary>
        /// <param name="appkey">Not applicable for WordPress, can be any value and will be ignored.</param>
        /// <param name="blogid">Not applicable for WordPress, can be any value and will be ignored.</param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="content"></param>
        /// <param name="publish">Whether to publish the post upon creation or leave it as a draft.</param>
        /// <returns>postid</returns>
        [XmlRpcMethod("blogger.newPost")]
        public int newPost(String appkey, int blogid, String username, String password, String content, bool publish)
        {
            return (int)this.Invoke("newPost", new object[] { appkey, blogid, username, password, content, publish });
        }


        /// <summary>
        /// Edit an existing post.
        /// 
        /// 401 - If the user does not have permission to edit this post.
        /// 401 - If publish is true and the user lacks the publish_posts cap.
        /// 404 - If no post with that postid exists.
        /// </summary>
        /// <param name="appkey">Not applicable for WordPress, can be any value and will be ignored.</param>
        /// <param name="postid"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="content"></param>
        /// <param name="publish"></param>
        /// <returns>bool</returns>
        [XmlRpcMethod("blogger.editPost")]
        public bool editPost(String appkey, int postid, String username, String password, String content, bool publish)
        {
            return (bool)this.Invoke("editPost", new object[] { appkey, postid, username, password, content, publish });
        }


        /// <summary>
        /// Delete an existing post.
        /// 
        /// Error:
        /// 401 - If the user does not have permission to delete this post.
        /// 404 - If no post with that postid exists.
        /// </summary>
        /// <param name="appKey">Not applicable for WordPress, can be any value and will be ignored.</param>
        /// <param name="postid"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="publish">Will be ignored.</param>
        /// <returns>bool</returns>
        [XmlRpcMethod("blogger.deletePost")]
        public bool deletePost(String appKey, int postid, String username, String password, bool publish)
        {
            return (bool)this.Invoke("deletePost", new object[] { appKey, postid, username, password, publish });
        }
    }
}
