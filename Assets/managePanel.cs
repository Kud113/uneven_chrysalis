using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace NovelGame
{
    public class managePanel : MonoBehaviour
    {
        public GameObject titleScreenPanel; // タイトル画面のパネル
        public GameObject gamePlayPanel; // ゲームプレイ画面のパネル

        public void StartGame()
        {
            titleScreenPanel.SetActive(false);
            gamePlayPanel.SetActive(true);
        }
    }
}
