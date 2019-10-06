using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "New Reset Command", menuName = "Commands/New Reset Command")]
public class ResetCommand : Command
{
	public override void Execute()
	{
		SceneManager.LoadScene(0);
	}
}
