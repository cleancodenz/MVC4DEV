netsh http show urlacl>> "%TEMP%\StartupLog.txt" 2>&1

netsh http delete urlacl url=http://+:81/ReverseString >> "%TEMP%\StartupLog.txt" 2>&1

netsh http add urlacl url=http://+:81/ReverseString user=everyone listen=yes delegate=yes  >> "%TEMP%\StartupLog.txt" 2>&1

