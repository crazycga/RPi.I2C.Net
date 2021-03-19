using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp
{
    public class ThunderBorg
    {
        public static readonly ushort I2C_SLAVE                 = 0x0703;
        public static readonly byte PWN_MAX                     = 0xFF;
        public static readonly byte I2C_MAX_LEN                 = 0x06;

        public static readonly decimal VOLTAGE_PIN_MAX          = 36.3M;
        public static readonly decimal VOLTAGE_PIN_CORRECTION   = 0.0M;
        public static readonly decimal BATTERY_MIN_DEFAULT      = 7.0M;
        public static readonly decimal BATTERY_MAX_DEFAULT      = 35.0M;

        public static readonly byte I2C_ID_THUNDERBORG          = 0x15;

        public static readonly byte COMMAND_SET_LED1            = 0x01;
        public static readonly byte COMMAND_GET_LED1            = 0x02;
        public static readonly byte COMMAND_SET_LED2            = 0x03;
        public static readonly byte COMMAND_GET_LED2            = 0x04;
        public static readonly byte COMMAND_SET_LEDS            = 0x05;
        public static readonly byte COMMAND_SET_LED_BATT_MON    = 0x06;
        public static readonly byte COMMAND_GET_LED_BATT_MON    = 0x07;
        public static readonly byte COMMAND_SET_A_FWD           = 0x08;
        public static readonly byte COMMAND_SET_A_REV           = 0x09;
        public static readonly byte COMMAND_GET_A               = 0x0A;
        public static readonly byte COMMAND_SET_B_FWD           = 0x0B;
        public static readonly byte COMMAND_SET_B_REV           = 0x0C;
        public static readonly byte COMMAND_GET_B               = 0x0D;
        public static readonly byte COMMAND_ALL_OFF             = 0x0E;
        public static readonly byte COMMAND_GET_DRIVE_A_FAULT   = 0x0F;
        public static readonly byte COMMAND_GET_DRIVE_B_FAULT   = 0x10;
        public static readonly byte COMMAND_SET_ALL_FWD         = 0x11;
        public static readonly byte COMMAND_SET_ALL_REV         = 0x12;
        public static readonly byte COMMAND_SET_FAILSAFE        = 0x13;
        public static readonly byte COMMAND_GET_FAILSAFE        = 0x14;
        public static readonly byte COMMAND_GET_BATT_VOLT       = 0x15;
        public static readonly byte COMMAND_SET_BATT_LIMITS     = 0x16;
        public static readonly byte COMMAND_GET_BATT_LIMITS     = 0x17;
        public static readonly byte COMMAND_WRITE_EXTERNAL_LED  = 0x18;
        public static readonly byte COMMAND_GET_ID              = 0x99;
        public static readonly byte COMMAND_SET_I2C_ADD         = 0xAA;

        public static readonly byte COMMAND_VALUE_FWD           = 0x01;
        public static readonly byte COMMAND_VALUE_REV           = 0x02;

        public static readonly byte COMMAND_VALUE_ON            = 0x01;
        public static readonly byte COMMAND_VALUE_OFF           = 0x00;

        public static readonly ushort COMMAND_ANALOG_MAX        = 0x3FF;

        public int ScanForThunderBorg(int busNumber = 1, Logger_class log = null)
        {
            int tempReturn = -1;

            if (log != null)
            {
                log.WriteLog("Starting scan for ThunderBorg board...");
            }

            using (var bus = RPi.I2C.Net.I2CBus.Open("/dev/i2c-" + busNumber.ToString()))
            {
                for (byte port = 0x03; port < 0x78; port++)
                {
                    try
                    {
                        bus.WriteByte(port, COMMAND_GET_ID);
                        byte[] response = bus.ReadBytes(port, I2C_MAX_LEN);
                        if (response[0] == 0x99)
                        {
                            if (response[1] == I2C_ID_THUNDERBORG)
                            {
                                tempReturn = port;
                                if (log != null)
                                {
                                    log.WriteLog("FOUND ThunderBorg board on port: " + port.ToString("X2"));
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // do nothing
                    }
                }
            }

            if (log!=null)
            {
                log.WriteLog("Finished port scan...");
            }

            return tempReturn;
        }
    }
}
