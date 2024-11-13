using UnityEngine;
using GoogleMobileAds.Api;
using Unity.VisualScripting;

public class AdsManager : MonoBehaviour
{
    [Header("AdsController")]
    [SerializeField] private BannerAdsController bannerAdsController;
    [SerializeField] private RewardedAdsController rewardedAdsController;
    [SerializeField] private InterstitialAdsController interstitialAdsController;


    void Start()
    {
        if ((bannerAdsController == null) || (rewardedAdsController == null) || (interstitialAdsController == null))
        {
            Debug.LogError("AdsControllerScript Missing");
            return;
        }


        // Initialize the google mobile ads sdk
        MobileAds.Initialize((initStatus) =>
        {
            Debug.Log("Google AdsMob initailized"+ initStatus );
            
            //bannerAdsController.LoadBannerAd();
        });
       
    }

    #region BannerAds
  
    public void ShowBannerAd()
    {
        bannerAdsController.LoadBannerAd();
    }

    #endregion

    #region RewardedAds
    public void LoadRewardedAd()
    {
        rewardedAdsController.LoadRewardedAd();
    }

    public void ShowRewardedAd()
    {
        rewardedAdsController.ShowRewardedAd();
    }

    #endregion


    #region InterstitialAds
    public void LoadInterstitialAd()
    {
        interstitialAdsController.LoadInterstitialAd();
    }

    public void ShowInterstitialAd()
    {
        interstitialAdsController.ShowInterstitialAd();
    }

    #endregion
}
