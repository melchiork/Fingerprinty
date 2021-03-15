using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fingerprinty.Sources
{
    /// <summary>
    /// TODO Docs
    /// </summary>
    public class MachineNameFingerprintSource : FingerprintSource
    {
        /// <summary>
        /// TODO Docs
        /// </summary>
        /// <returns></returns>
        public override string Get()
        {
            var machineName = Environment.MachineName;

            return machineName;
        }
    }
}
