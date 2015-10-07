namespace FirstPersonView
{
    /// <summary>
    /// Interface class for all FPV Objects
    /// </summary>
    public interface IFPV_Object
    {
        /// <summary>
        /// Enable First Person Render. OnPreRender()
        /// </summary>
        void EnableFirstPersonViewer();
        /// <summary>
        /// Disable First Person Render. OnPostRender()
        /// </summary>
        void DisableFirstPersonViewer();

        /// <summary>
        /// Set this and all objects inside as First Person Object objects.
        /// </summary>
        void SetAsFirstPersonObject();
        /// <summary>
        /// Remove this and all objects inside as First Person Object objects.
        /// </summary>
        void RemoveAsFirstPersonObject();

        /// <summary>
        /// Is this object a First Person type object.
        /// </summary>
        /// <returns></returns>
        bool IsFirstPersonObject();

        /// <summary>
        /// Set this object as visible from the FPV Camera.
        /// This is set by its children.
        /// </summary>
        void SetVisible();

        /// <summary>
        /// Remove a renderer from the list of renderers of this object.
        /// </summary>
        /// <param name="renderer"></param>
        void RemoveRenderer(IFPV_Renderer renderer);
    }
}
