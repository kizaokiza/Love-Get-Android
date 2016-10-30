using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuController : MenuElement {

    //menucontroll


    public void ButtonTappedControl()
    {

        Vector3 logoPindah = new Vector3(0f, 0.6f,3f);
        //Vector3 logoKecil = new Vector3(0.47f, 0.47f,0.47f);

        
        //iTween.ScaleTo(app.view.tapButton, logoKecil, 1.5f);
        iTween.MoveTo(app.view.tapButton, logoPindah, 1.5f);
        //app.view.nextPrevbutton.SetActive(true);
        Blinking();
        
    }

    public void StartGamePressedControl()
    {
        Vector3 logoPindah = new Vector3(0f, 12f, 3f);
        //Vector3 logoKecil = new Vector3(0.47f, 0.47f,0.47f);


        //iTween.ScaleTo(app.view.tapButton, logoKecil, 1.5f);
        iTween.MoveTo(app.view.tapButton, logoPindah, 1.5f);
        iTween.MoveTo(app.view.menuButton, logoPindah, 1.5f);
        //app.view.nextPrevbutton.SetActive(true);
        app.model.timesBlinking = 0;
        InvokeRepeating("ToggleStateTwo", app.model.startDelay, app.model.interval);
        
    }

    public void NextButtonPressedControl()
    {
        if (!app.model.disableFiring)
        {
            if (app.model.i <= 2)
            {
                app.model.i++;
                Vector3 nextone = new Vector3(app.model.movingCharModel*-1, 0f, 0f);
                iTween.MoveBy(app.view.karakter1, nextone, 0.75f);
                iTween.MoveBy(app.view.karakter2, nextone, 0.75f);
                iTween.MoveBy(app.view.karakter3, nextone, 0.75f);
            }
            if (app.model.j <= 2)
            {
                app.model.j++;
                Vector3 nextone = new Vector3(app.model.movingCharModel * -1, 0f, 0f);
                iTween.MoveBy(app.view.mode1, nextone, 0.75f);
                iTween.MoveBy(app.view.mode2, nextone, 0.75f);
                iTween.MoveBy(app.view.mode3, nextone, 0.75f);
            }
            UpdateTextAndButton();
            app.model.disableFiring = true;
            Invoke("EnableFiring", app.model.firingDisableDuration);
        }
    }

    public void PrevButtonPressedControl()
    {
        if (!app.model.disableFiring)
        {
            if (app.model.i <= 2)
            {
                app.model.i--;
                Vector3 nextone = new Vector3(app.model.movingCharModel, 0f, 0f);
                iTween.MoveBy(app.view.karakter1, nextone, 0.75f);
                iTween.MoveBy(app.view.karakter2, nextone, 0.75f);
                iTween.MoveBy(app.view.karakter3, nextone, 0.75f);
            }
            if (app.model.j <= 2)
            {
                app.model.j--;
                Vector3 nextone = new Vector3(app.model.movingCharModel, 0f, 0f);
                iTween.MoveBy(app.view.mode1, nextone, 0.75f);
                iTween.MoveBy(app.view.mode2, nextone, 0.75f);
                iTween.MoveBy(app.view.mode3, nextone, 0.75f);
            }
            UpdateTextAndButton();
            app.model.disableFiring = true;
            Invoke("EnableFiring", app.model.firingDisableDuration);
        }
    }

    private void CharSelect()
    {
        app.view.logoThumbnail.SetActive(true);
        app.view.tapButton.SetActive(false);
        app.view.charSelect.SetActive(true);
        app.view.nextPrevbutton.SetActive(true);
    }

    public void PilihKarakterButtonPressedControl()
    {
        app.view.charSelect.SetActive(false);
        app.view.modeSelect.SetActive(true);
        app.model.j = 0;
        app.model.i=100;
        UpdateTextAndButton();
    }

    public void PilihModeButtonPressedControl()
    {
        SceneManager.LoadScene("Core", LoadSceneMode.Single);
    }

    void EnableFiring()
    {
        app.model.disableFiring = false;
    }



    void UpdateTextAndButton()
    {
        if (app.model.i == 0 || app.model.j == 0)
        {
            app.view.prevButton.SetActive(false);
        }
        else
        {
            app.view.prevButton.SetActive(true);
        }

        if (app.model.i == 2 || app.model.j == 2)
        {
            app.view.nextButton.SetActive(false);
        }
        else
        {
            app.view.nextButton.SetActive(true);
        }
        if (app.model.i == 0)
        {
            app.view.karakterText.text = "Maya adalah seorang mahasiswi tingkat 2, dia juga bekerja sebagai waiter Part-time di cafe 'Coffee latte' ";
        };

        if (app.model.i == 1)
        {
            app.view.karakterText.text = "Irine adalah seorang mahasiswi tingkat 1, dia adalah seorang gamer. Di saat senggang ia senang menjadi caster di twitch ";
        }

        if (app.model.i == 2)
        {
            app.view.karakterText.text = "Rea adalah seorang designer yang bekerja di Advertising Agency. Hobinya adalah Cosplay dan menggambar manga";
        }
        if (app.model.j == 0)
        {
            app.view.modeText.text = "mode kasus adalah blabla";
        }
        if (app.model.j == 1)
        {
            app.view.modeText.text = "mode PDKT adalah blabla";
        }
        if (app.model.j == 2)
        {
            app.view.modeText.text = "mode nembak adalah blabla";
        }
    }

    #region Blink Effect
    public void Blinking()
    {

        app.view.imageblink.enabled = app.model.defaultState;
        StartBlink();
    }

    public void StartBlink()
    {
        // do not invoke the blink twice - needed if you need to start the blink from an external object
        if (app.model.isBlinking)
            return;

        if (app.view.imageblink != null)
        {
            app.model.isBlinking = true;
            InvokeRepeating("ToggleState", app.model.startDelay, app.model.interval);
        }
    }
    
    public void ToggleState()
    {
        app.view.imageblink.enabled = !app.view.imageblink.enabled;
        app.model.timesBlinking++;
        if (app.model.timesBlinking == 12)
        {
            app.view.imageblink.enabled = false;
            CancelInvoke();
            app.view.menuButton.SetActive(true);
           
        }

      

    }

    public void ToggleStateTwo()
    {
        //app.view.imageblink.enabled = !app.view.imageblink.enabled;
        app.model.timesBlinking++;
        if (app.model.timesBlinking == 6)
        {
            
            CancelInvoke();
            CharSelect();
            UpdateTextAndButton();
           

        }



    }
    #endregion






}
