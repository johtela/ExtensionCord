$nugetdir = "..\..\NuGet"
$project = "ExtensionCord"
$version = "1.0.0"
$projectdir = "$nugetdir\$project"

function BuildPackage ()
{
	& $nugetdir\nuget.exe pack $project.csproj
}

function ReleaseLocal ()
{
	BuildPackage 
	if (Test-Path $projectdir)
	{
		Remove-Item $projectdir -Recurse
	}
	& $nugetdir\nuget.exe add "$project.$version.nupkg" -source $nuget
}

ReleaseLocal