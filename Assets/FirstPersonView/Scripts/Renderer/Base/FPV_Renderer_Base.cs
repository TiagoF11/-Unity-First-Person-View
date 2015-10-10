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
        /// Is this renderer a first person object.
        /// This is set by the parent FPV_Object
        /// </summary>
        protected bool _isFirstPersonObject;
        /// <summary>
        /// Was this renderer affected by the FirstPersonCamera
        /// </summary>
        protected bool _rendererChanged = false;

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
            _rendererChanged = false;
            _isFirstPersonObject = false;
        }

        /// <summary>
        /// Enable First Person Viewer.
        /// </summary>
        public abstract void EnableFirstPersonViewer();

        /// <summary>
        /// Disable First Person Viewer.
        /// </summary>
        public abstract void DisableFirstPersonViewer();

        /// <summary>
        /// Set this renderer's layer as First Person Object and set the flag isFirstPersonObject to TRUE
        /// </summary>
        public void SetAsFirstPersonObject()
        {
            _isFirstPersonObject = true;
            _render.gameObject.layer = FPV.FIRSTPERSONRENDERLAYER;
            DisableFirstPersonViewer();
        }
        /// <summary>
        /// Remove this renderer's layer from First Person Object to a world object and set the flag isFirstPersonObject to FALSE
        /// </summary>
        public void RemoveAsFirstPersonObject()
        {
            _isFirstPersonObject = false;
            _render.gameObject.layer = _originalLayer;
        }

        // ----- Unity Callbacks -----

        void OnDestroy()
        {
            //This might be costly if this FPV_Object has too many renderers. Should be fine for small number of renderers
            _parent.RemoveRenderer(this);
        }
        
    }
}
