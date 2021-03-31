using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class scriptEnemy : MonoBehaviour {

    scriptGame sgame;
    scryptTimer timer;
    private string num;
    private int rand;
    private int ni;


    void Start ()
    {
        sgame = GameObject.Find("server").GetComponent<scriptGame>();
        timer = GameObject.Find("server").GetComponent<scryptTimer>();
    }

    void Timer()
    {
        timer.time = 2;
    }

    void Update()
    {
        if (sgame.enemyturn == 1)
        {
            sgame.defend = 3;
            for (int i = 0; i < 5; i++)
            {
                if (sgame.enemyHandCards[i] != null)
                {
                    if (sgame.enemyHandCards[i].transform.gameObject.name == sgame.cards[4].transform.gameObject.name)
                    {
                        if ((sgame.playerHealth < 5) & (sgame.enemyMana > 2))
                        {
                            ni = i + 5;
                            num = ni.ToString();
                            Instantiate(sgame.enemyHandCards[i], new Vector3(2, 1, -4), sgame.enemyHandCards[i].transform.rotation).gameObject.name = num;

                            sgame.defend = 1;

                            sgame.enemyMana = sgame.enemyMana - 3;
                            sgame.ManaE.text = sgame.enemyMana.ToString();
                            sgame.enemyHandCards[i] = null;
                            i = 5;
                        }
                    }
                }
            }
            sgame.enemyturn = 1.5f;
        }


        if (sgame.enemyturn == 1.5f)
        {
            if (sgame.defend == 0)
            {
                sgame.playerHealth = sgame.playerHealth - 4;
                sgame.enemyShield = sgame.enemyShield - 1;
                sgame.HealthPlayer.text = sgame.playerHealth.ToString();
                num = ni.ToString();
                Destroy(GameObject.Find(num));
                sgame.enemyturn = 2;
            }
            if (sgame.defend == 2)
            {
                num = ni.ToString();
                Destroy(GameObject.Find(num));
                sgame.enemyturn = 2;
            }
            if (sgame.defend == 3)
            {
                sgame.enemyturn = 2;
            }
        }


        if (sgame.enemyturn == 2)
        {
            sgame.defend = 3;
            for (int i1 = 0; i1 < 5; i1++)
            {
                for (int i2 = 0; i2 < 5; i2++)
                {
                    if (sgame.enemyHandCards[i1] != null)
                    {
                        if (sgame.enemyHandCards[i1].transform.gameObject.name == sgame.cards[2].transform.gameObject.name)
                        {
                            if (sgame.enemyHandCards[i2] != null)
                            {
                                if (sgame.enemyHandCards[i2].transform.gameObject.name == sgame.cards[1].transform.gameObject.name)
                                {
                                    if ((sgame.playerHealth < 13) & (sgame.playerMana < 2) & (sgame.playerShield == 0) & (sgame.enemyMana > 5))
                                    {
                                        sgame.enemyMana = sgame.enemyMana - 6;
                                        sgame.ManaE.text = sgame.enemyMana.ToString();
                                        sgame.enemyHandCards[i1] = null;
                                        sgame.enemyHandCards[i2] = null;
                                        i1 = i1 + 5;
                                        i2 = i2 + 5;
                                        num = i1.ToString();
                                        num = i2.ToString();
                                        i1 = i1 - 5;
                                        i2 = i2 - 5;
                                        sgame.playerHealth = sgame.playerHealth - 12;
                                        sgame.HealthPlayer.text = sgame.playerHealth.ToString();
                                        sgame.playerFrost = 1;
                                        sgame.PIce.SetActive(true);
                                        sgame.playerFire = 2;
                                        i1 = 5;
                                        i2 = 5;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            sgame.enemyturn = 3;
        }


        if (sgame.enemyturn == 3)
        {
            sgame.defend = 3;
            for (int i = 0; i < 5; i++)
            {
                if (sgame.enemyHandCards[i] != null)
                {
                    if (sgame.enemyHandCards[i].transform.gameObject.name == sgame.cards[1].transform.gameObject.name)
                    {
                        if ((sgame.playerHealth < 6) & (sgame.enemyMana > 2) & (sgame.playerShield == 0))
                        {
                            ni = i + 5;
                            num = ni.ToString();
                            Instantiate(sgame.enemyHandCards[i], new Vector3(2, 1, -4), sgame.enemyHandCards[i].transform.rotation).gameObject.name = num;

                            sgame.defend = 1;

                            sgame.enemyMana = sgame.enemyMana - 3;
                            sgame.ManaE.text = sgame.enemyMana.ToString();
                            sgame.enemyHandCards[i] = null;
                            i = 5;
                        }
                    }
                }
            }
            sgame.enemyturn = 3.5f;
        }


        if (sgame.enemyturn == 3.5f)
        {
            if (sgame.defend == 0)
            {
                sgame.playerHealth = sgame.playerHealth - 5;
                sgame.HealthPlayer.text = sgame.playerHealth.ToString();
                sgame.playerFire = 2;
                num = ni.ToString();
                Destroy(GameObject.Find(num));
                sgame.enemyturn = 4;
            }
            if (sgame.defend == 2)
            {
                num = ni.ToString();
                Destroy(GameObject.Find(num));
                sgame.enemyturn = 4;
            }
            if (sgame.defend == 3)
            {
                sgame.enemyturn = 4;
            }
        }


        if (sgame.enemyturn == 4)
        {
            sgame.defend = 3;
            for (int i = 0; i < 5; i++)
            {
                if (sgame.enemyHandCards[i] != null)
                {
                    if (sgame.enemyHandCards[i].transform.gameObject.name == sgame.cards[2].transform.gameObject.name)
                    {
                        if ((sgame.playerHealth < 6) & (sgame.enemyMana > 2) & (sgame.playerShield == 0))
                        {
                            ni = i + 5;
                            num = ni.ToString();
                            Instantiate(sgame.enemyHandCards[i], new Vector3(2, 1, -4), sgame.enemyHandCards[i].transform.rotation).gameObject.name = num;

                            sgame.defend = 1;

                            sgame.enemyMana = sgame.enemyMana - 3;
                            sgame.ManaE.text = sgame.enemyMana.ToString();
                            sgame.enemyHandCards[i] = null;
                            i = 5;
                        }
                    }
                }
            }
            sgame.enemyturn = 4.5f;
        }


        if (sgame.enemyturn == 4.5f)
        {
            if (sgame.defend == 0)
            {
                sgame.playerHealth = sgame.playerHealth - 5;
                sgame.HealthPlayer.text = sgame.playerHealth.ToString();
                sgame.playerFrost = 1;
                sgame.PIce.SetActive(true);
                num = ni.ToString();
                Destroy(GameObject.Find(num));
                sgame.enemyturn = 5;
            }
            if (sgame.defend == 2)
            {
                num = ni.ToString();
                Destroy(GameObject.Find(num));
                sgame.enemyturn = 5;
            }
            if (sgame.defend == 3)
            {
                sgame.enemyturn = 5;
            }
        }


        if (sgame.enemyturn == 5)
        {
            sgame.defend = 3;
            for (int i = 0; i < 5; i++)
            {
                if (sgame.enemyHandCards[i] != null)
                {
                    if (sgame.enemyHandCards[i].transform.gameObject.name == sgame.cards[0].transform.gameObject.name)
                    {
                        if (((sgame.playerHealth < 7) & (sgame.enemyMana > 2) & (sgame.playerShield == 0)) | ((sgame.playerHealth < 4) & (sgame.enemyMana > 2)))
                        {
                            ni = i + 5;
                            num = ni.ToString();
                            Instantiate(sgame.enemyHandCards[i], new Vector3(2, 1, -4), sgame.enemyHandCards[i].transform.rotation).gameObject.name = num;

                            sgame.defend = 1;

                            sgame.enemyMana = sgame.enemyMana - 3;
                            sgame.ManaE.text = sgame.enemyMana.ToString();
                            sgame.enemyHandCards[i] = null;
                            i = 5;
                        }
                    }
                }
            }
            sgame.enemyturn = 5.5f;
        }


        if (sgame.enemyturn == 5.5f)
        {
            if (sgame.defend == 0)
            {
                sgame.playerHealth = sgame.playerHealth - 6;
                sgame.HealthPlayer.text = sgame.playerHealth.ToString();
                sgame.playerShield = 0;
                num = ni.ToString();
                Destroy(GameObject.Find(num));
                sgame.enemyturn = 6;
            }
            if (sgame.defend == 2)
            {
                num = ni.ToString();
                Destroy(GameObject.Find(num));
                sgame.enemyturn = 6;
            }
            if (sgame.defend == 3)
            {
                sgame.enemyturn = 6;
            }
        }


        if (sgame.enemyturn == 6)
        {
            sgame.defend = 3;
            for (int i = 0; i < 5; i++)
            {
                if (sgame.enemyHandCards[i] != null)
                {
                    if (sgame.enemyHandCards[i].transform.gameObject.name == sgame.cards[5].transform.gameObject.name)
                    {
                        if ((sgame.enemyMana > 4) & (sgame.enemyShield == 0))
                        {
                            sgame.enemyMana = sgame.enemyMana - 4;
                            sgame.ManaE.text = sgame.enemyMana.ToString();
                            ni = i + 5;
                            num = ni.ToString();
                            Instantiate(sgame.enemyHandCards[i], new Vector3(2, 1, -4), sgame.enemyHandCards[i].transform.rotation).gameObject.name = num;
                            sgame.enemyHandCards[i] = null;
                            sgame.enemyShield = 2;
                            i = 5;
                        }
                    }
                }
            }
            Timer();
            sgame.enemyturn = 6.5f;
        }

        if(sgame.enemyturn == 6.5f)
        {
            if (timer.time == 0)
            {
                Destroy(GameObject.Find(num));
                sgame.enemyturn = 7;
            }
        }

        if (sgame.enemyturn == 7)
        {
            sgame.defend = 3;
            for (int i = 0; i < 5; i++)
            {
                if (sgame.enemyHandCards[i] != null)
                {
                    if (sgame.enemyHandCards[i].transform.gameObject.name == sgame.cards[3].transform.gameObject.name)
                    {
                        if ((sgame.enemyMana > 4) & ((sgame.enemyHealth < 13) | (sgame.enemyFire > 0)) & (sgame.enemyFrost == 0))
                        {
                            sgame.enemyMana = sgame.enemyMana - 4;
                            sgame.ManaE.text = sgame.enemyMana.ToString();
                            ni = i + 5;
                            num = ni.ToString();
                            Instantiate(sgame.enemyHandCards[i], new Vector3(2, 1, -4), sgame.enemyHandCards[i].transform.rotation).gameObject.name = num;
                            sgame.enemyHealth = sgame.enemyHealth + 6;
                            sgame.HealthEnemy.text = sgame.enemyHealth.ToString();
                            sgame.enemyFire = 0;
                            sgame.enemyHandCards[i] = null;
                            i = 5;
                        }
                    }
                }
            }
            Timer();
            sgame.enemyturn = 8;
        }

        if (sgame.enemyturn == 7.5f)
        {
            if (timer.time == 0)
            {
                Destroy(GameObject.Find(num));
                sgame.enemyturn = 8;
            }
        }

        if (sgame.enemyturn == 8)
        {
            sgame.defend = 3;
            for (int i = 0; i < 5; i++)
            {
                if (sgame.enemyHandCards[i] != null)
                {
                    if (sgame.enemyHandCards[i].transform.gameObject.name == sgame.cards[3].transform.gameObject.name)
                    {
                        if ((sgame.enemyMana > 3) & (sgame.enemyHealth < 7) & (sgame.enemyFrost == 0))
                        {
                            sgame.enemyMana = sgame.enemyMana - 4;
                            sgame.ManaE.text = sgame.enemyMana.ToString();
                            ni = i + 5;
                            num = ni.ToString();
                            Instantiate(sgame.enemyHandCards[i], new Vector3(2, 1, -4), sgame.enemyHandCards[i].transform.rotation).gameObject.name = num;
                            sgame.enemyHealth = sgame.enemyHealth + 6;
                            sgame.HealthEnemy.text = sgame.enemyHealth.ToString();
                            sgame.enemyFire = 0;
                            sgame.enemyHandCards[i] = null;
                            i = 5;
                        }
                    }
                }
            }
            Timer();
            sgame.enemyturn = 9;
        }

        if (sgame.enemyturn == 8.5f)
        {
            if (timer.time == 0)
            {
                Destroy(GameObject.Find(num));
                sgame.enemyturn = 9;
            }
        }

        if (sgame.enemyturn == 9)
        {
            sgame.defend = 3;
            for (int i = 0; i < 5; i++)
            {
                if (sgame.enemyHandCards[i] != null)
                {
                    if (sgame.enemyHandCards[i].transform.gameObject.name == sgame.cards[0].transform.gameObject.name)
                    {
                        if (((sgame.enemyMana > 2) & (sgame.playerShield != 0) & (sgame.enemyShield != 0) & (sgame.enemyHealth > 5)) | ((sgame.enemyMana > 4) & (sgame.playerShield != 0)))
                        {
                            ni = i + 5;
                            num = ni.ToString();
                            Instantiate(sgame.enemyHandCards[i], new Vector3(2, 1, -4), sgame.enemyHandCards[i].transform.rotation).gameObject.name = num;

                            sgame.defend = 1;

                            sgame.enemyMana = sgame.enemyMana - 3;
                            sgame.ManaE.text = sgame.enemyMana.ToString();
                            sgame.enemyHandCards[i] = null;
                            i = 5;
                        }
                    }
                }
            }
            sgame.enemyturn = 9.5f;
        }

        if (sgame.enemyturn == 9.5f)
        {
            if (sgame.defend == 0)
            {
                sgame.playerHealth = sgame.playerHealth - 2;
                sgame.HealthPlayer.text = sgame.playerHealth.ToString();
                sgame.playerShield = 0;
                num = ni.ToString();
                Destroy(GameObject.Find(num));
                sgame.enemyturn = 10;
            }
            if (sgame.defend == 2)
            {
                num = ni.ToString();
                Destroy(GameObject.Find(num));
                sgame.enemyturn = 10;
            }
            if (sgame.defend == 3)
            {
                sgame.enemyturn = 10;
            }
        }

        if (sgame.enemyturn == 10)
        {
            sgame.defend = 3;
            for (int i = 0; i < 5; i++)
            {
                if (sgame.enemyHandCards[i] != null)
                {
                    if (sgame.enemyHandCards[i].transform.gameObject.name == sgame.cards[2].transform.gameObject.name)
                    {
                        if (((sgame.enemyMana > 2) & (sgame.playerShield == 0) & (sgame.enemyShield != 0) & (sgame.enemyHealth > 5)) | ((sgame.enemyMana > 4) & (sgame.playerShield == 0)))
                        {
                            ni = i + 5;
                            num = ni.ToString();
                            Instantiate(sgame.enemyHandCards[i], new Vector3(2, 1, -4), sgame.enemyHandCards[i].transform.rotation).gameObject.name = num;

                            sgame.defend = 1;

                            sgame.enemyMana = sgame.enemyMana - 3;
                            sgame.ManaE.text = sgame.enemyMana.ToString();
                            sgame.enemyHandCards[i] = null;
                            i = 5;
                        }
                    }
                }
            }
            sgame.enemyturn = 10.5f;
        }

        if (sgame.enemyturn == 10.5f)
        {
            if (sgame.defend == 0)
            {
                sgame.playerHealth = sgame.playerHealth - 5;
                sgame.HealthPlayer.text = sgame.playerHealth.ToString();
                sgame.playerFrost = 1;
                sgame.PIce.SetActive(true);
                num = ni.ToString();
                Destroy(GameObject.Find(num));
                sgame.enemyturn = 11;
            }
            if (sgame.defend == 2)
            {
                num = ni.ToString();
                Destroy(GameObject.Find(num));
                sgame.enemyturn = 11;
            }
            if (sgame.defend == 3)
            {
                sgame.enemyturn = 11;
            }
        }

        if (sgame.enemyturn == 11)
        {
            sgame.defend = 3;
            for (int i = 0; i < 5; i++)
            {
                if (sgame.enemyHandCards[i] != null)
                {
                    if (sgame.enemyHandCards[i].transform.gameObject.name == sgame.cards[1].transform.gameObject.name)
                    {
                        if (((sgame.enemyMana > 2) & (sgame.playerShield == 0) & (sgame.enemyShield != 0) & (sgame.enemyHealth > 5)) | ((sgame.enemyMana > 4) & (sgame.playerShield == 0)))
                        {
                            ni = i + 5;
                            num = ni.ToString();
                            Instantiate(sgame.enemyHandCards[i], new Vector3(2, 1, -4), sgame.enemyHandCards[i].transform.rotation).gameObject.name = num;

                            sgame.defend = 1;

                            sgame.enemyMana = sgame.enemyMana - 3;
                            sgame.ManaE.text = sgame.enemyMana.ToString();
                            sgame.enemyHandCards[i] = null;
                            i = 5;
                        }
                    }
                }
            }
            sgame.enemyturn = 11.5f;
        }

        if (sgame.enemyturn == 11.5f)
        {
            if (sgame.defend == 0)
            {
                sgame.playerHealth = sgame.playerHealth - 5;
                sgame.HealthPlayer.text = sgame.playerHealth.ToString();
                sgame.playerFire = 2;
                num = ni.ToString();
                Destroy(GameObject.Find(num));
                sgame.enemyturn = 12;
            }
            if (sgame.defend == 2)
            {
                num = ni.ToString();
                Destroy(GameObject.Find(num));
                sgame.enemyturn = 12;
            }
            if (sgame.defend == 3)
            {
                sgame.enemyturn = 12;
            }
        }

        if (sgame.enemyturn == 12)
        {
            sgame.defend = 3;
            for (int i = 0; i < 5; i++)
            {
                if (sgame.enemyHandCards[i] != null)
                {
                    if (sgame.enemyHandCards[i].transform.gameObject.name == sgame.cards[4].transform.gameObject.name)
                    {
                        if (((sgame.enemyMana > 2) & (sgame.playerShield != 0) & (sgame.enemyShield != 0) & (sgame.enemyHealth > 5)) | ((sgame.enemyMana > 4) & (sgame.playerShield != 0)))
                        {
                            ni = i + 5;
                            num = ni.ToString();
                            Instantiate(sgame.enemyHandCards[i], new Vector3(2, 1, -4), sgame.enemyHandCards[i].transform.rotation).gameObject.name = num;

                            sgame.defend = 1;

                            sgame.enemyMana = sgame.enemyMana - 3;
                            sgame.ManaE.text = sgame.enemyMana.ToString();
                            sgame.enemyHandCards[i] = null;
                            i = 5;
                        }
                    }
                }
            }
            sgame.enemyturn = 12.5f;
        }

        if (sgame.enemyturn == 12.5f)
        {
            if (sgame.defend == 0)
            {
                sgame.playerHealth = sgame.playerHealth - 4;
                sgame.playerShield = sgame.playerShield - 1;
                sgame.HealthPlayer.text = sgame.playerHealth.ToString();
                num = ni.ToString();
                Destroy(GameObject.Find(num));
                sgame.enemyturn = 13;
            }
            if (sgame.defend == 2)
            {
                num = ni.ToString();
                Destroy(GameObject.Find(num));
                sgame.enemyturn = 13;
            }
            if (sgame.defend == 3)
            {
                sgame.enemyturn = 13;
            }
        }

        if (sgame.enemyturn == 13)
        {
            sgame.defend = 3;
            for (int i = 0; i < 5; i++)
            {
                if (sgame.enemyHandCards[i] != null)
                {
                    if (sgame.enemyHandCards[i].transform.gameObject.name == sgame.cards[0].transform.gameObject.name)
                    {
                        if ((sgame.enemyMana > 4) & (sgame.playerShield == 0))
                        {
                            ni = i + 5;
                            num = ni.ToString();
                            Instantiate(sgame.enemyHandCards[i], new Vector3(2, 1, -4), sgame.enemyHandCards[i].transform.rotation).gameObject.name = num;

                            sgame.defend = 1;

                            sgame.enemyMana = sgame.enemyMana - 3;
                            sgame.ManaE.text = sgame.enemyMana.ToString();
                            sgame.enemyHandCards[i] = null;
                            i = 5;
                        }
                    }
                }
            }
            sgame.enemyturn = 13.5f;
        }

        if (sgame.enemyturn == 13.5f)
        {
            if (sgame.defend == 0)
            {
                sgame.playerHealth = sgame.playerHealth - 6;
                sgame.HealthPlayer.text = sgame.playerHealth.ToString();
                sgame.playerShield = 0;
                num = ni.ToString();
                Destroy(GameObject.Find(num));
                sgame.enemyturn = 14;
            }
            if (sgame.defend == 2)
            {
                num = ni.ToString();
                Destroy(GameObject.Find(num));
                sgame.enemyturn = 14;
            }
            if (sgame.defend == 3)
            {
                sgame.enemyturn = 14;
            }
        }

        if (sgame.enemyturn == 14)
        {
            sgame.defend = 3;
            for (int i = 0; i < 5; i++)
            {
                if (sgame.enemyHandCards[i] != null)
                {
                    if (sgame.enemyHandCards[i].transform.gameObject.name == sgame.cards[4].transform.gameObject.name)
                    {
                        if ((sgame.enemyMana > 4) & (sgame.playerShield == 0))
                        {
                            ni = i + 5;
                            num = ni.ToString();
                            Instantiate(sgame.enemyHandCards[i], new Vector3(2, 1, -4), sgame.enemyHandCards[i].transform.rotation).gameObject.name = num;

                            sgame.defend = 1;

                            sgame.enemyMana = sgame.enemyMana - 3;
                            sgame.ManaE.text = sgame.enemyMana.ToString();
                            sgame.enemyHandCards[i] = null;
                            i = 5;
                        }
                    }
                }
            }
            sgame.enemyturn = 14.5f;
        }

        if (sgame.enemyturn == 14.5f)
        {
            if (sgame.defend == 0)
            {
                sgame.playerHealth = sgame.playerHealth - 4;
                sgame.HealthPlayer.text = sgame.playerHealth.ToString();
                num = ni.ToString();
                Destroy(GameObject.Find(num));
                sgame.enemyturn = 15;
            }
            if (sgame.defend == 2)
            {
                num = ni.ToString();
                Destroy(GameObject.Find(num));
                sgame.enemyturn = 15;
            }
            if (sgame.defend == 3)
            {
                sgame.enemyturn = 15;
            }
        }

        if (sgame.enemyturn == 15)
        {
            sgame.defend = 3;
            if (sgame.enemyFire > 0)
            {
                sgame.enemyFire = sgame.enemyFire - 1;
                sgame.enemyHealth = sgame.enemyHealth - 2;
            }
            sgame.EIce.SetActive(false);
            sgame.enemyFrost = 0;
            for (int i = 0; i < 5; i++)
            {
                sgame.enemyHandCards[i] = null;
                i = i + 5;
                num = i.ToString();
                Destroy(GameObject.Find(num));
                rand = Random.Range(0, 7);
                i = i - 5;
                sgame.enemyHandCards[i] = sgame.cards[rand];
            }
            sgame.playerMana = 8;
            sgame.ManaP.text = sgame.playerMana.ToString();
            sgame.reload = false;
            sgame.enemyturn = 0;
            sgame.player1turn = true;
            sgame.turnButton.text = ("сбросить карты");
        }
    }
}

