using UnityEngine;
using System.Collections;

using Soomla.Profile;
using Soomla;
//using JsonDotNet;

public class TestSoomlaProfile : MonoBehaviour {

	// Use this for initialization
	void Start () {
		SoomlaProfile.Initialize();

		ProfileEvents.OnLoginStarted += OnLoginStarted;
		ProfileEvents.OnLoginFinished += OnLoginFinished;
		ProfileEvents.OnLoginFailed += OnLoginFailed;
		ProfileEvents.OnLoginCancelled += OnLoginCancelled;

		ProfileEvents.OnLogoutFinished += onLogoutFinished;
		ProfileEvents.OnLogoutFailed += onLogoutFailed;
	}

	public void OnLoginStarted(Provider provider, string payload) {

	}

	public void OnLoginFinished(UserProfile profile, string payload) {
		Debug.Log("OnLoginFinished : " + profile.toJSONObject().Print(true));
	}

	public void OnLoginCancelled(Provider profile, string s) {
	}

	public void OnLoginFailed(Provider profile, string message, string payload) {
		Debug.Log("OnLoginFailed : " + message);
	}

	public void onLogoutFinished(Provider provider) {
		// provider is the social provider
		
		// ... your game specific implementation here ...
    }

	public void onLogoutFailed(Provider provider, string payload) {
		// provider is the social provider
		// payload is an identification string that you can give when you initiate the logout operation and want to receive back upon failure
		
		// ... your game specific implementation here ...
    }
    
	
	// Update is called once per frame
	void OnGUI () {
		if(GUILayout.Button("Login G+", GUILayout.MinWidth(200), GUILayout.MinHeight(100))) {
			SoomlaProfile.Login(Provider.GOOGLE, "", null);
		}

		if(GUILayout.Button("Logout G+", GUILayout.MinWidth(200), GUILayout.MinHeight(100))) {
			SoomlaProfile.Logout(Provider.GOOGLE);
        }

		if(GUILayout.Button("Login Twitter", GUILayout.MinWidth(200), GUILayout.MinHeight(100))) {
			SoomlaProfile.Login(Provider.TWITTER, "", null);
		}
		
		if(GUILayout.Button("Logout Twitter", GUILayout.MinWidth(200), GUILayout.MinHeight(100))) {
			SoomlaProfile.Logout(Provider.TWITTER);
        }
    }
}
