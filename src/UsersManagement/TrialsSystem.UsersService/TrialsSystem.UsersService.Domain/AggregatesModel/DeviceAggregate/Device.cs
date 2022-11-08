using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrialsSystem.UsersService.Domain.AggregatesModel.DeviceAggregate
{
    internal class Device
    {
        public string Id { get; set; }
        public string SerialNumber { get; set; }
        public string Model { get; set; }
        public DeviceType Type { get; set; }
        public string FirmwareVersion { get; set; }
    }
}
