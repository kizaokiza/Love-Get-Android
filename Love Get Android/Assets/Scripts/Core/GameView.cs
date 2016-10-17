using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameView : GameElement
{
    public Image karakterSprite;
    public GameObject nameText;
    public Text dialogueText;
    public GameObject explanationPanel;
    public GameObject explanationText;

    //Button pilihan

    public GameObject buttonPilihan;
    //public GameObject buttonPilihan1;
    //public GameObject buttonPilihan2;
    //public GameObject buttonPilihan3;
    //public GameObject buttonPilihan4;

    //text pilihan
    //public GameObject textPilihan1;
    //public GameObject textPilihan2;
    //public GameObject textPilihan3;
    //public GameObject textPilihan4;

    public void ExplanationBoxTouched()
    {
        buttonPilihan.SetActive(true);
        app.controller.Expression5();
    }

    public void PilihanSatu()
    {
       
        app.controller.PilihanSatuControl();
        
    }

    public void PilihanDua()
    {
        app.controller.PilihanDuaControl();
    }

    public void PilihanTiga()
    {
        app.controller.PilihanTigaControl();
    }

    public void PilihanEmpat()
    {
        app.controller.PilihanEmpatControl();
    }

}
