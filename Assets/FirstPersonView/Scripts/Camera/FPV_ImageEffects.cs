using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace FirstPersonView
{
    public class FPV_ImageEffects : MonoBehaviour
    {
        public Camera WorldCamera;
        public Camera FPVCamera;

        private RenderTexture mainRenderTexture;

        private int screenX;
        private int screenY;

        //Render Texture Properties
        //----- Change these properties for your specific needs -----
        private RenderTextureFormat renderTextureFormat = RenderTextureFormat.DefaultHDR;
        private int renderTextureDepth = 16; //Number of bits in depth buffer (0, 16 or 24). Note that only 24 bit depth has stencil buffer.

        void Start()
        {
            CreateRenderTexture();
        }

        /// <summary>
        /// Create the RenderTexture that will be used by both cameras.
        /// </summary>
        private void CreateRenderTexture()
        {
            screenX = Screen.width;
            screenY = Screen.height;

            mainRenderTexture = new RenderTexture(screenX, screenY, renderTextureDepth, renderTextureFormat);
            mainRenderTexture.Create();

            WorldCamera.targetTexture = mainRenderTexture;
            FPVCamera.targetTexture = mainRenderTexture;
        }

        void Update()
        {
            if (HasResolutionChanged())
            {
                CreateRenderTexture();
            }
        }

        /// <summary>
        /// Check if resolution of the screen has changed
        /// </summary>
        /// <returns></returns>
        private bool HasResolutionChanged()
        {
            return screenX != Screen.width || screenY != Screen.height;
        }

        /// <summary>
        /// Set the active Render Texture to the mainRenderTexture
        /// </summary>
        void OnPreRender()
        {
            RenderTexture.active = mainRenderTexture;
        }
    }
}
