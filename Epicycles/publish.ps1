$secret = dotnet user-secrets list | ? { $_.StartsWith("NUGET_KEY") }
$key = $secret.Split(" ")[2]

$versionInfo = gc .\Epicycles.csproj | ? { $_.Contains("PackageVersion") }
$version = $versionInfo.Split("<")[1].Split(">")[1]

dotnet pack -c Release
dotnet nuget push bin/Release/*.nupkg --api-key $key