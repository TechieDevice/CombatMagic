using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptHealing : MonoBehaviour
{

    scriptGame sgame;
    Ray ray;
    RaycastHit hitCard;
    RaycastHit hitTarget;
    private bool Target;
    private string num;

    void Start()
    {
        sgame = GameObject.Find("server").GetComponent<scriptGame>();
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
            if ((Input.GetMouseButtonUp(0)) & (Target == true) & ((sgame.playerMana < 4) | (sgame.playerFrost != 0)))
            {
                if ((hitCard.transform.gameObject.name == gameObject.name) & ((gameObject.name == "0") | (gameObject.name == "1") | (gameObject.name == "2") | (gameObject.name == "3") | (gameObject.name == "4")))
                {
                    hitCard.transform.position = new Vector3(hitCard.transform.position.x, hitCard.transform.position.y - 0.4f, hitCard.transform.position.z + 1.2f);
                    Target = false;
                }
            }
            if (Input.GetMouseButtonUp(0) & (Target == true) & (sgame.playerMana > 3) & (sgame.playerFrost == 0))
            {
                if ((hitCard.transform.gameObject.name == gameObject.name) & ((gameObject.name == "0") | (gameObject.name == "1") | (gameObject.name == "2") | (gameObject.name == "3") | (gameObject.name == "4")))
                {
                    for (int i1 = 0; i1 < 5; i1++)
                    {
                        num = i1.ToString();
                        if (hitCard.transform.gameObject.name == num)
                        {
                            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                            if (Physics.Raycast(ray, out hitTarget))
                            {
                                if (hitTarget.transform.gameObject.name == "Board")
                                {
                                    sgame.playerHealth = sgame.playerHealth + 6;
                                    sgame.HealthPlayer.text = sgame.playerHealth.ToString();
                                    sgame.playerFire = 0;
                                    sgame.playerMana = sgame.playerMana - 4;
                                    sgame.playerHandCards[i1] = null;
                                    sgame.ManaP.text = sgame.playerMana.ToString();
                                    Destroy(hitCard.transform.gameObject);
                                    Target = false;
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
