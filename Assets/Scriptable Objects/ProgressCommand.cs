using UnityEngine;

[CreateAssetMenu(fileName = "New Progress Command", menuName = "Commands/New Progress Command")]
public class ProgressCommand : Command
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

	public override string FormattedCommandMessage
	{
		get
		{
			int countTotal = 0;
			int countDone = 0;

			foreach (ImageElement ie in ImageElement.Elements.Values)
			{
				countTotal++;
				if (ie.RawImage.enabled)
				{
					countDone++;
				}
			}

			return $"<color=\"yellow\">Progress:</color> (<color=\"yellow\">{countDone}</color>/<color=\"yellow\">{countTotal}</color>)";
		}
	}
}
