using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace NovelGame
{
    public class MainTextControl : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI _mainTextObject;
        bool select = false;
        // Start is called before the first frame update
        void Start()
        {
            DisplayText();
        }

        // Update is called once per frame
        void Update()
        {
            // クリックされたとき、次の行へ移動
            if (Input.GetMouseButtonUp(0))
            {
                GoToTheNextLine();
                DisplayText();
            }
        }

        // 次の行へ移動
        public void GoToTheNextLine()
        {
            GameManager.Instance.lineNumber++;
        }

        // テキストを表示
        public void DisplayText()
        {
            string sentence = GameManager.Instance.userScriptManager.GetCurrentSentence();
            _mainTextObject.text = sentence;
        }
    }
}