using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuModel : MenuElement {

    //menumodel
    //blink start
    public float interval = 0.2f;
    public float startDelay = 0.1f;
    public bool currentState = true;
    public bool defaultState = true;
    public bool isBlinking = false;
    public int timesBlinking;
    //blink end

    //nextprev start
    public bool disableFiring = false;
    public float firingDisableDuration = 0.75f; // or whatever time you want
    public int i;
    public int j;
    public float movingCharModel = 6.7f;
    //nextprev end

}
