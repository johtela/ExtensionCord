& {
    $ErrorActionPreference = "SilentlyContinue"
	..\LiterateProgramming\bin\Debug\csweave.exe src\*.cs *.md -s ExtensionCord.sln -o docs -f html -t -v
}