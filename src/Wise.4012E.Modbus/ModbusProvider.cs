using NModbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Wise.E4012.Modbus
{
    public class ModbusProvider : IDisposable
    {
        private TcpClient _client = null;

        private IModbusMaster _master = null;

        public ushort KnobOne { get; private set; }
        public ushort KnopTwo { get; private set; }
        public bool SwitchOne { get; private set; }
        public bool SwitchTwo { get; private set; }

        public bool RelayOne
        {
            set
            {
                _master.WriteSingleCoil(0, 16, value); // 17 linker relay
            }
        }

        public bool RelayTwo
        {
            set
            {
                _master.WriteSingleCoil(0, 17, value);  // 18 rechter relay
            }
        }

        public ModbusProvider(string ipAddress)
        {
            _client = new TcpClient(ipAddress, 502);

            var factory = new ModbusFactory();

            _master = factory.CreateMaster(_client);
        }

        public void ReadSensors()
        {
            // Knobs

            var readHoldingRegisters = _master.ReadHoldingRegisters(0, 0, 2);

            KnobOne = readHoldingRegisters[0];

            KnopTwo = readHoldingRegisters[1];

            // Switches

            ushort startAddress = 0;
            ushort numInputs = 2;

            var switches = _master.ReadInputs(0, startAddress, numInputs);

            SwitchOne = switches[0];
            SwitchTwo = switches[1];
        }

        #region IDisposable Support

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _master.Dispose();
                    _master = null;

                    _client.Dispose();
                    _client = null;
                }

                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
        }

        #endregion IDisposable Support
    }
}