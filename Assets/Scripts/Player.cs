using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("子彈物件")]
    public GameObject Bullet;
    [Header("子彈生成的位置")]
    public GameObject CreateObject;
    [Header("設定多少時間產生一顆子彈")]
    public float SetTimer;
    float ScriptTimer;
    [Header("發射子彈聲音")]
    public AudioSource ShootAudio;
    [Header("玩家總血量")]
    public float PlayerTotalHP;
    [Header("傷害玩家血量")]
    public float HurtPlayerHP;
    float ScriptHP; //程式中計算玩家血量
    [Header("玩家血量血條")]
    public Image PlayerHPBar;


    [Header("遊戲結束的UI")]
    public GameObject GameOverObject;

    // Start is called before the first frame update
    void Start()
    {
        //遊戲開始持續以設定的秒數呼叫function
        //InvokeRepeating(function名稱,第一次多少時間後呼叫function(秒為單位),固定多少時間後呼叫function(秒為單位)
        InvokeRepeating("CreateBullet", SetTimer, SetTimer);
        ScriptHP = PlayerTotalHP;
        Time.timeScale = 1; //整體遊戲時間復原
    }
    void CreateBullet()
    {
        Instantiate(Bullet, CreateObject.transform.position, CreateObject.transform.rotation);
        ShootAudio.Play();

    }

    // Update is called once per frame
    void Update()
    {
        /*ScriptTimer += Time.deltaTime;
        if(ScriptTimer>=SetTimer)
        {
            //動態生成
            Instantiate(Bullet, CreateObject.transform.position, CreateObject.transform.rotation);
            ScriptTimer = 0;
        }*/
        
    }

    public void HurtPlayer() //如果敵機子彈打到玩家就呼叫此function進行扣血
    {
        ScriptHP -= HurtPlayerHP;
        ScriptHP = Mathf.Clamp(ScriptHP, 0, PlayerTotalHP);
        //程式中玩家總血量不能為負值，所以透過Mathf.Clamp限制數值介於0-PlayerTotalHP之間
        PlayerHPBar.fillAmount = ScriptHP / PlayerTotalHP;
        //將玩家的血量換算成0-1之間的小數帶入血條圖中
        if(ScriptHP<=0)
        {
            GameOverObject.SetActive(true); //開啟GameOver視窗
            Time.timeScale = 0; //整體遊戲時間暫停
        }
    }
}
