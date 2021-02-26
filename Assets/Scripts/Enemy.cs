using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy多久後自己消滅")]
    public float DeleteTime;
    [Header("移動速度")]
    public float Speed;
    [Header("子彈物件")]
    public GameObject Bullet;
    [Header("子彈生成的位置")]
    public GameObject CreateObject;
    [Header("設定多少時間產生一顆子彈")]
    public float SetTimer;
    float ScriptTimer;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, DeleteTime);
        //敵機多久時間將自己消滅
        InvokeRepeating("CreateBullet", SetTimer, SetTimer);
    }

    void CreateBullet()
    {
        Instantiate(Bullet, CreateObject.transform.position, CreateObject.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Speed * Time.deltaTime);
        //敵機位移
    }
}