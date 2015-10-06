using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace FirstPersonView
{
    /// <summary>
    /// FPV Renderer for Disable Only objects.
    /// This class will disable the renderer on OnPreCull.
    /// It will re-enable it on OnPostRender.
    /// </summary>
    public class FPV_Renderer_DisableOnly : FPV_Renderer_Base
    {
        /// <summary>
        /// store if the first person viewer was enabled.
        /// This is needed because we disable the renderer when enabling first person viewer.
        /// </summary>
        private bool viewChanged;

        public override void Setup(Renderer render, IFPV_Object parent)
        {
            base.Setup(render, parent);
            viewChanged = false;
        }

        /// <summary>
        /// Enable first Person Viewer
        /// </summary>
        public override void EnableFirstPersonViewer()
        {
            if (isVisible)
            {
                viewChanged = true;
                _render.enabled = false;
            }
        }

        /// <summary>
        /// Disable first Person Viewer.
        /// </summary>
        public override void DisableFirstPersonViewer()
        {
            if (viewChanged)
            {
                viewChanged = false;
                _render.enabled = true;
            }
        }
    }
}
