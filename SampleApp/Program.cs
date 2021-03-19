using System;
using System.Collections.Generic;
using System.Text;

namespace SampleApp
{
	class Program
	{
		static void Main(string[] args)
		{
			int TBORG_ADDRESS = 0x15;

			Console.WriteLine("Hello World!");
			using (var bus = RPi.I2C.Net.I2CBus.Open("/dev/i2c-1"))
			{
				//Console.WriteLine("In using clause with type: " + bus.GetType());
				//Console.WriteLine("Other info:");


				//try
				//{
				//	bus.WriteByte(TBORG_ADDRESS, 0x99);
				//}
				//catch (Exception ex)
    //            {
				//	Console.WriteLine("Failed to do 'WriteByte'... Moving on.");
				//	Console.WriteLine("-------------- Message --------------------");
				//	Console.WriteLine(ex.Message);
				//	if (ex.InnerException != null)
    //                {
				//		Console.WriteLine("INNER EXCEPTION: " + ex.InnerException.Message);
    //                }
    //            }

				//try
				//{
				//	bus.WriteCommand(TBORG_ADDRESS, 0x99, 0x00);
				//}
				//catch (Exception ex)
    //            {
				//	Console.WriteLine("Failed to do 'WriteCommand'...  Moving on.");
				//	Console.WriteLine("-------------- Message --------------------");
				//	Console.WriteLine(ex.Message);
				//	if (ex.InnerException != null)
				//	{
				//		Console.WriteLine("INNER EXCEPTION: " + ex.InnerException.Message);
				//	}
				//}

    //            try
    //            {
				//	bus.WriteBytes(TBORG_ADDRESS, new byte[] { 0x03, 0x00, 0x00 });
				//	bus.WriteBytes(TBORG_ADDRESS, new byte[] { 0x01, 0x00, 0x00 });
				//}
				//catch (Exception ex)
    //            {
				//	Console.WriteLine("Failed to do 'WriteBytes'...  Moving on.");
				//	Console.WriteLine("-------------- Message --------------------");
				//	Console.WriteLine(ex.Message);
				//	if (ex.InnerException != null)
				//	{
				//		Console.WriteLine("INNER EXCEPTION: " + ex.InnerException.Message);
				//	}
				//}

    //            try
    //            {
				//	bus.WriteBytes(TBORG_ADDRESS, new byte[] { 0x99 });
				//}
				//catch (Exception ex)
    //            {
				//	Console.WriteLine("I'm reporting that I failed to write the 0x99, but did I?");
    //            }

				//byte[] response = bus.ReadBytes(TBORG_ADDRESS, 6);
				//for (int i = 0; i < response.Length; i++)
				//{
				//	Console.WriteLine("Byte: " + response[i].ToString("X2"));
				//}

				//byte[] resp2 = bus.ReadBytes(TBORG_ADDRESS, 6);
				//for (int i = 0; i < resp2.Length; i++)
				//{
				//	Console.WriteLine("Byte: " + resp2[i].ToString("X2"));
				//}

				//Console.WriteLine("Let's try stopping motors...");
				//try
				//{
				//	bus.WriteByte(TBORG_ADDRESS, 14);
				//}
				//catch (Exception ex)
    //            {
				//	Console.WriteLine("Well, of course I failed to write the ALL_STOP command...");
    //            }

				//Console.WriteLine("Let's try running some motors...");
    //            try
    //            {
				//	bus.WriteBytes(TBORG_ADDRESS, new byte[] { 8, 128 });
    //            }
				//catch (Exception ex)
    //            {
				//	Console.WriteLine("Am I lying to you?");
    //            }

				//Console.WriteLine("Sleeping.....");
				//System.Threading.Thread.Sleep(1000);

				//Console.WriteLine("Running another ALL_STOP");
    //            try
    //            {
				//	bus.WriteByte(TBORG_ADDRESS, 14);
				//}
				//catch (Exception ex)
    //            {
				//	Console.WriteLine("This is getting boring.");
    //            }

				Wheels_class x = new Wheels_class();
				x.TestAllCommands(bus);

				ThunderBorg myBorg = new ThunderBorg();
				Logger_class myLog = new Logger_class();
				int port = myBorg.ScanForThunderBorg(1, myLog);

				





			}
		}
	}
}
