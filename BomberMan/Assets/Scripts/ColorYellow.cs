﻿using UnityEngine;
using System.Collections;

public class ColorYellow : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Renderer>().material.color = Color.yellow;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
