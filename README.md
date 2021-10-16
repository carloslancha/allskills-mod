# allskills-mod

This mod adds support to create an ovelary with all the skills in Hollow Knight that can be used in OBS for streaming.

# Requirements
- Hollow Knight 1.4.3.2
- Modding API 1.4.3.2-60

## How to install

Unzip the [last release](https://github.com/carloslancha/allskills-mod/releases/latest) .zip file in `HollowKnightPath/hollow_knight_Data/Managed/Mods` folder.

## How to integrate in OBS

- Add a new Browser source in your Scene.
- Select Local File
- Browse file `HollowKnightPath/hollow_knight_Data/Managed/Mods/AllSkills/overlay.html`
- Set size to 1920x1080px
- Enjoy

## How to customize the Overlay
- You can customize the position, size and other styles by editing the [styles.css](https://github.com/carloslancha/allskills-mod/blob/master/AllSkills/Resources/styles.html) file.
- You can configure the mod behavior by editing the configuration in the [overlay.html](https://github.com/carloslancha/allskills-mod/blob/master/AllSkills/Resources/overlay.html#L4) file.

#### Config API 

| Parameter | Type | Description |
| :--- | :--- | :--- |
| `showCompleted` | Boolean | Show completed image when all skills set as required are accquired. |
| `skills` | Object | Object with all the [skills configuration](#skills-api-heading). |

#### Skills API

| Parameter | Type | Default | Description |
| :--- | :--- | :--- | :--- |
| **acidArmour** | | | Isma's Tear |
| required | Boolean | `true` | |
| show | Boolean | `true` | |
| **cyclone** | | | Cyclone Slash |
| required | Boolean | `true` | |
| show | Boolean | `true` | |
| **dashLevel** | | | Mothwing / Shade Cloak |
| requiredLevel | Int | `2` | `0` Not required <br/> `1` Mothwing Cloak <br/> `2` Shade Cloak |
| show | Boolean | `true` | |
| **doubleJump** | | | Monarch Wings |
| required | Boolean | `true` | |
| show | Boolean | `true` | |
| **dreamNailLevel** | | | Dream Nail |
| requiredLevel | Int | `1` | `0` Not required <br/> `1` Dream Nail </br> `2` Awake Dream Nail |
| show | Boolean | `true` | |
| **fireballLevel** | | | |
| requiredLevel | Int | `2` | `0` Not required <br/> `1` Vengeful Spirit <br/> `2` Shade Soul |
| show | Boolean | `true` | |
| **focus** | | | Focus |
| required | Boolean | `true` | |
| show | Boolean | `true` |  |
| **greatSlash** | | | Great Slash |
| required | Boolean | `true` |  |
| show | Boolean | `true` | |
| **quakeLevel** | | | Desolate Dive / Descending Dark |
| requiredLevel | Int | `2` | `0` Not required <br/> `1` Desolate Dive <br/> `2` Descending Dark |
| show | Boolean | `true` | |
| **screamLevel** | | | Howling Wraiths / Abyss Shriek |
| requiredLevel | Int | `2` | `0` Not required <br/> `1` Howling Wraiths <br/> `2` Abyss Shriek |
| show | Boolean | `true` | |
| **superDash** | | | Crystal Heart |
| required | Boolean | `true` | |
| show | Boolean | `true` |  |
| **wallJump** | | | Mantis Claw |
| required` | Boolean | `true` | |
| show | Boolean | `true` | |

## Preview

![image](https://user-images.githubusercontent.com/5803434/137046521-501b043d-5d67-4077-b2bb-87583ce47836.png)

## License

GNU GPLv3 License © Carlos Lancha.<br/>
www.twitch.tv/empaventuras
