using UnityEngine;

namespace FirstPersonView
{
    public class FPV_FinalCamera : FPV_Camera
    {
        /// <summary>
        /// Camera component of the WorldCamera
        /// </summary>
        private Camera worldCamera;
        /// <summary>
        /// Camera component of the First Person Camera
        /// </summary>
        private Camera fpvCamera;

        /// <summary>
        /// Render texture used for the World Camera and the First Person Camera to render into.
        /// </summary>
        private RenderTexture mainRenderTexture;

        /// <summary>
        /// Screen size variables to check if the screen resolution has changed.
        /// </summary>
        private int screenX;
        private int screenY;

        //Render Texture Properties
        //----- Change these properties for your specific needs -----
        private RenderTextureFormat renderTextureFormat = RenderTextureFormat.DefaultHDR;
        private int renderTextureDepth = 16; //Number of bits in depth buffer (0, 16 or 24). Note that only 24 bit depth has stencil buffer.


        void Awake()
        {
            SetCamera();
            UpdateStaticCamera();
        }

        void Start()
        {
            SetCameras();
            CreateRenderTexture();
        }

        /// <summary>
        /// Set the reference cameras from the static variables.
        /// </summary>
        private void SetCameras()
        {
            worldCamera = FPV.worldCamera.GetCamera();
            fpvCamera = FPV.firstPersonCamera.GetCamera();
        }

        /// <summary>
        /// Manualy update the static camera variable of this component.
        /// </summary>
        public override void UpdateStaticCamera()
        {
            FPV.finalCamera = this;
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

            worldCamera.targetTexture = mainRenderTexture;
            fpvCamera.targetTexture = mainRenderTexture;
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
        /// Set the active Render Texture to the mainRenderTexture so this camera renders the result of the World Camera and First Person View Camera.
        /// </summary>
        void OnPreRender()
        {
            RenderTexture.active = mainRenderTexture;
        }
    }
}
