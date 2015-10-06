using UnityEngine;
using UnityEngine.Rendering;

namespace FirstPersonView
{
    /// <summary>
    /// FPV Renderer for Objects that contain custom shadow casting mode, or are subject to shadow casting mode change.
    /// </summary>
    public class FPV_Renderer_Custom : FPV_Renderer_Base
    {
        /// <summary>
        /// The shadowCastMode of this renderer.
        /// </summary>
        private ShadowCastingMode rendererShadowCastMode;

        public override void Setup(Renderer render, IFPV_Object parent)
        {
            base.Setup(render, parent);
            rendererShadowCastMode = render.shadowCastingMode;
        }

        /// <summary>
        /// Enable First Person Viewer.
        /// Simply switch the shadowCastingMode to ShadowsOnly.
        /// </summary>
        public override void EnableFirstPersonViewer()
        {
            if(isVisible)
            {
                _render.shadowCastingMode = ShadowCastingMode.ShadowsOnly;
            }
        }

        /// <summary>
        /// Disable First Person Viewer.
        /// Switch back to the shadow casting this renderer was using.
        /// </summary>
        public override void DisableFirstPersonViewer()
        {
            if(isVisible)
            {
                _render.shadowCastingMode = rendererShadowCastMode;
            }
        }

        /// <summary>
        /// Manualy change the custom shadowCastingMode of this renderer.
        /// </summary>
        /// <param name="mode"></param>
        public void SetShadowCastingMode(ShadowCastingMode mode)
        {
            rendererShadowCastMode = mode;
        }
    }
}