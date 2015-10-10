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
        public override void Setup(Renderer render, IFPV_Object parent)
        {
            base.Setup(render, parent);
        }

        /// <summary>
        /// Enable first Person Viewer
        /// </summary>
        public override void EnableFirstPersonViewer()
        {
            _render.enabled = false;
        }

        /// <summary>
        /// Disable first Person Viewer.
        /// </summary>
        public override void DisableFirstPersonViewer()
        {
            _render.enabled = true;
        }
        
        /// <summary>
        /// After this object is rendered by a camera, it will first check if it is a first person object.
        /// If not, and if the current camera rendering is the world camera, it will tell the parent object that an object was affected
        /// to the First Person View, and then it will enable the First Person View to prepare for the First Person Camera.
        /// </summary>
        void OnRenderObject()
        {
            if (_isFirstPersonObject) return;

            if (!isFPVCameraRendering)
            {
                _parent.SetChanged();
                EnableFirstPersonViewer();
            }
        }
        
    }
}
