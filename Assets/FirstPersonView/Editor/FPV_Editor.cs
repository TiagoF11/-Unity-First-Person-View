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
            GameObject worldCam = new GameObject("MainCamera");
            
            Undo.RegisterCreatedObjectUndo(worldCam, "Created World Camera");

            worldCam.AddComponent<Camera>();

            Camera worldCamera = worldCam.GetComponent<Camera>();

            worldCamera.gameObject.AddComponent<AudioListener>();
            worldCamera.gameObject.AddComponent<GUILayer>();
            worldCamera.gameObject.AddComponent<FlareLayer>();

            Undo.AddComponent<FPV_WorldCamera>(worldCamera.gameObject);

            Undo.RecordObject(worldCamera, "Near Clip Plane change");
            worldCamera.nearClipPlane = 0.1f;

            Undo.RecordObject(worldCamera, "Modify culling mask");
            worldCamera.cullingMask = ~(1 << FPV.FIRSTPERSONRENDERLAYER);

            Undo.RecordObject(worldCamera, "set HDR");
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

            Undo.AddComponent<AudioListener>(worldCamera.gameObject);
            Undo.AddComponent<GUILayer>(worldCamera.gameObject);
            Undo.AddComponent<FlareLayer>(worldCamera.gameObject);

            Undo.AddComponent<FPV_WorldCamera>(worldCamera.gameObject);
            /*
            worldCamera.gameObject.AddComponent<AudioListener>();
            worldCamera.gameObject.AddComponent<GUILayer>();
            worldCamera.gameObject.AddComponent<FlareLayer>();
            */
            Undo.RecordObject(worldCamera, "Modify near clip plane");
            worldCamera.nearClipPlane = 0.1f;

            Undo.RecordObject(worldCamera, "Modify culling mask");
            worldCamera.cullingMask = ~(1 << FPV.FIRSTPERSONRENDERLAYER);

            Undo.RecordObject(worldCamera, "set HDR");
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
            GameObject fpvcam = new GameObject("FPV_Camera");

            Undo.RegisterCreatedObjectUndo(fpvcam, "Created fpv Camera");

            fpvcam.AddComponent<Camera>();

            Camera fpvCamera = fpvcam.GetComponent<Camera>();

            //Set parent and local transform
            Undo.SetTransformParent(fpvCamera.transform, parentCamera.transform, "new parent set");

            Undo.RecordObject(fpvCamera, "Change local position to Zero");
            fpvCamera.transform.localPosition = Vector3.zero;
            Undo.RecordObject(fpvCamera, "Change local rotation to identity");
            fpvCamera.transform.localRotation = Quaternion.identity;

            Undo.AddComponent<AudioListener>(fpvCamera.gameObject);
            Undo.AddComponent<FPV_FirstPersonCamera>(fpvCamera.gameObject);

            //Set name and layer
            Undo.RecordObject(fpvCamera, "Set Tag");
            fpvCamera.tag = "FirstPersonCamera";
            Undo.RecordObject(fpvCamera, "Set Layer");
            fpvCamera.gameObject.layer = FPV.FIRSTPERSONRENDERLAYER;

            //Set camera properties
            Undo.RecordObject(fpvCamera, "Set near clip plane");
            fpvCamera.nearClipPlane = 0.01f;
            Undo.RecordObject(fpvCamera, "set far clip plane");
            fpvCamera.farClipPlane = 2;
            Undo.RecordObject(fpvCamera, "set depth");
            fpvCamera.depth = parentCamera.depth + 1;
            Undo.RecordObject(fpvCamera, "set clear flags");
            fpvCamera.clearFlags = CameraClearFlags.Depth;
            Undo.RecordObject(fpvCamera, "set hdr");
            fpvCamera.hdr = parentCamera.hdr;
            Undo.RecordObject(fpvCamera, "set rendering path");
            fpvCamera.renderingPath = parentCamera.renderingPath;


            //Instantiate Image Effects Camera
            GameObject fpv_imageEff = new GameObject("FPV_FinalCamera");

            Undo.RegisterCreatedObjectUndo(fpv_imageEff, "Created image effects Camera");

            Undo.AddComponent<Camera>(fpv_imageEff.gameObject);

            Camera fpv_imageEffects = fpv_imageEff.GetComponent<Camera>();

            //Set parent and local transform
            Undo.SetTransformParent(fpv_imageEffects.transform, fpvCamera.transform, "new parent set");
            Undo.RecordObject(fpvCamera, "Change local position to Zero");
            fpv_imageEffects.transform.localPosition = Vector3.zero;
            Undo.RecordObject(fpvCamera, "Change local rotation to identity");
            fpv_imageEffects.transform.localRotation = Quaternion.identity;


            Undo.AddComponent<FPV_FinalCamera>(fpv_imageEffects.gameObject);


            //Set name and layer
            Undo.RecordObject(fpv_imageEffects, "set hdr");
            fpv_imageEffects.tag = "FirstPersonCamera";
            Undo.RecordObject(fpv_imageEffects, "set hdr");
            fpv_imageEffects.gameObject.layer = FPV.FIRSTPERSONRENDERLAYER;

            //Set camera properties
            Undo.RecordObject(fpv_imageEffects, "set near clip plane");
            fpv_imageEffects.nearClipPlane = 1f;
            Undo.RecordObject(fpv_imageEffects, "set far clip plane");
            fpv_imageEffects.farClipPlane = 2;
            Undo.RecordObject(fpv_imageEffects, "set septh");
            fpv_imageEffects.depth = fpv_imageEffects.depth + 1;
            Undo.RecordObject(fpv_imageEffects, "set clear flags");
            fpv_imageEffects.clearFlags = CameraClearFlags.Nothing;
            Undo.RecordObject(fpv_imageEffects, "set culling mask");
            fpv_imageEffects.cullingMask = 0;
            Undo.RecordObject(fpv_imageEffects, "set hdr");
            fpv_imageEffects.hdr = parentCamera.hdr;
            Undo.RecordObject(fpv_imageEffects, "set rendering path");
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

            Undo.AddComponent<FPV_Object>(Selection.activeGameObject);

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

            Undo.AddComponent<FPV_Object_DisableOnly>(Selection.activeGameObject);

            Debug.LogFormat("FPV: Set the Object: '{0}' as FPV Object (No Shadow/Disable Only)", Selection.activeGameObject.name);
        }


    }
}
