using System;
using System.Threading.Tasks;
using System.Linq;
using Veldrid;
using Veldrid.Sdl2;
using Veldrid.StartupUtilities;

namespace FacadeUI
{
    public class Window
    {
        private Sdl2Window _window;
        private GraphicsDevice _graphicsDevice; 

        public View MainView {get;set;}

        public Window()
        {
            //--TODO: This is temporary while I build the library out.  Future state is to load from file, initiated by the client application
            MainView = new View() ;
        }

        public async Task Run()
        {
            var task = Task.Run(() =>
            {           
                //--TODO: These values should come from the MainView in the future
                var windowCI = new WindowCreateInfo()
                {
                    X = 100,
                    Y = 100,
                    WindowHeight = 540,
                    WindowWidth = 960,
                    WindowTitle = "Veldrid Tutorial"
                };

                _window = VeldridStartup.CreateWindow(windowCI);
                _graphicsDevice = VeldridStartup.CreateGraphicsDevice(_window);
                //--_window.BorderVisible = false; -- This is nice for a future state where we can render the title bar better...
                                
                // _View = new MyView();

                //_View.Initialize(_Window, _graphicsDevice);

                WindowLoop();

                DisposeResources();
            }) ;

            await task ;
        }

        private void WindowLoop()
        {  
            DateTime ts = DateTime.Now;
            while(_window.Exists)
            {
                DateTime now = DateTime.Now;
                TimeSpan diff = now - ts;

                _window.PumpEvents();
                //_View.UpdateTick((float)diff.TotalSeconds);
                //Draw();
                ts = now;
            } 
        }

        private void DisposeResources()
        {
            _graphicsDevice.Dispose() ;
        }
    }
}
