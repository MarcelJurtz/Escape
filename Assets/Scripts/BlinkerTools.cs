using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkerTools : MonoBehaviour {

    float speed = 2.0f;

    public bool blink;
    public bool fade;

    private Text text;

    void Start()
    {
        text = GetComponent<Text>();
    }
    
	void Update () {

        if (blink && fade)
        {
            Debug.Log("Please only use either blinking or fading.");
        }
        else if (blink)
        {
            Color newColor = text.color;
            newColor.a = Mathf.Round(Mathf.PingPong(Time.time * speed, 1.0f));
            text.color = newColor;
        }
        else if (fade)
        {
            Color newColor = text.color;
            newColor.a = (Mathf.Sin(Time.time * speed) + 1.0f) / 2.0f;
            text.color = newColor;
        }
    }
}
