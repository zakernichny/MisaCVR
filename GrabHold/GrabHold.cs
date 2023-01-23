using ABI.CCK.Components;
using ABI_RC.Core.InteractionSystem;
using System.Reflection;
using static ABI.CCK.Components.CVRPickupObject;
using UnityEngine;

namespace Misatyan
{
    internal class GrabHold
    {
        static ControllerRay rayRight;
        static CVRPickupObject pk;
        static bool grabHand = false;
        static GripType GribZero;
        public static void Grab()
        {
            
            try
            {
                if (Input.GetKey(KeyCode.Mouse4))
                    grabHand = !grabHand;
                if (grabHand)
                {
                    if (GameObject.Find("_PLAYERLOCAL/[CameraRigDesktop]/Camera"))
                        if (GameObject.Find("_PLAYERLOCAL/[CameraRigDesktop]/Camera").GetComponent<ControllerRay>())
                            if (GameObject.Find("_PLAYERLOCAL/[CameraRigDesktop]/Camera").GetComponents<ControllerRay>().Length <= 1)
                            {
                                var ray = GameObject.Find("_PLAYERLOCAL/[CameraRigDesktop]/Camera").GetComponent<ControllerRay>();
                                ray.attachmentPoint = GameObject.Find("_PLAYERLOCAL/[PlayerAvatar]/_CVRAvatar(Clone)").GetComponent<Animator>().GetBoneTransform(HumanBodyBones.RightHand).gameObject;
                                var gm = GameObject.Find("_PLAYERLOCAL/[CameraRigDesktop]/Camera");
                                rayRight = gm.AddComponent<ControllerRay>();
                                rayRight.highlightMaterial = ray.highlightMaterial;
                                rayRight.holderRoot = ray.holderRoot;
                            }
                            else
                            {
                                var ray = GameObject.Find("_PLAYERLOCAL/[CameraRigDesktop]/Camera").GetComponent<ControllerRay>();
                                ray.attachmentPoint = GameObject.Find("_PLAYERLOCAL/[PlayerAvatar]/_CVRAvatar(Clone)").GetComponent<Animator>().GetBoneTransform(HumanBodyBones.RightHand).gameObject;
                                GameObject.Find("_PLAYERLOCAL/[CameraRigDesktop]/Camera").GetComponents<ControllerRay>()[1].attachmentPoint = GameObject.Find("_PLAYERLOCAL/[PlayerAvatar]/_CVRAvatar(Clone)").GetComponent<Animator>().GetBoneTransform(HumanBodyBones.LeftHand).gameObject;

                            }


                    if (Input.GetKeyDown(KeyCode.Mouse3))
                    {
                        Ray ray2 = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
                        RaycastHit raycastHit2;
                        if (Physics.Raycast(ray2, out raycastHit2))
                        {
                            MethodInfo[] dynMethods = rayRight.GetType().GetMethods(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                            MethodInfo grab = null;
                            foreach (var item in dynMethods)
                                if (item.Name.Contains("GrabObject"))
                                    grab = item;
                            pk = raycastHit2.transform.gameObject.GetComponent<CVRPickupObject>();
                            GribZero = pk.gripType;
                            pk.gripType = GripType.Origin;
                            grab.Invoke(rayRight, new object[] { pk, new Vector3(0, 0, 0) });
                        }
                    }
                    if (Input.GetKeyUp(KeyCode.Mouse3))
                    {
                        pk.Drop();
                        pk.gripType = GribZero;
                    }

                }
                else
                {
                    var ray = GameObject.Find("_PLAYERLOCAL/[CameraRigDesktop]/Camera").GetComponent<ControllerRay>();
                    ray.attachmentPoint = GameObject.Find("_PLAYERLOCAL/[CameraRigDesktop]/Camera/AttachmentPoint");
                }
            }
            catch { }
        }
    }
}
