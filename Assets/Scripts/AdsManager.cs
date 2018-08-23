using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using GoogleMobileAds;
using GoogleMobileAds.Api;

public class AdsManager : MonoBehaviour 
{
	BannerView bannerView;
    InterstitialAd interstitial;

	void Start () 
	{
		//REQUEST ADS
        //BANNERY
        // replace this id with your orignal admob id for banner ad
        string adUnitId = "ca-app-pub-6664990634315908/8095203321";

        // Create a 320x50 banner at the top of the screen.
        bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the banner with the request.
        bannerView.LoadAd(request);
        bannerView.OnAdLoaded += HandleOnAdLoaded;

        //INTERSTITIAL
        // Initialize an InterstitialAd.
        string interstitialId = "ca-app-pub-6664990634315908/2683094546";
        interstitial = new InterstitialAd(interstitialId);
        AdRequest requestInterstitial = new AdRequest.Builder().Build();
        interstitial.OnAdClosed += Interstitial_OnAdClosed;
        interstitial.LoadAd(request);

	}
	

	void Update () 
	{
		
	}
	public void OnDestroy()
    {
        bannerView.Destroy();
    }

    void HandleOnAdLoaded(object a, EventArgs args)
    {
        print("loaded");
        bannerView.Show();
    }


    private void Interstitial_OnAdClosed(object sender, System.EventArgs e)
    {

    }

	
    public void RequestBanner()
    {
        bannerView.Show();
    }

    public void DestroyBanner()
    {
        bannerView.Hide();
    }

    public void RequestInterstitial()
    {
        Debug.Log("Showing interstitial ad");
        interstitial.Show();
    }

#region Banner callback handlers

    public void HandleAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLoaded event received");
    }

    public void HandleAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print("HandleFailedToReceiveAd event received with message: " + args.Message);
    }

    public void HandleAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
    }

    public void HandleAdLeftApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeftApplication event received");
    }

#endregion
}
