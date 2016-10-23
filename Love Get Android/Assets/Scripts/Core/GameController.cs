using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
 #endif
 



public class GameController : GameElement
{
    //gamecontrol

    public void PilihanSatuControl()
    {
        app.view.buttonPilihan.SetActive(false);
        app.controller.Expression1();

        if (!app.model.isTyping)
        {
            StartCoroutine(TextScroll("Hmm, Ternyata kamu anaknya asik juga ya! Senang punya teman seperti kamu!"));
        }
    }

    public void PilihanDuaControl()
    {
        app.view.buttonPilihan.SetActive(false);
        app.controller.Expression2();
    }

    public void PilihanTigaControl()
    {
        app.view.buttonPilihan.SetActive(false);
        app.controller.Expression3();
    }

    public void PilihanEmpatControl()
    {
        app.view.buttonPilihan.SetActive(false);
        app.controller.Expression4();
    }


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
