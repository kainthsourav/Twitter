namespace Twitter.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TweetsData")]
    public class TweetModel
    {
        [Key]
        public int TweetId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string TweetDescription { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public int commentsCount { get; set; }
        public int likesCount { get; set; }

    }
}
