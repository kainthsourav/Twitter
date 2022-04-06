using System;

namespace Twitter.ViewModel
{
    public class TweetViewModel
    {
      public int TweetId { get; set; }
      public int UserId { get; set; }
      public string TweetDescription { get; set; }
      public DateTime createdAt { get; set; }
      public DateTime updatedAt { get; set; }
      public int commentsCount { get; set; }
      public int likesCount { get; set; }

    }
}
