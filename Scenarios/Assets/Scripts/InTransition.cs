﻿using UnityEngine;

public class InTransition : MonoBehaviour
{
    public GameObject videoPlayer;
    public float pauseLength;
    public float speed;

    private Material material;
    private float pause;

    // Use this for initialization
    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    private void OnEnable()
    {
        videoPlayer.SetActive(true);

        pause = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (pause <= pauseLength)
        {
            pause += 1.0f * Time.deltaTime;
        }
        else
        {
            Color colour = material.color;

            if (colour.a > 0.0f)
            {
                colour.a -= speed * Time.deltaTime;

                material.color = colour;
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }

    void OnDisable()
    {
        Color colour = material.color;

        colour.a = 1.0f;

        material.color = colour;
    }
}