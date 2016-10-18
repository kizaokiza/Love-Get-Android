using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuMethod : MonoBehaviour {
    //menumethod
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
    public GameObject buttonCoba;
    public GameObject settingButton;
    public GameObject mailButton;
    public GameObject moode;
    public GameObject moodel;
    public GameObject pilihMode;
    public Text descripionText;
    public Text modelText;
    public Text modeText;
    public MaskableGraphic imageblink;

    bool disableFiring = false;
    float firingDisableDuration = 0.75f; // or whatever time you want





    public float interval = 1f;
    public float startDelay = 0.5f;
    public bool currentState = true;
    public bool defaultState = true;
    bool isBlinking = false;
    int coba;
    public int i = 0;
    public int j;
    public AudioClip clip;



    // Use this for initialization
    void Start()
    {

        menuPanel.SetActive(false);
        karakter1.SetActive(false);
        settingButton.SetActive(false);
        mailButton.SetActive(false);
        moode.SetActive(false);
        mode1.SetActive(false);
        mode2.SetActive(false);
        mode3.SetActive(false);
        pilihMode.SetActive(false);
        j = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (i == 0 || j==0)
        {
            prevButton.SetActive(false);
        }else
        {
            prevButton.SetActive(true);
        }

        if (i == 2 || j==2)
        {
            nextButton.SetActive(false);
        }
        else
        {
            nextButton.SetActive(true);
        }
        if (i == 0)
        {
            modelText.text = "Maya adalah seorang mahasiswi tingkat 2, dia juga bekerja sebagai waiter Part-time di cafe 'Coffee latte' ";
        };

        if (i == 1)
        {
            modelText.text = "Irine adalah seorang mahasiswi tingkat 1, dia adalah seorang gamer. Di saat senggang ia senang menjadi caster di twitch ";
        }

        if (i == 2)
        {
            modelText.text = "Rea adalah seorang designer yang bekerja di Advertising Agency. Hobinya adalah Cosplay dan menggambar manga";
        }
        if (j == 0)
        {
            modeText.text = "mode kasus adalah blabla";
        }
        if (j == 1)
        {
            modeText.text = "mode PDKT adalah blabla";
        }
        if (j == 2)
        {
            modeText.text = "mode nembak adalah blabla";
        }
    }

    public void next()
    {
        if (!disableFiring)
        {
            if (i <= 2)
        {
            i++;
            Vector3 nextone = new Vector3(-5.85f, 0f, 0f);
            iTween.MoveBy(karakter1, nextone, 0.75f);
            iTween.MoveBy(karakter2, nextone, 0.75f);
            iTween.MoveBy(karakter3, nextone, 0.75f);
        }
        if (j <= 2)
        {
            j++;
            Vector3 nextone = new Vector3(-5.85f, 0f, 0f);
            iTween.MoveBy(mode1, nextone, 0.75f);
            iTween.MoveBy(mode2, nextone, 0.75f);
            iTween.MoveBy(mode3, nextone, 0.75f);
        }
            disableFiring = true;
            Invoke("EnableFiring", firingDisableDuration);
        }


    }

    void EnableFiring()
    {
        disableFiring = false;
    }

    public void prev()
    {

        if (!disableFiring)
        {
            if (i >= 1)
            {
                i--;
                Vector3 prevone = new Vector3(5.85f, 0f, 0f);
                iTween.MoveBy(karakter1, prevone, 0.75f);
                iTween.MoveBy(karakter2, prevone, 0.75f);
                iTween.MoveBy(karakter3, prevone, 0.75f);

            }
            if (j >= 1)
            {
                j--;
                Vector3 prevone = new Vector3(5.85f, 0f, 0f);
                iTween.MoveBy(mode1, prevone, 0.75f);
                iTween.MoveBy(mode2, prevone, 0.75f);
                iTween.MoveBy(mode3, prevone, 0.75f);

            }
            disableFiring = true;
            Invoke("EnableFiring", firingDisableDuration);
        }
      
    }

    public void MainMenuMoving()
    {
        Vector3 logoPindah= new Vector3(0.34f, 3.84f, 0);
        Vector3 logoKecil = new Vector3(0.47f, 0.47f, 0.47f);
        
        //Color colorToFadeTo = new Color(1f, 1f, 1f, 0f);
        iTween.MoveTo(mainMenu, logoPindah, 2);
        iTween.ScaleTo(mainMenu, logoKecil, 2);
        Blinking();
        //Destroy(button);
        //Destroy(buttontap);

    }

    public void GotoGame()
    {
        SceneManager.LoadScene("test", LoadSceneMode.Single);
    }

    public void PilihKarakter()
    {
        karakter1.SetActive(false);
        karakter2.SetActive(false);
        karakter3.SetActive(false);
        mode1.SetActive(true);
        mode2.SetActive(true);
        mode3.SetActive(true);
        moodel.SetActive(false);
        moode.SetActive(true);
        pilihMode.SetActive(true);
        j = 0;
        i = 0;
    }

    void PanelControl()
    {
        menuPanel.SetActive(true);
        karakter1.SetActive(true);
        settingButton.SetActive(true);
        mailButton.SetActive(true);

    }
    
    #region Blink Effect
    public void Blinking()
    {

        imageblink.enabled = defaultState;
        StartBlink();
    }

    public void StartBlink()
    {
        // do not invoke the blink twice - needed if you need to start the blink from an external object
        if (isBlinking)
            return;

        if (imageblink != null)
        {
            isBlinking = true;     
           
                InvokeRepeating("ToggleState", startDelay, interval);
            
            
            
        }
    }

    public void ToggleState()
    {
        imageblink.enabled = !imageblink.enabled;
        coba++;
        if (coba == 10)
        {
            Destroy(imageblink);
            CancelInvoke();
            PanelControl();

        }
        
        // plays the clip at (0,0,0)
       // if (clip)
          //  AudioSource.PlayClipAtPoint(clip, Vector3.zero);
        
    }
    #endregion

}



