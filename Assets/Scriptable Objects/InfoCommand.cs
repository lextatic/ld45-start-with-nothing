using UnityEngine;

[CreateAssetMenu(fileName = "New Info Command", menuName = "Commands/New Info Command")]
public class InfoCommand : Command
{
	public override void Execute()
	{
		int countTotal = 0;
		int countDone = 0;

		foreach(ImageElement ie in ImageElement.Elements.Values)
		{
			countTotal++;
			if(ie.RawImage.enabled)
			{
				countDone++;
			}
		}

		CommandMessage = $"Progress: ({countDone}/{countTotal})";
	}
}
