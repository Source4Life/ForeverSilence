using BepInEx;
using GorillaNetworking;
using System.Collections;
using UnityEngine;

namespace ForeverSilence
{
    [BepInPlugin("com.source4life.foreversilence", "Forever Silence", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        void Start()
        {
            StartCoroutine(SHUTUP());
        }
        IEnumerator SHUTUP()
        {
            while (true)
            {
                if (NetworkSystem.Instance.InRoom)
                {
                    foreach (var line in GorillaScoreboardTotalUpdater.allScoreboardLines)
                    {
                        if (line == null) continue;
                        line.muteButton.isOn = true;
                        line.PressButton(true, GorillaPlayerLineButton.ButtonType.Mute);
                    }
                }
                yield return new WaitForSeconds(1f);
            }
        }
    }
}

// meow :3