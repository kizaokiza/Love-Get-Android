using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameView : GameElement
{
    //gameview
    public Image karakterSprite;
    public GameObject nameText;
    public Text dialogueText;
    public GameObject explanationPanel;
    public GameObject explanationText;

    //Button pilihan
	public GameObject[] pilihanButton;

    public void ExplanationBoxTouched()
    {
        
    }
}
