using UnityEngine;

public class ButtonManager : MonoBehaviour {

	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LevelLoader loader = new LevelLoader();
            loader.LoadMainScene();
        }
    }
}
