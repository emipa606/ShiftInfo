# Shift Info Mod - GitHub Copilot Instructions

Welcome to the Shift Info mod development guide. Below is a comprehensive overview of the mod's purpose, key features, systems architecture, coding conventions, XML integration, and a primer on Harmony patching.

## Mod Overview and Purpose

**Shift Info** is designed to enhance your RimWorld gameplay by providing real-time information on your pawns' current activities. Drawing inspiration from the scheduling systems in games like Prison Architect, this mod aims to help players better manage and coordinate large colonies by adding low-priority alerts for various time assignments, including custom ones introduced by other mods. Our goal is to address scheduling issues, especially as your colony grows.

## Key Features and Systems

- **Dynamic Alerts Module:** The mod creates low-priority alerts for each time assignment category. Alerts only show when there are pawns actively engaged unless configured otherwise in the mod settings.
  
- **Custom Time Assignments:** The system supports integration with time assignments added by other mods, ensuring flexibility and extended functionality.
  
- **Inclusion Options:** Users can configure the mod to include or exclude prisoners and slaves in shift tracking, offering tailored colony management.

## Coding Patterns and Conventions

- **File Organization:** Code is organized by functionality and responsibility. For example, `Alert_Shift.cs` handles alert logic, while `ShiftInfoMod.cs` manages mod initialization.

- **Class Access Modifiers:** Public classes like `Alert_Shift` are implemented for extensions and game integration. Internal classes like `ShiftInfoMod` and `ShiftInfoSettings` keep mod configurations encapsulated.

- **Static Utility Classes:** We utilize static classes such as `ShiftInfo` and `AlertsReadout_CheckAddOrRemoveAlert` for universal methods and patches, minimizing unintended state changes and simplifying method access.

## XML Integration

- **Data-Driven Design:** RimWorld's modding heavily relies on XML for defining game data. `Shift Info` integrates with XML to detect and categorize time assignments.
  
- **Localization:** Localizations can be stored in XML format to manage alert text for multiple languages, improving accessibility and usability for international players.

## Harmony Patching

- **Purpose and Use:** Harmony Patching is employed to override or extend existing game methods without altering the original assembly. This ensures our mod runs alongside others seamlessly.

- **Targeted Patches:** The mod includes patch classes such as `AlertsReadout_Constructor` to modify game behaviors specifically where necessary for new functionality without broader unintended effects.

## Suggestions for Copilot

To maximize the use of GitHub Copilot for this project, consider the following prompts:

1. **Alert Logic Enhancement:** Suggest and implement advanced alert filtering logic to enhance user customization.
   
2. **Custom Assignment Handling:** Generate examples of how to handle custom time assignments added by other mods.

3. **Configurable Settings:** Provide boilerplate code for implementing and storing mod setting changes dynamically.

4. **Localization Expansion:** Generate template XML for localization that supports multiple languages for mod alerts.

5. **Harmony Patching Examples:** Craft example patches for new alerts with `Harmony` that affect game methods related to time management.

By adhering to these structures and suggestions, the Shift Info mod will be well-equipped to track and display pawn activities, thereby enhancing gameplay management and strategy.
