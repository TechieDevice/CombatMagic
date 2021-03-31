using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scryptMenu : MonoBehaviour {

    public void playGame(string name)
    {
        Application.LoadLevel(name);
    }

    public void exit()
    {
        Application.Quit();
    }
}
