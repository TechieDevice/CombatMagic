using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptFrost : MonoBehaviour
{

    scriptGame sgame;
    Ray ray;
    RaycastHit hitCard;
    RaycastHit hitTarget;
    private bool Target;
    private string num;
    private string num1;
    private bool x;
    private int ni;

    void Start()
    {
        sgame = GameObject.Find("server").GetComponent<scriptGame>();
        x = false;
    }


    void Update()
    {
        if ((sgame.player1turn == true) & (sgame.reload == false))
        {
            if (Input.GetMouseButtonDown(0))
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hitCard))
                {
                    Target = true;
                    if ((hitCard.transform.gameObject.name != "Board") & (hitCard.transform.gameObject.name == gameObject.name) & ((gameObject.name == "0") | (gameObject.name == "1") | (gameObject.name == "2") | (gameObject.name == "3") | (gameObject.name == "4")))
                    {
                        hitCard.transform.position = new Vector3(hitCard.transform.position.x, hitCard.transform.position.y + 0.4f, hitCard.transform.position.z - 1.2f);
                    }
                }
            }
            if (Input.GetMouseButtonUp(0) & (Target == true) & (sgame.playerMana < 3) & (sgame.playerMana < 3))
            {
                if ((hitCard.transform.gameObject.name == gameObject.name) & ((gameObject.name == "0") | (gameObject.name == "1") | (gameObject.name == "2") | (gameObject.name == "3") | (gameObject.name == "4")))
                {
                    hitCard.transform.position = new Vector3(hitCard.transform.position.x, hitCard.transform.position.y - 0.4f, hitCard.transform.position.z + 1.2f);
                    Target = false;
                }
            }
            if (Input.GetMouseButtonUp(0) & (Target == true) & (sgame.playerMana > 2))
            {
                if ((hitCard.transform.gameObject.name == gameObject.name) & ((gameObject.name == "0") | (gameObject.name == "1") | (gameObject.name == "2") | (gameObject.name == "3") | (gameObject.name == "4")))
                {
                    for (int i1 = 0; i1 < 5; i1++)
                    {
                        num1 = i1.ToString();
                        if (hitCard.transform.gameObject.name == num1)
                        {
                            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                            if (Physics.Raycast(ray, out hitTarget))
                            {
                                if (hitTarget.transform.gameObject.name == "Board")
                                {
                                    sgame.playerMana = sgame.playerMana - 3;
                                    sgame.ManaP.text = sgame.playerMana.ToString();
                                    sgame.playerHandCards[i1] = null;

                                    if (sgame.enemyShield == 0)
                                    {
                                        if ((sgame.enemyMana > 1) & (sgame.enemyFrost == 0))
                                        {
                                            for (int i = 0; i < 5; i++)
                                            {
                                                if (sgame.enemyHandCards[i] != null)
                                                {
                                                    if (sgame.enemyHandCards[i].transform.gameObject.name == sgame.cards[6].transform.gameObject.name)
                                                    {
                                                        ni = i + 5;
                                                        num = ni.ToString();
                                                        Instantiate(sgame.enemyHandCards[i], new Vector3(2, 1, -4), sgame.enemyHandCards[i].transform.rotation).gameObject.name = num;
                                                        sgame.enemyMana = sgame.enemyMana - 2;
                                                        sgame.ManaE.text = sgame.enemyMana.ToString();
                                                        sgame.enemyHandCards[i] = null;
                                                        i = i + 5;
                                                        num = i.ToString();
                                                        Destroy(GameObject.Find(num));
                                                        i = 5;
                                                        x = false;
                                                    }
                                                    else
                                                    {
                                                        x = true;
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            x = true;
                                        }
                                    }
                                    else
                                    {
                                        x = true;
                                    }

                                    if (x == true)
                                    {
                                        if (sgame.enemyShield > 0)
                                        {
                                            sgame.enemyShield = sgame.enemyShield - 1;
                                        }
                                        else
                                        {
                                            sgame.enemyHealth = sgame.enemyHealth - 5;
                                            sgame.HealthEnemy.text = sgame.enemyHealth.ToString();
                                            sgame.EIce.SetActive(true);
                                            sgame.enemyFrost = 1;
                                        }

                                    }

                                    Target = false;
                                    Destroy(hitCard.transform.gameObject);
                                }
                                else
                                {
                                    hitCard.transform.position = new Vector3(hitCard.transform.position.x, hitCard.transform.position.y - 0.4f, hitCard.transform.position.z + 1.2f);
                                }
                            }
                            else
                            {
                                hitCard.transform.position = new Vector3(hitCard.transform.position.x, hitCard.transform.position.y - 0.4f, hitCard.transform.position.z + 1.2f);
                            }
                        }
                    }
                }
            }
        }
    }
}
