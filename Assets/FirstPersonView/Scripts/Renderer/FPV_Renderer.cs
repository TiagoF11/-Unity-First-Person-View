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
        /// Called when a camera is going to render this object.
        /// This reduces the amount of work done for the FPV Camera, since only objects inside its frustum will be called (or casts shadows inside the camera's frustum)
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
