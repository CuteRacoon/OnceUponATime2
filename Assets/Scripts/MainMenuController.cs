using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public Text screenText;
    public GameObject nextButton;
    private int startFontSize;
    private Coroutine showTextCoroutine;
    public GameObject esctext;
    public GameObject screenTextObj;
    void Start()
    {
        nextButton.SetActive(false);
        screenText.text = null;
        startFontSize = screenText.fontSize;
        StartCoroutine(ShowPrehistoryText());
        showTextCoroutine = StartCoroutine(ShowPrehistoryText());
        esctext.SetActive(false);
    }
    private void Update()
    {
        // Отслеживаем нажатие клавиши Esc
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StopPrehistoryText();
        }
    }
    public void OnNextButton()
    {
        PlayGame();
    }
    private IEnumerator ShowPrehistoryText()
    {
        yield return new WaitForSeconds(2f);
        screenText.fontSize = 80;
        esctext.SetActive(true);
        yield return StartCoroutine(ShowText("Жили-были...", 4f));
        screenText.fontSize = startFontSize;
        yield return StartCoroutine(ShowText("мужик да баба. У них была дочка да сынок маленький", 4f));
        yield return StartCoroutine(ShowText("Доченька, — говорила мать, — мы поедем на работу, береги братца! \nНе ходи со двора, будь умницей — мы купим тебе платочек.", 9f));
        yield return StartCoroutine(ShowText("Отец с матерью ушли, а дочка позабыла, что ей приказывали: \nпосадила братца на травке под окошко, сама побежала на улицу,\nзаигралась, разгулялась.", 10f));
        yield return StartCoroutine(ShowText("Налетели гуси-лебеди, подхватили мальчика, унесли на крыльях.", 5f));
        yield return StartCoroutine(ShowText("Вернулась девочка, глядь — братца нету...", 4f));
        esctext.SetActive(false);
        yield return StartCoroutine(ShowText("", 1f));
        
        nextButton.SetActive(true);
    }
    private IEnumerator ShowText(string text, float delay)
    {
        screenText.text = text;
        yield return new WaitForSeconds(delay); // Ждем указанное время
    }
    private void StopPrehistoryText()
    {
        if (showTextCoroutine != null)
        {
            StopCoroutine(showTextCoroutine); // Останавливаем корутину
            showTextCoroutine = null;
            screenText.text = "";
            screenTextObj.SetActive(false);
            nextButton.SetActive(true); // Сразу показываем кнопку
            esctext.SetActive(false);
        }

    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }
}
