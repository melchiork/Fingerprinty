﻿using System;
using Microsoft.Win32;

namespace Fingerprinty
{
    public class WindowsProductIdFingerprintProvider : FingerprintProvider
    {
        public override SupportedPlatforms SupportedPlatforms { get; } = SupportedPlatforms.Windows;

        public WindowsProductIdFingerprintProvider(FingerprintFactory fingerprintFactory) : base(fingerprintFactory)
        {
        }

        public override Fingerprint Get()
        {
            var productId = GetProductId();

            return FingerprintFactory.Create(productId);
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
                throw new InvalidOperationException("Unable to calculate ProductId.", ex);
            }

            if (productId == null) throw new InvalidOperationException("ProductId is null.");

            return productId;
        }
    }
}