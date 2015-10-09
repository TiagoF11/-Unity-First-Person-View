using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace FirstPersonView
{
    public abstract class FPV_Camera : MonoBehaviour, IFPV_Camera
    {
        protected Camera _camera;

        /// <summary>
        /// Get and Set the camera component of this object.
        /// </summary>
        protected void SetCamera()
        {
            _camera = GetComponent<Camera>();
        }

        /// <summary>
        /// Manualy update the static camera variable of this component.
        /// </summary>
        public abstract void UpdateStaticCamera();

        /// <summary>
        /// Get the camera component of this camera.
        /// </summary>
        /// <returns></returns>
        public Camera GetCamera()
        {
            return _camera;
        }
    }
}
