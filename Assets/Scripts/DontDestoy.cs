using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestoy : MonoBehaviour
{
    private void Awake()
    {
        //DontDestroyOnLoad切換場景不要把物件刪除（物件名稱）
        //gameObject=程式碼掛在哪個物件上就代表該物件
        DontDestroyOnLoad(gameObject);
    }
}
