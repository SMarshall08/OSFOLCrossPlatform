using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSFOLCrossPlatform
{
    public interface IEmailAttachment
    {
        string FileName { get; }
        string FilePath { get; }
        string ContentType { get; }
    }
}
