using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuInstructionButton : MonoBehaviour
{
	public void InstructionScene()
	{
		SceneManager.LoadScene("InstructionScene");
	}
}
