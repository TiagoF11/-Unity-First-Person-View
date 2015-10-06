using UnityEngine;

namespace FirstPersonView
{
    public class FPV_Object_DisableOnly : FPV_Object
    {
        /// <summary>
        /// Add a new IFPV_Renderer to the container if the transform contains any.
        /// This DisableOnly class will simply add FPV_Renderer_DisableOnly Components to the objects.
        /// </summary>
        /// <param name="trans"></param>
        protected override void AddNewRenderer(Transform trans)
        {
            Renderer render = trans.GetComponent<Renderer>();

            if (render != null) //Add new IFPV_Renderer only if the object contains it.
            {
                AddRenderer(render, trans.gameObject.AddComponent<FPV_Renderer_DisableOnly>());
            }
        }

        /// <summary>
        /// Add this object to the DisableOnlyFPO container
        /// </summary>
        protected override void AddToContainer()
        {
            FPV_Container.AddDisableOnlyFPO(this);
        }

        /// <summary>
        /// Remove this object from the DisableOnlyFPO container
        /// </summary>
        protected override void OnDestroy()
        {
            FPV_Container.RemoveDisableOnlyFPO(this);
        }
    }
}