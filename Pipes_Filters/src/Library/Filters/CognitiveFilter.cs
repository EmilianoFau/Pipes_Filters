using System.Globalization;
using System;
using CognitiveCoreUCU;
namespace CompAndDel;

public class CognitiveFilter : ICognitiveFilter
{
    public CognitiveFilter(string photo)
    {
        this.Photo = photo;
    }
    public IPicture Filter(IPicture image)
    {
        return image;
    }
    public bool Identify()
    {
        CognitiveFace cog = new CognitiveFace(false);
        cog.Recognize(this.Photo);
        if (cog.FaceFound)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public string Photo {get; set;}
}