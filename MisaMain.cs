using ABI_RC.Core.UI;
using ABI_RC.Systems.MovementSystem;
using MelonLoader;
using PlayerList.Events;
using ReticleSW;
using RTG;
using System;
using System.Collections;
using System.IO;
using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

namespace Misatyan
{
    public class Misa : MelonMod
    {

        public static Misa Instance { get; private set; }

        public MelonLogger.Instance Logger => Instance.LoggerInstance;

        public override void OnUpdate()
        {
            if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.R))
            {
                if ((CohtmlHud.Instance != null) && (CohtmlHud.Instance.desktopPointer != null))
                    CohtmlHud.Instance.desktopPointer.SetActive(!CohtmlHud.Instance.desktopPointer.activeSelf);
            }
            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.T))
            {
                var TP = GameObject.Find("_PLAYERLOCAL/[CameraRigDesktop]/Camera/LookTarget");
                GameObject.Find("_PLAYERLOCAL").GetComponent<MovementSystem>().TeleportTo(TP.transform.position);
            }

        }
        [Obsolete]
        public override void OnApplicationStart()
        {
            MelonCoroutines.Start(WaitForMenu());
            Instance = this;
        }
        public IEnumerator WaitForMenu()
        {
            while (!GameObject.Find("Cohtml/CohtmlWorldView")) { yield return new WaitForSeconds(1); }
            var reticle = GameObject.Find("_PLAYERLOCAL/[CameraRigDesktop]/Camera/Canvas/Image");
            reticle.GetComponent<Image>().sprite = Swap.Reticle();
            reticle.GetComponent<Image>().material.shader = Shader.Find("Sprites/Default");
            reticle.transform.localScale = new Vector2(1, 1);
        }
    }
}

