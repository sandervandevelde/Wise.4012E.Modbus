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

namespace Wise.E4012.Modbus.DemoApp
{
    internal class Program
    {
        /// <summary>
        /// Simple Modbus TCP master read inputs example.
        /// </summary>
        private static void Main(string[] args)
        {
            using (var modbusProvider = new ModbusProvider("192.168.1.142"))
            {
                bool switched = false;

                while (true)
                {
                    Thread.Sleep(125);
                    switched = !switched;

                    modbusProvider.RelayOne = switched;
                    modbusProvider.RelayTwo = switched;

                    modbusProvider.ReadSensors();

                    Console.WriteLine($"{(modbusProvider.KnobOne + "    ").Substring(0, 4)} | {(modbusProvider.KnobTwo + "    ").Substring(0, 4)} | {(modbusProvider.KnobAvg + "    ").Substring(0, 4)} | {(modbusProvider.SwitchOne + "    ").Substring(0, 5)} | {(modbusProvider.SwitchTwo + "    ").Substring(0, 5)}");
                }
            }
        }
    }
}