using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour {

    GestureRecognizer swipeControls;

	void Start () {
        swipeControls = GetComponent<GestureRecognizer>();
	}

    void Update () {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) || swipeControls.Tap)
        {
            GetComponent<LevelLoader>().LoadMainScene();
        }

    }
}
