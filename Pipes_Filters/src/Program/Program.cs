using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;
using TwitterUCU;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"luke.jpg");

            CognitiveFilter filterCognitve = new CognitiveFilter(@"luke.jpg");
            PipeNull nullPipe = new PipeNull();
            ConditionalPipe condPipe = new ConditionalPipe(nullPipe, picture, filterCognitve);

            SaveFilter filterSave1 = new SaveFilter(@"luke1.jpg");
            PipeSerial serialPipe1 = new PipeSerial(filterSave1, condPipe);

            FilterGreyscale greyscaleFilter = new FilterGreyscale();
            PipeSerial serialPipe2 = new PipeSerial(greyscaleFilter, serialPipe1);

            serialPipe2.Send(picture);

            
        }        
    }
}

