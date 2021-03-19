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
			//using (var bus = RPi.I2C.Net.I2CBus.Open("/dev/i2c-1"))
			//{
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

			//Wheels_class x = new Wheels_class();
			//x.TestAllCommands(bus);


			//}

			Logger_class myLog = new Logger_class();
			ThunderBorg myBorg = new ThunderBorg(myLog);

			TestBorg(myBorg, myLog);


		}

		private static void TestBorg(ThunderBorg myBorg, Logger_class log)
        {
			myBorg.SetMotorA(128, log);
			System.Threading.Thread.Sleep(1000);
			int getx = myBorg.GetMotorA(log);
			log.WriteLog("Reporting speed A: " + getx.ToString());
			myBorg.GetDriveFaultA(log);

			myBorg.AllStop(log);

			myBorg.SetMotorB(128, log);
			System.Threading.Thread.Sleep(1000);
			int gety = myBorg.GetMotorB(log);
			log.WriteLog("Reporting speed B: " + gety.ToString());
			myBorg.GetDriveFaultB(log);

			myBorg.AllStop(log);

			myBorg.SetMotorA(-128, log);
			System.Threading.Thread.Sleep(1000);
			getx = myBorg.GetMotorA(log);
			log.WriteLog("Reporting speed A: " + getx.ToString());
			myBorg.GetDriveFaultA(log);

			myBorg.AllStop(log);

			myBorg.SetMotorB(-128, log);
			System.Threading.Thread.Sleep(1000);
			gety = myBorg.GetMotorB(log);
			log.WriteLog("Reporting speed B: " + gety.ToString());
			myBorg.GetDriveFaultB(log);

			myBorg.AllStop(log);

			myBorg.SetAllMotors(128, log);
			System.Threading.Thread.Sleep(1000);
			myBorg.AllStop();

			myBorg.SetAllMotors(-128, log);
			System.Threading.Thread.Sleep(1000);
			myBorg.AllStop();

			myBorg.GetFailsafe(log);
			myBorg.SetFailsafe(true, log);
			myBorg.SetFailsafe(true, log);
			myBorg.SetFailsafe(false, log);
			myBorg.SetFailsafe(false, log);

			myBorg.GetLED1(log);
			myBorg.GetLED2(log);

			myBorg.GetLEDBatteryMonitor(log);
			myBorg.SetLEDBatteryMonitor(false, log);
			myBorg.GetLEDBatteryMonitor(log);
			myBorg.SetLED1(255, 255, 255, log);
			System.Threading.Thread.Sleep(1000);

			myBorg.SetLED1(0, 0, 0, log);

			//for (int i = 0; i < 255; i = i + 10)
			//         {
			//	for (int j = 0; j < 255; j = j + 10)
			//             {
			//		for (int k = 0; k < 255; k = k + 10)
			//                 {
			//			myBorg.SetLEDs(Convert.ToByte(i), Convert.ToByte(j), Convert.ToByte(k), log);
			//                 }
			//             }
			//         }

			log.WriteLog("Battery voltage: " + myBorg.GetBatteryVoltage(log).ToString());

			myBorg.SetLEDBatteryMonitor(true, log);
			log.WriteLog("Board ID: 0x" + myBorg.GetBoardID(log).ToString("X2"));
			myBorg.GetBatteryMonitoringLimits(log);

			myBorg.SetBatteryMonitoringLimits(7.0M, 35.0M, log);

		}
	}
}
