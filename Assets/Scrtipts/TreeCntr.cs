using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCntr : MonoBehaviour {

   // public bool canBGMove = false;
    private GameObject[] blocksArr;// массив блоков
    public BGCntr bGCntr;
    private List<GameObject> blockList;
    private int quantityBlocks;//число блоков 
    private int actualBlock = 1;// актуальный блок
    private float position = 0f;
    public GameObject Block;
    public GameObject Crone;
    public GameObject Roots;
    public int hp=2;
    public Animation hitTreeAnim;
    public GameCntr GameCntr;// связь с скриптом GameCntr
    public GameObject stump;//кидаем сюда пень
    public GameObject tree;//префаб дерева
    private Transform thisTransform;//для кеширования transform
    
    // Use this for initialization

    private void Awake()
    {
        hitTreeAnim = GetComponent<Animation>();//кешируем анимацию
        thisTransform = this.GetComponent<Transform>();//кешируем
        //canBGMove = false;
        
    }


    void Start () {
   
        GetComponent<CapsuleCollider2D>().enabled = false;// убираем коллайдер при спавне, чтобы нельзя было бить правое дерео
               
        quantityBlocks = Random.Range(1, 10) + 2;// задаем случайное число, отвечающее за количество блоков
        blocksArr = new GameObject[quantityBlocks];// инициализируем массив блоков 

        blocksArr[0] = Instantiate(Roots, new Vector3(thisTransform.position.x, thisTransform.position.y + position), Quaternion.identity);//создаем корни
        blocksArr[0].transform.parent = thisTransform;// делаем дерево родителем корней, чтобы менять позицию корней вместе с позицией дерева 

        

        for (int i = 1; i < quantityBlocks - 1; i++)// создаем блокки 
        {
            position += 1.5f;
            blocksArr[i] = Instantiate(Block, new Vector3(thisTransform.position.x, thisTransform.position.y + position), Quaternion.identity);
            blocksArr[i].transform.parent = transform;// делаем дерево родителем блока
        }

        position += 1.5f;

        blocksArr[quantityBlocks - 1] = Instantiate(Crone, new Vector3(thisTransform.position.x, thisTransform.position.y + position), Quaternion.identity);// создаем крону
        blocksArr[quantityBlocks - 1].transform.parent = thisTransform;// делаем дерево родителем кроны

        position = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (GameCntr.isDead)// при смерти среднего/текущего/main дерева
        {
            thisTransform.Translate(GameCntr.moveSpeed * Vector2.left * Time.deltaTime);//говорим дереву(уже правому) двигаться влево со скоростью moveSpeed    
        }

        if (transform.position.x < 0)// когда правое дерево встает в центр (условно становится среднем/текущем/main )
        {
            GameCntr.canBGMove = false;
            thisTransform.position = new Vector3(0, -4, 0);//кидаем его в центр сцены
            GetComponent<CapsuleCollider2D>().enabled = true;// включаем коллайдер, чтобы его можно было рубить 
            GameCntr.isDead = false;// сообщаем, что main дерево живо
        }

    }

    private void OnMouseDown()
    {
        hp -= 1;

        hitTreeAnim.Play("onHitTree");

        if (hp == 0)
        {
            GameCntr.OnDeath();

            Destroy(blocksArr[actualBlock]);
            actualBlock++;
            hp = 2;
            
            

            if (actualBlock == quantityBlocks)
            {

                //bGCntr.canIMove = true; // запускаем анимацию BG

                // bGCntr.SetCanIMove(true);
                GameCntr.canBGMove = true;
               // GetComponent<BGCntr>().canIMove = true;

                foreach (GameObject block in blocksArr)
                {
                    Destroy(block);
                }                                                 //////////Делаем эту херню, чтобы оно не спавнило по несколько лишних крон и корней

                thisTransform.DetachChildren();

                Instantiate(tree , new Vector3(12, -4, 0), Quaternion.identity);//спавним новое правое дерево

                Instantiate(stump, new Vector3(0, -4, 0), Quaternion.identity); //спавним пень в центре сцены



                GameCntr.isDead = true;//говорим, что main дерево мертво

                Destroy(this.gameObject);//уничтожаем себя (main дерево)

                
            }

            for (int i = actualBlock; i < quantityBlocks; i++)
            {
                 blocksArr[i].transform.position =new Vector3(blocksArr[i].transform.position.x, blocksArr[i].transform.position.y-1.5f,0);
            }

        }
    }
}
