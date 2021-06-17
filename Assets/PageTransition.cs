using UnityEngine;

public class PageTransition : MonoBehaviour
{
    public GameObject mainPage;
    public GameObject controlsPage;
    public GameObject creditsPage;

    void Start()
    {
        mainPage.SetActive(true);
        controlsPage.SetActive(false);
        creditsPage.SetActive(false);
    }

    public void ShowControls()
    {
        mainPage.SetActive(false);
        controlsPage.SetActive(true);
        creditsPage.SetActive(false);
    }

    public void ShowCredits()
    {
        mainPage.SetActive(false);
        controlsPage.SetActive(false);
        creditsPage.SetActive(true);
    }

    public void ClickBack()
    {
        mainPage.SetActive(true);
        controlsPage.SetActive(false);
        creditsPage.SetActive(false);
    }
}
