using ABI_RC.Systems.MovementSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Misatyan
{
    internal class DirectionFly
    {
        static bool FlySomewhere = false;
        public static void CanFly()
        {
            if (Input.GetKeyDown(KeyCode.Keypad5))
                FlySomewhere = !FlySomewhere;

            if (FlySomewhere)
            {
                var PL = GameObject.Find("_PLAYERLOCAL");
                PL.GetComponent<MovementSystem>().canFly = true;
            }
        }
    }
}
