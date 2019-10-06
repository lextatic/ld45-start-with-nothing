using UnityEngine;

[CreateAssetMenu(fileName = "New Info Command", menuName = "Commands/New Info Command")]
public class InfoCommand : Command
{
	public override void Execute() { }

	public override string FormattedCommandMessage
	{
		get
		{
			return $"<color=\"yellow\">{CommandMessage}</color>";
		}
	}
}
