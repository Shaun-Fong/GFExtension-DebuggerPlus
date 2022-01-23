using UnityEngine;
using System.Text;
using System.Collections;
using UnityEngine.Assertions;
using GameFramework;
using UnityGameFramework.Runtime;

namespace DebuggerPlus.Command
{

    public class Command
    {

        public string Command_text { get; set; }

        public static CommandShell Shell { get; private set; }
        public static CommandHistory History { get; private set; }
        public static CommandAutocomplete Autocomplete { get; private set; }

        public static bool IssuedError
        {
            get { return Shell.IssuedErrorMessage != null; }
        }

        public Command()
        {
            Shell = new CommandShell();
            History = new CommandHistory();
            Autocomplete = new CommandAutocomplete();

            Command_text = "";

            Shell.RegisterCommands();

            if (IssuedError)
            {
                Log.Error("Command Error: {0}", Shell.IssuedErrorMessage);
            }

            foreach (var command in Shell.Commands)
            {
                Autocomplete.Register(command.Key);
            }
        }

        public void EnterCommand()
        {
            Log.Info("Command:{0}", Command_text);
            Shell.RunCommand(Command_text);
            History.Push(Command_text);

            if (IssuedError)
            {
                Log.Error("Command Error: {0}", Shell.IssuedErrorMessage);
            }

            Command_text = "";
        }

        public void CompleteCommand()
        {
            string head_text = Command_text;
            int format_width = 0;

            string[] completion_buffer = Autocomplete.Complete(ref head_text, ref format_width);
            int completion_length = completion_buffer.Length;

            if (completion_length != 0)
            {
                Command_text = head_text;
            }

            if (completion_length > 1)
            {
                // Print possible completions
                var log_buffer = new StringBuilder();

                foreach (string completion in completion_buffer)
                {
                    log_buffer.Append(completion.PadRight(format_width + 4));
                }

                Log.Info("Command:{0}", log_buffer);
            }
        }
    }
}
