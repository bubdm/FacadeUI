using System;
using Veldrid;
using Veldrid.Utilities;
using Veldrid.SPIRV;
using FacadeUI.Drawing.Utility;

namespace FacadeUI.Drawing
{
    public class Canvas
    {
        private GraphicsDevice _device ;
        private DisposeCollectorResourceFactory _resources ;

        public Canvas(GraphicsDevice device)
        {
            // May need to implement Disposable Pattern to force the system
            // to actually dispose of the resources instead of waiting on the GC

            _device = device ;
            _resources = new DisposeCollectorResourceFactory(device.ResourceFactory) ;
        }

        private void Initialize()
        {
            // Setup full render pipeline resources, basic one-time initialization

            (Shader vs, Shader fs) = ShaderHelper.LoadSPIRV(_device, _resources, "roundedquad") ;
        }
    }
}
