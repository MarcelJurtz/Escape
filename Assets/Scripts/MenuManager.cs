using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    public Text highscoreText;

	void Start () {
        highscoreText.text = "HIGHSCORE: " + HighscoreManager.getHighscore().ToString("D2");
	}
}
