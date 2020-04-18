# DotNetUnixGPSConverter
A C# Unix/GPS time converter with minimal .NET dependencies

HOW TO USE
----------
* Build project to produce UnixGPSConverter.dll
* Include reference: using UnixGPSConverter;
* Use one of the two available functions in the library

// Convert GPS time to Unix time

double convertedTime = UGPSC.UnixToGPS(originalUnixTime);

// Convert Unix time to GPS time

double convertedTime = UGPSC.GPSToUnix(originalGPSTime);
