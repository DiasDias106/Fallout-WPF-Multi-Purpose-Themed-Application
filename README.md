<h1 align="center">☢️ Fallout WPF: Multi-Purpose Themed Application</h1>

<p align="center">
  <i>A Pip-Boy-styled desktop app in C# / WPF that packs minigames, tools, a music player and a mercenary-contracts database into one Fallout-themed experience.</i>
</p>

<p align="center">
  <img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white" alt="C#"/>
  <img src="https://img.shields.io/badge/WPF-XAML-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" alt="WPF"/>
  <img src="https://img.shields.io/badge/.NET%20Framework-4.8-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" alt=".NET Framework 4.8"/>
  <img src="https://img.shields.io/badge/Entity%20Framework-6-1a1b27?style=for-the-badge" alt="EF6"/>
  <img src="https://img.shields.io/badge/SQL%20Server-LocalDB-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white" alt="SQL Server LocalDB"/>
</p>

---

## 📖 About

**Fallout WPF** was my **first C# project**. It is a desktop application whose whole interface is styled after the *Pip-Boy*, the wrist computer from the *Fallout* games. It combines more than ten mini-applications and taught me the fundamentals of GUI design, event-driven programming, data binding and local database access.

## ✨ Features

| | Feature | Description |
|---|---------|-------------|
| 🏠 | **Themed home page** | Pip-Boy-style hub to navigate between all modules |
| 📘 | **Rules page** | Explains how every section works |
| 🧾 | **Mercenaries Hub (CRUD)** | Create, read, update and delete mercenary contracts stored in a local database |
| 🔢 | **Number guessing game** | With custom victory and defeat music |
| ✊ | **Rock, Paper, Scissors** | Classic minigame |
| 🎲 | **Dice game** | Randomised dice mechanics |
| 🃏 | **Card guessing game** | Chance-based card challenge |
| 💪 | **Attribute simulator** | Fallout-style character stat assignment |
| 🔒 | **"Seal Algorithm"** | Custom algorithm minigame |
| 🧮 | **Pip-Boy calculator** | Fully working, themed calculator |
| 🖼️ | **Image carousel** | Built with **Dependency Properties** |
| 🎵 | **Music library** | Built-in audio player with multiple tracks |
| 💬 | **Quotes** | Random Fallout-inspired phrases |

## 🏗️ Architecture

The app follows a simple **Model / View / Controller** split:

- **Views**: one XAML window per module (`Inicio`, `Calculadora`, `Jogodados`, `PedraPapelTesoura`, `Mercenarios_Hub`, …)
- **Controller/**: game logic and **value converters** for data binding (`ClsJogodados`, `ClsPPT`, `Conversor*`, …)
- **Model/**: **Entity Framework 6** (Database-First, `Hub.edmx`) mapped to a SQL Server LocalDB database

## 🚀 Getting Started

### Requirements
- Windows
- **Visual Studio 2019/2022** with the *.NET desktop development* workload
- **.NET Framework 4.8**
- **SQL Server Express LocalDB** (installed with Visual Studio)

### Run
```bash
git clone https://github.com/DiasDias106/Fallout-WPF-Multi-Purpose-Themed-Application.git
```
1. Open `projeto_final_prog2/Programacao2_final/Programacao2_final.csproj` in Visual Studio.
2. Restore NuGet packages (Entity Framework 6).
3. Press **F5** to build and run.

> The Mercenaries Hub expects a LocalDB database (`Database1.mdf`) in the app's data directory, as configured in `App.config`.

## 📁 Project Structure

```
projeto_final_prog2/Programacao2_final/
├── *.xaml / *.xaml.cs   # Windows for each module
├── Controller/          # Game logic and value converters
├── Model/               # Entity Framework model (Hub.edmx) and entities
├── Sons_e_video/        # Sound effects, music and video
└── App.config           # Connection string (LocalDB)
```

## ⚠️ Disclaimer

Fan-made educational project. *Fallout* and all related names and assets belong to Bethesda Softworks.

## 📜 License

Distributed under the terms of the [LICENSE](LICENSE) file in this repository.

---

<p align="center">Made by <a href="https://github.com/DiasDias106">Francisco Dias</a></p>
