using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFlasher : MonoBehaviour {

    public int delay = 2;
    public SpriteRenderer rend;
    int counter;
    bool toggle = false;

	// Update is called once per frame
	void FixedUpdate () {
        Flash(rend);
	}

    void Flash(SpriteRenderer rend)
    {
        if(counter >= delay)
        {
            counter = 0;

            toggle = !toggle;

            if (toggle)
            {
                rend.enabled = false;
            }
            else
            {
                rend.enabled = true;
            }
        }
        else
        {
            counter++;
        }
    }
}
