## MOBA Matchmaking Simulation (C#)

A console-based MOBA match simulation written in C# that models core backend game systems such as matchmaking, team composition, performance scoring, and match outcome determination.

The project focuses on clean object-oriented design, LINQ-based aggregation, and deterministic win conditions using team kills and networth. It also includes MVP and SVP calculations based on individual player performance, mirroring real-world competitive game logic.

## Overview

This project simulates the backend logic of a MOBA-style match using C#. 
It focuses on designing scalable domain models and implementing deterministic match outcomes based on team and player performance.

Key systems include:
- Match creation and team assignment (5v5)
- Randomized player generation with roles, KDA, and networth
- Performance-based MVP (winning team) and SVP (losing team) calculation
- Match verdict logic using weighted kills and total networth
- Aggregation of match statistics using LINQ

The goal of this project is to demonstrate backend engineering principles such as separation of concerns, data aggregation, and decision-making logic in a game-like domain.

## Concepts Demonstrated

- Object-Oriented Programming (C#)
- Domain-driven design for game systems
- LINQ aggregation (Sum, OrderBy, Concat)
- Deterministic win-condition logic
- Performance scoring algorithms
- Clean separation between entities (Match, Player, Helper)

## Tech Stack

- Language: C#
- Runtime: .NET
- Paradigm: Object-Oriented Programming
- Tools: LINQ, System.Collections.Generic
