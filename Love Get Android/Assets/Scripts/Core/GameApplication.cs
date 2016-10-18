using UnityEngine;
using System.Collections;

public class GameElement : MonoBehaviour
{
    //gameapp

    public GameApplication app { get { return GameObject.FindObjectOfType<GameApplication>(); } }
}


public class GameApplication : MonoBehaviour {

    public GameModel model;
    public GameView view;
    public GameController controller;


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
