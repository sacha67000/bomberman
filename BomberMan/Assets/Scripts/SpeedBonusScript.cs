﻿using UnityEngine;
using System.Collections;

public class SpeedBonusScript : MonoBehaviour {
    private MapScript map;
    // Use this for initialization
    void Start () {
        map = GameObject.Find("Map").GetComponent<MapScript>();
    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.right * Time.deltaTime * 20);
        transform.Rotate(Vector3.up * Time.deltaTime * 20);
    }

    void OnTriggerEnter(Collider other)
    {
        int x = (int)this.gameObject.transform.position.x;
        int y = (int)this.gameObject.transform.position.z;
        other.gameObject.GetComponent<PlayerControl>().speed += 1;
        map.blockArray[x, y] = null;
        Destroy(this.gameObject);
    }
}