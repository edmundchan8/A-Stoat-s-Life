using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    //If level is splash screen (Level 0), load next scene after certain seconds
    //get access to current level
	[Header ("Constant Settings")]
	[SerializeField]
	int CURRENT_LEVEL = 0;
	[SerializeField]
	float LOAD_NEXT_LEVEL_TIME = 0f;

    void Start()
    {	//sets current level to CURRENT_LEVEL
        CURRENT_LEVEL = SceneManager.GetActiveScene().buildIndex;
        if (CURRENT_LEVEL == 0)
        {	//load the title screen after certain period of time
            Invoke("LoadAfterSplash", LOAD_NEXT_LEVEL_TIME);
        }
    }

    void LoadAfterSplash()
    {
        //This will set an int variable to be currentlevel ++, then load that variable number corresponding to the level
        int level = CURRENT_LEVEL + 1;
        SceneManager.LoadScene(level);
    }

	//load level method by name
	public void LoadLevelName (string LEVEL_NAME)
	{
		SceneManager.LoadScene (LEVEL_NAME);
	}
}
