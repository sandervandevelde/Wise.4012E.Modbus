using NModbus;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wise.E4012.Modbus;
using Wise.E4012.Modbus.DemoApp.Properties;

namespace Wise.E4012.Modbus.DemoApp
{
    /// <summary>
    /// Example program for Wise.4012E.Modbus library
    /// Copyright 2017 Sander van de Velde (@svelde)
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Simple Modbus TCP master read inputs example.
        /// </summary>
        private static void Main(string[] args)
        {
            var ipAddress = Settings.Default.IpAddress;

            using (var modbusProvider = new ModbusProvider(ipAddress))
            {
                bool switched = false;

                while (true)
                {
                    Thread.Sleep(125);
                    switched = !switched;

                    try
                    {
                        modbusProvider.RelayOne = switched;
                        modbusProvider.RelayTwo = switched;

                        modbusProvider.ReadSensors();

                        Console.WriteLine($"{(modbusProvider.KnobOne + "    ").Substring(0, 4)} | {(modbusProvider.KnobTwo + "    ").Substring(0, 4)} | {(modbusProvider.KnobAvg + "    ").Substring(0, 4)} | {(modbusProvider.SwitchOne + "    ").Substring(0, 5)} | {(modbusProvider.SwitchTwo + "    ").Substring(0, 5)}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Exception {ex.Message}");
                    }
                }
            }
        }
    }
}