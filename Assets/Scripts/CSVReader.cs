using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace NovelGame
{
    public class CSVReader : MonoBehaviour
    {
        TextAsset csvFile; // CSVファイル
        List<Dictionary<string, string>> csvDatas = new List<Dictionary<string, string>>(); // CSVの中身を入れるリスト;
        private void Reset()
        {
            csvDatas = new List<Dictionary<string, string>>();
        }

        public void Read(string path)
        {
            Debug.Log(path);
            csvFile = Resources.Load(path) as TextAsset; // Resources下のCSV読み込み
            Debug.Log(csvFile);
            StringReader reader = new StringReader(csvFile.text);

            // ヘッダー行を読み込んで、各列の名前を取得
            string[] headers = reader.ReadLine().Split(',');

            while (reader.Peek() != -1) // reader.Peekが-1になるまで
            {
                string line = reader.ReadLine(); // 一行ずつ読み込み
                string[] values = line.Split(','); // , 区切りで値を取得

                // 各列のデータをヘッダーと対応させてDictionaryに格納
                Dictionary<string, string> data = new Dictionary<string, string>();
                for (int i = 0; i < headers.Length; i++)
                {
                    data[headers[i]] = values[i];
                }

                // リストに追加
                csvDatas.Add(data);
            }
        }

        public string getSpeaker(int row)
        {
            return csvDatas[row]["speaker"];
        }

        public string getSentence(int row)
        {
            return csvDatas[row]["text"];
        }
        public Dictionary<string, string> GetRowData(int rowNumber)
        {
            // 行番号は1から始まるが、リストのインデックスは0から始まるため、
            // rowNumber - 1 でインデックスを調整
            if (rowNumber > 0 && rowNumber <= csvDatas.Count)
            {
                return csvDatas[rowNumber - 1];
            }
            return null; // 該当する行がなければnullを返す
        }
    }
}
