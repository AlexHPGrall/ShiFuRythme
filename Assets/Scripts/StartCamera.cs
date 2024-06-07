using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class StartCamera : MonoBehaviour
{
	public float startRot, finalRot;
	public AudioSource audioSource;
	private float t = 0;
	bool skippedFirstFrame = false;
	private void OnEnable()
	{
		transform.position = new Vector3(-1.3f, 2.442f, 1.277f);
		transform.localEulerAngles = new Vector3(startRot, 0, 90);
		audioSource.Play();
		skippedFirstFrame = false;
		t = 0;
	}
	private void Update()
	{
		if (!skippedFirstFrame)
		{
			skippedFirstFrame = true;
			return;
		}
		transform.localEulerAngles = new Vector3(Mathf.LerpUnclamped(startRot,finalRot, ElasticEaseOut(t)), 0, 90);
		t = Mathf.Min(t + (Time.deltaTime*0.5f), 1);
	}
	static public float ElasticEaseOut(float p)
	{
		return Mathf.Sin(-13f * Mathf.PI*0.5f * (p + 1f)) * Mathf.Pow(2f, -10f * p) + 1f;
	}
}
