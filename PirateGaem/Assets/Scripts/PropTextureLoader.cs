﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PropTextureLoader : MonoBehaviour {

	public List<Texture2D> Props = new List<Texture2D>();

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/**
	 * Fetches a single random entry from the loaded textures.
	 */
	public Texture2D getRandomTexture() {
		return Props [Random.Range (0, Props.Count)];
	}
}
