using UnityEngine;
using System.Collections;

public class BombScript : MonoBehaviour {
    public int bombRange;
    public GameObject owner;
    public GameObject explosion;
    private MapScript map;
    private float timer = 0;
    private bool sizeSwitch = false;
    private Vector3 bigScale = new Vector3(1.3f, 1.3f, 1.3f);
    private Vector3 smallScale = new Vector3(1.0f, 1.0f, 1.0f);

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
        foreach (Transform child in explosion.transform)
        {
            child.gameObject.GetComponent<ParticleSystem>().startLifetime = (bombRange - 1) * 0.025f;
        }
        explosion.SetActive(true);
        explosion.transform.parent = null;
        Destroy(map.blockArray[x, y]);
        map.blockArray[x, y] = null;
        owner.GetComponent<PlayerControl>().bombNumber += 1;
    }


    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;
        if (timer > 5)
            explode();

        if (sizeSwitch == false)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, bigScale, 2 * Time.deltaTime);
            if ((int)timer == 0 || (int)timer == 2 || (int)timer == 4)
                sizeSwitch = !sizeSwitch;
        }
        else
        {
            transform.localScale = Vector3.Lerp(transform.localScale, smallScale, 2 * Time.deltaTime);
            if ((int)timer == 1 || (int)timer == 3)
                sizeSwitch = !sizeSwitch;
        }
    }


}
