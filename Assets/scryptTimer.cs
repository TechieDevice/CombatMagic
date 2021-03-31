using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scryptTimer : MonoBehaviour {
	public float time=0;

    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            if (time < 0)
            {
                time = 0;
            }
        }
    }
}
