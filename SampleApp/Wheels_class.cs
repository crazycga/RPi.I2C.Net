using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp
{
    public class Wheels_class
    {
        private int _TBORG_ADDRESS = 0x15;

        public void TestAllCommands(RPi.I2C.Net.I2CBus incomingBus)
        {
            Console.WriteLine("****************************************");
            Console.WriteLine("* Performing all commands test         *");
            Console.WriteLine("****************************************");
            Console.WriteLine();

            Console.WriteLine("Testing COMMAND_ALL_OFF");
            incomingBus.WriteByte(_TBORG_ADDRESS, 0x14);
            Console.WriteLine("Reading response: " + ParseBytes(incomingBus.ReadBytes(_TBORG_ADDRESS, 6)));
            Console.WriteLine();

            Console.WriteLine("Testing COMMAND_SET_A_FWD");
            incomingBus.WriteBytes(_TBORG_ADDRESS, new byte[] { 0x08, 0x80 });
            Console.WriteLine("Response: " + ParseBytes(incomingBus.ReadBytes(_TBORG_ADDRESS, 6)));
            Console.WriteLine();

            System.Threading.Thread.Sleep(2000);
            
            Console.WriteLine("Testing COMMAND_ALL_OFF");
            incomingBus.WriteByte(_TBORG_ADDRESS, 0x0E);
            Console.WriteLine("Reading response: " + ParseBytes(incomingBus.ReadBytes(_TBORG_ADDRESS, 6)));
            Console.WriteLine();

            System.Threading.Thread.Sleep(2000);

            Console.WriteLine("Testing COMMAND_SET_B_REV");
            incomingBus.WriteBytes(_TBORG_ADDRESS, new byte[] { 12, 0x80 });
            Console.WriteLine("Response: " + ParseBytes(incomingBus.ReadBytes(_TBORG_ADDRESS, 6)));
            Console.WriteLine();

            System.Threading.Thread.Sleep(2000);

            Console.WriteLine("Testing COMMAND_SET_LED1");
            incomingBus.WriteBytes(_TBORG_ADDRESS, new byte[] { 0x01, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF });
            Console.WriteLine("Response: " + ParseBytes(incomingBus.ReadBytes(_TBORG_ADDRESS, 6)));
            Console.WriteLine();

            Console.WriteLine("Testing COMMAND_GET_LED1");
            incomingBus.WriteByte(_TBORG_ADDRESS, 0x02);
            Console.WriteLine("Reading response: " + ParseBytes(incomingBus.ReadBytes(_TBORG_ADDRESS, 6)));
            Console.WriteLine();

            Console.WriteLine("Testing COMMAND_SET_LED2");
            incomingBus.WriteBytes(_TBORG_ADDRESS, new byte[] { 0x03, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF });
            Console.WriteLine("Response: " + ParseBytes(incomingBus.ReadBytes(_TBORG_ADDRESS, 6)));
            Console.WriteLine();

            Console.WriteLine("Testing COMMAND_GET_LED2");
            incomingBus.WriteByte(_TBORG_ADDRESS, 0x04);
            Console.WriteLine("Reading response: " + ParseBytes(incomingBus.ReadBytes(_TBORG_ADDRESS, 6)));
            Console.WriteLine();

            Console.WriteLine("Testing COMMAND_SET_LEDS");
            incomingBus.WriteBytes(_TBORG_ADDRESS, new byte[] { 0x05, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF });
            Console.WriteLine("Response: " + ParseBytes(incomingBus.ReadBytes(_TBORG_ADDRESS, 6)));
            Console.WriteLine();

            Console.WriteLine("Testing COMMAND_SET_A_FWD");
            incomingBus.WriteBytes(_TBORG_ADDRESS, new byte[] { 0x08, 0x80 });
            Console.WriteLine("Response: " + ParseBytes(incomingBus.ReadBytes(_TBORG_ADDRESS, 6)));
            Console.WriteLine();

            Console.WriteLine("Testing COMMAND_SET_B_REV");
            incomingBus.WriteBytes(_TBORG_ADDRESS, new byte[] { 0x0C, 0x80 });
            Console.WriteLine("Response: " + ParseBytes(incomingBus.ReadBytes(_TBORG_ADDRESS, 6)));
            Console.WriteLine();

            Console.WriteLine("Testing COMMAND_GET_DRIVE_A_FAULT");
            incomingBus.WriteByte(_TBORG_ADDRESS, 0x0E);
            Console.WriteLine("Reading response: " + ParseBytes(incomingBus.ReadBytes(_TBORG_ADDRESS, 6)));
            Console.WriteLine();

            Console.WriteLine("Testing COMMAND_GET_DRIVE_B_FAULT");
            incomingBus.WriteByte(_TBORG_ADDRESS, 0x0F);
            Console.WriteLine("Reading response: " + ParseBytes(incomingBus.ReadBytes(_TBORG_ADDRESS, 6)));
            Console.WriteLine();

            Console.WriteLine("Testing COMMAND_SET_FAILSAFE");
            incomingBus.WriteBytes(_TBORG_ADDRESS, new byte[] { 0x13, 0x01 });
            Console.WriteLine("Reading response: " + ParseBytes(incomingBus.ReadBytes(_TBORG_ADDRESS, 6)));
            Console.WriteLine();

            Console.WriteLine("Waiting for a few seconds...");
            System.Threading.Thread.Sleep(5000);

            Console.WriteLine("Testing COMMAND_SET_FAILSAFE");
            incomingBus.WriteBytes(_TBORG_ADDRESS, new byte[] { 0x13, 0x00 });
            Console.WriteLine("Reading response: " + ParseBytes(incomingBus.ReadBytes(_TBORG_ADDRESS, 6)));
            Console.WriteLine();




            Console.WriteLine("Testing COMMAND_GET_BATT_VOLT");
            incomingBus.WriteByte(_TBORG_ADDRESS, 21);
            Console.WriteLine("Response: " + ParseBytes(incomingBus.ReadBytes(_TBORG_ADDRESS, 6)));

            Console.WriteLine("Testing COMMAND_ALL_OFF");
            incomingBus.WriteByte(_TBORG_ADDRESS, 0x14);
            Console.WriteLine("Reading response: " + ParseBytes(incomingBus.ReadBytes(_TBORG_ADDRESS, 6)));
            Console.WriteLine();


        }

        private void ShowBytes(byte[] incoming)
        {
            if ((incoming == null) || (incoming.Length == 0))
            {
                Console.WriteLine("No bytes found");
            }
            else
            {
                for (int i = 0; i < incoming.Length; i++) 
                {
                    Console.Write(incoming[i].ToString("X2") + " ");
                }
                Console.WriteLine();
            }
        }

        private string ParseBytes(byte[] incoming)
        {
            string tempReturn = string.Empty;

            if ((incoming == null) || (incoming.Length == 0))
            {
                tempReturn = "No bytes returned.";
            }
            else
            {
                for (int i = 0; i < incoming.Length; i++)
                {
                    tempReturn += incoming[i].ToString("X2") + " ";
                }
            }

            return tempReturn;
        }

    }
}
