using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private Rigidbody2D rb;
    void Start()
    {
        System.Random r = new System.Random();
        rb = GetComponent<Rigidbody2D>();
        int rl = r.Next(1, 3);
        if(rl == 0)
        {
            rb.velocity = new Vector2(4f, 3f);
        }
        else
        {
            rb.velocity = new Vector2(-4f, 3f);
        }
    }

    
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            SoundManage.PlayPickCoinSound();
            System.Random random = new System.Random();
            int u = random.Next(5, 10);
            CoinCnt.coin_num += u;
            Destroy(gameObject);
        }
    }
}
