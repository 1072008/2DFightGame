using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("子彈多久後自己消滅")]
    public float DeleteTime;
    [Header("移動速度")]
    public float Speed;
    [Header("爆炸聲音")]
    public AudioSource BombAudio;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, DeleteTime);
        //沒打到敵機狀態下多久時間將自己消滅
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Speed * Time.deltaTime);
        //子彈位移
    }
    //子彈打到敵機
    public void OnTriggerEnter2D(Collider2D hit)
        //如果子彈為玩家的子彈，並且子彈攻擊到敵機
    {
        if (hit.GetComponent<Collider2D>().tag == "Enemy" && gameObject.tag == "PlayerBullet")
        {
            Camera.main.GetComponent<GM>().AddTotalScore();
            BombAudio.Play();
            Destroy(hit.gameObject);
            //敵機消失
            Destroy(gameObject,0.1f);
            //玩家子彈消失
        }
        if(hit.GetComponent<Collider2D>().tag=="EnemyBullet"&&gameObject.tag=="PlayerBullet")
        {
            Destroy(hit.gameObject);
            Destroy(gameObject);
        }
        if(hit.GetComponent<Collider2D>().tag=="Player"&&gameObject.tag=="EnemyBullet")
        {
            hit.GetComponent<Player>().HurtPlayer();
            Destroy(gameObject);
        }
    }
}
