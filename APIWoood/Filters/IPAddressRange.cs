using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Web;

namespace APIWoood.Filters
{
    public class IPAddressRange
    {
        readonly AddressFamily addressFamily;
        readonly byte[] lowerBytes;
        readonly byte[] upperBytes;

        public IPAddressRange(string lower, string upper)
        {
            // Assert that lower.AddressFamily == upper.AddressFamily

            IPAddress lowerInclusive = IPAddress.Parse(lower);
            IPAddress upperInclusive = IPAddress.Parse(upper);

            this.addressFamily = lowerInclusive.AddressFamily;
            this.lowerBytes = lowerInclusive.GetAddressBytes();
            this.upperBytes = upperInclusive.GetAddressBytes();
        }

        public bool IsInRange(string ip)
        {
            IPAddress address = IPAddress.Parse(ip);
            if (address.AddressFamily != addressFamily)
            {
                return false;
            }

            byte[] addressBytes = address.GetAddressBytes();

            bool lowerBoundary = true, upperBoundary = true;

            for (int i = 0; i < this.lowerBytes.Length &&
                (lowerBoundary || upperBoundary); i++)
            {
                if ((lowerBoundary && addressBytes[i] < lowerBytes[i]) ||
                    (upperBoundary && addressBytes[i] > upperBytes[i]))
                {
                    return false;
                }

                lowerBoundary &= (addressBytes[i] == lowerBytes[i]);
                upperBoundary &= (addressBytes[i] == upperBytes[i]);
            }

            return true;
        }
    }
}