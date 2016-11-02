using UnityEngine;
using System.Collections;

public class BasicMapGenerator : MonoBehaviour {

    public GameObject floor;
    public GameObject wall;
    public GameObject grass;

	// Use this for initialization
	void Start () {

        //Arena

        for (int x = 0; x < 40; x++)
        {
            for (int y = 0; y < 30; y++)
            {
               GameObject obj = (GameObject)Instantiate(floor, new Vector3(x, 0, y), Quaternion.identity);
                obj.transform.SetParent(this.gameObject.transform);
            }
        }

        //Walls
        for (int x = 0; x < 40; x++)
        {
            GameObject obj = (GameObject)Instantiate(wall, new Vector3(x, 1, 0), Quaternion.identity);
            obj.transform.SetParent(this.gameObject.transform);
            obj = (GameObject)Instantiate(wall, new Vector3(x, 1, 29), Quaternion.identity);
            obj.transform.SetParent(this.gameObject.transform);
        }

        for (int y = 1; y < 29; y++)
        {
            GameObject obj = (GameObject)Instantiate(wall, new Vector3(0, 1, y), Quaternion.identity);
            obj.transform.SetParent(this.gameObject.transform);
            obj = (GameObject)Instantiate(wall, new Vector3(39, 1, y), Quaternion.identity);
            obj.transform.SetParent(this.gameObject.transform);
        }

        //Grass
        /*
        for (int x = -30; x < 70; x++)
        {
            for (int y = -20; y < 50; y++)
            {
                if ((x < 0 || x >= 40) || (y < 0 || y >= 30)) {
                    GameObject obj = (GameObject)Instantiate(grass, new Vector3(x, 0, y), Quaternion.identity);
                    obj.transform.SetParent(this.gameObject.transform);
                }
            }
        }
        */

    }

    // Update is called once per frame
    void Update () {
	
	}
}
