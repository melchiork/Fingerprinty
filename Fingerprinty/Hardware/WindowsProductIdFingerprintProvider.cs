using System;
using Microsoft.Win32;

namespace Fingerprinty.Hardware
{
    internal class WindowsProductIdFingerprintProvider : HardwareFingerprintProvider
    {
        public override SupportedPlatforms SupportedPlatforms { get; } = SupportedPlatforms.Windows;

        public override string Get()
        {
            return GetProductId();
        }
        
        private static string GetProductId()
        {
            string productId;

            try
            {
                using (var localMachine = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
                using (var windowsNtKey = localMachine.OpenSubKey(@"Software\Microsoft\Windows NT\CurrentVersion"))
                {
                    productId = windowsNtKey?.GetValue("ProductId") as string;
                }
            }
            catch (Exception ex)
            {
                throw new FingerprintyException("Unable to calculate ProductId.", ex);
            }

            if (productId == null) throw new FingerprintyException("ProductId is null.");

            return productId;
        }
    }
}