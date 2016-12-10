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
    private bool activeCollision = false;

    // Use this for initialization
    void Start () {
        map = GameObject.Find("Map").GetComponent<MapScript>();
    }

    void activateCollision()
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.GetComponent<MeshCollider>())
                child.gameObject.GetComponent<MeshCollider>().enabled = true;
        }
        activeCollision = true;
    }

    void explode()
    {
        int x = (int)this.gameObject.transform.position.x;
        int y = (int)this.gameObject.transform.position.z;

        int right = 0;
        int left = 0;
        int up = 0;
        int down = 0;

        GameObject player;
        if ((player = map.checkPlayersPosition(x, y)) != null)
        {
            player.GetComponent<PlayerControl>().DestroyPlayer();
        }
        for (int i = 1; i < bombRange && (x + i) < 40; i++)
        {
            if (map.blockArray[x + i, y])
            { 
                if (map.blockArray[x + i, y].tag == "DestructibleBox")
                    map.blockArray[x + i, y].GetComponent<BoxScript>().BoxDestroy();
                right = i;
                break;
            }
            else
            {
                if ((player = map.checkPlayersPosition(x + i, y)) != null)
                {
                    player.GetComponent<PlayerControl>().DestroyPlayer();
                }
            }
            right = i;
        }
        for (int i = 1; i < bombRange && (y + i) < 30; i++)
        {
            if (map.blockArray[x, y + i])
            {
                if (map.blockArray[x, y + i].tag == "DestructibleBox")
                    map.blockArray[x, y + i].GetComponent<BoxScript>().BoxDestroy();
                up = i;
                break;
            }
            else
            {
                if ((player = map.checkPlayersPosition(x, y + i)) != null)
                {
                    player.GetComponent<PlayerControl>().DestroyPlayer();
                }
            }
            up = i;
        }
        for (int i = 1; i < bombRange && (x - i) >= 0; i++)
        {
            if (map.blockArray[x - i, y])
            {
                if (map.blockArray[x - i, y].tag == "DestructibleBox")
                    map.blockArray[x - i, y].GetComponent<BoxScript>().BoxDestroy();
                left = i;
                break;
            }
            else
            {
                if ((player = map.checkPlayersPosition(x - i, y)) != null)
                {
                    player.GetComponent<PlayerControl>().DestroyPlayer();
                }
            }
            left = i;
        }
        for (int i = 1; i < bombRange && (y - i) >= 0; i++)
        {
            if (map.blockArray[x, y - i] )
            {
                if (map.blockArray[x, y - i].tag == "DestructibleBox")
                    map.blockArray[x, y - i].GetComponent<BoxScript>().BoxDestroy();
                down = i;
                break;
            }
            else
            {
                if ((player = map.checkPlayersPosition(x, y - i)) != null)
                {
                    player.GetComponent<PlayerControl>().DestroyPlayer();
                }
            }
            down = i;
        }

        foreach (Transform child in explosion.transform)
        {
            switch ((int)child.gameObject.transform.eulerAngles.y)
            {
                case 0:
                    child.gameObject.GetComponent<ParticleSystem>().startLifetime = (up) * 0.025f;
                    child.gameObject.GetComponent<ParticleSystem>().startSpeed = 50;
                    break;
                case 90:
                    child.gameObject.GetComponent<ParticleSystem>().startLifetime = (right) * 0.025f;
                    child.gameObject.GetComponent<ParticleSystem>().startSpeed = 50;
                    break;
                case 180:
                    child.gameObject.GetComponent<ParticleSystem>().startLifetime = (down) * 0.025f;
                    child.gameObject.GetComponent<ParticleSystem>().startSpeed = 50;
                    break;
                case 270:
                    child.gameObject.GetComponent<ParticleSystem>().startLifetime = (left) * 0.025f;
                    child.gameObject.GetComponent<ParticleSystem>().startSpeed = 50;
                    break;
            }
            //           child.gameObject.GetComponent<ParticleSystem>().startLifetime = (bombRange - 1) * 0.05f;
            //           child.gameObject.GetComponent<ParticleSystem>().startSpeed = 25;
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
        if (map.checkPlayersPosition((int)transform.position.x, (int)transform.position.z) == null)
        {
            this.activateCollision();
        }
    }


}
