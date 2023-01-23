using ABI_RC.Core.Newton.ImageEffects;
using ABI_RC.Core.Savior;
using ABI_RC.Systems.MovementSystem;
using System;
using UnityEngine;

namespace Misatyan
{
    internal class PlayerList
    {
        public static void List()
        {
            //[Best-Modder]                                 Voltan
            //[And no less brilliant layout designer]:      Misatyan
            int W = Screen.currentResolution.width;
            int H = Screen.currentResolution.height;
            float coeff = 6;
            float sizeY = 3 * coeff;
            int fpsValue = (int)(1.0f / Time.smoothDeltaTime);
            string text = string.Empty;
            var Players = MetaPort.Instance.PlayerManager.NetworkPlayers;
            
            GUIStyle style = new GUIStyle();
            style.alignment = TextAnchor.MiddleLeft;
            style.normal.textColor = Color.white;

            Rect Header = new Rect(10, 10, (W / coeff), (H / sizeY));

            Rect Head = new Rect(new Vector2(Header.x - 5, Header.y - 5), new Vector2(Header.width + 10, Header.height + 10));
            GUI.Box(Head, "");

            text = $"MisaCVR";
            Rect Label = new Rect(new Vector2(Header.x, Header.y), new Vector2(2 * Header.width / 3, 2 * Header.height / 3));
            style.fontSize = (int)Label.height;
            style.stretchWidth = true;



            GUI.Label(Label, text, style);

            text = "FPS";
            Rect FPS = new Rect(new Vector2(Label.x + Label.width, Label.y), new Vector2(Header.width / 6, Label.height / 2));
            style.fontSize = (int)FPS.height;
            GUI.Label(FPS, text, style);

            text = "Total";
            Rect Total = new Rect(new Vector2(FPS.x, FPS.y + FPS.height), new Vector2(Header.width / 6, Label.height / 2));
            style.fontSize = (int)Total.height;
            GUI.Label(Total, text, style);

            text = $"{fpsValue}";
            Rect FPSvalue = new Rect(new Vector2(FPS.x + FPS.width, FPS.y), new Vector2(FPS.width, FPS.height));
            style.fontSize = (int)FPSvalue.height;
            if (fpsValue < 20)
                style.normal.textColor = Color.red;
            else if (fpsValue >= 20 && fpsValue < 30)
                style.normal.textColor = Color.yellow;
            else
                style.normal.textColor = Color.green;
            style.alignment = TextAnchor.MiddleRight;
            GUI.Label(FPSvalue, text, style);

            text = $"{Players.Count}";
            Rect Totalvalue = new Rect(new Vector2(FPSvalue.x, FPSvalue.y + FPSvalue.height), new Vector2(FPSvalue.width, FPSvalue.height));
            style.normal.textColor = Color.cyan;
            style.fontSize = (int)Totalvalue.height;
            GUI.Label(Totalvalue, text, style);



            text = "#";
            Rect num = new Rect(new Vector2(Label.x, Label.y + Label.height), new Vector2(Header.width / 10, Header.height - Label.height));
            style.fontSize = (int)(num.height);
            style.alignment = TextAnchor.LowerLeft;
            GUI.Box(num, "");
            GUI.Label(num, text, style);

            text = "username";
            Rect username = new Rect(new Vector2(num.x+num.width, Label.y + Label.height), new Vector2((Header.width - num.width) / 3, Header.height - Label.height));
            style.fontSize = (int)username.height;
            GUI.Box(username, "");
            GUI.Label(username, text, style);

            text = "rank";
            Rect rank = new Rect(new Vector2(username.x+username.width, Label.y + Label.height), new Vector2((Header.width - num.width) / 3, Header.height - Label.height));
            style.fontSize = (int)rank.height/2;
            GUI.Box(rank, "");
            GUI.Label(rank, text, style);

            text = "speak";
            Rect speak = new Rect(new Vector2(rank.x + rank.width, Label.y + Label.height), new Vector2((Header.width - num.width) / 3, Header.height - Label.height));
            style.fontSize = (int)speak.height / 2;
            style.alignment = TextAnchor.LowerRight;
            GUI.Box(speak, "");
            GUI.Label(speak, text, style);
            //GUIStyle table = new GUIStyle();
            //table.alignment = TextAnchor.UpperLeft;
            //table.normal.textColor = Color.cyan;
            //GUI.Label(new Rect(20, 70, 20, 20), $"<size=14>#</size>", table);
            //GUI.Label(new Rect(40, 70, 100, 20), $"<size=14>username</size>", table);
            //GUI.Label(new Rect(200, 70, 100, 20), $"<size=14>rank</size>", table);
            //table.alignment= TextAnchor.UpperRight;
            //GUI.Label(new Rect(300, 70, 100, 20), $"<size=14>speak</size>", table);
            //int i = 0;
            //if (Players.Count != 0)
            //    GUI.Box(new Rect(10, 100, 320, 20 * Players.Count), "");
            //string playerList = string.Empty;
            //foreach (var player in Players)
            //{
            //    i++;

            //    
            //    string speak;
            //    if (player.TalkerAmplitude > 0)
            //    {
            //        speak = "speak";
            //    }
            //    else speak = string.Empty;
            //    GUI.Label(new Rect(20, 80 + 20 * i, 20, 20), $"<size=14>{i}</size>", table);
            //    GUIStyle rank = new GUIStyle();
            //    rank.alignment = TextAnchor.UpperLeft;
            //    rank.normal.textColor = Color.Lerp(player.PlayerNameplate.nameplateBackground.color, Color.white, 0.5f);
            //    if (GUI.Button(new Rect(40, 80 + 20 * i, 120, 20), $"<size=14>{player.Username}</size>", rank))
            //    {
            //        GameObject.Find("_PLAYERLOCAL").GetComponent<MovementSystem>().TeleportTo(player.DarkRift2Player.Position);
            //    }
            //    GUI.Label(new Rect(160, 80 + 20 * i, 100, 20), $"<size=14>{player.ApiUserRank}</size>", rank);
            //    GUIStyle speaker = new GUIStyle();
            //    speaker.alignment = TextAnchor.UpperLeft;
            //    speaker.normal.textColor = Color.green;
            //    GUI.Label(new Rect(260, 80 + 20 * i, 100, 20), $"<size=14>{speak}</size>", speaker);
        }

    }

}

