using System;
using Akka.Actor;

namespace WinTail
{
    /// <summary>
    /// Actor responsible for serializing message writes to the console.
    /// (write one message at a time, champ :)
    /// </summary>
    class ConsoleWriterActor : UntypedActor
    {
        //enum OddOrEvenEnum
        //{
        //    odd,
        //    even
        //}
        protected override void OnReceive(object message)
        {
           // var msg = message as string;
           if(message is Messages.StartProcessing)
            {
                PrintInstructions();
            }
            else if (message is Messages.InputError)
            {
                var msg = message as Messages.InputError;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(msg.Reason);
            }
            else if (message is Messages.InputSuccess)
            {
                var msg = message as Messages.InputSuccess;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(msg.Reason);
            }
            else
            {
                Console.WriteLine(message);
            }


            //// if message has even # characters, display in red; else, green
            //var OddOrEvenValue = msg.Length % 2 == 0 ? OddOrEvenEnum.even: OddOrEvenEnum.odd;
            //var color = OddOrEvenValue == OddOrEvenEnum.even ? ConsoleColor.Red : ConsoleColor.Green;
            //var alert = $"Your string {msg} had an {OddOrEvenValue} # of characters.\n";
            //Console.ForegroundColor = color;
            //Console.WriteLine(alert);
            Console.ResetColor();

        }

        private static void PrintInstructions()
        {
            Console.WriteLine("Write whatever you want into the console!");
            Console.Write("Some lines will appear as");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(" red ");
            Console.ResetColor();
            Console.Write(" and others will appear as");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" green! ");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Type 'exit' to quit this application at any time.\n");
        }
    }
}
