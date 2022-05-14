using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class DialogHandler : MonoBehaviour
{
    public string dialog;
    [SerializeField]
    private TextMeshProUGUI dialogBox;
    private string dialogText;
    public bool isFinished = false;

    private Coroutine printDialog;

    private void Start()
    {
        printDialog = StartCoroutine(printText());
    }

    private void Update()
    {
        bool isOverUI = EventSystem.current.IsPointerOverGameObject();
        if (!isFinished)
        {
            if (Input.GetMouseButtonDown(0) && isOverUI)
            {
                StopCoroutine(printDialog);
                dialogBox.text = dialog;
                isFinished = true;
            }
            else
            {
                dialogBox.text = dialogText;
            }
        }
    }

    public void CloseBtn()
    {
        Destroy(gameObject);
    }

    IEnumerator printText()
    {
        isFinished = false;
        yield return new WaitForSeconds(.05f);
        foreach (char c in dialog.ToCharArray())
        {
            dialogText += c;
            yield return new WaitForSeconds(.05f);
        }
        isFinished = true;
    }
}
