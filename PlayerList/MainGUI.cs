using ABI_RC.Core.Savior;
using Misatyan;
using ReticleSW;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class MainGUI : MonoBehaviour
{

    public PlayerListGUI PlayerList;
    public DebugGUI debug;
    public TextForGUI textForGUIFun;
    public GameObject Scale;
    private static int colint = 1;
    int textweq;
    int textweq2;
    string textwe;

    
    GameObject MainGm;
    public MainGUI() { }
    public void Start()
    {
        MainGm = new GameObject("MainGUIGM");
        Scale = new GameObject("Scale");
        var Canvas = new CanvarForGUI().CreateCanvas("MainGUI", RenderMode.ScreenSpaceOverlay);
        debug = new DebugGUI().CreateDebug("Debug", Canvas);
        PlayerList = new PlayerListGUI().CreatePlayerList("PlayerList", Canvas);
        Canvas.GameObjectCanvas.transform.parent = MainGm.transform;
        Scale.AddComponent<RectTransform>();
        Scale.GetComponent<RectTransform>().pivot = new Vector2(0, 1);
        Scale.GetComponent<RectTransform>().anchorMax = new Vector2(0, 1);
        Scale.GetComponent<RectTransform>().anchorMin = new Vector2(0, 1);
        Scale.transform.parent = Canvas.GameObjectCanvas.transform;
        Scale.transform.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);

        PlayerList.ListMain.transform.parent = Scale.transform;

        GameObject.DontDestroyOnLoad(MainGm);
        //if (ConfiglistSer.Configlist.OnGUIDes)
        //    NyupMain.mainGUI.debug.EnableDebug();
        //else
        //    NyupMain.mainGUI.debug.DisableDebug();
        //Misa.MainGUI.PlayerList.DisablePlayerList();
        Misa.MainGUI.PlayerList.EnablePlayerList();

        PlayerList.ListMain.transform.position = new Vector2(0, 0);
        textForGUIFun = new TextForGUI().CreateTextMeshPro($"ArrListText");
        textForGUIFun.AddToParent(Scale.transform);
        textForGUIFun.SetConnect(ConnectTipe.Up);
        textForGUIFun.SetScale(new Vector2(1f, 1f));
        textForGUIFun.SetSizeDelta(new Vector2(400, 700));
        //textForGUIFun.gameMeshProUGUI.transform.position = new Vector2(0, 0);
        //textForGUIFun.gameMeshProUGUI.transform.localPosition = new Vector2(0, 0);
        textForGUIFun.SetPosition(new Vector2(350, 0));
    }

    public static IEnumerator WaitForMenu()//
    {
        while (!GameObject.Find("Cohtml/CohtmlWorldView")) { yield return new WaitForSeconds(1); }
        Misa.MainGUI.Start();
    }
    public void Update()
    {
        if (Scale != null && debug != null)
        {
            var si = ConfiglistSer.Configlist.GUISS;
            Scale.transform.localScale = (new Vector2(si - 0.1f, si - 0.1f));
            debug.Background.GameObjectBackground.transform.localScale = (new Vector2(si, si));
        }
        //if (ConfiglistSer.Configlist.ArrList)
        //{
        //    string saw = "";
        //    for (int i = 0; i < ButtonsAPI.arrayfunct.Count; i++)
        //    {
        //        saw = saw + "\n" + ButtonsAPI.arrayfunct[i];
        //        if (textForGUIFun != null)
        //            textForGUIFun.SetText($"<color=#{ColorUtility.ToHtmlStringRGB(ColorShit.HSBColor.ToColor(new ColorShit.HSBColor(Mathf.PingPong(Time.time * ColorsByTrust.espRainbowSpeed, 1f), 1f, 1f)))}><size=14>" + saw + "</size></color>");
        //    }
        //    try
        //    {
        //        if (ButtonsAPI.arrayfunct.Count == 0 && textForGUIFun != null)
        //            textForGUIFun.SetText($"");
        //    }
        //    catch { }
        //}
        //else
        //{
        //    if (textForGUIFun != null)
        //        textForGUIFun.SetText($"");
        //}


        if (PlayerList != null)
        {
            PlayerList.GUICapacityUpdate(string.Concat(new string[]
                   {
                        //"<b><color=#00FFFF>",
                        //string.Format("<size=31>World Capacity: (Photon){0} (API){1}</size>", NyupPatches.Photoncapacity, NyupPatches.APIcapacity),
                        //"</color></b>\n<size=31><color=#0000FF>",
                        string.Format("Total:{0}",MetaPort.Instance.PlayerManager.NetworkPlayers.Count),
                        //"</color></size><size=31>" 
                        //"<color=#FF0000>",
                        //string.Format("PhotonPlayers:{0}", GUIList.Photonp),
                        //"</color></size>",
                        //"</color></b>\n",
                        string.Format("<size=31>{0}({1})</size>",DateTime.Now.ToString("h:mm:ss tt"),DateTime.Now.ToString("HH:mm:ss")),
                   }));
            //PlayerList.textForGUIPlayerListUpdate("<size=28>" + MenuList.userListGlobal + "</size>");
            PlayerList.textForGUIPlayerListUpdate("<size=28>" + "ХУЙ БЛЯДБ" + "</size>");
            //PlayerList.BackgroundMain.SetSizeDelta(new Vector2(80, GUIList.Photonp * 5.2f));

            //if (!MainColor.PlList)
            //{
            //    var color = new Color(MainColor.ColorForOldNyup.r, MainColor.ColorForOldNyup.g, MainColor.ColorForOldNyup.b, MainColor.ColorForOldNyup.a / 4f);
            //    debug.Background.SetColor(color);
            //    PlayerList.SetColor(color);
            //    MainColor.PlList = true;
            //}
        }
    }


    public void SetMenuText(string text)
    {
        if (PlayerList != null)
        {
            textweq2++;
            if (textwe == text)
            {
                textweq++;
            }
            textwe = text;
            if (textweq != textweq2)
            {
                colint = 1;
                debug.SetText(text);
            }
            else
            {
                colint++;
                debug.TextForGUIList[0].textMeshProUGUI.text = (string.Format("<b><color=#FFFF00>({0})</color></b> ", colint) + text);
            }
            textweq2 = 0;
            textweq = 0;
        }
    }
}
public class PlayerListGUI
{
    public GameObject ListMain;
    public Background BackgroundLite;
    public Background BackgroundMain;
    public TextForGUI textForGUIPlayerList;
    public TextForGUI textForGUICapacity;
    public TextForGUI textForGUIPlayersCount;
    public TextForGUI textForGUIArrList;
    public PlayerListGUI CreatePlayerList(string PlayerListName, CanvarForGUI canvarForGUI)
    {
        ListMain = new GameObject(PlayerListName);
        ListMain.transform.parent = canvarForGUI.GameObjectCanvas.transform;
        ListMain.AddComponent<RectTransform>();
        ListMain.GetComponent<RectTransform>().pivot = new Vector2(0, 1);
        ListMain.GetComponent<RectTransform>().anchorMax = new Vector2(0, 1);
        ListMain.GetComponent<RectTransform>().anchorMin = new Vector2(0, 1);
        ListMain.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

        var BackgroundLite = new Background().CreateBackground("BackgroundLite");
        BackgroundLite.AddToParent(canvarForGUI.GameObjectCanvas.transform);
        BackgroundLite.SetConnect(ConnectTipe.LeftUp);
        BackgroundLite.SetScale(new Vector2(4, 4));
        BackgroundLite.SetSizeDelta(new Vector2(80, 15));
        BackgroundLite.SetPosition(new Vector2(10, -10));
        BackgroundLite.AddToParent(ListMain.transform);

        var textForGUICapacity = new TextForGUI().CreateTextMeshPro($"textForGUICapacity");
        textForGUICapacity.AddToParent(BackgroundLite.GameObjectBackground.transform);
        textForGUICapacity.SetConnect(ConnectTipe.Up);
        textForGUICapacity.SetScale(new Vector2(0.12f, 0.12f));
        textForGUICapacity.SetSizeDelta(new Vector2(900, 130));
        textForGUICapacity.SetPosition(new Vector2(0, 0));
        textForGUICapacity.textMeshProUGUI.alignment = TextAlignmentOptions.Center;

        var textForGUIPlayersCount = new TextForGUI().CreateTextMeshPro($"textForGUIPlayersCount");
        textForGUIPlayersCount.AddToParent(BackgroundLite.GameObjectBackground.transform);
        textForGUIPlayersCount.SetConnect(ConnectTipe.Up);
        textForGUIPlayersCount.SetScale(new Vector2(0.13f, 0.13f));
        textForGUIPlayersCount.SetSizeDelta(new Vector2(900, 50));
        textForGUIPlayersCount.SetPosition(new Vector2(0, -7));
        textForGUIPlayersCount.textMeshProUGUI.alignment = TextAlignmentOptions.Center;

        var BackgroundMain = new Background().CreateBackground("BackgroundMain");
        BackgroundMain.AddToParent(canvarForGUI.GameObjectCanvas.transform);
        BackgroundMain.SetConnect(ConnectTipe.LeftUp);
        BackgroundMain.SetScale(new Vector2(4, 4));
        BackgroundMain.SetSizeDelta(new Vector2(80, 5));
        BackgroundMain.SetPosition(new Vector2(10, -80));
        BackgroundMain.AddToParent(ListMain.transform);

        var textForGUIPlayerList = new TextForGUI().CreateTextMeshPro($"textForGUIPlayers");
        textForGUIPlayerList.AddToParent(BackgroundMain.GameObjectBackground.transform);
        textForGUIPlayerList.SetConnect(ConnectTipe.Up);
        textForGUIPlayerList.SetScale(new Vector2(0.13f, 0.13f));
        textForGUIPlayerList.SetSizeDelta(new Vector2(920, 2200));
        textForGUIPlayerList.SetPosition(new Vector2(20, 0));
        return new PlayerListGUI() { textForGUIPlayerList = textForGUIPlayerList, ListMain = ListMain, BackgroundMain = BackgroundMain, BackgroundLite = BackgroundLite, textForGUICapacity = textForGUICapacity, textForGUIPlayersCount = textForGUIPlayersCount };
    }
    public void EnablePlayerList()
    {
        ListMain.SetActive(true);
    }
    public void DisablePlayerList()
    {
        ListMain.SetActive(false);
    }
    public void SetColor(Color color)
    {
        BackgroundLite.SetColor(color);
        BackgroundMain.SetColor(color);
    }
    public void textForGUIPlayerListUpdate(string text)
    {
        textForGUIPlayerList.textMeshProUGUI.text = text;
    }
    public void textForGUIPlayersCountUpdate(string text)
    {
        textForGUIPlayersCount.textMeshProUGUI.text = text;
    }
    public void GUICapacityUpdate(string text)
    {
        textForGUICapacity.textMeshProUGUI.text = text;
    }
}
public class DebugGUI
{
    public Background Background;
    public List<TextForGUI> TextForGUIList;
    public DebugGUI CreateDebug(string DebugName, CanvarForGUI canvarForGUI)
    {
        var Background = new Background().CreateBackground(DebugName);
        Background.AddToParent(canvarForGUI.GameObjectCanvas.transform);
        Background.SetConnect(ConnectTipe.RightUp);
        Background.SetScale(new Vector2(4, 4));
        Background.SetSizeDelta(new Vector2(440, 370));
        Background.SetPosition(new Vector2(-10, -10));
        var TextForGUIList = new List<TextForGUI>();
        float pos = -360f;
        for (int i = 0; i < 24; i++)
        {
            pos = pos + 15f;
            var text = new TextForGUI().CreateTextMeshPro($"Text: {i}");
            text.AddToParent(Background.GameObjectBackground.transform);
            text.SetConnect(ConnectTipe.Up);
            text.SetScale(new Vector2(0.4f, 0.4f));
            text.SetPosition(new Vector2(45f, pos));
            text.SetSizeDelta(new Vector2(1300f, 60f));
            TextForGUIList.Add(text);
        }
        return new DebugGUI() { Background = Background, TextForGUIList = TextForGUIList };
    }
    public void EnableDebug()
    {
        Background.GameObjectBackground.SetActive(true);
    }
    public void DisableDebug()
    {
        Background.GameObjectBackground.SetActive(false);
    }
    public void SetText(int text)
    {
        SetText(text.ToString());
    }
    public void SetText(string text)
    {
        for (int i = TextForGUIList.Count - 2; i > -1; i--)
        {
            TextForGUIList[i + 1].textMeshProUGUI.text = TextForGUIList[i].textMeshProUGUI.text;
        }
        TextForGUIList[0].SetText(text);
    }
}
public enum ConnectTipe
{
    LeftUp,
    Up,
    RightUp,
    Left,
    Center,
    Right,
    LeftDown,
    Down,
    RightDown
}
public class Background
{
    public GameObject GameObjectBackground;
    public RawImage RawImageBackground;
    public Background CreateBackground(string BackgroundName)
    {
        var background = new Background();
        var GameObjectBackground = new GameObject(BackgroundName);
        var RawImage = GameObjectBackground.AddComponent<RawImage>(); ;

        background.GameObjectBackground = GameObjectBackground;
        background.RawImageBackground = RawImage;
        return background;
    }
    public void SetColor(Color color)
    {
        RawImageBackground.color = color;
    }
    public void AddToParent(Transform transform)
    {
        GameObjectBackground.transform.parent = transform;
    }
    public void SetConnect(ConnectTipe connectTipe)
    {
        if (connectTipe == ConnectTipe.LeftUp)
        {
            GameObjectBackground.GetComponent<RectTransform>().pivot = new Vector2(0, 1);
            GameObjectBackground.GetComponent<RectTransform>().anchorMax = new Vector2(0, 1);
            GameObjectBackground.GetComponent<RectTransform>().anchorMin = new Vector2(0, 1);
        }
        if (connectTipe == ConnectTipe.Up)
        {
            GameObjectBackground.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 1);
            GameObjectBackground.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 1);
            GameObjectBackground.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 1);
        }
        if (connectTipe == ConnectTipe.RightUp)
        {
            GameObjectBackground.GetComponent<RectTransform>().pivot = new Vector2(1, 1);
            GameObjectBackground.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
            GameObjectBackground.GetComponent<RectTransform>().anchorMin = new Vector2(1, 1);
        }

        if (connectTipe == ConnectTipe.Left)
        {
            GameObjectBackground.GetComponent<RectTransform>().pivot = new Vector2(0, 0.5f);
            GameObjectBackground.GetComponent<RectTransform>().anchorMax = new Vector2(0, 0.5f);
            GameObjectBackground.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0.5f);
        }
        if (connectTipe == ConnectTipe.Center)
        {
            GameObjectBackground.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
            GameObjectBackground.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.5f);
            GameObjectBackground.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.5f);


        }
        if (connectTipe == ConnectTipe.Right)
        {
            GameObjectBackground.GetComponent<RectTransform>().pivot = new Vector2(1, 0.5f);
            GameObjectBackground.GetComponent<RectTransform>().anchorMax = new Vector2(1, 0.5f);
            GameObjectBackground.GetComponent<RectTransform>().anchorMin = new Vector2(1, 0.5f);

        }

        if (connectTipe == ConnectTipe.LeftDown)
        {
            GameObjectBackground.GetComponent<RectTransform>().pivot = new Vector2(0, 0f);
            GameObjectBackground.GetComponent<RectTransform>().anchorMax = new Vector2(0, 0f);
            GameObjectBackground.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0f);

        }
        if (connectTipe == ConnectTipe.Down)
        {
            GameObjectBackground.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0f);
            GameObjectBackground.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0f);
            GameObjectBackground.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0f);

        }
        if (connectTipe == ConnectTipe.RightDown)
        {
            GameObjectBackground.GetComponent<RectTransform>().pivot = new Vector2(1, 0f);
            GameObjectBackground.GetComponent<RectTransform>().anchorMax = new Vector2(1, 0f);
            GameObjectBackground.GetComponent<RectTransform>().anchorMin = new Vector2(1, 0f);
        }
    }
    public void SetSizeDelta(Vector2 vector2)
    {
        //gameMeshProUGUI.GetComponent<RectTransform>().position = vector2;
        GameObjectBackground.GetComponent<RectTransform>().sizeDelta = vector2;
    }
    public void SetPosition(Vector2 vector2)
    {
        //gameMeshProUGUI.GetComponent<RectTransform>().position = vector2;
        GameObjectBackground.GetComponent<RectTransform>().anchoredPosition = vector2;
    }
    public void SetScale(Vector2 vector2)
    {
        //gameMeshProUGUI.GetComponent<RectTransform>().position = vector2;
        GameObjectBackground.GetComponent<RectTransform>().localScale = vector2;
    }
    public void Destroy()
    {
        GameObject.Destroy(GameObjectBackground);
    }
}
public class CanvarForGUI
{
    public GameObject GameObjectCanvas;
    public Canvas canvas;
    public CanvarForGUI CreateCanvas(string CanvasName, RenderMode renderMode)
    {
        var CanvarForGUI = new CanvarForGUI();
        var GameObjectCanvas = new GameObject(CanvasName);
        var canvas = GameObjectCanvas.AddComponent<Canvas>();
        GameObjectCanvas.AddComponent<CanvasScaler>();
        GameObjectCanvas.AddComponent<GraphicRaycaster>();
        GameObjectCanvas.GetComponent<Canvas>().renderMode = renderMode;
        CanvarForGUI.canvas = canvas;
        CanvarForGUI.GameObjectCanvas = GameObjectCanvas;
        return CanvarForGUI;
    }
}
public class TextForGUI
{
    public GameObject gameMeshProUGUI;
    public TextMeshProUGUI textMeshProUGUI;
    public TextForGUI CreateTextMeshPro(string Name)
    {
        var gameMeshProUGUI = new GameObject(Name);
        var textMeshProUGUI = gameMeshProUGUI.AddComponent<TextMeshProUGUI>();
        // textMeshProUGUI.SetText(Name);
        textMeshProUGUI.overflowMode = TextOverflowModes.Ellipsis;
        textMeshProUGUI.fontSize = 34;
        //textMeshProUGUI.autoSizeTextContainer = true;
        return new TextForGUI() { gameMeshProUGUI = gameMeshProUGUI, textMeshProUGUI = textMeshProUGUI };
    }
    public void AddToParent(Transform transform)
    {
        gameMeshProUGUI.gameObject.transform.parent = transform;
    }
    public void SetScale(Vector2 vector2)
    {
        //gameMeshProUGUI.GetComponent<RectTransform>().position = vector2;
        gameMeshProUGUI.GetComponent<RectTransform>().localScale = vector2;
    }
    public void SetSizeDelta(Vector2 vector2)
    {
        //gameMeshProUGUI.GetComponent<RectTransform>().position = vector2;
        gameMeshProUGUI.GetComponent<RectTransform>().sizeDelta = vector2;
    }
    public void SetConnect(ConnectTipe connectTipe)
    {
        if (connectTipe == ConnectTipe.LeftUp)
        {
            gameMeshProUGUI.GetComponent<RectTransform>().pivot = new Vector2(0, 1);
            gameMeshProUGUI.GetComponent<RectTransform>().anchorMax = new Vector2(0, 1);
            gameMeshProUGUI.GetComponent<RectTransform>().anchorMin = new Vector2(0, 1);
        }
        if (connectTipe == ConnectTipe.Up)
        {
            gameMeshProUGUI.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 1);
            gameMeshProUGUI.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 1);
            gameMeshProUGUI.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 1);
        }
        if (connectTipe == ConnectTipe.RightUp)
        {
            gameMeshProUGUI.GetComponent<RectTransform>().pivot = new Vector2(1, 1);
            gameMeshProUGUI.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
            gameMeshProUGUI.GetComponent<RectTransform>().anchorMin = new Vector2(1, 1);
        }

        if (connectTipe == ConnectTipe.Left)
        {
            gameMeshProUGUI.GetComponent<RectTransform>().pivot = new Vector2(0, 0.5f);
            gameMeshProUGUI.GetComponent<RectTransform>().anchorMax = new Vector2(0, 0.5f);
            gameMeshProUGUI.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0.5f);


        }
        if (connectTipe == ConnectTipe.Center)
        {
            gameMeshProUGUI.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
            gameMeshProUGUI.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.5f);
            gameMeshProUGUI.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.5f);


        }
        if (connectTipe == ConnectTipe.Right)
        {
            gameMeshProUGUI.GetComponent<RectTransform>().pivot = new Vector2(1, 0.5f);
            gameMeshProUGUI.GetComponent<RectTransform>().anchorMax = new Vector2(1, 0.5f);
            gameMeshProUGUI.GetComponent<RectTransform>().anchorMin = new Vector2(1, 0.5f);

        }

        if (connectTipe == ConnectTipe.LeftDown)
        {
            gameMeshProUGUI.GetComponent<RectTransform>().pivot = new Vector2(0, 0f);
            gameMeshProUGUI.GetComponent<RectTransform>().anchorMax = new Vector2(0, 0f);
            gameMeshProUGUI.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0f);

        }
        if (connectTipe == ConnectTipe.Down)
        {
            gameMeshProUGUI.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0f);
            gameMeshProUGUI.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0f);
            gameMeshProUGUI.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0f);

        }
        if (connectTipe == ConnectTipe.RightDown)
        {
            gameMeshProUGUI.GetComponent<RectTransform>().pivot = new Vector2(1, 0f);
            gameMeshProUGUI.GetComponent<RectTransform>().anchorMax = new Vector2(1, 0f);
            gameMeshProUGUI.GetComponent<RectTransform>().anchorMin = new Vector2(1, 0f);
        }
    }
    public void SetPosition(Vector2 vector2)
    {
        //gameMeshProUGUI.GetComponent<RectTransform>().position = vector2;
        gameMeshProUGUI.GetComponent<RectTransform>().anchoredPosition = vector2;
    }
    public void SetText(string text)
    {
        textMeshProUGUI.SetText(text);
    }
    public void Destroy()
    {
        GameObject.Destroy(textMeshProUGUI);
    }
}
