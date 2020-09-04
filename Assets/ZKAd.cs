using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;
using UnityEngine.SceneManagement;

public class ZKAd : MonoBehaviour {

	BannerView bannerView;
	public static InterstitialAd interstitial;
	public static RewardBasedVideoAd rewardBasedVideo;
	public string androidAppIdCode = "ca-app-pub-5796843895531667~4210718696";
	public string androidBanner = "ca-app-pub-3940256099942544/6300978111";
	public string androidInterstitial = "ca-app-pub-3940256099942544/1033173712";
	public string androidRewarded = "ca-app-pub-3940256099942544/5224354917";
	public string iosAppIdCode = "ca-app-pub-5796843895531667~5078159377";
	public string iosBanner = "ca-app-pub-5796843895531667/1710185036";
	public string iosInterstitial = "ca-app-pub-5796843895531667/7652776856";
	public string iosRewarded = "ca-app-pub-3940256099942544/5224354917";

	AdRequest intrequest;

    public void Start(){
		DontDestroyOnLoad(this.gameObject);

		//Initialize
		#if UNITY_ANDROID
		string appId = androidAppIdCode;
		#elif UNITY_IPHONE
		string appId = iosAppIdCode;
		#else
		string appId = "NONE";
		#endif

		MobileAds.Initialize (appId);

		//BANNER
        this.RequestBanner();
		// Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the banner with the request.
        bannerView.LoadAd(request);


		//INTERSTITIAL
		#if UNITY_ANDROID
			string interstitialUnitId = androidInterstitial;
		#elif UNITY_IPHONE
			string interstitialUnitId = iosInterstitial;
		#else
			string interstitialUnitId = "unexpected_platform";
		#endif

		// Initialize an InterstitialAd.
		interstitial = new InterstitialAd(interstitialUnitId);

		// Create an empty ad request.
		intrequest = new AdRequest.Builder().Build();
		// Load the interstitial with the request.
		interstitial.LoadAd(intrequest);

		// Called when an ad request has successfully loaded.
		interstitial.OnAdLoaded += HandleOnAdLoaded;
		// Called when an ad request failed to load.
		interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
		// Called when an ad is shown.
		interstitial.OnAdOpening += HandleOnAdOpened;
		// Called when the ad is closed.
		interstitial.OnAdClosed += HandleOnAdClosed;
		// Called when the ad click caused the user to leave the application.
		interstitial.OnAdLeavingApplication += HandleOnAdLeavingApplication;

		//REWARDED
		// Get singleton reward based video ad reference.
		rewardBasedVideo = RewardBasedVideoAd.Instance;
		// Called when an ad request has successfully loaded.
		rewardBasedVideo.OnAdLoaded += HandleRewardBasedVideoLoaded;
		// Called when an ad request failed to load.
		rewardBasedVideo.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;
		// Called when an ad is shown.
		rewardBasedVideo.OnAdOpening += HandleRewardBasedVideoOpened;
		// Called when the ad starts to play.
		rewardBasedVideo.OnAdStarted += HandleRewardBasedVideoStarted;
		// Called when the user should be rewarded for watching a video.
		rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
		// Called when the ad is closed.
		rewardBasedVideo.OnAdClosed += HandleRewardBasedVideoClosed;
		// Called when the ad click caused the user to leave the application.
		rewardBasedVideo.OnAdLeavingApplication += HandleRewardBasedVideoLeftApplication;
		//RequestRewardBasedVideo();
    }

    public void RequestBanner(){
        #if UNITY_ANDROID
			string adUnitId = androidBanner;
        #elif UNITY_IPHONE
			string adUnitId = iosBanner;
        #else
            string adUnitId = "unexpected_platform";
        #endif

        // Create a 320x50 banner at the top of the screen.
        bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);
    }

	public void HandleOnAdLoaded(object sender, EventArgs args)
	{
		MonoBehaviour.print("HandleAdLoaded event received");
	}

	public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
	{
		MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
	+ args.Message);
		interstitial.LoadAd(intrequest);
	}

	public void HandleOnAdOpened(object sender, EventArgs args)
	{
		MonoBehaviour.print("HandleAdOpened event received");
	}

	public void HandleOnAdClosed(object sender, EventArgs args)
	{
		MonoBehaviour.print("HandleAdClosed event received");
		interstitial.LoadAd(intrequest);
	}

	public void HandleOnAdLeavingApplication(object sender, EventArgs args)
	{
		MonoBehaviour.print("HandleAdLeavingApplication event received");
	}

	public void RequestRewardBasedVideo(){
		#if UNITY_ANDROID
		string adUnitId = androidRewarded;
		#elif UNITY_IPHONE
		string adUnitId = iosRewarded;
		#else
		string adUnitId = "unexpected_platform";
		#endif

		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder().Build();
		// Load the rewarded video ad with the request.
		rewardBasedVideo.LoadAd(request, adUnitId);
	}

	public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
	{
	MonoBehaviour.print("HandleRewardBasedVideoLoaded event received");
	}

	public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
	{
		MonoBehaviour.print("HandleRewardBasedVideoFailedToLoad event received with message: " + args.Message);
		this.RequestRewardBasedVideo();
	}

	public void HandleRewardBasedVideoOpened(object sender, EventArgs args)
	{
		MonoBehaviour.print("HandleRewardBasedVideoOpened event received");
		this.RequestRewardBasedVideo();
	}

	public void HandleRewardBasedVideoStarted(object sender, EventArgs args)
	{
	MonoBehaviour.print("HandleRewardBasedVideoStarted event received");
	}

	public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
	{
	MonoBehaviour.print("HandleRewardBasedVideoClosed event received");
	}

	public void HandleRewardBasedVideoRewarded(object sender, Reward args)
	{
		string type = args.Type;
		double amount = args.Amount;
		/*
		MonoBehaviour.print(
		"HandleRewardBasedVideoRewarded event received for "
		+ amount.ToString() + " " + type);
		*/
		SceneManager.LoadScene ("Main");
	}

	public void HandleRewardBasedVideoLeftApplication(object sender, EventArgs args)
	{
	MonoBehaviour.print("HandleRewardBasedVideoLeftApplication event received");
	}
}
