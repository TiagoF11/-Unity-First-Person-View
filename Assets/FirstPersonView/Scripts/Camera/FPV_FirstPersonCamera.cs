using UnityEngine;

namespace FirstPersonView
{
    public class FPV_FirstPersonCamera : MonoBehaviour
    {
        /// <summary>
        /// Static variable of the FPV Camera.
        /// </summary>
        public static Camera fpvCamera;

        private RenderBuffer activeRT;
        private Camera cam;

        void Awake()
        {
            fpvCamera = cam = GetComponent<Camera>();
        }

        /// <summary>
        /// Pre Cull Method.
        /// This is called for objects which need to be disabled before rendering.
        /// </summary>
        void OnPreCull()
        {
            FPV_Renderer_Base.isFPVCameraRendering = true;
            FPV_Container.EnableDisableOnlyFirstPersonViewer();
        }

        /// <summary>
        /// On Pre Render.
        /// Called for objects that get their ShadowCasterMode changed.
        /// </summary>
        void OnPreRender()
        {
            FPV_Container.EnableFirstPersonViewer();
        }

        /// <summary>
        /// On Post Render.
        /// Revert everything back to normal.
        /// </summary>
        void OnPostRender()
        {
            FPV_Container.DisableFirstPersonViewer();
            FPV_Renderer_Base.isFPVCameraRendering = false;
        }

        public Camera GetCamera()
        {
            return cam;
        }
    }
}