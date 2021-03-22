get-process | where-object {$_.MainWindowTitle -eq "Cloud"} | stop-process

get-process | where-object {$_.MainWindowTitle -eq "ManagementCenter"} | stop-process

get-process | where-object {$_.MainWindowTitle -eq "Host1"} | stop-process
get-process | where-object {$_.MainWindowTitle -eq "Host2"} | stop-process
get-process | where-object {$_.MainWindowTitle -eq "Host3"} | stop-process
get-process | where-object {$_.MainWindowTitle -eq "Host4"} | stop-process
get-process | where-object {$_.MainWindowTitle -eq "Host5"} | stop-process
get-process | where-object {$_.MainWindowTitle -eq "Host6"} | stop-process
get-process | where-object {$_.MainWindowTitle -eq "Host7"} | stop-process

get-process | where-object {$_.MainWindowTitle -eq "Router1"} | stop-process
get-process | where-object {$_.MainWindowTitle -eq "Router2"} | stop-process
get-process | where-object {$_.MainWindowTitle -eq "Router3"} | stop-process
get-process | where-object {$_.MainWindowTitle -eq "Router4"} | stop-process
get-process | where-object {$_.MainWindowTitle -eq "Router5"} | stop-process