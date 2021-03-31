using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class scriptGame : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject Player;
    public GameObject PIce;
    public GameObject EIce;
    public GameObject PShield;
    public GameObject EShield;
    public Material Shield2;
    public Material Shield1;
    public GameObject EFire;
    public GameObject PFire;
    public Text ManaP;
    public Text turnButton;
    public Text ManaE;
    public Text HealthPlayer;
    public Text HealthEnemy;
    public GameObject[] cards;
    public GameObject[] playerHandCards;
    public GameObject[] enemyHandCards;
    private int rand;
    Ray ray;
    RaycastHit hitcard;
    RaycastHit hitboard;
    private string num;
    public int enemyHealth;
    public int enemyMana;
    public int playerMana;
    public int playerHealth;
    public int play;
    public int playerShield;
    public int enemyShield;
    public int playerFire;
    public int enemyFire;
    public int playerFrost;
    public int enemyFrost;
    private bool Target;
    public bool player1turn;
    public bool reload;
    public int defend;
    public float enemyturn;


    public void Button()
    {
        if (player1turn == true)
        {
            if ((reload == true) & (player1turn == true))
            {
                if (playerFire > 0)
                {
                    playerFire = playerFire - 1;
                    playerHealth = playerHealth - 2;
                }
                playerFrost = 0;
                PIce.SetActive(false);
                HealthPlayer.text = playerHealth.ToString();
                for (int i = 0; i < 5; i++)
                {
                    if (playerHandCards[i] == null)
                    {
                        rand = Random.Range(0, 7);
                        playerHandCards[i] = cards[rand];
                        num = i.ToString();
                        Instantiate(playerHandCards[i], new Vector3(-2 + i * 1.01f, -0.5f, -5), playerHandCards[i].transform.rotation).gameObject.name = num;
                    }
                }
                turnButton.text = ("пропустить"); ;
                enemyMana = 8;
                ManaE.text = enemyMana.ToString();
                player1turn = false;
                enemyturn = 1;
                reload = false;
            }

            if ((reload == false) & (player1turn == true))
            {
                reload = true;
                turnButton.text = ("конец хода");
            }
        }

        if (defend == 1)
        {
            defend = 0;
        }
    }


    void Start ()
    {
        player1turn = true;
        playerHealth = 25;
        playerMana = 8;
        playerShield = 0;
        playerFire = 0;
        playerFrost = 0;
        enemyHealth = 25;
        enemyMana = 8;
        enemyShield = 0;
        enemyFire = 0;
        enemyFrost = 0;
        reload = false;
        defend = 3;
        PIce.SetActive(false);
        EIce.SetActive(false);
        PShield.SetActive(false);
        EShield.SetActive(false);
        PFire.SetActive(false);
        EFire.SetActive(false);

        for (int i = 0; i < 5; i++)
        {
            rand = Random.Range(0, 7);
            playerHandCards[i] = cards[rand];
            num = i.ToString();
            Instantiate(playerHandCards[i], new Vector3(-2 + i * 1.01f, -0.5f, -5), playerHandCards[i].transform.rotation).gameObject.name = num;
        }

        for (int i = 0; i < 5; i++)
        {
            rand = Random.Range(0, 7);
            enemyHandCards[i] = cards[rand];
        }
    }

    void Update()
    {
        if (enemyHealth < 1)
        {
            Destroy(Enemy);
            Application.LoadLevel("Menu");
        }
        if (playerHealth < 1)
        {
            Destroy(Player);
            Application.LoadLevel("Menu");
        }
        
        if (playerShield == 0)
        {
            PShield.SetActive(false);
        }

        if (enemyShield == 0)
        {
            EShield.SetActive(false);
        }

        if(playerShield == 1)
        {
            PShield.GetComponent<Renderer>().material = Shield1;
            PShield.SetActive(true);
        }

        if (enemyShield == 1)
        {
            EShield.GetComponent<Renderer>().material = Shield1;
            EShield.SetActive(true);
        }

        if (playerShield == 2)
        {
            PShield.GetComponent<Renderer>().material = Shield2;
            PShield.SetActive(true);
        }

        if (enemyShield == 2)
        {
            EShield.GetComponent<Renderer>().material = Shield2;
            EShield.SetActive(true);
        }

        if (playerFire == 0)
        {
            PFire.SetActive(false);
        }

        if (enemyFire == 0)
        {
            EFire.SetActive(false);
        }

        if (playerFire == 1)
        {
            PFire.SetActive(true);
            PFire.transform.position = new Vector3(PFire.transform.position.x, -3.5f, PFire.transform.position.z);
        }

        if (enemyFire == 1)
        {
            EFire.SetActive(true);
            EFire.transform.position = new Vector3(EFire.transform.position.x, -3.5f, EFire.transform.position.z);
        }

        if (playerFire == 2)
        {
            PFire.SetActive(true);
            PFire.transform.position = new Vector3(PFire.transform.position.x, -3, PFire.transform.position.z);
        }

        if (enemyFire == 2)
        {
            EFire.SetActive(true);
            EFire.transform.position = new Vector3(EFire.transform.position.x, -3, EFire.transform.position.z);
        }

        if (playerHealth > 25)
        {
            playerHealth = 25;
            HealthPlayer.text = "25";
        }
        if (enemyHealth > 25)
        {
            enemyHealth = 25;
            HealthEnemy.text = "25";
        }
        if (player1turn == true)
        {

            if (reload == true)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out hitcard))
                    {
                        Target = true;
                        if (hitcard.transform.gameObject.name != "Board")
                        {
                            hitcard.transform.position = new Vector3(hitcard.transform.position.x, hitcard.transform.position.y + 0.4f, hitcard.transform.position.z - 1.2f);
                        }
                    }
                }
                if (Input.GetMouseButtonUp(0) & (Target == true))
                {
                    for (int i = 0; i < 5; i++)
                    {
                        num = i.ToString();
                        if (hitcard.transform.gameObject.name == num)
                        {
                            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                            if (Physics.Raycast(ray, out hitboard))
                            {
                                if (hitboard.transform.gameObject.name == "Board")
                                {
                                    playerHandCards[i] = null;
                                    num = i.ToString();
                                    Destroy(GameObject.Find(num));
                                    Target = false;
                                }
                                else
                                {
                                    hitcard.transform.position = new Vector3(hitcard.transform.position.x, hitcard.transform.position.y - 0.4f, hitcard.transform.position.z + 1.2f);
                                }
                            }
                            else
                            {
                                hitcard.transform.position = new Vector3(hitcard.transform.position.x, hitcard.transform.position.y - 0.4f, hitcard.transform.position.z + 1.2f);
                            }
                        }
                    }
                }
            }
        }
    }
}

