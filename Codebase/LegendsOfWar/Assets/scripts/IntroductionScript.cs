using UnityEngine;

public class IntroductionScript : MonoBehaviour
{
	[SerializeField]
	GameObject loading = null;

	void Update()
	{
		if ( Input.anyKeyDown )
		{
			if ( Input.GetKey( KeyCode.Escape ) )
				ApplicationManager.Instance.ChangeAppState( StateID.STATE_MAIN_MENU );
			else if ( !Input.GetKey( KeyCode.F12 ) )
			{
				loading.SetActive( true );
				ApplicationManager.Instance.ChangeAppState( StateID.STATE_INGAME );
			}
		}
	}
}