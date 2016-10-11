using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameView : MonoBehaviour {
    public static GameView instance;
    public GameObject tap;
    public GameObject mainMenu;
    public GameObject menuPanel;
    public GameObject karakter1;
    public GameObject karakter2;
    public GameObject karakter3;
    public GameObject mode1;
    public GameObject mode2;
    public GameObject mode3;
    public GameObject nextButton;
    public GameObject prevButton;
    public GameObject settingButton;
    public GameObject mailButton;
    public GameObject moode;
    public GameObject moodel;
    public GameObject pilihKarakterButton;
    public Text modelText;
    public Text modeText;
    public MaskableGraphic imageblink;

    public int i = 0;
    public int j;
    public AudioClip clip;


  

    // Use this for initialization
    void Start () {
       
        menuPanel.SetActive(false);
        karakter1.SetActive(false);
        settingButton.SetActive(false);
        mailButton.SetActive(false);
        moode.SetActive(false);
        mode1.SetActive(false);
        mode2.SetActive(false);
        mode3.SetActive(false);
        pilihKarakterButton.SetActive(false);
        j = 100;
        
    }
	
	// Update is called once per frame
	void Update () {
        
        //GameController.instance.UpdateNextPreviewButton();
	
	}

    public void TapButtonPressed()
    {
        GameController tap = gameObject.AddComponent<GameController>();
        tap.TapPressed();
    }

    public void NextButtonPressed()
    {
        GameController.instance.next();
    }

    public void PrevButtonPressed()
    {
        GameController.instance.prev();
    }

   public void PilihKarakterButtonPressed()
    {
        GameController.instance.PilihKarakter();
    }

    
}
