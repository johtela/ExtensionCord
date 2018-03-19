$csweavedir = "$env:LOCALAPPDATA\csweave"

function GenerateDocs ()
{
	& {
		$ErrorActionPreference = "SilentlyContinue"
		& $csweavedir\csweave.exe src\*.cs *.md -s ExtensionCord.sln -o docs -f html -t -v -u
	}
}

GenerateDocs