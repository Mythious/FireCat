﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
        if (Input.GetButtonDown("Select1") || Input.GetButtonDown("Select2") || Input.GetButtonDown("Select3") || Input.GetButtonDown("Select4"))
        {
            SceneManager.LoadScene("SampleScene");
        }
        else if (Input.GetButtonDown("Cancel"))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
