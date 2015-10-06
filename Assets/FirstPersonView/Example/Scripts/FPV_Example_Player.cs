using FirstPersonView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace FirstPersonViewer.Example
{
    public class FPV_Example_Player : MonoBehaviour
    {
        public Transform weaponPlacement;

        public GameObject weaponPrefabWithFPV;
        public GameObject weaponPrefabWithoutFPV;

        private FPV_Example_Weapon weapon;

        [Header("Cameras")]
        public Camera worldCamera;
        public FPV_FirstPersonCamera fpvCamera;
        private Camera fpvcam;

        void Start()
        {
            fpvcam = fpvCamera.GetCamera();
        }

        void Update()
        {
            if(Input.GetKeyDown(KeyCode.P))
            {
                CreateWeapon();
            }

            if(Input.GetKeyDown(KeyCode.I))
            {
                SwitchWeapon();
            }

            ChangeFOV();
        }

        private void ChangeFOV()
        {
            //World Camera FOV
            float fOVChange = 0;
            if(Input.GetKey(KeyCode.Comma))
            {
                fOVChange = -Time.deltaTime*10;
            }
            else if(Input.GetKey(KeyCode.Period))
            {
                fOVChange = Time.deltaTime*10;
            }
            worldCamera.fieldOfView = Mathf.Clamp(worldCamera.fieldOfView + fOVChange, 50, 120);

            //First Person Camera FOV
            fOVChange = 0;
            if (Input.GetKey(KeyCode.N))
            {
                fOVChange = -Time.deltaTime*10;
            }
            else if (Input.GetKey(KeyCode.M))
            {
                fOVChange = Time.deltaTime*10;
            }
            fpvcam.fieldOfView = Mathf.Clamp(fpvcam.fieldOfView + fOVChange, 4, 70);
        }
        
        private void CreateWeapon()
        {
            if (weapon != null) return;

            GameObject newWeapon = FPV.Instantiate(weaponPrefabWithFPV);

            weapon = newWeapon.GetComponent<FPV_Example_Weapon>();
            weapon.Setup();
            SetWeaponOnPlayer();
        }

        private void SwitchWeapon()
        {
            if(weapon.IsOnPlayer())
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
