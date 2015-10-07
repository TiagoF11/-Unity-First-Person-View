using UnityEngine;

namespace FirstPersonView
{
    public class FPV_FirstPersonCamera : MonoBehaviour
    {
        /// <summary>
        /// Camera component of this camera
        /// </summary>
        private Camera fpvCamera;

        void Awake()
        {
            UpdateStaticCamera();
            fpvCamera = GetComponent<Camera>();
        }

        /// <summary>
        /// Manualy update the static first person view camera variable.
        /// </summary>
        public void UpdateStaticCamera()
        {
            FPV.firstPersonCamera = this;
        }

        /// <summary>
        /// Get the camera component of this camera.
        /// </summary>
        /// <returns></returns>
        public Camera GetCamera()
        {
            return fpvCamera;
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
    }
}