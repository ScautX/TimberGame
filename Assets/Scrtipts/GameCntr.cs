﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCntr : MonoBehaviour {

    public HitController Tree;//связь скриптов
    public GameObject firstTree;// первое дерево необходимо, чтобы включить коллайдер при открытии сцены
    public bool isDead = false;// говорим, что все живы здоровы 
    public int Wood = 0;
    public int moveSpeed;
    public GameObject desParticle;
    private ParticleSystem PS;
    // Use this for initialization
    void Start () {
        firstTree.GetComponent<CapsuleCollider2D>().enabled = true;//включаем первому дерево коллайдер
        PS = desParticle.GetComponent<ParticleSystem>();
	}

    // Update is called once per frame

    public void OnDead()
    {
        
        desParticle.GetComponent<ParticleSystem>().Play();
    }
}
