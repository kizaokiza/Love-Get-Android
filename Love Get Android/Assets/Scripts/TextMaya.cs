using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextMaya : MonoBehaviour {

    //gameapp
    public Text dialogText;
    GameObject textbox;
    public int currentLine;
    public int endAtLine;
    public SpriteRenderer spriteRenderer;

    private bool isTyping = false;
    private bool cancelTyping = false;

    

    public float typeSpeed;

    public Sprite sprite1; // Drag your first sprite here
    public Sprite sprite2; // Drag your second sprite here
    public Sprite sprite3; // Drag your first sprite here
    public Sprite sprite4; // Drag your second sprite here
    public Sprite sprite5; // Drag your second sprite here
    




    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
       
	
	}

    private IEnumerator TextScroll (string lineOfText)
    {
        int letter = 0;
        dialogText.text = "";
        isTyping = true;
        cancelTyping = false;

        while (isTyping && !cancelTyping && (letter <lineOfText.Length-1))
        {
            dialogText.text += lineOfText[letter];
            letter += 1;
            yield return new WaitForSeconds(typeSpeed);
        }

        dialogText.text = lineOfText;
        isTyping = false;
        cancelTyping = false;
    }

    public void clicked1()
    {
        if (!isTyping)
        {
            StartCoroutine(TextScroll("Hmm, Ternyata kamu anaknya asik juga ya! Senang punya teman seperti kamu!"));
        }
        
        //dialogText.text = "Pilihan 1";
        spriteRenderer.GetComponent<SpriteRenderer>().sprite = sprite2;
    }

    public void clicked2()
    {
        if (!isTyping)
        {
            StartCoroutine(TextScroll("Ja-jangan ucapkan kata-kata mesum dong!"));
        }
        spriteRenderer.GetComponent<SpriteRenderer>().sprite = sprite3;
    }

    public void clicked3()
    {
        dialogText.text = "Pilihan 3";
        spriteRenderer.GetComponent<SpriteRenderer>().sprite = sprite4;
    }

    public void clicked4()
    {
        dialogText.text = "Pilihan 4";
        spriteRenderer.GetComponent<SpriteRenderer>().sprite = sprite5;
    }
}
