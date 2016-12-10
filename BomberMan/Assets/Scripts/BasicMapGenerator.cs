using UnityEngine;
using System.Collections;

public class BasicMapGenerator : MonoBehaviour {

    public GameObject floor;
    public GameObject wall;
    public GameObject grass;

	// Use this for initialization
	void Start () {

        //Arena

        for (int x = 0; x < 19; x++)
        {
            for (int y = 0; y < 15; y++)
            {
               GameObject obj = (GameObject)Instantiate(floor, new Vector3(x, 0, y), Quaternion.identity);
                obj.transform.SetParent(this.gameObject.transform);
            }
        }

        //Walls
        for (int x = 0; x < 19; x++)
        {
            GameObject obj = (GameObject)Instantiate(wall, new Vector3(x, 1, 0), Quaternion.identity);
            obj.transform.SetParent(this.gameObject.transform);
            obj = (GameObject)Instantiate(wall, new Vector3(x, 1, 14), Quaternion.identity);
            obj.transform.SetParent(this.gameObject.transform);
        }

        for (int y = 1; y < 14; y++)
        {
            GameObject obj = (GameObject)Instantiate(wall, new Vector3(0, 1, y), Quaternion.identity);
            obj.transform.SetParent(this.gameObject.transform);
            obj = (GameObject)Instantiate(wall, new Vector3(18, 1, y), Quaternion.identity);
            obj.transform.SetParent(this.gameObject.transform);
        }

        for (int x = 2; x < 19; x = x + 2)
        {
            for (int y = 2; y < 14; y = y + 2)
            {
                GameObject obj = (GameObject)Instantiate(wall, new Vector3(x, 1, y), Quaternion.identity);
                obj.transform.SetParent(this.gameObject.transform);
            }
        }


        //Grass
        GameObject objGrass = (GameObject)Instantiate(grass, new Vector3(20, -1, 15), Quaternion.identity);
        objGrass.transform.SetParent(this.gameObject.transform);
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
