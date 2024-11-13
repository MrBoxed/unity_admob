using GoogleMobileAds.Api;
using Unity.VisualScripting;
using UnityEngine;

public class BannerAdsController : MonoBehaviour
{
    [SerializeField] private string bannerAdID;
    [SerializeField] private BannerView bannerView;
    [SerializeField] private AdPosition adPosition = AdPosition.Top;

    // Size of the banner refer: 
    // https://developers.google.com/admob/unity/banner#banner_sizes
    [SerializeField] private AdSize adSize ; 

    private void Awake()
    {

        adSize = AdSize.Banner;
        // USE FOR FULL WIDTH BANNER AD
        //adSize = AdSize.GetLandscapeAnchoredAdaptiveBannerAdSizeWithWidth(Screen.width);
    }

    /// <summary>
    /// Creates a 320x50 banner view at top of the screen.
    /// </summary>
    public void CreateBannerView()
    {
        Debug.Log("Creating banner view");

        // If we already have a banner , destroy the old one.
        if(bannerView != null )
        {
            DestroyAd();
        }

        // Create a 320x50 banner at top of the screen
        bannerView = new BannerView(bannerAdID, adSize, adPosition);
    }

    /// <summary>
    /// Create the banner view and load the banner ad.
    /// </summary>
    public void LoadBannerAd()
    {
        //create an instance of a banner view first
        if(bannerView == null)
        {
            CreateBannerView();
        }

        // Create our request use to load the ad.
        var adRequest = new AdRequest();

        //send the request to load the ad.
        Debug.Log("Loading banner ad.");
        bannerView.LoadAd(adRequest);

        ListenToAdEvents();
    }

    /// <summary>
    /// listen to events the banner view may raise.
    /// </summary>
    private void ListenToAdEvents()
    {
        // Raised when an ad is loaded into the banner view.
        bannerView.OnBannerAdLoaded += () =>
        {
            Debug.Log("Banner view loaded an ad with response : "
                + bannerView.GetResponseInfo());
        };
        // Raised when an ad fails to load into the banner view.
        bannerView.OnBannerAdLoadFailed += (LoadAdError error) =>
        {
            Debug.LogError("Banner view failed to load an ad with error : "
                + error);
        };
        // Raised when the ad is estimated to have earned money.
        bannerView.OnAdPaid += (AdValue adValue) =>
        {
            Debug.Log(string.Format("Banner view paid {0} {1}.",
                adValue.Value,
                adValue.CurrencyCode));
        };
        // Raised when an impression is recorded for an ad.
        bannerView.OnAdImpressionRecorded += () =>
        {
            Debug.Log("Banner view recorded an impression.");
        };
        // Raised when a click is recorded for an ad.
        bannerView.OnAdClicked += () =>
        {
            Debug.Log("Banner view was clicked.");
        };
        // Raised when an ad opened full screen content.
        bannerView.OnAdFullScreenContentOpened += () =>
        {
            Debug.Log("Banner view full screen content opened.");
        };
        // Raised when the ad closed full screen content.
        bannerView.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Banner view full screen content closed.");
        };
    }

    /// <summary>
    /// Destroys the banner view.
    /// </summary>
    public void DestroyAd()
    {
        if (bannerView != null)
        {
            Debug.Log("Destroying banner view.");
            bannerView.Destroy();
            bannerView = null;
        }
    }
}
