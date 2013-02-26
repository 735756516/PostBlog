using System;
using CookComputing.XmlRpc;

namespace PostBlog
{
    public class BloggerEntity
    {
        /// <summary>
        /// 用户博客的基本信息
        /// </summary>
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public struct UserBlog
        {
            public Object blogid;
            public String url;          // Homepage URL for this blog.
            public String blogName;
            public bool isAdmin;
            public String xmlrpc;       // URL endpoint to use for XML-RPC requests on this blog.
        }


        /// <summary>
        /// 用户信息 
        /// </summary>
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public struct UserInfo
        {
            public Object userid;
            public String nickname;
            public String firstname;
            public String lastname;
            public String url;
        }


        /// <summary>
        /// 博客(文章)信息
        /// </summary>
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public struct Post
        {
            public Object postid;
            public Object userid;
            public DateTime dateCreated;
            public String content;          //  Character-encoded XML.
        }
    }
}
