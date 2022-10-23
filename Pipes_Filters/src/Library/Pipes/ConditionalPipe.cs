using System.Threading;
using System;
using CompAndDel.Filters;
namespace CompAndDel.Pipes;

public class ConditionalPipe : IPipe
{ 
    public void Conditional()
    {
        var boolean = Filtro.Identify();
        if (boolean)
        {
            PipeNull nullPipe = new PipeNull();
            TwitterFilter filterTwitter = new TwitterFilter("nueva imagen", @"luke1.jpg");
            PipeSerial serialPipe1 = new PipeSerial(filterTwitter, nullPipe);
            serialPipe1.Send(this.Picture);
        }
        else
        {
            PipeNull nullPipe = new PipeNull();
            SaveFilter filterSave = new SaveFilter(@"beer.jpg");
            PipeSerial serialPipe1 = new PipeSerial(filterSave, nullPipe);
            FilterNegative negativeFilter = new FilterNegative();
            PipeSerial serialPipe2 = new PipeSerial(negativeFilter, serialPipe1);
            serialPipe2.Send(this.Picture);
        }
    }
    IPipe Pipe;
    IPicture Picture;
    ICognitiveFilter Filtro;
    public ConditionalPipe(IPipe pipe, IPicture picture, ICognitiveFilter filtro) 
    {
        this.Pipe = pipe;
        this.Picture = picture;  
        this.Filtro = filtro;
        Conditional();
    }

    public IPicture Send(IPicture picture)
    {
        Pipe.Send(picture.Clone());
        return this.Pipe.Send(picture);
    }
}