using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapScript : MonoBehaviour {

    // Use this for initialization

    public GameObject box;
    public GameObject[,] blockArray = new GameObject[40, 30];
    void Start()
    {
        // Putting all the walls in the block array
        foreach (Transform child in transform)
        {
            if (child.tag == "UndestructibleBlock")
            {
                blockArray[(int)child.position.x, (int)child.position.z] = child.gameObject;
            }
        }

        // Generating random destructible boxes
        for (int x = 0; x < 40; x++)
        {
            for (int y = 0; y < 30; y++)
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
        if (blockArray[38, 1] != null)
        {
            Destroy(blockArray[38, 1]);
            blockArray[38, 1] = null;
        }
        if (blockArray[37, 1] != null)
        {
            Destroy(blockArray[37, 1]);
            blockArray[37, 1] = null;
        }
        if (blockArray[38, 2] != null)
        {
            Destroy(blockArray[38, 2]);
            blockArray[38, 2] = null;
        }

        // Spawn 3
        if (blockArray[1, 28] != null)
        {
            Destroy(blockArray[1, 28]);
            blockArray[1, 28] = null;
        }
        if (blockArray[2, 28] != null)
        {
            Destroy(blockArray[2, 28]);
            blockArray[2, 28] = null;
        }
        if (blockArray[1, 27] != null)
        {
            Destroy(blockArray[1, 27]);
            blockArray[1, 27] = null;
        }

        // Spawn 4
        if (blockArray[38, 28] != null)
        {
            Destroy(blockArray[38, 28]);
            blockArray[38, 28] = null;
        }
        if (blockArray[37, 28] != null)
        {
            Destroy(blockArray[37, 28]);
            blockArray[37, 28] = null;
        }
        if (blockArray[38, 27] != null)
        {
            Destroy(blockArray[38, 27]);
            blockArray[38, 27] = null;
        }
    }

    // Update is called once per frame
    void Update () {
	
	}
}
