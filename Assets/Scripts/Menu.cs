using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//新的Unity場景切換須先加入SceneManagement程式庫
using UnityEngine.UI;
//宣告UI相關變數時，需用到此資料庫

public class Menu : MonoBehaviour
{

    bool isControl;//控制聲音開關
    public Image SoundButton;//聲音按鈕
    WWW localFile;
    Texture texture;

    // Start is called before the first frame update
    private void Start()
    {
        isControl = false;
        AudioListener.pause = isControl;
        //AudioListener.pause = false;整體環境聲音開啟，所有場景都有聲
        //AudioListener.pause = true;整體環境聲音關閉，所有場景都無聲
        /*string path = Application.streamingAssetsPath + "/SoundOpen.png";
        localFile = new WWW(path);//將圖片路徑轉成網址
        texture = localFile.texture;
        SoundButton.sprite = Sprite.Create(texture as Texture2D, new Rect(0, 0, texture.width, texture.height), Vector2.zero);*/
        //透過Sprite.Create帶入圖片
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
    #region 變換場景
    public void NextScene()
    {
        //Debug.Log("Next Scene");
        //跳關卡程式
        //Application.LoadLevel("場景名稱");
        //Application.LoadLevel(0);輸入下一個場景的ID
        //Application.LoadLevel當前場景的名稱
        //Application.LoadLevel(Application.loadedLevel);重新遊戲寫法

        //跳關卡程式（二），可提前加載場景
        //SceneManager.LoadScene("場景名稱");
        //SceneManager.LoadScene(0);輸入下一個場景的ID
        //重新遊戲SceneManager.LoadScene(Application.loadedLevel);

        Application.LoadLevel(1);
      
    }
    #endregion
    #region 關閉程式
    public void CloseAPP()
    {
        Application.Quit();
    }
    #endregion

    public void ControlSound()
    {
        isControl = !isControl;
        AudioListener.pause = isControl;
        if (isControl)
        {
            SoundButton.sprite = Resources.Load<Sprite>("SoundOpen");
            /*string path = Application.streamingAssetsPath + "/SoundOpen.png";//讀取streamingAssets資料夾內的圖片名稱
            localFile = new WWW(path);//將圖片路徑轉換成網址
            texture = localFile.texture;
            SoundButton.sprite = Sprite.Create(texture as Texture2D, new Rect(0, 0, texture.width, texture.height), Vector2.zero);*/
            //透過Sprite.Create帶入圖片
        }
        else
        {
            SoundButton.sprite = Resources.Load<Sprite>("SoundClose");
            /*string path = Application.streamingAssetsPath + "/SoundClose.png";
            localFile = new WWW(path);
            texture = localFile.texture;
            SoundButton.sprite = Sprite.Create(texture as Texture2D, new Rect(0, 0, texture.width, texture.height), Vector2.zero);*/
        }
    }
}
