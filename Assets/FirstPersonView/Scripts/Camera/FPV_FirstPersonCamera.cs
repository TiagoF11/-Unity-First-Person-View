using UnityEngine;

namespace FirstPersonView
{
    public class FPV_FirstPersonCamera : FPV_Camera
    {
        void Awake()
        {
            SetCamera();
            UpdateStaticCamera();
        }

        /// <summary>
        /// Manualy update the static first person view camera variable.
        /// </summary>
        public override void UpdateStaticCamera()
        {
            FPV.firstPersonCamera = this;
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