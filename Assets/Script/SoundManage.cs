using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManage : MonoBehaviour
{
    public static AudioSource AudioSource;
    public static AudioClip pick_coin;
    public static AudioClip boss_common_attack;
    public static AudioClip player_attack;
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        pick_coin = Resources.Load<AudioClip>("pick_coin");
        boss_common_attack = Resources.Load<AudioClip>("CANNON_ATTACK_01");
        player_attack = Resources.Load<AudioClip>("player_attack");
    }
    void Update()
    {
        
    }
    public static void PlayPlayerAttackSound()
    {
        AudioSource.PlayOneShot(player_attack);
    }
    public static void PlayBossAttackSound()
    {
        AudioSource.PlayOneShot(boss_common_attack);
    }
    public static void PlayPickCoinSound()
    {
        AudioSource.PlayOneShot(pick_coin);
    }
}
