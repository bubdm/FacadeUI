using System;
using System.Collections.Generic;
using System.Linq;
using FacadeUI.Utility;

namespace FacadeUI
{
    public class UIObject
    : IDisposable
    {
        
        public string Id {get;set;} = string.Empty ;
        public Rectangle Bounds {get; set;} 

        #region Housekeeping
        private bool disposedValue;

        public UIObject()
        {
        }
 
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // Invoke the destroy call
                    OnDestroy() ;
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~UIObject()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }       
        #endregion

        #region Lifecycle Management

        protected virtual void OnCreate() {}    // OnDestroy()?

        protected virtual void OnLoadResources() {}

        protected virtual void OnDestroy() {}

        #endregion

        #region Visual Operations
        public bool Visible {get; private set;} = false;

        public void Show()
        {
            if(!Visible)
            {
                Visible = true;
                OnShow() ;
            }
        }
        protected virtual void OnShow() {}

        public void Hide()
        {
            if(Visible)
            {
                Visible = false ;
                OnHide() ;
            }
        }
        protected virtual void OnHide() {}

        #endregion

        #region Drawing
        protected void Draw()
        {
            //--TODO: Setup transforms and build an actual draw context
            OnPreDraw() ;

            OnDraw() ;

            foreach(var child in _children)
            {
                child.Draw() ;
            }

            OnPostDraw() ;
        }

        protected virtual void OnPreDraw() {}
        protected virtual void OnDraw() {}
        protected virtual void OnPostDraw() {}

        #endregion


        #region Child Management
        //--TODO: Address this design later.. It feels too low-level to expose like this
        //        Maybe use a ViewBuilder pattern or something to help put everything together
        //        with an object factory that can instantiate everything.
        private List<UIObject> _children = new List<UIObject>() ;

        public IEnumerable<UIObject> Children {get{return _children;}}

        public int AddChild(string id, UIObject child)
        {
            int index = _children.Count ;

            // may need some guards around this in the future
            //child.Parent = this ;

            _children.Add(child) ;

            return index ;
        }

        public void RemoveChild(string id)
        {
            _children.RemoveAll(p => p.Id == id) ;
        }

        public void RemoveChild(int index)
        {
            if(index >= 0 && index < _children.Count)
            {
                _children.RemoveAt(index) ;
            }
      }

        public void RemoveAllChildren()
        {
            _children.Clear() ;
        }

        #endregion
    }
}