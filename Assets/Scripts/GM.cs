using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour
{
    public enum SelectDevice
    {
        Keyboard,
        Mobile,
        PCUI
    }
    [Header("選擇輸入裝置")]
    public SelectDevice Select_Device;
    [Header("飛機移動速度")]
    public float Speed;
    [Header("Player")]
    public GameObject Player;
    [Header("tra")]
    public float MinX, MaxX, MinY, MaxY;

    [Header("多久時間產生一隻敵機")]
    public float CreateTimer;
    [Header("設定敵機出現的y位置數值")]
    public float YPpos;
    [Header("產生的敵機")]
    public GameObject Enemy;

    [Header("打死敵機加的分數")]
    public int AddScore;
    public int TotalScore;
    [Header("分數的文字")]
    public Text TotalScoreText;



    bool IsJoystick, CanJoystick;//判斷是否選到搖桿模式
    void Start()
    { 
        InvokeRepeating("CreateEnemy",CreateTimer,CreateTimer);
    }

    void CreateEnemy()
    {
        //設定敵機產出的位置
        Vector3 CreatePosition = new Vector3(Random.Range(MinX, MaxX), YPpos,0f);
        //產出敵機
        GameObject Prefab=Instantiate(Enemy, CreatePosition, transform.rotation)as GameObject;
        //動態生成出來的飛機轉角度
        Prefab.transform.eulerAngles = new Vector3(0, 0, 180);
    }

    // Update is called once per frame
    void Update()
    {
        switch (Select_Device)
        {
            #region 鍵盤控制
            case SelectDevice.Keyboard:
                //當按下Ａ鍵
                /*if (Input.GetKey(KeyCode.A))
                {
                    //Vector3.left(-1,0,0) Vector3.right(1,0,0) Vector3.up(0,1,0)
                    Player.transform.Translate(Vector3.left * Speed * Time.deltaTime);
                }*/

                Player.transform.Translate(Input.GetAxis("Horizontal") * Speed * Time.deltaTime, Input.GetAxis("Vertical") * Speed * Time.deltaTime,0);
                break;
            #endregion
            #region 手機控制
            case SelectDevice.Mobile:
                Player.transform.Translate(Input.acceleration.x* Speed * Time.deltaTime, Input.acceleration.y* Speed * Time.deltaTime, 0);
                break;
            #endregion
            #region PC搖桿控制
            case SelectDevice.PCUI:
                IsJoystick = true;
                break;
            #endregion

        }
        /* 簡易限制寫法
         * if (Player.transform.position.x < MinX)
        {
            Player.transform.position = new Vector3(MinX, Player.transform.position.y, Player.transform.position.z);
        }*/

        Player.transform.position = new Vector3(Mathf.Clamp(Player.transform.position.x, MinX, MaxX), Mathf.Clamp(Player.transform.position.y, MinY, MaxY), Player.transform.position.z);
        //Mathf為內建
    }

    public void AddTotalScore()
    {
        TotalScore += AddScore;
        Debug.Log("Score:" + TotalScore);
        TotalScoreText.text = "Score:" + TotalScore;
    }
    public void IsUsingJoystick()
    {
        CanJoystick = true;
    }
    public void IsntUsingJoystick()
    {
        CanJoystick = false;
    }
    public void UsingJoyStick(Vector3 pos)
    {
        if(CanJoystick&&IsJoystick)
        {
            Player.transform.Translate(pos.x * Speed * Time.deltaTime, pos.y * Speed * Time.deltaTime, 0, Space.World);
        }
    }
}
