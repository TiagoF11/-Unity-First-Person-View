using UnityEngine;

namespace FirstPersonView
{
    public class FPV_Object_Custom : FPV_Object
    {
        /// <summary>
        /// Add a new IFPV_Renderer to the container if the transform contains any.
        /// This Custom class will simply add FPV_Renderer_Custom component to the objects.
        /// </summary>
        /// <param name="trans"></param>
        protected override void AddNewRenderer(Transform trans)
        {
            Renderer render = trans.GetComponent<Renderer>();

            if (render != null) //Add new IFPV_Renderer only if the object contains it.
            {
                AddRenderer(render, trans.gameObject.AddComponent<FPV_Renderer_Custom>());
            }
        }
    }
}
