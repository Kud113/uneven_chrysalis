using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace NovelGame
{
    public class GameManager : MonoBehaviour
    {
        // 別のクラスからGameManagerの変数などを使えるようにするためのもの。（変更はできない）
        public static GameManager Instance { get; private set; }
        [SerializeField] TextAsset _savedata;
        public UserScriptManager userScriptManager;
        public MainTextControl mainTextControl;
        public MainSpeakerControl mainSpeakerControl;
        // ユーザスクリプトの、今の行の数値。クリック（タップ）のたびに1ずつ増える。
        [System.NonSerialized] public int lineNumber;
        [System.NonSerialized] public string chapter;
        void RoadSaveChapter()
        {
            StringReader reader = new StringReader(_savedata.text);
            chapter = reader.ReadLine();
        }
        void Awake()
        {
            // これで、別のクラスからGameManagerの変数などを使えるようになる。
            Instance = this;
            RoadSaveChapter();
            lineNumber = 0;
            
        }
    }
}