using UnityEngine;
using System.Collections;
using FirstPersonView;

namespace FirstPersonViewer.Example
{
    public class FPV_Example_Weapon : MonoBehaviour
    {
        public Rigidbody wRigidbody;
        public Collider wCollider;

        public IFPV_Object fpvObject { get; private set; }

        private bool isOnPlayer;


        public void Setup()
        {
            fpvObject = GetComponent<IFPV_Object>();

            isOnPlayer = false;
        }
        
        public void SetWeaponOnPlayer(Transform player)
        {
            transform.SetParent(player);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;

            wRigidbody.isKinematic = true;
            wCollider.enabled = false;

            isOnPlayer = true;

            fpvObject.SetAsFirstPersonObject();
        }

        public void SetWeaponOnWorld()
        {
            transform.parent = null;

            wRigidbody.isKinematic = false;
            wCollider.enabled = true;

            isOnPlayer = false;

            fpvObject.RemoveAsFirstPersonObject();
        }

        public bool IsOnPlayer()
        {
            return isOnPlayer;
        }

    }
}
