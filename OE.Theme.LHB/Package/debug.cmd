XCOPY "..\Client\bin\Debug\net8.0\OE.Theme.LHB.Client.Oqtane.dll" "..\..\oqtane.framework\Oqtane.Server\bin\Debug\net8.0\" /Y
XCOPY "..\Client\bin\Debug\net8.0\OE.Theme.LHB.Client.Oqtane.pdb" "..\..\oqtane.framework\Oqtane.Server\bin\Debug\net8.0\" /Y
XCOPY "..\Client\Libs\*" "..\..\oqtane.framework\Oqtane.Server\bin\Debug\net8.0\" /Y

XCOPY "..\Client\wwwroot\*" "..\..\oqtane.framework\Oqtane.Server\wwwroot\" /Y /S /I
