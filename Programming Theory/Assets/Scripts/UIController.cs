using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    [SerializeField] private Button button;
    

    Color pressedColor = Color.green;
    Color normalColor = Color.red;
    bool isPressed = false;
    public void PressButton()
    {
        if (!isPressed)
        {
            SceneManagement.Instance.PauseGame();
            isPressed = true;
            ChangeButtonColor(pressedColor);
            return;
        }
        SceneManagement.Instance.ResumeGame();
        isPressed = false;
        ChangeButtonColor(normalColor);

    }

    void ChangeButtonColor(Color newColor)
    {
        button.GetComponent<Image>().color = newColor;
    }

   
}