using UnityEngine;
using System.Linq;
using System;

// game manager -> chat class
// rest -> player flashlight

namespace HandyHarryHack
{
    class Hack
    {
        public class Settings
        {
            public static bool
                bUnlmitedGlowStick,
                bFoundPlayer,
                bEnabledWaterMark,
                bDrawMenu,
                bPlaceInElevator,
                bDisableTeleport
                ;
        }

        private static Hack instance = new Hack();
        private RoomGameManager gameMgr;
        private PlayerDeathManager pdm;
        private NetworkPlayer player;        
      
        public static Hack Get()
        {
            return Hack.instance;
        }
        public void DebugMessage(string message)
        {
            //Color[] colors = (Color[])Enum.GetValues(typeof(Color));
            //System.Random rnd = new System.Random();
            //Color color = (Color)colors.GetValue(rnd.Next(colors.Length));
            this.gameMgr.chat.chatSlots[0].text = message;
            this.gameMgr.chat.chatSlots[0].name = "LeetHacker700";
            this.gameMgr.chat.chatSlots[0].color = Color.green;
        }

        public void SetPDM(PlayerDeathManager pdm)
        {
            this.pdm = pdm;
        }

        public void SetGameManger(RoomGameManager mgr)
        {
            this.gameMgr = mgr;
        }

        public void SetPlayer(NetworkPlayer p )
        {
            player = p;
            //this.player = gameMgr.players.Where(p => p.playerSteamID == this.playerSteamId).FirstOrDefault();            
        }

        public void EnablePower()
        {            
            this.gameMgr.masterSwitchActive = true;
            GameObject.FindWithTag("MasterSwitch").GetComponent<MasterSwitch>().interactable = true;
        }
        
        public void InstantlyEnd()
        {
            this.EnablePower();
            this.gameMgr.escapeReady = true;
            this.gameMgr.elevatorLight.SetActive(true);
        }

        public void AddBattery()
        {
            this.pdm.batteries++;
        }

        public void Update()
        {
            if(Input.GetKeyDown(KeyCode.U))
            {
                foreach (var p in this.gameMgr.livingPlayers)
                {
                    if(p.playerSteamID != player.playerSteamID)
                    {
                        
                    }
                } 
                
                
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                
                DebugMessage("true");
                this.AddBattery();
            }            
        }
    }
}
