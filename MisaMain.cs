using MelonLoader;
using System;

namespace Misatyan
{
    public class Misa : MelonMod
    {

        public static Misa Instance { get; private set; }
        public static MainGUI MainGUI = new MainGUI();

        public MelonLogger.Instance Logger => Instance.LoggerInstance;

        public override void OnUpdate()
        {
            //Riticle On|Off by SDraw
            ReticleSwitch.TurnOff();

            //The some sheeeesh that give props to ur hands
            //GrabHold.Grab();

            //Can fly somewhere
            DirectionFly.CanFly();

            MainGUI.Update();
        }

        //Swap shit CVR's riticle to good red point
        [Obsolete]
        public override void OnApplicationStart()
        {
            MelonCoroutines.Start(ReticleSwitch.WaitForMenu());
            //MelonCoroutines.Start(MainGUI.WaitForMenu());
            Instance = this;
        }

        //PlayerList on GUI
        public override void OnGUI()
        {
            PlayerList.List();
        }
    }
}

