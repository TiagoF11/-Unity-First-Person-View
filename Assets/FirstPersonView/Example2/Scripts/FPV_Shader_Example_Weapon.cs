using UnityEngine;
using System.Collections;

namespace FirstPersonView
{
    public class FPV_Shader_Example_Weapon : MonoBehaviour
    {
        public Rigidbody wRigidbody;
        public Collider wCollider;

        public IFirstPersonShader_Object fpvObject { get; private set; }

        private bool isOnPlayer;


        public void Setup()
        {
            fpvObject = GetComponent<IFirstPersonShader_Object>();

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

            fpvObject.EnableFirstPersonView();
        }

        public void SetWeaponOnWorld()
        {
            transform.parent = null;

            wRigidbody.isKinematic = false;
            wCollider.enabled = true;

            isOnPlayer = false;

            fpvObject.DisableFirstPersonView();
        }

        public bool IsOnPlayer()
        {
            return isOnPlayer;
        }

    }
}