using System;
namespace CompAndDel;

public interface ICognitiveFilter : IFilter
{
    bool Identify();
}