using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace FirstPersonView
{
    public class FPV_Object : MonoBehaviour, IFPV_Object
    {
        /// <summary>
        /// Is this object enabled.
        /// </summary>
        protected bool _isEnabled;

        /// <summary>
        /// Is this object a First Person type object.
        /// </summary>
        protected bool _isNotFirstPersonObject;

        /// <summary>
        /// Container of all renderers inside this object.
        /// </summary>
        protected List<IFPV_Renderer> _renderers;

        /// <summary>
        /// Was EnableFirstPersonRender successfull.
        /// </summary>
        protected bool _viewChanged;
        
        /// <summary>
        /// Stores if the object is visible. this is set by the children
        /// </summary>
        protected bool _isVisible;

        /// <summary>
        /// This variable stores if this object can be enabled for First Person View.
        /// This variable is used to cut down the amount of checks the method needs to do (1 check vs 3 checks for every object).
        /// </summary>
        protected bool _canEnableFPV;


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
            _isEnabled = gameObject.activeInHierarchy;
            _isNotFirstPersonObject = true;
            AddToContainer();
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

        /// <summary>
        /// Add this object to the container.
        /// </summary>
        protected virtual void AddToContainer()
        {
            FPV_Container.AddGenericFPO(this);
        }


        // ----- RENDER -----

        /// <summary>
        /// Enable First Person Render.
        /// Since this object is the parent, then all objects must share the same state as this (is FPV or not).
        /// Better for performance, since we don't need to ask every renderer if it is in FPV mode.
        /// </summary>
        public virtual void EnableFirstPersonViewer()
        {
            if (_canEnableFPV)
            {
                _viewChanged = true;
                for (int i = 0; i < _renderers.Count; i++)
                {
                    _renderers[i].EnableFirstPersonViewer();
                }
            }
        }

        /// <summary>
        /// Disable First Person Render
        /// </summary>
        public virtual void DisableFirstPersonViewer()
        {
            if (_viewChanged)
            {
                _viewChanged = false;
                for (int i = 0; i < _renderers.Count; i++)
                {
                    _renderers[i].DisableFirstPersonViewer();
                }
                _isVisible = false;
            }
        }
         
         
        // ----- LAYERS -----

        /// <summary>
        /// Set this and all objects inside as First Person Render objects.
        /// </summary>
        public void SetAsFirstPersonObject()
        {
            _isNotFirstPersonObject = false;
            SetFPVEnabled();
            for (int i = 0; i < _renderers.Count; i++)
            {
                _renderers[i].SetAsFirstPersonObject();
            }
        }

        /// <summary>
        /// Remove this and all objects inside from First Person Render objects.
        /// </summary>
        public void RemoveAsFirstPersonObject()
        {
            _isNotFirstPersonObject = true;
            SetFPVEnabled();
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
            return !_isNotFirstPersonObject;
        }

        /// <summary>
        /// Set this object as visible from the FPV Camera.
        /// This is set by its children.
        /// </summary>
        public void SetVisible()
        {
            if(!_isVisible)
            {
                _isVisible = true;
                SetFPVEnabled();
            }
        }

        /// <summary>
        /// Set if this object is FPV Enabled.
        /// </summary>
        private void SetFPVEnabled()
        {
            _canEnableFPV = _isVisible && _isEnabled && _isNotFirstPersonObject;
        }

        // ----- Unity Callbacks -----

        void OnEnable()
        {
            _isEnabled = true;
            SetFPVEnabled();
        }

        void OnDisable()
        {
            _isEnabled = false;
            SetFPVEnabled(); 
        }

        /// <summary>
        /// Always remove the object if it is destroyed
        /// </summary>
        protected virtual void OnDestroy()
        {
            FPV_Container.RemoveGenericFPO(this);
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