﻿namespace BlogBuzz.Models.Domain.ViewModels
{
    public class AddLikeRequest
    {
        public Guid BlogPostId { get; set; }
        public Guid UserId { get; set; }
    }
}
