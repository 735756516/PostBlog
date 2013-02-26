using System;
using CookComputing.XmlRpc;

namespace PostBlog
{
    /// <summary>
    /// 参考自(MetaWeblogAPI 支持 WordPress)：
    /// http://codex.wordpress.org/XML-RPC_MetaWeblog_API
    /// </summary>
    public class MetaWeblogAPI : XmlRpcClientProtocol
    {
        /// <summary>
        /// Retrieve a post.
        /// 
        /// Error:
        /// 401 - If the user does not have permission to edit this post.
        /// 404 - If no post with that postid exists.
        /// </summary>
        /// <param name="postid"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>MetaWeblogEntity.Post</returns>
        [XmlRpcMethod("metaWeblog.getPost")]
        public MetaWeblogEntity.Post getPost(String postid, String username, String password)
        {
            return (MetaWeblogEntity.Post)this.Invoke("getPost", new object[] { postid, username, password });
        }


        /// <summary>
        /// Retrieve a list of recent posts.
        /// 
        /// Error:
        /// If a user cannot edit a post that would be included in the result set, it will be omitted from the response. 
        /// Therefore, the total number of posts returned may be less than the requested quantity.
        /// </summary>
        /// <param name="blogid">Not applicable for WordPress, can be any value and will be ignored.</param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="numberOfPosts">Optional.</param>
        /// <returns>MetaWeblogEntity.Post Array</returns>
        [XmlRpcMethod("metaWeblog.getRecentPosts")]
        public MetaWeblogEntity.Post[] getRecentPosts(String blogid, String username, String password, int numberOfPosts)
        {
            return (MetaWeblogEntity.Post[])this.Invoke("getRecentPosts", new object[] { blogid, username, password, numberOfPosts });
        }


        /// <summary>
        /// Create a new post.
        /// 
        /// Error:
        /// 401 - If user does not have permission to edit or publish posts of the specified type.
        /// 401 - If user does not have permission to edit other users' posts but wp_author_id is specified.
        /// 404 - If invalid post format is specified.
        /// </summary>
        /// <param name="blogid">Not applicable for WordPress, can be any value and will be ignored.</param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="content"></param>
        /// <param name="publish"></param>
        /// <returns>string postid</returns>
        [XmlRpcMethod("metaWeblog.newPost")]
        public String newPost(String blogid, String username, String password, MetaWeblogEntity.Post content, bool publish)
        {
            content.dateCreated.AddHours(-1);

            return (String)this.Invoke("newPost", new object[] { blogid, username, password, content, publish });
        }


        /// <summary>
        /// Edit an existing post.
        /// 
        /// Error:
        /// 401 - If user does not have permission to edit this post.
        /// 401 - If user does not have permission to edit other users' posts but wp_author_id is specified.
        /// 404 - If no post with that postid exists.
        /// 404 - If invalid post format is specified.
        /// </summary>
        /// <param name="postid"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="content"></param>
        /// <param name="publish"></param>
        /// <returns>bool</returns>
        [XmlRpcMethod("metaWeblog.editPost")]
        public bool editPost(String postid, String username, String password, MetaWeblogEntity.Post content, bool publish)
        {
            return (bool)this.Invoke("editPost", new object[] { postid, username, password, content, publish });
        }


        /// <summary>
        /// Delete an existing post. 
        /// Equivalent to blogger.deletePost.
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
        public bool deletePost(String appKey, Object postid, String username, String password, bool publish)
        {
            return (bool)this.Invoke("deletePost", new object[] { appKey, postid, username, password, publish });
        }


        /// <summary>
        /// Retrieve list of categories.
        /// 
        /// Error:
        /// 401 - If the user does not have the edit_posts cap.
        /// </summary>
        /// <param name="blogid">can be any value.</param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>MetaWeblogEntity.Category Array</returns>
        [XmlRpcMethod("metaWeblog.getCategories")]
        public MetaWeblogEntity.Category[] getCategories(String blogid, String username, String password)
        {
            return (MetaWeblogEntity.Category[])this.Invoke("getCategories", new object[] { blogid, username, password });
        }


        /// <summary>
        /// Upload a media file.
        /// 
        /// Error:
        /// 401 - If the user does not have the upload_files cap.
        /// 500 - File upload failure.
        /// </summary>
        /// <param name="blogid"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="data"></param>
        /// <returns>MetaWeblogEntity.MediaFile</returns>
        [XmlRpcMethod("metaWeblog.newMediaObject")]
        public MetaWeblogEntity.MediaFile newMediaObject(String blogid, String username, String password, MetaWeblogEntity.MediaObject data)
        {
            return (MetaWeblogEntity.MediaFile)this.Invoke("newMediaObject", new object[] { blogid, username, password, data });
        }


        /// <summary>
        /// Returns information about all the blogs a given user is a member of. 
        /// Equivalent to blogger.getUsersBlogs.
        /// </summary>
        /// <param name="appKey">Not applicable for WordPress, can be any value and will be ignored.</param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>MetaWeblogEntity.UserBlog Array</returns>
        [XmlRpcMethod("blogger.getUsersBlogs")]
        public MetaWeblogEntity.UserBlog[] getUsersBlogs(String appKey, String username, String password)
        {
            return (MetaWeblogEntity.UserBlog[])this.Invoke("getUsersBlogs", new object[] { appKey, username, password });
        }
    }
}
