# Copilot Instructions for Shift Info Mod Development

## Mod Overview and Purpose
**Mod Name:** Shift Info  
**Author:** Mlie  
**PackageId:** Mlie.ShiftInfo  

The "Shift Info" mod for RimWorld is designed to assist players in tracking what their pawns are doing at any given time in the game. Inspired by the mini-schedule display in Prison Architect, this mod provides a convenient way to monitor and troubleshoot scheduling issues that may arise as the number of pawns in your colony increases.

## Key Features and Systems
- **Time Assignment Alerts:** The mod introduces low-priority alerts for each possible time assignment type, including those added by other mods.
- **Pawn Activity Display:** By default, the alerts only show if a pawn is actively engaged in the time assignment type, but this can be adjusted to always show.
- **Customizable Options:** Players have the option to include prisoners and slaves in the shift information.
- **Mod Configuration:** Various mod-options allow players to customize how information is displayed and what units are included.

## Coding Patterns and Conventions
- **C# Coding Conventions:** Follow standard C# conventions with clear naming for classes and methods, adhering to PascalCase for public members, and camelCase for private members.
- **Separation of Concerns:** The mod's code is organized across multiple files, each responsible for a specific part of the functionality, such as settings, alert handling, and main mod operations.
- **Minimal Use of XML:** This mod currently relies mainly on C# code with no XML definitions found in the project structure.

## XML Integration
- The mod does not utilize XML for its definitions, focusing instead on C# for dynamic functionality and settings management.

## Harmony Patching
- The mod depends on **Harmony** for patching game methods to introduce new behaviors without altering original game code.
- **Harmony Usage:** `AlertsReadout_CheckAddOrRemoveAlert.cs` includes a `Postfix` method to extend the behavior of RimWorld's alert system to incorporate its custom alerts.

## Suggestions for Copilot
1. **Automate Recurrent Patterns:**
   - Utilize Copilot to suggest enhancements for alert types by analyzing and automating similar patterns across different alert categories.
   
2. **Settings Management:**
   - Leverage Copilot's suggestions to streamline `ShiftInfoSettings.cs` for more efficient handling of user options and data exposure.
   
3. **Enhanced Customization Options:**
   - Implement additional user customization options with the help of Copilot, such as toggles or sliders in the settings UI.

4. **Documentation Enhancements:**
   - Encourage Copilot to generate inline comments that explain complex code sections within methods like `GetExplanation` and `GetReport`.

5. **Feature Expansion:**
   - Get Copilot's assistance to brainstorm and code new features that align with the current system, such as extended time assignment types or conditional alert triggers.

This structured guideline should assist you while using GitHub Copilot to enhance and maintain the Shift Info mod effectively.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

