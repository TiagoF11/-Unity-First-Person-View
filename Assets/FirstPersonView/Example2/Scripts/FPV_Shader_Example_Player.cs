using UnityEngine;
using System.Collections;

namespace FirstPersonView
{
    public class FPV_Shader_Example_Player : MonoBehaviour
    {
        public Transform weaponPlacement;

        public GameObject weaponPrefabWithFPV;
        public GameObject weaponPrefabWithoutFPV;

        private FPV_Shader_Example_Weapon weapon;

        [Header("Cameras")]
        public Camera worldCamera;
        public Camera fpvCamera;

        void Start()
        {
            CreateWeapon();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                SwitchWeapon();
            }

            ChangeFOV();
        }

        private void ChangeFOV()
        {
            //World Camera FOV
            float fOVChange = 0;
            if (Input.GetKey(KeyCode.Comma))
            {
                fOVChange = -Time.deltaTime * 10;
            }
            else if (Input.GetKey(KeyCode.Period))
            {
                fOVChange = Time.deltaTime * 10;
            }
            worldCamera.fieldOfView = Mathf.Clamp(worldCamera.fieldOfView + fOVChange, 50, 120);

            //First Person Camera FOV
            fOVChange = 0;
            if (Input.GetKey(KeyCode.N))
            {
                fOVChange = -Time.deltaTime * 10;
            }
            else if (Input.GetKey(KeyCode.M))
            {
                fOVChange = Time.deltaTime * 10;
            }
            fpvCamera.fieldOfView = Mathf.Clamp(fpvCamera.fieldOfView + fOVChange, 4, 70);
        }

        private void CreateWeapon()
        {
            if (weapon != null) return;

            GameObject newWeapon = FirstPersonShader.Instantiate(weaponPrefabWithFPV);

            weapon = newWeapon.GetComponent<FPV_Shader_Example_Weapon>();
            weapon.Setup();
            SetWeaponOnPlayer();
        }

        private void SwitchWeapon()
        {
            if (weapon.IsOnPlayer())
            {
                SetWeaponOnWorld();
            }
            else
            {
                SetWeaponOnPlayer();
            }
        }

        private void SetWeaponOnPlayer()
        {
            weapon.SetWeaponOnPlayer(weaponPlacement);
        }

        private void SetWeaponOnWorld()
        {
            weapon.SetWeaponOnWorld();
        }
    }
}