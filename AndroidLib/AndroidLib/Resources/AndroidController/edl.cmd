@echo off

color C
title EDL MODE MI FLASH TOOL

echo.

"%~dp0fastboot_edl.exe" reboot-edl

echo.

echo Press any key to exit... 

pause>nul