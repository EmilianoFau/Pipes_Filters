using System;
using TwitterUCU;
namespace CompAndDel;

public class TwitterFilter : IFilter
{
    public string Text {get; set;}
    public string Photo {get; set;}
    public TwitterFilter(string text, string photo)
    {
        this.Text = text;
        this.Photo = photo;
    }
    public IPicture Filter(IPicture image)
    {
        var twitter = new TwitterImage();
        Console.WriteLine(twitter.PublishToTwitter(Text, Photo));
        return image;
    }
}