Set-Location ./ZP.CSharp.Enigma.Docs
If (Test-Path ./docs)
{
    If (Test-Path ./old-docs)
    {
    Remove-Item ./old-docs -Recurse
    }
    Rename-Item ./docs ./old-docs
}
Set-Location ..