using UnityEngine;
using System.Collections;

public class BombScript : MonoBehaviour {
    public int bombRange;
    public GameObject owner;
    private MapScript map;
    private float timer = 0;

    // Use this for initialization
    void Start () {
        map = GameObject.Find("Map").GetComponent<MapScript>();
    }

    void activateCollision()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.GetComponent<MeshCollider>().enabled = true;
        }
    }

    void explode()
    {
        int x = (int)this.gameObject.transform.position.x;
        int y = (int)this.gameObject.transform.position.z;
        for (int i = 1; i < bombRange && (x + i) < 40; i++)
        {
            if (map.blockArray[x + i, y] && map.blockArray[x + i, y].tag == "DestructibleBox")
            { 
                map.blockArray[x + i, y].GetComponent<BoxScript>().BoxDestroy();
                break;
            }
        }
        for (int i = 1; i < bombRange && (y + i) < 30; i++)
        {
            if (map.blockArray[x, y + i] && map.blockArray[x, y + i].tag == "DestructibleBox")
            {
                map.blockArray[x, y + i].GetComponent<BoxScript>().BoxDestroy();
                break;
            }
        }
        for (int i = 1; i < bombRange && (x - i) >= 0; i++)
        {
            if (map.blockArray[x - i, y] && map.blockArray[x - i, y].tag == "DestructibleBox")
            {
                map.blockArray[x - i, y].GetComponent<BoxScript>().BoxDestroy();
                break;
            }
        }
        for (int i = 1; i < bombRange && (y - i) >= 0; i++)
        {
            if (map.blockArray[x, y - i] && map.blockArray[x, y - i].tag == "DestructibleBox")
            {
                map.blockArray[x, y - i].GetComponent<BoxScript>().BoxDestroy();
                break;
            }
        }
        Destroy(map.blockArray[x, y]);
        map.blockArray[x, y] = null;
        owner.GetComponent<PlayerControl>().bombNumber += 1;
    }


    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;
        if (timer > 3)
            explode();
	}
}
