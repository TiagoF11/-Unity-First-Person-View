using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace FirstPersonView
{
    public class FPV_Object : MonoBehaviour, IFPV_Object
    {
        /// <summary>
        /// Is this object a First Person type object.
        /// </summary>
        protected bool _isFirstPersonObject;

        /// <summary>
        /// Container of all renderers inside this object.
        /// </summary>
        protected List<IFPV_Renderer> _renderers;

        /// <summary>
        /// Checks if a renderer inside this object has been affected by the First Person View
        /// </summary>
        protected bool _rendererChanged;


        // ----- Public Variables -----
        /// <summary>
        /// Should this FPV_Object render shadows on the world camera.
        /// </summary>
        public bool worldShadowsWhileInFPV;

        void Awake()
        {
            Setup();
        }

        /// <summary>
        /// Setup method for the object.
        /// </summary>
        protected virtual void Setup()
        {
            _isFirstPersonObject = false;
            SetRenderers();
        }

        /// <summary>
        /// Set the renderers inside this Object
        /// </summary>
        /// <param name="obj"></param>
        protected virtual void SetRenderers()
        {
            _renderers = new List<IFPV_Renderer>();
            SetRenderersRecursively(transform);
        }

        /// <summary>
        /// Add IFPV_Renderer recursively.
        /// Automatically creates the different types of rendering objects based on their shadow casting mode.
        /// </summary>
        /// <param name="trans"></param>
        protected void SetRenderersRecursively(Transform trans)
        {
            AddNewRenderer(trans);

            //Continue for the rest of the children
            foreach (Transform child in trans)
            {
                if (child.GetComponent<IFPV_Object>() != null) continue;

                //Continue recursively
                SetRenderersRecursively(child);
            }
        }

        /// <summary>
        /// Add a new IFPV_Renderer to the container if the transform contains any.
        /// </summary>
        /// <param name="renderer"></param>
        protected virtual void AddNewRenderer(Transform trans)
        {
            Renderer render = trans.GetComponent<Renderer>();

            if (render != null) //Add new IFPV_Renderer only if the object contains it.
            {
                switch (render.shadowCastingMode)
                {
                    case ShadowCastingMode.On:
                        AddRenderer(render, trans.gameObject.AddComponent<FPV_Renderer>());
                        break;
                    case ShadowCastingMode.Off:
                        AddRenderer(render, trans.gameObject.AddComponent<FPV_Renderer>());
                        //AddRenderer(render, trans.gameObject.AddComponent<FPV_Renderer_DisableOnly>());
                        break;
                    case ShadowCastingMode.TwoSided:
                        AddRenderer(render, trans.gameObject.AddComponent<FPV_Renderer_Custom>());
                        break;
                }
            }
        }

        /// <summary>
        /// Add the renderer to the container and Setup the renderer.
        /// </summary>
        /// <param name="render"></param>
        /// <param name="renderer"></param>
        protected void AddRenderer(Renderer render, IFPV_Renderer renderer)
        {
            renderer.Setup(render, this);
            _renderers.Add(renderer);
        }
         
        // ----- LAYERS -----

        /// <summary>
        /// Set this and all objects inside as First Person Render objects.
        /// </summary>
        public void EnableAsFirstPersonObject()
        {
            _isFirstPersonObject = true;
            for (int i = 0; i < _renderers.Count; i++)
            {
                _renderers[i].SetAsFirstPersonObject();
            }
        }

        /// <summary>
        /// Remove this and all objects inside from First Person Render objects.
        /// </summary>
        public void DisableAsFirstPersonObject()
        {
            _isFirstPersonObject = false;
            for (int i = 0; i < _renderers.Count; i++)
            {
                _renderers[i].RemoveAsFirstPersonObject();
            }
        }

        /// <summary>
        /// Is this object a First Person type object.
        /// </summary>
        /// <returns></returns>
        public bool IsFirstPersonObject()
        {
            return _isFirstPersonObject;
        }

        /// <summary>
        /// Set that a renderer in this object has changed.
        /// This is used for FPV_Object_Disable objects in Update function.
        /// </summary>
        public virtual void SetChanged()
        {
            _rendererChanged = true;
        }

        /// <summary>
        /// Remove a renderer from the list of renderers of this object.
        /// </summary>
        /// <param name="renderer"></param>
        public void RemoveRenderer(IFPV_Renderer renderer)
        {
            _renderers.Remove(renderer);
        }
        
    }
}