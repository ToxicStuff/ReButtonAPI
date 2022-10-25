using MelonLoader;
using ReButtonAPI.QuickMenu;
using ReButtonAPI.Wings;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnhollowerRuntimeLib;
using UnityEngine;

[assembly: MelonInfo(typeof(ReButtonAPI.Main), "ReButtonAPI", "1.0.0.", "Requi (Ported XoX-Toxic)")]
[assembly: MelonGame("VRChat", "VRChat")]

namespace ReButtonAPI
{
    //This ButtonAPI isnt Standalone, its just for HowTo
    public class Main : MelonMod
    {
        public static GameObject UserInterface; //New UI is "Obfuscate" thats why we need first to Grab the GameObject
        public override void OnApplicationStart()
        {
            ClassInjector.RHelperRegisterTypeInIl2Cpp<EnableDisableListener>();
            MelonCoroutines.Start(WaitForUI());
            IEnumerator WaitForUI()
            {
                while (ReferenceEquals(VRCUiManager.field_Private_Static_VRCUiManager_0, null)) yield return null; // wait till VRCUIManger isnt null
                foreach (var GameObjects in Resources.FindObjectsOfTypeAll<GameObject>())
                {
                    if (GameObjects.name.Contains("UserInterface"))
                    {
                        UserInterface = GameObjects; 
                    }
                }

                while (ReferenceEquals(QuickMenuEx.Instance, null)) yield return null;
                // Code lol
            }
        }
    }
}
