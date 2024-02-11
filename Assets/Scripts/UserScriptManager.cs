using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace NovelGame
{
    public class UserScriptManager : MonoBehaviour
    {


        // 文章中の文（ここでは１行ごと）を入れておくためのリスト
        List<string> _sentences = new List<string>();
        List<string> _speaker = new List<string>();
        public CSVReader CSVReader;
        private void Awake()
        {
            //CSVReader = new CSVReader();
            Reload();
        }
        void Reload()
        {
            //Debug.Log(GameManager.Instance.chapter + ".csv");
            CSVReader.Read(GameManager.Instance.chapter);
            
        }

        // 現在の行の文を取得する
        public string GetCurrentSentence()
        {
            return CSVReader.getSentence(GameManager.Instance.lineNumber);
        }
        public string GetCurrentSpeaker()
        {
            return CSVReader.getSpeaker(GameManager.Instance.lineNumber);
        }
    }
}