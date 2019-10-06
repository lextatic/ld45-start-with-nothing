using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Console : MonoBehaviour
{
	public TMP_InputField InputField;
	public TMP_Text TextField;

	public List<Command> PermanentCommands;

	public List<Command> EnabledCommands;

	private void Start()
	{
		ClearInputField();
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
				if(!EnabledCommands.Contains(unlockedCommand))
				{
					EnabledCommands.Add(unlockedCommand);
				}
			}

			TextField.SetText($">\n{cmd.CommandMessage}\n>{InputField.text}");
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
}
