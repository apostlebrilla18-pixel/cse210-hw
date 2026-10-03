using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Story of Life", " Eric Owusu", 120);
        Comment comment1 = new Comment("Manasseh", " insightful");
        video1.AddComment(comment1);
        Comment comment2 = new Comment("Paul", " good");
        video1.AddComment(comment2);
        Comment comment3 = new Comment("Man", " nice");
        video1.AddComment(comment3);
        videos.Add(video1);

        Video video2 = new Video("Life", " Richmond Muss", 10);
        Comment comment4 = new Comment("Kofi", " wow");
        video2.AddComment(comment4);
        Comment comment5 = new Comment("Pau", " great");
        video2.AddComment(comment5);
        Comment comment6 = new Comment("Mansa", " useful");
        video2.AddComment(comment6);
        videos.Add(video2);

        Video video3 = new Video("Football", " Richard Oti", 200);
        Comment comment7 = new Comment("Kwame", " indeed");
        video3.AddComment(comment7);
        Comment comment8 = new Comment("Randy", " grateful");
        video3.AddComment(comment8);
        Comment comment9 = new Comment("Mansah", " massive");
        video3.AddComment(comment9);
        videos.Add(video3);

        foreach (Video video in videos)
        {
            Console.WriteLine("Title: " + video.GetTitle() + " Author:  " + video.GetAuthor() + " Comment: " + video.GetCommentCount() + " Length: " + video.GetLength());

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine(comment.GetName() + comment.GetText());
            }
        }
    }
}
