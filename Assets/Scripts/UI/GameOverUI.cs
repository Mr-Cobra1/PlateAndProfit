using StarterAssets;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.Windows;

public class GameOverUI : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI recipesDelieveredText;

    private void Start()
    {
        KitchenGameManager.Instance.OnStateChanged += KitchenGameManager_OnStateChanged;

        Hide();
    }

    private void KitchenGameManager_OnStateChanged(object sender, EventArgs e)
    {
        if (KitchenGameManager.Instance.IsGameOver())
        {
            Show();
            Cursor.lockState = CursorLockMode.Confined;

            int recipesDelieveredValue = Mathf.CeilToInt(DeliveryManager.Instance.GetSuccessfulRecipesAmount());
            recipesDelieveredText.text = recipesDelieveredValue.ToString();
        }
        else
        {
            Hide();
        }
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }

}
