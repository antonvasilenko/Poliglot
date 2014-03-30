@echo off
SETLOCAL ENABLEDELAYEDEXPANSION

:: set the working dir (default to current dir)
set wdir=%cd%
if not (%1)==() set wdir=%1

:: set the file extension (default to cs)
set extension=cs
if not (%2)==() set extension=%2

set platform=droid
if not (%3) ==() set platform=%3

echo =======================================================
echo executing transform for platform %platform% from %wdir%
echo =======================================================
:: create a list of all the T4 templates in the working dir
rem dir %wdir%\*.tt /b /s > t4list.txt
:: instead get predefined list of files to transform


set t4list=t4list_%platform%.txt
echo opening %t4list% ...
if exist %t4list% (
    echo the following T4 templates will be transformed:
    type %t4list%
    echo.
) else (
    echo file %t4list% doesnt'exists. Please create one and fill it with paths to *.tt files to transform
    exit /B
)

:: transform all the templates
echo transforming ...
for /f %%d in (%t4list%) do (
set file_name=%%d
set file_name=!file_name:~0,-3!.%extension%
echo  \--^> !file_name!    
libs\tt\TextTransform.exe -out !file_name! %%d
)

echo transformation complete