using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuElement : MonoBehaviour
{

    public MenuApplication app { get { return GameObject.FindObjectOfType<MenuApplication>(); } }
}
public class MenuApplication : MonoBehaviour {


    public MenuModel model;
    public MenuView view;
    public MenuController controller;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
