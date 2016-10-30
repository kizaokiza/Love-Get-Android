using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuView : MenuElement {
    //menuview
    public GameObject tapButton;
    public GameObject logoThumbnail;
    public MaskableGraphic imageblink;
    public GameObject charSelect;
    public GameObject modeSelect;
    public GameObject nextPrevbutton;
    public GameObject nextButton;
    public GameObject prevButton;
    public GameObject menuButton;

    //karakter object
    public GameObject karakter1;
    public GameObject karakter2;
    public GameObject karakter3;

    //mode object
    public GameObject mode1;
    public GameObject mode2;
    public GameObject mode3;

    //panel Text
    public GameObject panelKarakterText;
    public GameObject panelModeText;
    public Text karakterText;
    public Text modeText;


    public void MainMenuMoving()
    {
        app.controller.ButtonTappedControl();
    }

    public void StartGamePressed()
    {
        app.controller.StartGamePressedControl();
    }

    public void NextButtonPressed()
    {
        app.controller.NextButtonPressedControl();
    }

    public void PrevButtonPressed()
    {
        app.controller.PrevButtonPressedControl();
    }

    public void PilihKarakterButtonPressed()
    {
        app.controller.PilihKarakterButtonPressedControl();
    }

    public void PilihModeButtonPressed()
    {
        app.controller.PilihModeButtonPressedControl();
    }


    // Use this for initialization

}
