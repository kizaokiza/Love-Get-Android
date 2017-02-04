using UnityEngine;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
 #endif
 



public class GameController : GameElement
{
    //gamecontrol

    public void PilihanSatuControl()
    {	
		
        app.controller.Expression1();

        if (!app.model.isTyping)
        {
            StartCoroutine(TextScroll("Hmm, Ternyata kamu anaknya asik juga ya! Senang punya teman seperti kamu!"));
        }
    }

	public void hidePilihanButton(bool hide){
		int length = app.view.pilihanButton.Length;
		if (hide) {
			for (int i = 0; i < length; i++) {
				app.view.pilihanButton [i].SetActive (false);	
			}
		} else {
			for (int i = 0; i < length; i++) {
				app.view.pilihanButton[i].SetActive(true);	
			}
		}
	}
		
	public int idCase;
	public string caseDialog;
	public int caseExpression;
	public int caseIs_flipped;
	public int caseIs_main;
	public int caseIs_over;
	public int caseContinue_id;
	public int caseQuestion_id;

	//case mode

	public void dialogLine(int id){
		hidePilihanButton (true);

		this.idCase = id;
		caseDialog = app.caseMode.dialog.mainCase [id].dialog;
		caseExpression = app.caseMode.dialog.mainCase [id].expression;
		caseIs_flipped = app.caseMode.dialog.mainCase [id].is_flipped;
		caseIs_main = app.caseMode.dialog.mainCase [id].is_main;
		caseIs_over = app.caseMode.dialog.mainCase [id].is_over;
		caseContinue_id = app.caseMode.dialog.mainCase [id].continue_id;
		caseQuestion_id = app.caseMode.dialog.mainCase [id].question_id;

		app.view.dialogueText.text= caseDialog;
	}

	//------------//

	public void next(){
		int cId = app.caseMode.dialog.mainCase [idCase].continue_id;
		int qId = app.caseMode.dialog.mainCase [idCase].question_id;
		if (app.caseMode.dialog.mainCase [idCase].is_over == 0) {
			dialogLine (idCase = cId);
		} else {
			questionLine (qId);
		}
	}
	//------------//
	//case question

	public int id { get; set; }
	public string question { get; set; }
	public int is_over { get; set; }
	public int continue_id { get; set; }
	public AnswerList[] answerList { get; set; }

	public void questionLine(int id){
		hidePilihanButton (false);

		this.idQuestion = id;
		this.question = app.caseQuestion.question.mainQuestion [id].question;
		this.is_over = app.caseQuestion.question.mainQuestion [id].is_over;
		this.continue_id = app.caseQuestion.question.mainQuestion [id].continue_id;
		this.answer_id = app.caseQuestion.question.mainQuestion [id].answer_id;

		app.view.dialogueText.text = question;

	}
	//--------------//

    #region Expressions
    public void Expression1()
    {
    #if UNITY_EDITOR
        app.view.karakterSprite.sprite = (Sprite)UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/Sprite/Char/blush2.png", typeof(Sprite));
# endif
    }
    public void Expression2()
    {
#if UNITY_EDITOR
        app.view.karakterSprite.sprite = (Sprite)UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/Sprite/Char/laugh2.png", typeof(Sprite));
# endif
    }
    public void Expression3()
    {
#if UNITY_EDITOR
        app.view.karakterSprite.sprite = (Sprite)UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/Sprite/Char/mad2.png", typeof(Sprite));
# endif
    }
    public void Expression4()
    {
#if UNITY_EDITOR
        app.view.karakterSprite.sprite = (Sprite)UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/Sprite/Char/sad2.png", typeof(Sprite));
# endif
    }
    public void Expression5()
    {
#if UNITY_EDITOR
        app.view.karakterSprite.sprite = (Sprite)UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/Sprite/Char/smile2.png", typeof(Sprite));
#endif
    }

    #endregion

    #region Typing
    private IEnumerator TextScroll(string lineOfText)
    {
        int letter = 0;
        app.view.dialogueText.text = "";
        app.model.isTyping = true;
        app.model.cancelTyping = false;

        while (app.model.isTyping && !app.model.cancelTyping && (letter < lineOfText.Length - 1))
        {
            app.view.dialogueText.text += lineOfText[letter];
            letter += 1;
            yield return new WaitForSeconds(app.model.typeSpeed);
        }

        app.view.dialogueText.text = lineOfText;
        app.model.isTyping = false;
        app.model.cancelTyping = false;
    }
    #endregion


}
