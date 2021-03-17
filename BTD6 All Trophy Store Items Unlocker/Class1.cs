using Assets.Scripts.Unity;
using Assets.Scripts.Unity.UI_New.Main;
using Harmony;
using MelonLoader;
[assembly: MelonInfo(typeof(BTD6_All_Trophy_Store_Items_Unlocker.Class1), "All Trophy Store Items Unlocker", "1.0.0", "kenx00x")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
namespace BTD6_All_Trophy_Store_Items_Unlocker
{
    public class Class1 : MelonMod
    {
        public override void OnApplicationStart()
        {
            MelonLogger.Log("All Trophy Store Items Unlocker loaded!");
        }
        [HarmonyPatch(typeof(MainMenu), "Open")]
        public class TitleScreen_Patch
        {
            [HarmonyPostfix]
            public static void Postfix()
            {
                foreach (var item in Game.instance.trophyStoreItems.storeItems)
                {
                    Game.instance.playerService.Player.AddTrophyStoreItem(item.id);
                }
            }
        }
    }
}