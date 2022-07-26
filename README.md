# allskills-mod

This mod adds support to create an ovelary with all the skills in Hollow Knight that can be used in OBS for streaming.

# Requirements
- Hollow Knight 1.5.78
- Modding API 1.5.78

## How to install
Unzip the [last release](https://github.com/carloslancha/allskills-mod/releases/latest) .zip file in `HollowKnightPath/hollow_knight_Data/Managed/Mods` folder.

## How to integrate in OBS
- Add a new Browser source in your Scene.
- Select Local File
- Browse file `HollowKnightPath/hollow_knight_Data/Managed/Mods/AllSkills/overlay.html`
- Set size to 1920x1080px
- Enjoy

## How to customize the Overlay
- You can customize the position, size and other styles by editing the [styles.css](./AllSkills/Resources/styles.html) file.
- You can configure the mod behavior by editing the configuration in the [overlay.html](./AllSkills/Resources/overlay.html#L4) file.

#### Config API 

| Parameter | Type | Description |
| :--- | :--- | :--- |
| `showCompleted` | Boolean | Show completed image when all skills set as required are accquired. |
| `skills` | Object | Object with all the [skills configuration](#skills-api-heading). |

### Skills API
- [About Skills API](./SkillsAPI.md)

## Preview

![image](https://user-images.githubusercontent.com/5803434/137046521-501b043d-5d67-4077-b2bb-87583ce47836.png)

## For Devs
-	[Documentation for developers](./AllSkills/DEV.md)

## License

GNU GPLv3 License © Carlos Lancha.<br/>
[Twitch/Empaventuras](https://www.twitch.tv/empaventuras)