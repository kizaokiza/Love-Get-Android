using UnityEngine;
using System.Collections;

public class GameController : GameView {
    public static GameController instance;
    
    bool disableFiring = false;
    float firingDisableDuration = 0.75f;
    const float karakterMoving = 5.85f;
    const float karakterMovingTime = 0.75f;

    public float interval = 1f;
    public float startDelay = 0.5f;
    public bool currentState = true;
    public bool defaultState = true;
    bool isBlinking = false;
    int coba;
    
    public AudioClip clip;

  
    void UpdateNextPreviewButton()
    {
        if (GameView.instance.i == 0 || GameView.instance.j == 0)
        {
            GameView.instance.prevButton.SetActive(false);
        }
        else
        {
            GameView.instance.prevButton.SetActive(true);
        }

        if (GameView.instance.i == 2 || GameView.instance.j == 2)
        {
            GameView.instance.nextButton.SetActive(false);
        }
        else
        {
            GameView.instance.nextButton.SetActive(true);
        }
    }

    void UpdateNextPreviewText()
    {

        if (GameView.instance.i == 0)
        {
            GameView.instance.modelText.text = "Maya adalah seorang mahasiswi tingkat 2, dia juga bekerja sebagai waiter Part-time di cafe 'Coffee latte' ";
        };

        if (GameView.instance.i == 1)
        {
            GameView.instance.modelText.text = "Irine adalah seorang mahasiswi tingkat 1, dia adalah seorang gamer. Di saat senggang ia senang menjadi caster di twitch ";
        }

        if (GameView.instance.i == 2)
        {
            GameView.instance.modelText.text = "Rea adalah seorang designer yang bekerja di Advertising Agency. Hobinya adalah Cosplay dan menggambar manga";
        }
        if (GameView.instance.j == 0)
        {
            GameView.instance.modeText.text = "mode kasus adalah blabla";
        }
        if (GameView.instance.j == 1)
        {
            GameView.instance.modeText.text = "mode PDKT adalah blabla";
        }
        if (GameView.instance.j == 2)
        {
            GameView.instance.modeText.text = "mode nembak adalah blabla";
        }

    }

    public void next()
    {
        if (!disableFiring)
        {
            if (GameView.instance.i <= 2)
            {
                GameView.instance.i++;
                Vector3 nextone = new Vector3(karakterMoving*-1f, 0f, 0f);
                iTween.MoveBy(GameView.instance.karakter1, nextone, karakterMovingTime);
                iTween.MoveBy(GameView.instance.karakter2, nextone, karakterMovingTime);
                iTween.MoveBy(GameView.instance.karakter3, nextone, karakterMovingTime);
            }
            if (GameView.instance.j <= 2)
            {
                GameView.instance.j++;
                Vector3 nextone = new Vector3(karakterMoving*-1f, 0f, 0f);
                iTween.MoveBy(GameView.instance.mode1, nextone, karakterMovingTime);
                iTween.MoveBy(GameView.instance.mode2, nextone, karakterMovingTime);
                iTween.MoveBy(GameView.instance.mode3, nextone, karakterMovingTime);
            }
            disableFiring = true;
            Invoke("EnableFiring", firingDisableDuration);
            UpdateNextPreviewButton();
            UpdateNextPreviewText();
        }
    }

    public void prev()
    {
        if (!disableFiring)
        {
            if (GameView.instance.i >= 1)
            {
                GameView.instance.i++;
                Vector3 nextone = new Vector3(karakterMoving, 0f, 0f);
                iTween.MoveBy(GameView.instance.karakter1, nextone, karakterMovingTime);
                iTween.MoveBy(GameView.instance.karakter2, nextone, karakterMovingTime);
                iTween.MoveBy(GameView.instance.karakter3, nextone, karakterMovingTime);
            }
            if (GameView.instance.j >= 1)
            {
                GameView.instance.j++;
                Vector3 nextone = new Vector3(karakterMoving, 0f, 0f);
                iTween.MoveBy(GameView.instance.mode1, nextone, karakterMovingTime);
                iTween.MoveBy(GameView.instance.mode2, nextone, karakterMovingTime);
                iTween.MoveBy(GameView.instance.mode3, nextone, karakterMovingTime);
            }
            disableFiring = true;
            Invoke("EnableFiring", firingDisableDuration);
            UpdateNextPreviewButton();
            UpdateNextPreviewText();
        }
    }

    void EnableFiring()
    {
        disableFiring = false;
    }

    public void TapPressed()
    {
      
        Vector3 logoPindah = new Vector3(0.34f, 3.84f, 0);
        Vector3 logoKecil = new Vector3(0.47f, 0.47f, 0.47f);

        //Color colorToFadeTo = new Color(1f, 1f, 1f, 0f);
        iTween.MoveTo(GameView.instance.mainMenu, logoPindah, 2);
        iTween.ScaleTo(GameView.instance.mainMenu, logoKecil, 2);
        Blinking();
    }

    public void Blinking()
    {

        GameView.instance.imageblink.enabled = defaultState;
        StartBlink();
    }

    public void StartBlink()
    {
        // do not invoke the blink twice - needed if you need to start the blink from an external object
        if (isBlinking)
            return;

        if (GameView.instance.imageblink != null)
        {
            isBlinking = true;

            InvokeRepeating("ToggleState", startDelay, interval);



        }
    }

    public void ToggleState()
    {
        GameView.instance.imageblink.enabled = !GameView.instance.imageblink.enabled;
        coba++;
        if (coba == 10)
        {
            Destroy(GameView.instance.imageblink);
            CancelInvoke();
            PanelControl();

        }
    }
    void PanelControl()
    {
        GameView.instance.menuPanel.SetActive(true);
        GameView.instance.karakter1.SetActive(true);
        GameView.instance.settingButton.SetActive(true);
        GameView.instance.mailButton.SetActive(true);

    }

    public void PilihKarakter()
    {
        GameView.instance.karakter1.SetActive(false);
        GameView.instance.karakter2.SetActive(false);
        GameView.instance.karakter3.SetActive(false);
        GameView.instance.mode1.SetActive(true);
        GameView.instance.mode2.SetActive(true);
        GameView.instance.mode3.SetActive(true);
        GameView.instance.moodel.SetActive(false);
        GameView.instance.moode.SetActive(true);
        GameView.instance.pilihKarakterButton.SetActive(true);
        GameView.instance.j = 0;
        GameView.instance.i = 0;
    }

    // Use this for initialization
    void Start () {
	
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
