using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Console : MonoBehaviour
{
	public TMP_InputField InputField;
	public TMP_Text TextField;

	public List<Command> PermanentCommands;

	public List<Command> EnabledCommands;

	private List<Command> UsedCommands;

	private void Start()
	{
		ClearInputField();
		UsedCommands = new List<Command>();
	}

	public void SubmitCommand()
	{
		//Debug.Log($"Execute {InputField.text}");
		Command cmd;
		if(FindCommand(InputField.text, out cmd))
		{
			cmd.Execute();

			foreach(Command unlockedCommand in cmd.CommandUnlocks)
			{
				if(!EnabledCommands.Contains(unlockedCommand) && !UsedCommands.Contains(unlockedCommand))
				{
					EnabledCommands.Add(unlockedCommand);
				}
			}

			if (CheckGameOver())
			{
				TextField.SetText($">\nWell done! You finished the game.\n>{InputField.text}");
				// Could disable commands here.
			}
			else
			{
				TextField.SetText($">\n{cmd.CommandMessage}\n>{InputField.text}");
			}
		}

		else
		{
			TextField.SetText($">\n{FindHelper()}\n>{InputField.text}");
		}

		ClearInputField();
	}

	private bool FindCommand(string commandToFind, out Command command)
	{
		command = null;

		foreach (Command cmd in PermanentCommands)
		{
			foreach (string alias in cmd.CommandAliases)
			{
				if (string.Compare(commandToFind, alias, true) == 0)
				{
					command = cmd;
					return true;
				}
			}

		}

		bool foundCommand = false;
		foreach (Command cmd in EnabledCommands)
		{
			foreach (string alias in cmd.CommandAliases)
			{
				if (string.Compare(commandToFind, alias, true) == 0)
				{
					command = cmd;
					foundCommand = true;
				}
			}

		}

		if(foundCommand)
		{
			EnabledCommands.Remove(command);
			UsedCommands.Add(command);
		}
		
		return foundCommand;
	}

	private string FindHelper()
	{
		var allCommandHints = new List<string>();

		foreach (Command cmd in PermanentCommands)
		{
			allCommandHints.AddRange(cmd.CommandHints);
		}

		foreach (Command cmd in EnabledCommands)
		{
			allCommandHints.AddRange(cmd.CommandHints);
		}

		return allCommandHints[Random.Range(0, allCommandHints.Count)];
	}

	private void ClearInputField()
	{
		InputField.ActivateInputField();
		InputField.Select();
		InputField.text = "";
	}

	private bool CheckGameOver()
	{
		foreach (ImageElement ie in ImageElement.Elements.Values)
		{
			if (!ie.RawImage.enabled)
			{
				return false;
			}
		}

		return true;
	}
}
