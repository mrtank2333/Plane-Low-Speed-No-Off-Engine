using System;
using GTA;
using GTA.Native;


namespace GTA5AircraftEngineNoOff
{
    public class EngineNoOff : Script   //"Script" class
    {
        Ped player;
        Vehicle Aircraft;
        public EngineNoOff()
        {
            Tick += OnTick;
        }
        void OnTick(object sender, EventArgs e)
        {
            player = Game.Player.Character;
            bool isExist = Function.Call<bool>(Hash.DOES_ENTITY_EXIST, player);//Does the character exist, if not it's possible the game is loading.
            if (isExist)
            {
                Aircraft = Game.Player.Character.CurrentVehicle;//The player's current vehicle is an Aircraft.
                if (player.IsInPlane && !player.IsInHeli)//The player is on a plane and the plane is not a helicopter.
                {
                    Aircraft.EngineRunning = true;
                }
            }
            else
            {
                return;
            }
        }
    }
}
