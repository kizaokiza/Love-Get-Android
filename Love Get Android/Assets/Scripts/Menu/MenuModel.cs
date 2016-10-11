using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuModel : MenuElement {

    public float interval = 0.2f;
    public float startDelay = 0.1f;
    public bool currentState = true;
    public bool defaultState = true;
    public bool isBlinking = false;
    public int timesBlinking;
    
   
}
