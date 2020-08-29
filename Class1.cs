using System;
using GTA;
using GTA.Native;


namespace GTA5AircraftEngineNoOff
{
    public class EngineNoOff : Script   //继承“Script”类
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
            bool isExist = Function.Call<bool>(Hash.DOES_ENTITY_EXIST, player);//人物是否存在，如果不存在有可能是在加载游戏
            if (isExist)
            {
                Aircraft = Game.Player.Character.CurrentVehicle;//玩家当前车辆是Aircraft
                if (player.IsInPlane && !player.IsInHeli)//在飞机上且飞机不是直升机
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