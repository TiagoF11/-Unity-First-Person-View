using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace FirstPersonView
{
    /// <summary>
    /// FPV Renderer for objects that cast shadows.
    /// </summary>
    public class FPV_Renderer : FPV_Renderer_Base
    {
        /// <summary>
        /// Enable First Person Viewer
        /// Simply change the shadowCastingMode to ShadowsOnly.
        /// </summary>
        public override void EnableFirstPersonViewer()
        {
            _render.shadowCastingMode = ShadowCastingMode.ShadowsOnly;
        }
         
        /// <summary>
        /// Disable First Person Viewer.
        /// Change back to shadowCastingMode.On
        /// </summary>
        public override void DisableFirstPersonViewer()
        {
            _render.shadowCastingMode = ShadowCastingMode.On;
        }

        /// <summary>
        /// Before this object is going to be rendered, it will check it is not a first person object.
        /// It will then see if the First Person camera is currently rendering, and will then enable the First Person View for this renderer.
        /// If not, it will revert the renrerer back to its original state.
        /// </summary>
        protected void OnWillRenderObject()
        {
            if (_isFirstPersonObject) return;

            if (isFPVCameraRendering)
            {
                _rendererChanged = true;
                EnableFirstPersonViewer();
            }
            else if (_rendererChanged)
            {
                _rendererChanged = false;
                DisableFirstPersonViewer();
            }
        }
    }
}
