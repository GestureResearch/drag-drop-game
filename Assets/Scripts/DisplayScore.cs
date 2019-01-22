using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.GetComponent<Text>().text += GameManagerScript.score.ToString();
	}
}
