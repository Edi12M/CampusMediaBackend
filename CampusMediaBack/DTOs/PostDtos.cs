﻿namespace CampusMediaBack.DTOs;
public class PostDto
{
    public int Id { get; set; }
    public string Image { get; set; } = string.Empty;
    public string Caption { get; set; } = string.Empty;
    public string Date { get; set; } = string.Empty;
    public List<int> Likes { get; set; } = new();
}
public class FeedPostDto : PostDto
{
    public string PosterName { get; set; } = string.Empty;
    public string PosterImage { get; set; } = string.Empty;
    public int PosterId { get; set; }
    public string? Feeling { get; set; }
    public string? Location { get; set; }
    public List<CommentResponseDto> Comments { get; set; } = new();
}
public class CreatePostRequest
{
    public string Image { get; set; } = string.Empty;
    public string Caption { get; set; } = string.Empty;
    public string Date { get; set; } = string.Empty;
}
