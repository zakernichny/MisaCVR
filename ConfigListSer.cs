using Newtonsoft.Json;
using System.IO;
public class ConfiglistSer
{
    static string settingsPath = "UserData/Configlist";
    public static Configlist Configlist = new Configlist();
    public static void SerializeConfig(bool e = true)
    {
        var Se = JsonConvert.SerializeObject(Configlist);
        File.WriteAllText(settingsPath, Se);

    }
    public static void DeserializeConfig()
    {
        if (File.Exists(settingsPath))
        {
            var tx = File.ReadAllText(settingsPath);
            Configlist = JsonConvert.DeserializeObject<Configlist>(tx);
        }
    }
}
public class Configlist
{
    public float FOV = 70;
    public float GUISS = 1;
    public bool OnGUIDesF = false;
    public bool OnGUIDes = false;
    public bool MenuplayersList = false;
    public bool MenuDebug = false;
    public bool СapsuleEsp = false;
    public bool Esp2d = false;
    public bool Esp3d = false;
    public bool Lines = false;
    public bool boow = false;
    public bool lastlocation = false;
    public bool InfiniteJump = false;
    public bool PhotonProt = true;
    public bool ArrList = false;
    public int pin = 0;
    public bool nameplateOutlineModeLocal = false;
    public bool OldnameplateOutlineModeLocal = false;
    public bool OldNewnameplateOutlineModeLocal = false;
    public bool QuestSpoof = false;
    public bool AntiBlock = true;
    // public bool InstanceHistoryDescendingEnabled = false;
    public bool HudMessage = false;
    public bool Offline = false;
}

