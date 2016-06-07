using UnityEngine;
using System.Collections;

public class Backgroundscroll : MonoBehaviour
{
	public float scrollSpeed;

	private Vector3 startPosition;

	void Start ()
	{
		startPosition = transform.position;
	}

	void Update ()
	{
		Vector2 offset = new Vector2 (Time.time * scrollSpeed, 0);
		GetComponent<Renderer>().material.mainTextureOffset = offset;﻿
	}
}