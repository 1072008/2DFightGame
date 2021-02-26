using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    string LevelAimScore = "LevelAimScore";
    public string[] TextLines; //讀取文字檔裡面的每行
    public List<string> TextScoreLines;
    public List<string> TextNameLines;

    public GameObject[] LevelsButton; //存放所有按鈕

    public int LevelID;
    public string[] TextLevelID;
    private void Awake() //把所有按鈕的tag加入
    {
        for(int i=0;i<LevelsButton.Length;i++)
        {
            LevelsButton[i].tag = i + "";
        }
    }

    //讀取text檔案裡的資料
    void Start()
    {
        string Path = "Assets/Resources/SetLevel.txt";
        StreamReader reader = new StreamReader(Path);
        //Debug.Log(reader.ReadToEnd()); //透過Debug顯示text內容
        //reader.Close(); //關閉讀取text檔案

        TextLines = File.ReadAllLines(Path);
        TextScoreLines.Clear();
        TextNameLines.Clear();
        for(int i=0;i<TextLines.Length;i++)
        {
            if (TextLines[i] != "")
            {
                string[] Lines = TextLines[i].Split('@');
                TextScoreLines.Add(Lines[1]);
                TextNameLines.Add(Lines[0]);
            }
        }
        string LevelIDPath = "Assets/Resources/LevelID.txt";
        TextLevelID = File.ReadAllLines(LevelIDPath);
        LevelID = int.Parse(TextLevelID[0]);
        for(int j=0;j<LevelID;j++)
        {
            LevelsButton[j].GetComponent<Button>().interactable = true;
        }
    }

    public void SetLevelAimScore(int AimScore)
    {
        // Staticvar.Level1AimsScore = AimScore; //儲存數值在全域變數  程式檔名.全域變數名稱＝要儲存的資料

        PlayerPrefs.SetInt(LevelAimScore, AimScore); //Unity內建儲存資料的方式 PlayerPrefs.SetInt(欄位名稱，儲存的數值）;
        Debug.Log("Save AimScore:" + AimScore);
    }
    public void NextScene(string SceneName)
    {
        Application.LoadLevel(SceneName);
    }
}
