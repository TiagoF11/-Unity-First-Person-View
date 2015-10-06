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

        /// <summary>
        /// Enable First Person Viewer
        /// </summary>
        void EnableFirstPersonViewer();
        /// <summary>
        /// Disable First Person Viewer
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

        /// <summary>
        /// Is this renderer visible.
        /// </summary>
        /// <returns></returns>
        bool IsVisible();
    }
}
