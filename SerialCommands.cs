using System;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Threading.Tasks;

namespace InFocusCtrl
{
    class InvalidCommandException : Exception { }

    public abstract class Projector
    {
        public enum Power { Off, On }
        public enum VideoSources { VGA1, VGA2, HDMI, SVideo, Composite }

        SerialPort m_serialPort;
        protected Stream PortStream
        {
            get { return m_serialPort.BaseStream; }
        }

        protected abstract int BaudRate { get; }

        protected Projector()
        {
            // maybe we shouldn't hardcode?
            m_serialPort = new SerialPort("COM3", BaudRate, Parity.None, 8, StopBits.One);
            m_serialPort.Handshake = Handshake.None;
            m_serialPort.Open();
        }

        protected void SendString(string data)
        {
            m_serialPort.Write(data);
        }

        protected async Task<uint> IReadCommandResult()
        {
            // Example: sent "(LMP?)"
            StringBuilder cmdBuf = new StringBuilder();

            // Read in the result until we have everything
            byte[] buf = new byte[1024];
            while (true) {
                int count = await PortStream.ReadAsync(buf, 0, 1024);
                string retVal = ASCIIEncoding.ASCII.GetString(buf, 0, count);
                if (retVal.StartsWith("?"))
                    throw new InvalidCommandException();
                cmdBuf.Append(retVal);
                if (retVal.EndsWith(")"))
                    break;
            }

            // Sanity testing...
            // Example: rcv "(0-32766,42)"
            string result = cmdBuf.ToString();
            if (!(result.StartsWith("(") && result.EndsWith(")")))
                throw new InvalidCommandException();

            // Now, proc the result
            // Exmaple: rcv "0-32766,42"
            result = result.Substring(1, result.Length - 2);
            string[] values = result.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            // values[0] = "0-32766", values[1] = 42
            // But sometimes the projector only returns the value...
            if (values.Length > 1)
                return Convert.ToUInt32(values[1]);
            else
                return Convert.ToUInt32(values[0]);
        }

        public abstract void SetPowerState(Power state);
        public abstract void SetVideoSource(VideoSources source);
    }

    public class InFocusIN146 : Projector
    {
        protected override int BaudRate { get => 115200; }

        #region Read Commands

        public async Task<uint> QueryLampLife()
        {
            SendString("(LMP?)");
            return await IReadCommandResult();
        }
        #endregion

        #region Write Commands
        public override void SetPowerState(Power state)
        {
            SendString(String.Format("(PWR{0})", (int)state));
        }

        public override void SetVideoSource(VideoSources source)
        {
            SendString(String.Format("(SRC{0})", (int)source));
        }
        #endregion
    }
}
