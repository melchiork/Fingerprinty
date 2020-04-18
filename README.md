# Fingerprinty
Fingerprinty is a library providing its users with various kinds of machine fingerprints. The library is .NET Standard and works with Windows and Linux albeit to a different extent.

## Supported Fingerprint Providers
|Fingerprint Provider|Description|Supported Platforms|
|---|---|---|
|AllMacAddressesFingerprintProvider|Provides fingerprint based on all MAC addresses of all network cards on the machine.|Windows and Linux|
|MachineNameFingerprintProvider|Provides fingerprint based on the machine name. |Windows and Linux|
|DriveFingerprintProvider|Provides fingerprint based on serial number of disk on which C drive is located.|Windows|
|AllDrivesFingerprintProvider|Provides fingerprint based on serial numbers of all installed hard drives.|Windows|
|WindowsProductIdFingerprintProvider|Provides fingerprint based on Windows ProductId.| Windows|

## Fingerprint Format
The default fingerprint format is matching `[a-f0-9]{4}-[a-f0-9]{4}-[a-f0-9]{4}-[a-f0-9]{4}` regex. For example `a035-1234-acda-09df`. 
This format can be overriden by providing custom implementations of `FingerprintFactory` and `Fingerprint` classes.

## DI Support
Fingerprinty is DI container agnostic. You can register the `FingerprintProviderFactory` as singleton (the class is stateless) or use `FingerprintProviderFactory.Default` property to access a static instance.
Each `FingerprintProvider` has a public constructor and they can be registered separately in the containter of your choice.

# Examples
## Get Fingerprint of Current Machine
```csharp
var provider = FingerprintProviderFactory.Default.CreateMachineNameProvider();
var fingerprint = provider.Get();
var fingerprintText = fingerprint.ToString(); //e.g. adc2-2387-d2a0-022c
```

## Check Supported Platforms
```csharp
var provider = FingerprintProviderFactory.Default.CreateAllMacAddressesProvider();
var supportedPlatforms = provider.SupportedPlatforms; //SupportedPlatforms.Linux | SupportedPlatforms.Windows
```

# Build Status
![CI](https://github.com/melchiork/Fingerprinty/workflows/CI/badge.svg)
![Create NuGet package](https://github.com/melchiork/Fingerprinty/workflows/Create%20NuGet%20package/badge.svg)
