using System.Text;
using System.Diagnostics;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace DebuggerPlus.Command
{
    public static class BuiltinCommands
    {

        [RegisterCommand(Help = "Display help information about a command", MaxArgCount = 1)]
        static void CommandHelp(CommandArg[] args) {
            if (args.Length == 0) {
                foreach (var command in Command.Shell.Commands) {
                    Log.Info("{0}: {1}", command.Key.PadRight(16), command.Value.help);
                }
                return;
            }

            string command_name = args[0].String.ToUpper();

            if (!Command.Shell.Commands.ContainsKey(command_name)) {
                Command.Shell.IssueErrorMessage("Command {0} could not be found.", command_name);
                return;
            }

            var info = Command.Shell.Commands[command_name];

            if (info.help == null) {
                Log.Info("{0} does not provide any help documentation.", command_name);
            } else if (info.hint == null) {
                Log.Info(info.help);
            } else {
                Log.Info("{0}\nUsage: {1}", info.help, info.hint);
            }
        }

        [RegisterCommand(Help = "Time the execution of a command", MinArgCount = 1)]
        static void CommandTime(CommandArg[] args) {
            var sw = new Stopwatch();
            sw.Start();

            Command.Shell.RunCommand(JoinArguments(args));

            sw.Stop();
            Log.Info("Time: {0}ms", (double)sw.ElapsedTicks / 10000);
        }

        [RegisterCommand(Help = "List all variables or set a variable value")]
        static void CommandSet(CommandArg[] args) {
            if (args.Length == 0) {
                foreach (var kv in Command.Shell.Variables) {
                    Log.Info("{0}: {1}", kv.Key.PadRight(16), kv.Value);
                }
                return;
            }

            string variable_name = args[0].String;

            if (variable_name[0] == '$') {
                Log.Warning("Warning: Variable name starts with '$', '${0}'.", variable_name);
            }

            Command.Shell.SetVariable(variable_name, JoinArguments(args, 1));
        }

        [RegisterCommand(Help = "No operation")]
        static void CommandNoop(CommandArg[] args) { }

        [RegisterCommand(Help = "Quit running application", MaxArgCount = 0)]
        static void CommandQuit(CommandArg[] args) {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
        }

        static string JoinArguments(CommandArg[] args, int start = 0) {
            var sb = new StringBuilder();
            int arg_length = args.Length;

            for (int i = start; i < arg_length; i++) {
                sb.Append(args[i].String);

                if (i < arg_length - 1) {
                    sb.Append(" ");
                }
            }

            return sb.ToString();
        }
    }
}
