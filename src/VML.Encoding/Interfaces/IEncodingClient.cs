using System.Linq;
using System;
using VML.Encoding.Model.Query;

namespace VML.Encoding.Interfaces
{
    public interface IEncodingClient
    {
        string Execute(EncodingQuery query);
    }
}