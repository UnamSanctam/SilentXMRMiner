### v1.5.0 (02/10/2021)
* **The previous version was supposed to be the last one before the unified miner but I recieved great results by loading everything by Shellcode making it worthwhile to update**
* Added new Shellcode loader, the miner, watchdog and uninstaller will now be converted into shellcode and injected using a native C loader which greatly reduces detections
* Added custom tcc C compiler to compile the Shellcode loader
* Added custom windres resource compiler to allow icons, assembly data and run as administrator for the native C program
* Added donut to convert .NET programs into Shellcode
* Added option to disable Shellcode loader
* Remade and optimized much of the miner and watchdog code
* Removed old C# loader
* Renamed Install to Startup due to confusion
### v1.4.4 (07/08/2021)
* **Any old miner using "Online Download" will automatically get this update for any new clients**
* Now gets the Remote Configuration every 100 minutes
* Added failover capability for the Remote Configuration URL, add several URLs by separating them by a comma (,)
* Changed the Remote Configuration scheme from INI to JSON, can still read INI files for backwards compatibility
* Added capabilities to change more miner settings with Remote Configuration
* Migrated from {%COMPUTERNAME%}, {%USERNAME%} and {%RANDOM%} to {COMPUTERNAME}, {USERNAME} and {RANDOM} but the old ones will still work for backwards compatibility
* Now replaces {COMPUTERNAME}, {USERNAME} and {RANDOM} with their respective values when using Remote Configuration
* Fixed possible Idle activation crash on Windows 7
* Added the Stealth Targets option which allows you to enter which programs the Stealth option should pause for
* Added algorithm selection to make it easier to use
* Fixed the GPU detection for systems that have custom lowercase characters like Turkish, seems like I failed the "Turkey Test" again
* Fixed broken builder help tooltips
* Major miner update/rework
* Improved miner stability
### v1.4.3 (19/07/2021)
* Greatly reduced Windows Defender detections when "Bypass Windows Defender" is enabled by replacing Assembly.Load with simply writing the payload to Temp and executing it since the folders are excluded
* Fixed the paths for systems that have custom lowercase characters like Turkish
### v1.4.2 (14/07/2021)
* Remade watchdog to reduce detections
* Obfuscated more strings to reduce new Windows Defender detections
* Reworked a lot of the injector
* Fixed a bug where two environment variables for paths could return different results
### v1.4.1 (10/07/2021)
* Fixed possible critical bug that makes the miner unable to see if a miner is running or not thus opening multiple miners
* Added backup servers for Online Downloader
* Added Install to System32 option (requires administrator permissions)
* Moved RunPE injector (Mandark) into miner to avoid internal Assembly.Load and improved it a bit
* Fixed possiblity of duplicate random obfuscation strings
* Improved Loader
* Improved Watchdog
* Improved obfuscation
### v1.4 (05/07/2021)
**v1.4.\* is the final update before the new, greatly improved unified miner that I'm working on.**
* Added the Online Downloader option that makes the miner download the miner binary (from GitHub) during runtime to greatly decrease file size (to less then 100kb) and detections - Also added a cache so that it won't have to download the miner on every start
* Made the Task Scheduler task start for all users
* Improved Watchdog program flow
* Renamed "Kill" Windows Defender to Bypass Windows Defender to better represent the new functionality
* Improved obfuscation/encryption
* Improved overall code
### v1.3.4 (14/05/2021)
* Made the Windows Defender Killer less intrusive, ironically to reduce detections
### v1.3.3 (13/05/2021)
* Fixed possible CPU fluctuation
* Added Stealth support for Windows 7 Task Manager
* Decreased Watchdog detections
* Fixed possible Run as Administrator issue on computers with low privileges
### v1.3.2 (09/05/2021)
* Fixed crash when mining from countries that block certain traffic
* Reduced default Start Delay to 15 seconds
### v1.3.1 (08/05/2021)
* Fixed weird Remote Configuration bug
### v1.3 (07/05/2021)
* Updated miner
* Added a Remote Configuration feature that can get the connection settings remotely from a URL at each startup
* Added option to auto-create an uninstaller for the miner
* Added Windows Defender "Killer"
* Added option to run as administrator
* Updated CUDA version to 11 to better support newer RTX cards
* Reworked whole program flow to bypass file scan detections
* Added link to wiki in builder for quicker access
* Added better DEBUG messaging
* Changed command line option prefixes
* Fixed config limitations
* Fixed bugs
### v1.2.3 (10/04/2021)
* Fixed watchdog temporary path
* Updated injector
* Readded injector options svchost.exe and conhost.exe
* Decreased injector detections
* Improved error handling
### v1.2.2 (09/04/2021)
* Fixed crash when some connections are blocked by the government/ISP in places like Turkey or China
### v1.2.1 (09/04/2021)
* Fixed minor injection option bug
### v1.2 (09/04/2021)
* Fixed critial bug on some Windows systems
* Added Task Scheduler startup when miner has administrator privileges
* Replaced and improved injector
* Added advanced options form
* Added debug option to display errors for testing
* Added ability to obfuscate watchdog
* Fixed miscellaneous bugs
### v1.1 (31/03/2021)
* Updated miner
* Improved miner performance
* Recoded injector and watchdog from VB to C#
* Decreased antivirus detections
* Added built-in function name obfuscation
* Added Process Hacker and Process Explorer to stealth targets
### v1.0.3 (27/03/2021)
* Updated Watchdog
* Improved injector workflow reliability
* Changed encryption since the code was detected
### v1.0.2 (19/03/2021)
* Added 0% Max CPU option
* Increased salt lengths
* Improved Watchdog implementation
* Improved persistance
### v1.0.1 (14/03/2021)
* Removed some injection options due to new Windows protections
### v1.0 (12/03/2021)
* Updated miner
* Decreased antivirus detections
* Added a watchdog that replaces the miner if removed and starts it if closed down
* Added anti-sleep
* Stopped the command window from showing briefly when started
* Fixed bugs
### v0.9 (02/02/2021)
* Updated miner
* Greatly decreased antivirus detections
* Idle Max CPU, added customizable Max CPU usage while the miner is idle
* Idle Wait, added customizable time to wait before the miner is idle
* Stealth, currently pauses the miner while Task Manager is open
* Start Delay, added a customizable start delay before the miner is injected and starts, decreases detection by a lot
* Hide file, can now choose to hide the copied miner file when "Install" is enabled
* Now hides the library folder
* Encrypted all strings
### v0.8.1 (07/01/2021)
* Improved AV bypass
* Reverted back to .NET Framework 4.5
* Fixed bug that stopped miner from injecting
* Improved file size
* Fixed incorrect scaling with some system languages
### v0.8 (04/01/2021)
* Updated miner
* Fixed bugs
* Lowered requirement to .NET 4.0
* Added SSL/TLS option
* Added custom parameter option
* Increased miner performance
### v0.7.1 (09/10/2020)
* Fixed a bug
### v0.7 (08/10/2020)
* Updated miner
* Added help tooltips to clarify options
* Fixed bugs
* Reworked some code
### v0.6 (21/04/2020)
* Updated miner
* Added custom Idle option to miner (Starts mining after 15 minutes of inactivity and stops when active again)
* Added more options in the builder (Enable/Disable CPU, Nicehash and Idle mining)
* Fixed driver paths
* Reworked some code
### v0.5 (09/04/2020)
* Updated miner
* Massively improved file size by compressing libraries
### v0.4 (18/12/2019)
* Updated miner
* Improvement to non-GPU enabled filesize
### v0.3 (10/12/2019)
* Updated to work with the new Monero fork
* Added toggle to enable/disable GPU mining
### v0.2 (05/08/2019)
* Added more injection process choices
* Added Max CPU choice
### v0.1 (03/08/2019)
* Inital release