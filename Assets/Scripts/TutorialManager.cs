using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SimpleTutorialAnimator : MonoBehaviour
{
    public GameObject tutorialPanel;
    public Image tutorialImage;
    public TMP_Text tutorialText;
    public Button nextButton;
    public Button skipButton;
    public Animator tutorialAnimator; // Referencia al Animator

    public Sprite[] tutorialSprites;
    public string[] tutorialTexts;

    private int currentStep = 0;
    public bool forceShowTutorial = false;  // Flag para forzar que se muestre el tutorial

void Start()
{
    if (forceShowTutorial || PlayerPrefs.GetInt("TutorialCompleted", 0) == 0)
    {
        tutorialPanel.SetActive(true);
        ShowStep();
    }
    else
    {
        tutorialPanel.SetActive(false);
    }

    nextButton.onClick.AddListener(NextStep);
    skipButton.onClick.AddListener(SkipTutorial);
}

    void ShowStep()
    {
        // Mostrar la imagen y el texto correspondientes
        tutorialImage.sprite = tutorialSprites[currentStep];
        tutorialText.text = tutorialTexts[currentStep];

        // Asegúrate de que el Animator esté en la animación correcta para esta imagen
        // Asumimos que las animaciones están nombradas de forma secuencial:
        string animationName = "TutorialStep" + (currentStep + 1);

        // Reproducir la animación correspondiente al paso actual
        tutorialAnimator.Play(animationName);
    }


    public void NextStep()
    {
        currentStep++;

        if (currentStep < tutorialSprites.Length)
        {
            ShowStep();  // Cambia la imagen y el texto

            // Activa el Trigger correspondiente al paso actual
            string triggerName = "Step" + currentStep + "Trigger";
            tutorialAnimator.SetTrigger(triggerName);
        }
        else
        {
            EndTutorial();
        }
    }

    void SkipTutorial()
    {
        EndTutorial();
    }

    void EndTutorial()
    {
        tutorialPanel.SetActive(false);
        PlayerPrefs.SetInt("TutorialCompleted", 1);
        PlayerPrefs.Save();
    }
}
