using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Scr_Control : MonoBehaviour
{
    public float speed_player = 10;
    public GameObject player;
    public GameObject shoot;
    public int Score_total = 0;
    public int life = 5;
    public GameObject shield;
    public float Px;
    public float Py;
    public float contador = 0;
    public float time1shoot = 0.2f;
    private int numLife;
    public GameObject damage;
    public bool cond;
    public float timeDamage = 0;
    private Animator ChangeColor;
    public int MaiorScore;

    public void Contador()//Conta tempo do shield
    {
        contador += Time.deltaTime; 
    }
    void Start()
    {
        numLife = life;
        ChangeColor = GetComponent<Animator>();
    }
    public void Damage(int tag)
    {
        if (ChangeColor.GetInteger("Cond") == 0 && tag == -1)
        {
            ChangeColor.SetInteger("Cond", 2);
            life--;
        }else if (ChangeColor.GetInteger("Cond") == 1 && tag == -1)
        {
            ChangeColor.SetInteger("Cond", 3);
            life--;
        }else if(ChangeColor.GetInteger("Cond") == 0 && tag == 0 ) {
            ChangeColor.SetInteger("Cond", 2);
            life--;
        }
        else if(ChangeColor.GetInteger("Cond") == 1 && tag == 1) {
            ChangeColor.SetInteger("Cond", 3);
            life--;
        }
        timeDamage = 0;

    }
    void Update()
    {
        //Player Move
        Px = transform.position.x;
        Py = transform.position.y;
        //Score_total += GetComponent<Scr_Enemy>().Score + GetComponent<Scr_Enemy2>().Score;
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        transform.Translate(new Vector2(
            x * Time.deltaTime * speed_player,
            y * Time.deltaTime * speed_player)
            );

        //Camera limit
        var leftBorder = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).x;
        var rightBorder = Camera.main.ViewportToWorldPoint(new Vector2(1, 0)).x;
        var topBorder = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).y;
        var bottomBorder = Camera.main.ViewportToWorldPoint(new Vector2(0, 1)).y;
        transform.position = new Vector2(
            Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
            Mathf.Clamp(transform.position.y, topBorder + 2, bottomBorder - 2)
            );

        if (transform.position.x == leftBorder)
        {
            transform.position = new Vector2(-transform.position.x, transform.position.y);
        }
        else if (transform.position.x == rightBorder)
        {
            transform.position = new Vector2(-transform.position.x, transform.position.y);
        }
        if (Input.GetKey(KeyCode.Space))//SHOOT
        {
            time1shoot += Time.deltaTime;
            if (time1shoot > 0.1f){
                Instantiate(shoot, new Vector2(transform.position.x, transform.position.y + 1.81f), Quaternion.identity);
                GameObject.Find("Controlador").GetComponent<Scr_MusicControl>().Lazer();
                time1shoot = 0;
            }
        }
        if (life <= 0){ // if no life
            SceneManager.LoadScene(2);
            MaiorScore = GameObject.Find("Score").GetComponent<Scr_Score>().score;
            if (MaiorScore > PlayerPrefs.GetInt("recorde"))
                PlayerPrefs.SetInt("recorde", MaiorScore);
            Destroy(gameObject);
        }
        if (Input.GetKeyDown(KeyCode.C ) && contador == 0)//SHIELD
        {
            Instantiate(shield, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        }
        if(contador>0)
            contador += Time.deltaTime;
        if (contador >= 3)//ZERA CONTADOR DO SHIELD
            contador = 0;

        //Troca cor da nave
        if (Input.GetKeyDown(KeyCode.X))
            ChangeColor.SetInteger("Cond", 1);
        
        if (Input.GetKeyDown(KeyCode.Z))
            ChangeColor.SetInteger("Cond", 0);

        if (ChangeColor.GetInteger("Cond") == 2){
            timeDamage += Time.deltaTime;
            if (timeDamage > 0.2) {
                ChangeColor.SetInteger("Cond", 0);
                timeDamage = 0;
            }
    }
        if (ChangeColor.GetInteger("Cond") == 3){
            Debug.Log("DAMAGE É TRUE");
            timeDamage += Time.deltaTime;
            if (timeDamage > 0.2) {
                ChangeColor.SetInteger("Cond", 1);
                timeDamage = 0;
                }
        }


    }
}
