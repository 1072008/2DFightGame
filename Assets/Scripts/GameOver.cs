using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class GameOver : MonoBehaviour
{
    [Header("目標分數文字")]
    public Text AimsScoreText;
    [Header("得分數文字")]
    public Text ScoreText;
    [Header("下一關的按鈕")]
    public Button NextButton;

    string LevelAimScore = "LevelAimScore";

    //讀取文字檔裡面的每行
    public string[] TextLines;
    public List<string> TextScoreLines;
    public List<string> TextNameLines;
    
    //關卡可開啟的ID
    public int LevelID;
    public string[] TextLevelID;

    // Start is called before the first frame update
    void Start()
    {
        AimsScoreText.text = "目標得分數" + PlayerPrefs.GetInt(LevelAimScore); //Unity內建取資料方式 PlayerPrefs.GetInt(欄位名稱);

        //AimsScoreText.text = "目標得分數" + Staticvar.Level1AimsScore; //使用全域變數

        ScoreText.text = "得分數" + Camera.main.GetComponent<GM>().TotalScore;

        string Path = "Assets/Resources/SetLevel.txt";
        StreamReader reader = new StreamReader(Path);
        //Debug.Log(reader.ReadToEnd()); //透過Debug顯示text內容
        //reader.Close(); //關閉讀取text檔案

        TextLines = File.ReadAllLines(Path);
        TextScoreLines.Clear();
        TextNameLines.Clear();
        for (int i = 0; i < TextLines.Length; i++)
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
    }

    //重新遊戲
    public void Regame()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
    public void NextGame()
    {
        if(LevelID-Staticvar.ClickLevelID==1)
        {
            LevelID++;//增加一關
            PlayerPrefs.SetInt(LevelAimScore, int.Parse(TextScoreLines[LevelID - 1]));//儲存下一關的目標得分
                                                                                      //清除文字檔案
            DeleteTxt();
            //將關卡數儲存到文字檔案
            WriteString();
            //重新進入遊戲場景
        }
        else
        {
            Staticvar.ClickLevelID++;
            PlayerPrefs.SetInt(LevelAimScore, int.Parse(TextScoreLines[Staticvar.ClickLevelID]));
        }

        Application.LoadLevel(Application.loadedLevel);
    }
    public void DeleteTxt()
    {
        string path = "Assets/Resources/LevelID.txt";
        File.WriteAllText(path, string.Empty);
    }
    public void WriteString()
    {
        string path = "Assets/Resources/LevelID.txt";
        StreamWriter writer = new StreamWriter(path, true); //開啟文字檔
        writer.WriteLine(LevelID + "");//寫入關卡的ID
        writer.Close();//關閉文字檔
    }
    public void BackMenu()
    {
        if(LevelID-Staticvar.ClickLevelID==1)
        {
            LevelID++;//增加一關
            PlayerPrefs.SetInt(LevelAimScore, int.Parse(TextScoreLines[LevelID - 1]));//儲存下一關的目標得分
            DeleteTxt();
            WriteString();//將關卡數儲存到文字檔案
        }
        else
        {
            Staticvar.ClickLevelID++;
            PlayerPrefs.SetInt(LevelAimScore, int.Parse(TextScoreLines[Staticvar.ClickLevelID]));
        }

        Application.LoadLevel("Menu");
    }
}
