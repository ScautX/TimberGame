using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCntr : MonoBehaviour {

  // public BGCntr Tree;//связь скриптов
    public GameObject firstTree;// первое дерево необходимо, чтобы включить коллайдер при открытии сцены
    public bool isDead = false;// говорим, что все живы здоровы 
    public int Wood = 0;
    public int moveSpeed;
    public GameObject deathParticle;
    public bool canBGMove;
    public int[] minionsArr;
    public GameObject[] minionsPrefabs;

    // Use this for initialization
    void Start () {
        firstTree.GetComponent<CapsuleCollider2D>().enabled = true;//включаем первому дерево коллайдер
        minionsArr = new int[3];                                                           //  bGAnim = backGround.GetComponent<Animation>();
        canBGMove = false;
        Spawn();
        
    }


    public void OnDeath()
    {

        Instantiate(deathParticle, new Vector3(0, -1.6f, 0), Quaternion.identity);
    }

    public void Spawn()
    {
        int shiftY = 0;
        
        for (int i = 1 ; i < minionsArr.Length; i++)
        {
            for (int j = 1 ; j < minionsArr[i]; j++)
            {
                Instantiate(minionsPrefabs[i], new Vector2(-6.82f+(0.38f*j), -1.71f + ( shiftY * 0.38f)) , Quaternion.identity);
                if (shiftY == 0)
                {
                    shiftY = 1;
                }
                else
                {
                    shiftY = 0;
                }
            }
        }
    }

    // Update is called once per frame
}
