using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace FirstPersonView
{
    /// <summary>
    /// ----------------------- DOES NOT WORK -----------------------
    /// </summary>
    public class FPV_Renderer_Terrain : FPV_Renderer_DisableOnly
    {
        private bool viewChanged;
        private Terrain terrain;

        public override void Setup(Renderer render, IFPV_Object parent)
        {
            terrain = GetComponent<Terrain>();
            _parent = parent;
            _render = render;
            _originalLayer = gameObject.layer;
            isVisible = true;
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
                terrain.enabled = false;
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
                terrain.enabled = true;
            }
        }
    }
}
