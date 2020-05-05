using System;
using System.Threading.Tasks;
using FacadeUI;

namespace Sandbox
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Window window = new Window() ;

            await window.Run();            
        }
    }
}
