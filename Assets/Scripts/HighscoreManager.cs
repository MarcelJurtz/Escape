using UnityEngine;
using UnityEngine.UI;

public class HighscoreManager : MonoBehaviour {

    private const string prefsKey = "Highscore";
    private const int defaultHighscore = 0;

	public static void setHighscore(int highscore)
    {
        if(highscore > getHighscore())
        {
            PlayerPrefs.SetInt(prefsKey, highscore);
        }     
    }

    public static int getHighscore()
    {  
        return (int)PlayerPrefs.GetInt(prefsKey, defaultHighscore);
    }
}
