$secret = dotnet user-secrets list | ? { $_.StartsWith("NUGET_KEY") }
$key = $secret.Split(" ")[2]

$versionInfo = gc .\Betelgeuse.csproj | ? { $_.Contains("PackageVersion") }
$version = $versionInfo.Split("<")[1].Split(">")[1]

$packageName = "bin/Release/Betelgeuse." + $version.ToString() + ".nupkg"

dotnet pack -c Release
dotnet nuget push $packageName --api-key $key --source https://api.nuget.org/v3/index.json