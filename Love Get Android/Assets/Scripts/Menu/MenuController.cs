using UnityEngine;
using System.Collections;

public class MenuController : MenuElement {


    public void ButtonTappedControl()
    {

        Vector3 logoPindah = new Vector3(0.34f, 3.84f,3f);
        Vector3 logoKecil = new Vector3(0.47f, 0.47f,0.47f);

        //Color colorToFadeTo = new Color(1f, 1f, 1f, 0f);
        iTween.ScaleTo(app.view.tapButton, logoKecil, 1.5f);
        iTween.MoveTo(app.view.tapButton, logoPindah, 1.5f);
        
        Blinking();
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
            //PanelControl();

        }

      

    }
    #endregion






}
