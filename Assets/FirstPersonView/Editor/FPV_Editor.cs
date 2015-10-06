using UnityEngine;
using System.Collections;
using UnityEditor;

namespace FirstPersonView.Editor
{
    public class FPV_Editor : MonoBehaviour
    {
        /// <summary>
        /// Create from scratch a FPV Camera in the scene.
        /// </summary>
        [MenuItem("Window/FPV/Camera/Create FPV Camera")]
        private static void CreateFPVCamera()
        {
            //Set Parent Camera
            Camera worldCamera = new GameObject("MainCamera").AddComponent<Camera>();

            worldCamera.gameObject.AddComponent<AudioListener>();
            worldCamera.gameObject.AddComponent<GUILayer>();
            worldCamera.gameObject.AddComponent<FlareLayer>();

            worldCamera.nearClipPlane = 0.1f;
            worldCamera.cullingMask = ~(1 << FPV_Container.FIRSTPERSONRENDERLAYER);
            worldCamera.hdr = true;

            CreateFPVCamera(worldCamera);

            Selection.activeTransform = worldCamera.transform;

            Debug.Log("FPV: Created the FPV Camera!");
        }

        /// <summary>
        /// Use the object the user has currently selected to transform it into a FPV Camera Ready.
        /// </summary>
        [MenuItem("Window/FPV/Camera/Set as FPV Camera")]
        private static void SetAsFPVCamera()
        {
            if (Selection.activeTransform == null)
            {
                Debug.LogWarning("FPV: No Camera Selected.");
                return;
            }

            Camera worldCamera = Selection.activeTransform.GetComponent<Camera>();

            if (worldCamera == null)
            {
                Debug.LogWarningFormat("FPV: Object: '{0}' is not a camera.", worldCamera.name);
                return;
            }

            worldCamera.gameObject.AddComponent<AudioListener>();
            worldCamera.gameObject.AddComponent<GUILayer>();
            worldCamera.gameObject.AddComponent<FlareLayer>();

            worldCamera.nearClipPlane = 0.1f;
            worldCamera.cullingMask = ~(1 << FPV_Container.FIRSTPERSONRENDERLAYER);
            worldCamera.hdr = true;
            CreateFPVCamera(worldCamera);

            Debug.LogFormat("FPV: Set the Camera: '{0}' as FPV ready Camera.", worldCamera.name);
        }

        /// <summary>
        /// Create the FPV Camera with all properties set.
        /// </summary>
        /// <param name="parentCamera"></param>
        /// <returns></returns>
        private static Camera CreateFPVCamera(Camera parentCamera)
        {
            //Instantiate FPV Camera
            Camera fpvCamera = new GameObject("FPV_Camera").AddComponent<Camera>();

            //Set parent and local transform
            fpvCamera.transform.SetParent(parentCamera.transform);
            fpvCamera.transform.localPosition = Vector3.zero;
            fpvCamera.transform.localRotation = Quaternion.identity;

            fpvCamera.gameObject.AddComponent<AudioListener>();
            fpvCamera.gameObject.AddComponent<FPV_FirstPersonCamera>();

            //Set name and layer
            fpvCamera.tag = "FirstPersonCamera";
            fpvCamera.gameObject.layer = FPV_Container.FIRSTPERSONRENDERLAYER;

            //Set camera properties
            fpvCamera.nearClipPlane = 0.01f;
            fpvCamera.farClipPlane = 2;
            fpvCamera.depth = parentCamera.depth + 1;
            fpvCamera.clearFlags = CameraClearFlags.Depth;
            fpvCamera.cullingMask = ~ ( 1 << FPV_Container.FIRSTPERSONRENDERLAYER );
            fpvCamera.hdr = parentCamera.hdr;
            fpvCamera.renderingPath = parentCamera.renderingPath;


            //Instantiate Image Effects Camera
            Camera fpv_imageEffects = new GameObject("FPV_ImageEffects").AddComponent<Camera>();

            //Set parent and local transform
            fpv_imageEffects.transform.SetParent(fpvCamera.transform);
            fpv_imageEffects.transform.localPosition = Vector3.zero;
            fpv_imageEffects.transform.localRotation = Quaternion.identity;

            fpv_imageEffects.gameObject.AddComponent<FPV_ImageEffects>();
            fpv_imageEffects.gameObject.GetComponent<FPV_ImageEffects>().FPVCamera = fpvCamera;
            fpv_imageEffects.gameObject.GetComponent<FPV_ImageEffects>().WorldCamera = parentCamera;


            //Set name and layer
            fpv_imageEffects.tag = "FirstPersonCamera";
            fpv_imageEffects.gameObject.layer = FPV_Container.FIRSTPERSONRENDERLAYER;

            //Set camera properties
            fpv_imageEffects.nearClipPlane = 1f;
            fpv_imageEffects.farClipPlane = 2;
            fpv_imageEffects.depth = fpv_imageEffects.depth + 1;
            fpv_imageEffects.clearFlags = CameraClearFlags.Nothing;
            fpv_imageEffects.cullingMask = 0;
            fpv_imageEffects.hdr = parentCamera.hdr;
            fpv_imageEffects.renderingPath = parentCamera.renderingPath;

            return fpvCamera;
        }


        /// <summary>
        /// Set the object currently selected as a generic FPV Object.
        /// </summary>
        [MenuItem("Window/FPV/Object/Set Objects as FPO (Shadow)")]
        private static void SetObjectAsFPO()
        {
            if (Selection.activeGameObject == null)
            {
                Debug.LogWarning("FPV: No Object Selected.");
                return;
            }

            Selection.activeGameObject.AddComponent<FPV_Object>();

            Debug.LogFormat("FPV: Set the Object: '{0}' as FPV Object (Shadow)", Selection.activeGameObject.name);
        }

        /// <summary>
        /// Set the object currently selected as a FPV Object of DisableOnly type
        /// </summary>
        [MenuItem("Window/FPV/Object/Set Objects as FPO (No Shadow. Disable Only)")]
        private static void SetObjectAsFPONoShadow()
        {
            if (Selection.activeGameObject == null)
            {
                Debug.LogWarning("FPV: No Object Selected.");
                return;
            }

            Selection.activeGameObject.AddComponent<FPV_Object_DisableOnly>();

            Debug.LogFormat("FPV: Set the Object: '{0}' as FPV Object (No Shadow/Disable Only)", Selection.activeGameObject.name);
        }


    }
}
