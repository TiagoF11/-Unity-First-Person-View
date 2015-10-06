using UnityEngine;
using UnityEngine.Rendering;

namespace FirstPersonView
{
    /// <summary>
    /// Abstract class for the FPV Renderers
    /// </summary>
    public abstract class FPV_Renderer_Base : MonoBehaviour, IFPV_Renderer
    {
        /// <summary>
        /// This is used to check if the FPV Camera is the one currently rendering.
        /// Much better for performance than calling Camera.Equals(Camera) for every single Renderer.
        /// </summary>
        public static bool isFPVCameraRendering { get; set; }
        /// <summary>
        /// The FPV Object that this renderer is part of
        /// </summary>
        protected IFPV_Object _parent;
        /// <summary>
        /// Original Layer of this renderer. Used to change back to world object.
        /// </summary>
        protected int _originalLayer;
        /// <summary>
        /// The renderer of this object
        /// </summary>
        protected Renderer _render;
        /// <summary>
        /// Store if this object is visible
        /// </summary>
        protected bool isVisible;

        /// <summary>
        /// Setup method for this class
        /// </summary>
        /// <param name="render"></param>
        /// <param name="parent"></param>
        public virtual void Setup(Renderer render, IFPV_Object parent)
        {
            _parent = parent;
            _render = render;
            _originalLayer = render.gameObject.layer;
            isVisible = true;
        }

        /// <summary>
        /// Enable First Person Viewer
        /// </summary>
        public abstract void EnableFirstPersonViewer();
        /// <summary>
        /// Disable First Person Viewer
        /// </summary>
        public abstract void DisableFirstPersonViewer();

        /// <summary>
        /// Set this renderer's layer as First Person Object
        /// </summary>
        public void SetAsFirstPersonObject()
        {
            _render.gameObject.layer = FPV_Container.FIRSTPERSONRENDERLAYER;
        }
        /// <summary>
        /// Remove this renderer's layer from First Person Object to a world object.
        /// </summary>
        public void RemoveAsFirstPersonObject()
        {
            _render.gameObject.layer = _originalLayer;
        }
        /// <summary>
        /// Is this object visible
        /// </summary>
        /// <returns></returns>
        public bool IsVisible()
        {
            return isVisible;
        }

        // ----- Unity Callbacks -----

        /// <summary>
        /// Called when a camera is going to render this object.
        /// This reduces the amount of work done for the FPV Camera, since only objects inside its frustum will be called (or casts shadows inside the camera's frustum)
        /// </summary>
        void OnWillRenderObject()
        {
            //Check if the actual camera rendering is the FPV Camera
            if(isFPVCameraRendering)
            {
                //Set the variable as visible
                isVisible = true;
                //Tell the parent object that it will need to render renderers.
                _parent.SetVisible();
            }
        }

    }
}
