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
        // ����������� ������� ������� Esc
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
        yield return StartCoroutine(ShowText("����-����...", 4f));
        screenText.fontSize = startFontSize;
        yield return StartCoroutine(ShowText("����� �� ����. � ��� ���� ����� �� ����� ���������", 4f));
        yield return StartCoroutine(ShowText("��������, � �������� ����, � �� ������ �� ������, ������ ������! \n�� ���� �� �����, ���� ������� � �� ����� ���� ��������.", 9f));
        yield return StartCoroutine(ShowText("���� � ������� ����, � ����� ��������, ��� �� �����������: \n�������� ������ �� ������ ��� ������, ���� �������� �� �����,\n����������, �����������.", 10f));
        yield return StartCoroutine(ShowText("�������� ����-������, ���������� ��������, ������ �� �������.", 5f));
        yield return StartCoroutine(ShowText("��������� �������, ����� � ������ ����...", 4f));
        esctext.SetActive(false);
        yield return StartCoroutine(ShowText("", 1f));
        
        nextButton.SetActive(true);
    }
    private IEnumerator ShowText(string text, float delay)
    {
        screenText.text = text;
        yield return new WaitForSeconds(delay); // ���� ��������� �����
    }
    private void StopPrehistoryText()
    {
        if (showTextCoroutine != null)
        {
            StopCoroutine(showTextCoroutine); // ������������� ��������
            showTextCoroutine = null;
            screenText.text = "";
            screenTextObj.SetActive(false);
            nextButton.SetActive(true); // ����� ���������� ������
            esctext.SetActive(false);
        }

    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }
}
