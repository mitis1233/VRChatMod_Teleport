using System;
using System.Collections;
using MelonLoader;
using UnityEngine;

namespace TP
{
    public class Main : MelonMod
    {
        GameObject quickMenu;
        public override void OnApplicationStart()
        {
            MelonCoroutines.Start(QMInitializer());
        }

        private IEnumerator QMInitializer()
        {
            while ((quickMenu = GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)")) == null)
                yield return null;
            SelMenu();
        }

        private void SelMenu()
        {
            Transform ButtonTP = quickMenu.transform.Find("Container/Window/QMParent/Menu_SelectedUser_Local/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_UserActions");
            Utils.CreateDefaultButton("傳送", new Vector3(0, -25, 0), "傳送到選擇的玩家 禁止在公開房使用", Color.white, ButtonTP,
                new Action(() => {
                    Utils.LocalPlayer.gameObject.transform.position = Utils.MenuControl.activePlayer.gameObject.transform.position;
                }));
        }
    }
}