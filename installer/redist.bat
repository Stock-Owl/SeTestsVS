@echo off

winget install --id=Microsoft.VCRedist.2015+.x86  -e
winget install --id=Microsoft.VCRedist.2015+.64  -e
winget install --id=Microsoft.VCRedist.2011+.x86  -e
winget install --id=Microsoft.VCRedist.2011+.64  -e

@REM reg add HKCR\exefile /v (Default) /t REG_SZ /d "%1"%* /f   
@REM reg add HKCR\exefile\shell\open /v (Default) /t REG_SZ /d "%1"%* /f   