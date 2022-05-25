using Octavo.Gate.Nabu.CORE.Entities.Core;
using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Content
{
    [DataContract]
    public class Article : BaseType
    {
        [DataMember]
        public int? ArticleID { get; set; }

        [DataMember]
        public Party AuthoredBy { get; set; }

        [DataMember]
        public DateTime PublishedDate { get; set; }

        [DataMember]
        public Content ArticleBody { get; set; }

        [DataMember]
        public Content ArticleImage { get; set; }

        [DataMember]
        public Content ArticleLink { get; set; }

        public Article() : base()
        {
            ArticleID = null;
            ArticleImage = null;
            ArticleLink = null;
        }

        public Article(int pArticleID) : base()
        {
            ArticleID = pArticleID;
        }

        public Article(int? pArticleID) : base()
        {
            ArticleID = pArticleID;
        }
    }

    [DataContract]
    public class RawArticle : BaseType
    {
        [DataMember]
        public int? ArticleID;

        [DataMember]
        public int AuthoredByPartyID;

        [DataMember]
        public DateTime PublishedDate;

        [DataMember]
        public string Title = "";

        [DataMember]
        public StructuredContent ArticleBody = null;

        [DataMember]
        public ManagedContent ArticleImage = null;

        [DataMember]
        public UnmanagedContent ArticleLink = null;

        public RawArticle() : base()
        {
            ArticleID = null;
        }

        public RawArticle(int pArticleID) : base()
        {
            ArticleID = pArticleID;
        }

        public RawArticle(int? pArticleID) : base()
        {
            ArticleID = pArticleID;
        }
    }
}
