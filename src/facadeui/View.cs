using System;
using System.Collections.Generic;
using FacadeUI.Utility;
using Veldrid;

namespace FacadeUI
{
    public class View
        : UIObject
    {
        private GraphicsDevice _graphicsDevice = null;

        public View()
        {

        }

        public void Initialize(GraphicsDevice graphicsDevice)
        {
            _graphicsDevice = graphicsDevice;
        }

        public void Render()
        {
            
        }
    }
}