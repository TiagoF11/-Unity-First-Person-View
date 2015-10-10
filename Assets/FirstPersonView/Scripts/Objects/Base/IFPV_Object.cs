namespace FirstPersonView
{
    /// <summary>
    /// Interface class for all FPV Objects
    /// </summary>
    public interface IFPV_Object
    {

        /// <summary>
        /// Set this and all objects inside as First Person Object objects.
        /// </summary>
        void EnableAsFirstPersonObject();
        /// <summary>
        /// Remove this and all objects inside as First Person Object objects.
        /// </summary>
        void DisableAsFirstPersonObject();

        /// <summary>
        /// Is this object a First Person type object.
        /// </summary>
        /// <returns></returns>
        bool IsFirstPersonObject();

        /// <summary>
        /// Set that a renderer in this object has changed.
        /// This is used for FPV_Object_Disable objects in Update function.
        /// </summary>
        void SetChanged();

        /// <summary>
        /// Remove a renderer from the list of renderers of this object.
        /// </summary>
        /// <param name="renderer"></param>
        void RemoveRenderer(IFPV_Renderer renderer);
    }
}
