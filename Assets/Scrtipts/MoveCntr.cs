using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitController : MonoBehaviour {

    public GameCntr GameCntr;// связь с скриптом GameCntr
    public GameObject stump;//  префаб пня. Нужен, чтобы спавнить его при смерти дерева
//    public string type; // Тип дерева
//    public Animation hitTreeAnim;

 //   public static System.Random rnd = new System.Random();//создаем объект класса рандом из библиотек sistem т.к. у юнити он всосный
 //   private int typeNumber;// номет типа дерева 

    // Use this for initialization
    void Start () {
 //       hitTreeAnim = GetComponent<Animation>();
        GetComponent<CapsuleCollider2D>().enabled = false;// убираем коллайдер при спавне, чтобы нельзя было бить правое дерео
 //       typeNumber = rnd.Next(1, 4);// рандомим номер типа дерева
 /*       switch (typeNumber)// обрабатываем то, что натворил рандом
        {
            case 1://Oak
                type = "Oak";
                Hp = 110;
                GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Trees/Oak");//подгружаем спрайт дуба\сакуры\березы
                break;
            case 2://Sakura
                type = "Sakura";
                Hp = 90;
                GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Trees/Sakura");
                break;
            case 3://Broch
                type = "Brich";
                Hp = 70;
                GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Trees/Brich");
                break;
            default:
                type = "Brich";
                Hp = 70;
                GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Trees/Brich");
                break;

        }
*/
    }
	
	// Update is called once per frame
	void Update () {

       if(GameCntr.isDead)// при смерти среднего/текущего/main дерева
        {
            transform.Translate(GameCntr.moveSpeed * Vector2.left * Time.deltaTime);//говорим дереву(уже правому) двигаться влево со скоростью moveSpeed    
        }

       if (transform.position.x < 0)// когда правое дерево встает в центр (условно становится среднем/текущем/main )
        {
            transform.position = new Vector3(0,0,0);//кидаем его в центр сцены
//            transform.Translate(Vector2.zero);//говорим ему не двигаться (на всякий)
            GetComponent<CapsuleCollider2D>().enabled = true;// включаем коллайдер, чтобы его можно было рубить 
            GameCntr.isDead = false;// сообщаем, что main дерево живо
        }
		
	}

    /*  void OnMouseDown()// метод обрабатывает клик по коллайдеру дерева
      {
          //       Hp -= 10;

                 hitTreeAnim.Play("onHitTree.anim");

                 if (Hp == 0)// ХЭПЭ равно нулю- фактическая смерть
                 {
                     switch (typeNumber)
                     {
                         case 1:
                             GameCntr.Wood += 15;// добавляем дерево
                             break;
                         case 2:
                             GameCntr.Wood += 10;// добавляем дерево
                             break;
                         case 3:
                             GameCntr.Wood += 8;// добавляем дерево
                             break;
                     }

                     GameCntr.Wood += 10;// добавляем дерево

                     Instantiate(this.gameObject, new Vector3(12, 0, 0), Quaternion.identity);//спавним новое правое дерево

                     Instantiate(stump,new Vector3(0,0,0), Quaternion.identity); //спавним пень в центре сцены

                     GameCntr.isDead = true;//говорим, что main дерево мертво

                     Destroy(this.gameObject);//уничтожаем себя (main дерево)
                 }

                 HpText.text = "HP: " + Hp;
                 WoodText.text = "Wood: " + GameCntr.Wood;


             }
             */
}
