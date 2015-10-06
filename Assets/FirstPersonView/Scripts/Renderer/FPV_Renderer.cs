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
            if (isVisible)
            {
                _render.shadowCastingMode = ShadowCastingMode.ShadowsOnly;
            }
        }

        /// <summary>
        /// Disable First Person Viewer.
        /// Change back to shadowCastingMode.On
        /// </summary>
        public override void DisableFirstPersonViewer()
        {
            if (isVisible)
            {
                _render.shadowCastingMode = ShadowCastingMode.On;
                isVisible = false;
            }
        }
    }
}
