using UnityEngine;

namespace FirstPersonView
{
    /// <summary>
    /// Interface for First Person Viewer Renderers.
    /// </summary>
    public interface IFPV_Renderer
    {
        /// <summary>
        /// Setup the renderer
        /// </summary>
        /// <param name="render"></param>
        void Setup(Renderer render, IFPV_Object parent);

        /// </summary>
        /// 
        /// <summary>
        void EnableFirstPersonViewer();

        /// <summary>
        /// Disable first Person Viewer.
        /// </summary>
        void DisableFirstPersonViewer();

        /// <summary>
        /// Set this renderer as First Person Object
        /// </summary>
        void SetAsFirstPersonObject();

        /// <summary>
        /// Set this renderer as First Person Object
        /// </summary>
        void RemoveAsFirstPersonObject();
    }
}
