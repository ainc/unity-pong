using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static int PlayerScore1 = 0;
    public static int PlayerScore2 = 0;

    public GUISkin layout;

    Transform theBall;

	// Use this for initialization
	void Start () {
        theBall = GameObject.FindGameObjectWithTag("Ball").transform;
	}

    public static void Score (string wallID) {
        if (wallID == "rightWall")
        {
            PlayerScore1++;
        } else
        {
            PlayerScore2++;
        }
    }
	
    void OnGUI () {
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), "" + PlayerScore1);
        GUI.Label(new Rect(Screen.width / 2 + 150 + 12, 20, 100, 100), "" + PlayerScore2);

        if (GUI.Button(new Rect(Screen.width / 2 - 60, 35, 120, 53), "RESTART"))
        {
            PlayerScore1 = 0;
            PlayerScore2 = 0;
            theBall.gameObject.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
        }

        if (PlayerScore1 == 10)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER ONE WINS");
            theBall.gameObject.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        } else if (PlayerScore2 == 10)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER TWO WINS");
            theBall.gameObject.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        }
    }
}