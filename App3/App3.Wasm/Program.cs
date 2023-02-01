using Microsoft.UI.Xaml;
using System;

namespace App3.Wasm
{
    public sealed class Program
    {
        private static App _app;

        static int Main(string[] args)
        {
            Microsoft.UI.Xaml.Application.Start(_ => _app = new App());

            return 0;
        }
    }
}
