using UnityEngine;

namespace FirstPersonView
{
    /// <summary>
    /// Static Class for the First Person Viewer Instantiation Methods.
    /// </summary>
    public static class FPV
    {
        public static FPV_WorldCamera worldCamera { get; set; }
        public static FPV_FirstPersonCamera firstPersonCamera { get; set; }
        public static FPV_FinalCamera finalCamera { get; set; }

        /// <summary>
        /// First Person Render Layer. This MUST be set in the Layer's settings.
        /// </summary>
        public static readonly int FIRSTPERSONRENDERLAYER = LayerMask.NameToLayer("FirstPersonView");

        /// <summary>
        /// Convert a First Person View point to World View point.
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static Vector3 FPVPointToWorldPoint(Vector3 point)
        {
            point = firstPersonCamera.GetCamera().WorldToScreenPoint(point); 
            return worldCamera.GetCamera().ScreenToWorldPoint(point);
        }

        /// <summary>
        /// Transform a point and a direction from First Person View to World View
        /// </summary>
        /// <param name="point"></param>
        /// <param name="direction"></param>
        /// <param name="resPoint"></param>
        /// <param name="resDirection"></param>
        public static void FPVToWorld(Vector3 point, Vector3 direction, out Vector3 resPoint, out Vector3 resDirection)
        {
            resPoint = FPVPointToWorldPoint(point);

            Vector3 pointForward = point + direction;
            pointForward = FPVPointToWorldPoint(pointForward);
            resDirection = pointForward - resPoint;
        }

        /// <summary>
        /// Transform a point and a direction based on a Transform from First Person View to World View
        /// </summary>
        /// <param name="trans"></param>
        /// <param name="resPoint"></param>
        /// <param name="resDirection"></param>
        public static void FPVToWorld(Transform trans, out Vector3 resPoint, out Vector3 resDirection)
        {
            FPVToWorld(trans.position, trans.forward, out resPoint, out resDirection);
        }

        /// <summary>
        /// Instantiate a new gameobject and automatically add it to the FPV Container of Generic Type.
        /// </summary>
        /// <param name="original"></param>
        /// <param name="position"></param>
        /// <param name="rotation"></param>
        /// <returns></returns>
        public static GameObject Instantiate(Object original, Vector3 position, Quaternion rotation)
        {
            GameObject result = Object.Instantiate(original, position, rotation) as GameObject;
            result.AddComponent<FPV_Object>();
            return result;
        }

        /// <summary>
        /// Instantiate a new gameobject and automatically add it to the FPV Container of DisableOnly Type.
        /// </summary>
        /// <param name="original"></param>
        /// <param name="position"></param>
        /// <param name="rotation"></param>
        /// <returns></returns>
        public static GameObject InstantiateDisableOnlyFPO(Object original, Vector3 position, Quaternion rotation)
        {
            GameObject result = Object.Instantiate(original, position, rotation) as GameObject;
            result.AddComponent<FPV_Object_DisableOnly>();
            return result;
        }

        /// <summary>
        /// Instantiate a new gameobject and automatically add it to the FPV Container of Generic type.
        /// </summary>
        /// <param name="original"></param>
        /// <returns></returns>
        public static GameObject Instantiate(Object original)
        {
            return Instantiate(original, Vector3.zero, Quaternion.identity);
        }

        /// <summary>
        /// Instantiate a new gameobject and automatically add it to the FPV Container of DisableOnly type.
        /// </summary>
        /// <param name="original"></param>
        /// <returns></returns>
        public static GameObject InstantiateDisableFPO(Object original)
        {
            return InstantiateDisableOnlyFPO(original, Vector3.zero, Quaternion.identity);
        }

    }
}