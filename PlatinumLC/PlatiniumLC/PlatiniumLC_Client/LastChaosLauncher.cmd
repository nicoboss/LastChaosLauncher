@ECHO OFF
REM ***************************************************************************
REM
REM Platinium Last Chaos Launcher from Nico Bosshard mit cwRsync_5.5.0_x86_Free
REM
REM ***************************************************************************

REM Set AppTitle
title PlatiniumLC Launcher - Synching please wait...

REM Make environment variable changes local to this batch file
SETLOCAL

REM Specify where to find rsync and related files
REM Default value is the directory of this batch file
SET CWRSYNCHOME=%~dp0

REM Create a home directory for .ssh 
REM IF NOT EXIST %CWRSYNCHOME%\home\%USERNAME%\.ssh MKDIR %CWRSYNCHOME%\home\%USERNAME%\.ssh

REM Make cwRsync home as a part of system PATH to find required DLLs
SET CWOLDPATH=%PATH%
SET PATH=%CWRSYNCHOME%\rsync;%PATH%

for %%f in ("%cd%") do SET DOWNLAODPATHWINDOWS=cygpath -u %%~sf
for /f "delims=" %%i in ('cygpath -u %DOWNLAODPATHWINDOWS%') do SET DOWNLAODPATH=%%i

REM Windows paths may contain a colon (:) as a part of drive designation and 
REM backslashes (example c:\, g:\). However, in rsync syntax, a colon in a 
REM path means searching for a remote host. Solution: use absolute path 'a la unix', 
REM replace backslashes (\) with slashes (/) and put -/cygdrive/- in front of the 
REM drive letter:

REM Stammverzeichniss da ich dies mit den rrsync restriction Einstllungen eingestellt habe. rsynch hat auch nur Zugriff auf dieses Verzeichniss. Ausserdem geht mit diesem RSA-key nur rsync.
chmod 700 /rsync/cwrsync
rsync -avz --copy-links -e "ssh -i /rsync/cwrsync -o UserKnownHostsFile=/rsync/known_hosts -o StrictHostKeyChecking=no" LastChaosSynch@46.234.39.153:/ %DOWNLAODPATH%
START /MIN ssh -f -L 4001:localhost:4001 -L 4101:localhost:4101 -L 5101:localhost:5101 -L 6101:localhost:6101 -L 2424:localhost:2424 -L 9110:localhost:9110 -L 52576:localhost:52576 -i /rsync/cwrsync -o UserKnownHostsFile=/rsync/known_hosts -o StrictHostKeyChecking=no LastChaosSynch@46.234.39.153 -N -v -v
start /MAX Multiclient.exe
