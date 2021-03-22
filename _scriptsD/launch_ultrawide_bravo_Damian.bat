@echo off
start .\..\ManagementCenter\ManagementCenter\bin\Debug\ManagementCenter.exe ".\..\sharedResources\tsst_config_bravo.xml" "ZWYKLY"
ping 192.0.2.2 -n 1 -w 200 > nul
start .\..\Cloud\Cloud\bin\Debug\Cloud.exe
ping 192.0.2.2 -n 1 -w 200 > nul

start .\..\ClientNode\ClientNode\bin\Debug\ClientNode.exe ".\..\sharedResources\tsst_config_bravo.xml" "1"
ping 192.0.2.2 -n 1 -w 200 > nul
start .\..\ClientNode\ClientNode\bin\Debug\ClientNode.exe ".\..\sharedResources\tsst_config_bravo.xml" "2"
ping 192.0.2.2 -n 1 -w 200 > nul
start .\..\ClientNode\ClientNode\bin\Debug\ClientNode.exe ".\..\sharedResources\tsst_config_bravo.xml" "3"
ping 192.0.2.2 -n 1 -w 200 > nul
start .\..\ClientNode\ClientNode\bin\Debug\ClientNode.exe ".\..\sharedResources\tsst_config_bravo.xml" "4"
ping 192.0.2.2 -n 1 -w 200 > nul
start .\..\ClientNode\ClientNode\bin\Debug\ClientNode.exe ".\..\sharedResources\tsst_config_bravo.xml" "5"
ping 192.0.2.2 -n 1 -w 200 > nul
start .\..\ClientNode\ClientNode\bin\Debug\ClientNode.exe ".\..\sharedResources\tsst_config_bravo.xml" "6"
ping 192.0.2.2 -n 1 -w 200 > nul
start .\..\ClientNode\ClientNode\bin\Debug\ClientNode.exe ".\..\sharedResources\tsst_config_bravo.xml" "7"
ping 192.0.2.2 -n 1 -w 200 > nul

start .\..\NetworkNode\NetworkNode\bin\Debug\NetworkNode.exe ".\..\sharedResources\tsst_config_bravo.xml" "1"
ping 192.0.2.2 -n 1 -w 200 > nul
start .\..\NetworkNode\NetworkNode\bin\Debug\NetworkNode.exe ".\..\sharedResources\tsst_config_bravo.xml" "2"
ping 192.0.2.2 -n 1 -w 200 > nul
start .\..\NetworkNode\NetworkNode\bin\Debug\NetworkNode.exe ".\..\sharedResources\tsst_config_bravo.xml" "3"
ping 192.0.2.2 -n 1 -w 200 > nul
start .\..\NetworkNode\NetworkNode\bin\Debug\NetworkNode.exe ".\..\sharedResources\tsst_config_bravo.xml" "4"
ping 192.0.2.2 -n 1 -w 200 > nul
start .\..\NetworkNode\NetworkNode\bin\Debug\NetworkNode.exe ".\..\sharedResources\tsst_config_bravo.xml" "5"

timeout /t 1

setlocal enableDelayedExpansion

set /a shift_x=170 Rem do modyfikacji stosownie do rozmiar�w monitora
set /a shift_y=220 Rem do modyfikacji stosownie do rozmiar�w monitora

for /l %%A in (1, 1, 7) do (
  set /a i=%%A-1
  set /a x=i*shift_x
  start ./cmdow.exe Host%%A /mov !x! 0
)

for /l %%A in (1, 1, 5) do (
  set /a i=%%A-1
  set /a x=i*shift_x
  start ./cmdow.exe Router%%A /mov !x! !shift_y!
)

set /a cloud_pos_x=5*shift_x
set /a mc_pos_x=6*shift_x

start ./cmdow.exe Cloud /mov !cloud_pos_x! !shift_y!
start ./cmdow.exe ManagementCenter /mov !mc_pos_x! !shift_y!

