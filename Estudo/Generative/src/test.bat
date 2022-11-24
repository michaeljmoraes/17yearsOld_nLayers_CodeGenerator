@echo off
rem test.bat

setlocal
set typeLibName=c:\winnt\system32\mshtml.tlb
set ifaceName=HTMLWindowEvents
set className=CMyEventSink
set textbox=textbox.exe

echo.
echo testing handlers.js...
cscript //nologo handlers.js %typeLibName% %ifaceName% %className%

echo.
echo testing hi.js...
%textbox% hi.js

echo.
echo testing hi.asp...
%textbox% hi.asp

echo.
echo testing handlers.asp...
%textbox% handlers.asp typeLibName=%typeLibName% ifaceName=%ifaceName% className=%className%

echo.
echo testing handlers.h.xc...
%textbox% handlers.h.xc typeLibName=%typeLibName% ifaceName=%ifaceName% className=%className%

endlocal
