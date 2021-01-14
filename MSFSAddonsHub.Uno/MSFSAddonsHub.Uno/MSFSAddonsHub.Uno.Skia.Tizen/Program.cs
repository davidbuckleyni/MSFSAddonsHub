﻿using Tizen.Applications;
using Uno.UI.Runtime.Skia;

namespace MSFSAddonsHub.Uno.Skia.Tizen
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new TizenHost(() => new MSFSAddonsHub.Uno.App(), args);
            host.Run();
        }
    }
}
