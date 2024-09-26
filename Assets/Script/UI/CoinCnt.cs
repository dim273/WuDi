using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCnt : MonoBehaviour
{
    public static int coin_num;
    public Text coin_cnt;
    void Start()
    {
        coin_num = 5;
        coin_cnt.text = coin_num.ToString();
    }
    void Update()
    {
        coin_cnt.text = coin_num.ToString();
    }
}
