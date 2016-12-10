using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapScript : MonoBehaviour {

    // Use this for initialization

    public GameObject box;
    public GameObject[,] blockArray = new GameObject[19, 15];
    public List<GameObject> players = new List<GameObject>();
    public GameObject player1;
    void Start()
    {
        players.Add(player1);
        // Putting all the walls in the block array
        foreach (Transform child in transform)
        {
            if (child.tag == "UndestructibleBlock")
            {
                blockArray[(int)child.position.x, (int)child.position.z] = child.gameObject;
            }
        }

        // Generating random destructible boxes
        for (int x = 0; x < 19; x++)
        {
            for (int y = 0; y < 15; y++)
            {
                if (blockArray[x, y] == null)
                {
                    if (Random.Range(0, 2) == 1)
                    {
                        GameObject obj = (GameObject)Instantiate(box, new Vector3(x, 1, y), Quaternion.identity);
                        obj.transform.SetParent(this.gameObject.transform);
                        blockArray[x, y] = obj;
                    }
                }
            }
        }
        // Checking that spawns are free
        checkSpawns();

    }


    void checkSpawns()
    {
        // Spawn 1
        if (blockArray[1, 1] != null)
        {
            Destroy(blockArray[1, 1]);
            blockArray[1, 1] = null;
        }
        if (blockArray[2, 1] != null)
        {
            Destroy(blockArray[2, 1]);
            blockArray[2, 1] = null;
        }
        if (blockArray[1, 2] != null)
        {
            Destroy(blockArray[1, 2]);
            blockArray[1, 2] = null;
        }

        // Spawn 2
        if (blockArray[17, 1] != null)
        {
            Destroy(blockArray[17, 1]);
            blockArray[17, 1] = null;
        }
        if (blockArray[16, 1] != null)
        {
            Destroy(blockArray[16, 1]);
            blockArray[16, 1] = null;
        }
        if (blockArray[17, 2] != null)
        {
            Destroy(blockArray[17, 2]);
            blockArray[17, 2] = null;
        }

        // Spawn 3
        if (blockArray[1, 13] != null)
        {
            Destroy(blockArray[1, 13]);
            blockArray[1, 13] = null;
        }
        if (blockArray[2, 13] != null)
        {
            Destroy(blockArray[2, 13]);
            blockArray[2, 13] = null;
        }
        if (blockArray[1, 12] != null)
        {
            Destroy(blockArray[1, 12]);
            blockArray[1, 12] = null;
        }

        // Spawn 4
        if (blockArray[17, 13] != null)
        {
            Destroy(blockArray[17, 13]);
            blockArray[17, 13] = null;
        }
        if (blockArray[16, 13] != null)
        {
            Destroy(blockArray[16, 13]);
            blockArray[16, 13] = null;
        }
        if (blockArray[17, 12] != null)
        {
            Destroy(blockArray[17, 12]);
            blockArray[17, 12] = null;
        }
    }

    public GameObject checkPlayersPosition(int x, int y)
    {
        foreach (GameObject player in players)
        {
            if (GetPlayerPosition(player.transform.position.x) == x && GetPlayerPosition(player.transform.position.z) == y)
            {
                return player;
            }
        }
        return null;
    }

    int GetPlayerPosition(float pos)
    {
        float number_end = pos % 1;
        int result = (int)pos;
        if (number_end >= 0.5)
            result += 1;
        return result;
    }

    // Update is called once per frame
    void Update () {
	
	}
}
