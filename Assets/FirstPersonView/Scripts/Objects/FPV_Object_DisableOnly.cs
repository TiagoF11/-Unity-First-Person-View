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
        /// check if a renderer inside was changed by the FPV. 
        /// If it was, it means that the renderers were disabled for the First Person View, so in this Update, 
        /// the method will re-enable the renderers so they are active when the World Camera is going to render.
        /// </summary>
        void Update()
        {
            if(_rendererChanged)
            {
                _rendererChanged = false;
                //On beggining of the frame, re-enable all objects that were disabled for the First Person View.
                for (int i = 0; i < _renderers.Count; i++)
                {
                    _renderers[i].DisableFirstPersonViewer();
                }
            }
        }
        
    }
}