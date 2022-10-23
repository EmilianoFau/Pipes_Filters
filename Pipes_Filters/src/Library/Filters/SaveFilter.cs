using System;
namespace CompAndDel;

public class SaveFilter : IFilter
{
    public string Path {get; set;}
    public SaveFilter(string path)
    {
        this.Path = path;
    }
    public IPicture Filter(IPicture image)
    {
        PictureProvider provider = new PictureProvider();
        provider.SavePicture(image, this.Path); 
        return image;
    }
}