using DebuggerPlus.Command;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExampleCommands
{

    [RegisterCommand(Name = "test", Help = "Example Command")]
    static void ExampleCommandTest(CommandArg[] args)
    {
        Debug.Log("ExampleCommandTest");
    }
}
