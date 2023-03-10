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
            int i = 0;
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
            style.fontSize = (int)(num.height / 1.2);
            style.alignment = TextAnchor.LowerLeft;
            GUI.Label(num, text, style);

            text = "username";
            Rect username = new Rect(new Vector2(num.x + num.width, Label.y + Label.height), new Vector2((Header.width - num.width) / 2, Header.height - Label.height));
            style.fontSize = (int)(username.height / 1.2);
            GUI.Label(username, text, style);

            text = "rank";
            Rect rank = new Rect(new Vector2(username.x + username.width, Label.y + Label.height), new Vector2((Header.width - num.width - username.width) / 2, Header.height - Label.height));
            style.fontSize = (int)(rank.height / 1.2);
            GUI.Label(rank, text, style);

            text = "speak";
            Rect speak = new Rect(new Vector2(rank.x + rank.width, Label.y + Label.height), new Vector2((Header.width - num.width - username.width - rank.width), Header.height - Label.height));
            style.fontSize = (int)(speak.height / 1.2);
            style.alignment = TextAnchor.LowerRight;
            GUI.Label(speak, text, style);
            
            Rect playerList = new Rect(new Vector2(Head.x, Head.y + Head.height), new Vector2(Head.width, Players.Count * num.height));
            if (Players.Count>0)
                GUI.Box(playerList, "");

            Rect position = new Rect(new Vector2(Header.x, playerList.y), new Vector2(Header.width, H / 2));
            Vector2 scroll = new Vector2(position.x, position.y);
            Rect viewRect = new Rect(new Vector2(scroll.x, scroll.y), new Vector2(position.width, Players.Count * num.height));
            GUI.BeginScrollView(position, scroll, viewRect);


            
            foreach (var player in Players)
            {
                i++;
                

                text = $"{i}";
                Rect numPL = new Rect(new Vector2(num.x, position.y + (i - 1) * num.height), new Vector2(num.width, num.height));
                style.alignment = TextAnchor.MiddleLeft;
                style.normal.textColor = Color.cyan;
                GUI.Label(numPL, text, style);

                text = $"{player.Username}";
                Rect usernamePL = new Rect(new Vector2(username.x, position.y + (i - 1) * username.height), new Vector2(username.width, username.height));
                style.alignment = TextAnchor.MiddleLeft;
                style.normal.textColor = Color.Lerp(player.PlayerNameplate.nameplateBackground.color, Color.white, 0.5f);
                if (GUI.Button(usernamePL, text, style))
                    GameObject.Find("_PLAYERLOCAL").GetComponent<MovementSystem>().TeleportTo(player.DarkRift2Player.Position);

                text = $"{player.ApiUserRank}";
                Rect rankPL = new Rect(new Vector2(rank.x, position.y + (i - 1) * rank.height), new Vector2(rank.width, rank.height));
                style.alignment = TextAnchor.MiddleLeft;
                GUI.Label(rankPL, text, style);

                
                if (player.TalkerAmplitude > 0)
                    text = "speak";
                else text = "";
                
                Rect Speaker = new Rect(new Vector2(speak.x, position.y + (i - 1) * speak.height), new Vector2(speak.width, speak.height));
                style.alignment = TextAnchor.MiddleRight;
                style.normal.textColor = Color.green;
                GUI.Label(Speaker, text, style);
            }
            GUI.EndScrollView();

        }


    }
}

