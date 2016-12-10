using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerScript : MonoBehaviour {

    private float time;

    private Text text;

    private MapScript map;

    // Use this for initialization
    void Start () {
        text = GetComponent<Text>();
        time = 180;
        map = GameObject.Find("Map").GetComponent<MapScript>();
    }
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;

        if (time <= 0)
        {
            Finish();
        }
        else
        {
            string min = ((int)time / 60).ToString();
            string sec = ((int)time % 60).ToString();

            if (((int)time % 60) < 10)
            {
                text.text = min + ":0" + sec;
            } else
                text.text = min + ":" + sec;
        }
	}

    public void Finish()
    {
        text.text = "0:00";
        map.Draw("Timeout...");
    }
}
