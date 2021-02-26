using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Movie : MonoBehaviour
{
    [Header("擺放影片物件")]
    public VideoPlayer MovieObject;
    //要等待一段時間後再回來檢查影片是否播放完畢
    bool isCheck;
    [Header("下一個關卡名稱")]
    public string SceneName;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitTime());
        //程式協同，可自己指定在哪行程式斷點停止多少時間，其餘程式可繼續執行
    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(1f) ;
        //程式在此行等待一秒鐘後再往下執行
        isCheck = true;
        //可以開始檢查影片是否播放完畢
    }
    // Update is called once per frame
    void Update()
    {
        //MovieObject.isPlaying=影片正在播放
        //!MovieObject.isPlaying=已經播放完畢
        if (!MovieObject.isPlaying && isCheck)
        {
            Application.LoadLevel(SceneName);
        }
    }
    public void NextScene(string SceneName)
    {
        Application.LoadLevel(SceneName);
    }
}
