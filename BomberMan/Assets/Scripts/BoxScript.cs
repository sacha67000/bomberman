using UnityEngine;
using System.Collections;

public class BoxScript : MonoBehaviour {

    public GameObject speedBonus;
    public GameObject rangeBonus;
    public GameObject numberBonus;

    private MapScript map;
    // Use this for initialization
    void Start () {
        map = GameObject.Find("Map").GetComponent<MapScript>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void BoxDestroy()
    {
        int x = (int)this.gameObject.transform.position.x;
        int y = (int)this.gameObject.transform.position.z;
        if (Random.Range(0, 3) == 1)
        {
            switch (Random.Range(0, 3))
            {
                case 0:
                    map.blockArray[x, y] = (GameObject)Instantiate(speedBonus, new Vector3(this.gameObject.transform.position.x, 1, this.gameObject.transform.position.z), Quaternion.identity);
                    break;
                case 1:
                    map.blockArray[x, y] = (GameObject)Instantiate(rangeBonus, new Vector3(this.gameObject.transform.position.x, 1, this.gameObject.transform.position.z), Quaternion.identity);
                    break;
                case 2:
                    map.blockArray[x, y] = (GameObject)Instantiate(numberBonus, new Vector3(this.gameObject.transform.position.x, 1, this.gameObject.transform.position.z), Quaternion.identity);
                    break;
            }
        }
        else
        {
            map.blockArray[x, y] = null;
        }

        Destroy(this.gameObject);
    }
}
