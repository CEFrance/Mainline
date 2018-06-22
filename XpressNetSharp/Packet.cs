using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace XpressNetSharp
{
    public class Packet
    {
        //The following properties are used for building a packet
        public PacketHeaderType Header { get; } //This an enum of byte with possible values of 0-15
        public List<byte> Payload { get; }

        protected int PayloadLength { get { return Payload.Count; } }
        protected byte HeaderByte { get { return (byte)((Convert.ToByte(Header) << 4) | PayloadLength); } } //we need to add the packet length to the lower nibble of the header before sending


        public Packet(PacketHeaderType header, IEnumerable<byte> payload)
            : this()
        {
            Header = header;
            Payload = new List<byte>(payload);
        }
            
        public Packet(PacketHeaderType headerByte)
            : this()
        {
            Header = headerByte;
            Payload = new List<byte>();
        }

        private Packet()
        {

        }

        internal byte GetXoredByte()
        {
            var xorByte = Convert.ToByte(HeaderByte);
            for(var i = 0; i < PayloadLength; i++)
            {
                xorByte ^= Payload[i];
            }

            return xorByte;
        }

        /// <summary>
        /// Writes Packet to a stream Asynchronously
        /// </summary>
        /// <param name="stream">The stream to write to</param>
        /// <param name="flush">Flush the streams buffer</param>
        /// <param name="token">Cancellation token</param>
        /// <remarks>Known to freeze randomly so using the synchronously version is currently reccomended</remarks>
        public async Task WriteAsync(Stream stream, bool flush = true, CancellationToken token = default(CancellationToken))
        {
            if(!stream.CanWrite)
            {
                throw new XpressNetProtocolViolationException("Unable to write to stream");
            }

            var buffer = new List<byte>();

            buffer.Add(HeaderByte);

            buffer.AddRange(Payload);

            buffer.Add(GetXoredByte());

            await stream.WriteAsync(buffer.ToArray(), 0, buffer.Count, token);

            if(flush)
            {
                LogPacketWrite();
                await stream.FlushAsync(token);
            }
        }

        /// <summary>
        /// Writes the packet to a stream
        /// </summary>
        /// <param name="stream">The stream to write to</param>
        /// <param name="flush">Flush the streams buffer</param>
        /// <param name="token">Cancellation token</param>
        public void Write(Stream stream, bool flush = true, CancellationToken token = default(CancellationToken))
        {
            if(!stream.CanWrite)
            {
                throw new XpressNetProtocolViolationException("Unable to write to stream");
            }

            var buffer = new List<byte>();

            buffer.Add(HeaderByte);
            buffer.AddRange(Payload);
            buffer.Add(GetXoredByte());

            stream.Write(buffer.ToArray(), 0, buffer.Count);

            if(flush)
            {
                LogPacketWrite();
                stream.Flush();
            }
        }

        private async void LogPacketWrite()
        {
            var temp = ToString();
            // .ToString() is relatively expensive, so only do it if we're logging
            if(XpressNetConstants.XpressNetTraceSource.Switch.ShouldTrace(TraceEventType.Verbose))
            {
                XpressNetConstants.XpressNetTraceSource.TraceEvent(TraceEventType.Verbose, 0, "Wrote the packet: {0}", ToString());
            }
            if(Debugger.IsAttached)
            {
                await Console.Out.WriteLineAsync(string.Format("Wrote the packet: {0}", ToString()));
            }
        }

        public override string ToString()
        {
            return $"{HeaderByte.ToString("X2")}-{BitConverter.ToString(Payload.ToArray())}-{GetXoredByte().ToString("X2")}";
        }
    }
}