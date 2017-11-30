using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;



//-------------------------------------------------------------------//

[RequireComponent(typeof(Button))]
public class UnityAdsButton : MonoBehaviour
{
    //---------- ONLY NECESSARY FOR ASSET PACKAGE INTEGRATION: ----------//

#if UNITY_IOS
private string gameId = "1622079";
#elif UNITY_ANDROID
private string gameId = "1622078";
#else
    private string gameId = "1622079";
#endif

    Button m_Button;

    public string placementId = "rewardedVideo";

    void Start()
    {
        m_Button = GetComponent<Button>();
        if (m_Button) m_Button.onClick.AddListener(ShowAd);

        if (Advertisement.isSupported)
        {
            Advertisement.Initialize(gameId, true);
        }

        //---------- ONLY NECESSARY FOR ASSET PACKAGE INTEGRATION: ----------//

        if (Advertisement.isSupported)
        {
            Advertisement.Initialize(gameId, true);
        }

        //-------------------------------------------------------------------//

    }

    void Update()
    {
        if (m_Button) m_Button.interactable = Advertisement.IsReady(placementId);
    }

    void ShowAd()
    {
        ShowOptions options = new ShowOptions();
        options.resultCallback = HandleShowResult;

        Advertisement.Show(placementId, options);
    }

    void HandleShowResult(ShowResult result)
    {
        if (result == ShowResult.Finished)
        {
            Debug.Log("Video completed - Offer a reward to the player");

        }
        else if (result == ShowResult.Skipped)
        {
            Debug.LogWarning("Video was skipped - Do NOT reward the player");

        }
        else if (result == ShowResult.Failed)
        {
            Debug.LogError("Video failed to show");
        }
    }
}