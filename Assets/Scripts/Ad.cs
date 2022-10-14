using UnityEngine;
using UnityEngine.Advertisements;
using GoogleMobileAds.Api;
using System;

public class Ad : MonoBehaviour, IUnityAdsListener
{
    public static Ad ad;

    private RewardBasedVideoAd rewardBasedVideo;
    private InterstitialAd interstitial;
    private BannerView bannerView;

    [Header("Google AdMob")]
    public string bannerID;
    public string interID;
    public string rewardID;

    [Header("Unity Ads")]
    public string gameID;
    public bool testMode = true;

    void Awake()
    {
        if (ad == null)
        {
            DontDestroyOnLoad(gameObject);
            ad = this;
        }
        else if (ad != this)
        {
            Destroy(gameObject);
        }
        Advertisement.AddListener(this);
    }

    void Start()
    {
        //RequestBanner();
        RequestInterstitial();
        RequestRewardBasedVideo();

        Advertisement.Initialize(gameID, testMode);
    }

    public void AdGoogle()
    {
        if (interstitial.IsLoaded())
        {
            interstitial.Show();
        }
        else if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }
    }

    public void AdUnity()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }
        else if (interstitial.IsLoaded())
        {
            interstitial.Show();
        }
    }

    public void Ad_OnlyUnity()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }
    }

    public void AdReward()
    {
        if (rewardBasedVideo.IsLoaded())
        {
            rewardBasedVideo.Show();
        }
        else if (Advertisement.IsReady("rewardedVideo"))
        {
            //var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show("rewardedVideo");
        }
        else
        {
            //Save.save.RewardUnsucces();
        }
    }

    public void LoadBanner()
    {
        RequestBanner();
    }


    //----------Unity Reward Video--------------------------------------------------


    private void ShowAd()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            //var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show("rewardedVideo");
        }
    }


    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished)
        {
            // Reward the user for watching the ad to completion.
            //Invoke(nameof(Reward1), 0.5f);
        }
        else if (showResult == ShowResult.Skipped)
        {
            // Do not reward the user for skipping the ad.
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.LogWarning("The ad did not finish due to an error.");
        }
    }

    public void OnUnityAdsReady(string placementId)
    {
        // If the ready Placement is rewarded, show the ad:
        if (placementId == "rewardedVideo")
        {
            // Optional actions to take when the placement becomes ready(For example, enable the rewarded ads button)
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        // Log the error.
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        // Optional actions to take when the end-users triggers an ad.
    }

    // When the object that subscribes to ad events is destroyed, remove the listener:
    public void OnDestroy()
    {
        Advertisement.RemoveListener(this);
    }


    //----------Google Admob Banner--------------------------------------------------
    private void RequestBanner()
    {
#if UNITY_ANDROID
        string adUnitId = bannerID;
#elif UNITY_IPHONE
        string adUnitId = bannerID;
#else
        string adUnitId = "unexpected_platform";
#endif
        // Create a 320x50 banner at the top of the screen.
        //AdSize adSize = new AdSize(250, 250);
        AdSize adSize = new AdSize(320, 40);
        bannerView = new BannerView(adUnitId, adSize, AdPosition.Top);
        AdRequest request = new AdRequest.Builder().Build();
        bannerView.LoadAd(request);
        bannerView.OnAdLoaded += OnBannerLoaded;
    }

    public void OnBannerLoaded(object sender, EventArgs args)
    {
        Debug.Log("HandleAdLoaded event received");
        Aspect_ratio.ratio.On_panel();
    }


    //----------Google Admob InterstitialAd--------------------------------------------------
    private void RequestInterstitial()
    {
#if UNITY_ANDROID
        string adUnitId = interID;
#elif UNITY_IPHONE
        string adUnitId = interID;
#else
        string adUnitId = "unexpected_platform";
#endif

        interstitial = new InterstitialAd(adUnitId);
        AdRequest request = new AdRequest.Builder().Build();
        interstitial.LoadAd(request);
        interstitial.OnAdClosed += OnInterClosed;
    }

    public void OnInterClosed(object sender, EventArgs args)
    {
        RequestInterstitial();
    }

    //----------Google Admob RewardVideoAd--------------------------------------------------
    private void RequestRewardBasedVideo()
    {
#if UNITY_ANDROID
        string adUnitId = rewardID;
#elif UNITY_IPHONE
        string adUnitId = rewardID;
#else
        string adUnitId = "unexpected_platform";
#endif

        rewardBasedVideo = RewardBasedVideoAd.Instance;
        AdRequest request = new AdRequest.Builder().Build();
        //.AddTestDevice(AdRequest.TestDeviceSimulator)
        //.AddTestDevice("")
        //.Build();

        this.rewardBasedVideo.LoadAd(request, adUnitId);

        rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;

        rewardBasedVideo.OnAdClosed += HandleRewardBasedVideoClosed;
    }

    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
        //Our Code
        //Invoke(nameof(Reward1), 0.5f);
    }

    public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
    {
        RequestRewardBasedVideo();
    }

    //void Reward1()
    //{
    //    Save.save.RewardSucces();
    //}

    //void Reward2()
    //{
    //    Save.save.RewardSucces2();
    //}
}

    
