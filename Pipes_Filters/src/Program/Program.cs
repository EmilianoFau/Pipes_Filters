using System.ComponentModel;
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
            /*Carga la imagen*/
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"luke.jpg");

            /*Modifica la imagen y la guarda con su respectivo filtro*/
            PipeNull nullPipe = new PipeNull();
            FilterNegative negativeFilter = new FilterNegative();
            PipeSerial serialPipe1 = new PipeSerial(negativeFilter, nullPipe);
            FilterGreyscale greyscaleFilter = new FilterGreyscale();
            PipeSerial serialPipe2 = new PipeSerial(greyscaleFilter, serialPipe1);
            
            picture = serialPipe1.Send(picture);
            provider.SavePicture(picture, @"luke.jpg");
            picture = serialPipe2.Send(picture);
            provider.SavePicture(picture, @"luke1.jpg");
            
            var twitter = new TwitterImage();
            Console.WriteLine(twitter.PublishToTwitter("New image!",@"luke.jpg"));
            Console.WriteLine(twitter.PublishToTwitter("New image!",@"luke1.jpg"));
        }        
    }
}

