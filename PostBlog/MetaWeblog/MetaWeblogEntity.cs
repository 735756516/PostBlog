using System;
using CookComputing.XmlRpc;

namespace PostBlog
{
    public class MetaWeblogEntity
    {
        /// <summary>
        /// 博客(文章)信息
        /// editPost()，getRecentPosts()，getPost() 可以取到博客信息
        /// </summary>
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public struct Post
        {
            public Object postid;
            public String title;
            public String description;                  // Post content.
            public String link;                         // Post URL.
            public String userid;                       // ID of post author.
            public DateTime dateCreated;
            public DateTime date_modified;              // Added in WordPress 3.4
            public DateTime date_modified_gmt;          // Added in WordPress 3.4
            public String permaLink;                    // Post URL, equivalent to link
            public String[] categories;                 // Names of categories assigned to the post
            public String[] mt_keywords;                // Names of tags assigned to the post.
            public String mt_excerpt;
            public String mt_text_more;                 // Post "Read more" text.
            public String mt_allow_comments;            // "open" or "closed"
            public String mt_allow_pings;               // "open" or "closed"
            public String wp_slug;
            public String wp_password;
            public String wp_author_id;
            public String wp_author_display_name;
            public String post_status;
            public String wp_post_format;               // Added in WordPress 3.1
            public bool sticky;                         // Added in WordPress 2.7.1
        }


        /// <summary>
        /// 博客分类信息
        /// </summary>
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public struct Category
        {
            public String categoryId;
            public String parentId;
            public String categoryName;
            public String categoryDescription;
            public String description;                  // Name of the category, equivalent to categoryName.
            public String htmlUrl;
            public String rssUrl;
        }
        

        /// <summary>
        /// 用户博客的基本信息
        /// </summary>
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public struct UserBlog
        {
            public String blogid;
            public String url;                           // Homepage URL for this blog.
            public String blogName;
            public bool isAdmin;
            public String xmlrpc;                        // URL endpoint to use for XML-RPC requests on this blog.
        }
        

        /// <summary>
        /// 媒体对象信息
        /// </summary>
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public struct MediaObject
        {
            public String name;                         // Filename.
            public String type;                         // File MIME type.
            public String bits;                         // base64-encoded binary data.
            public bool overwrite;                      // Optional. Overwrite an existing attachment of the same name.
        }


        /// <summary>
        /// 媒体文件信息
        /// </summary>
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public struct MediaFile
        {
            public String id;                           // (Added in WordPress 3.4)
            public String file;                         // Filename.
            public String url;
            public String type;
        }
    }
}
