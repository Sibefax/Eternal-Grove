# Eternal Grove

**A 2D resource management and base-building survival game** about maintaining an ancient magical grove in a vast, living forest.

You are the last Warden — the guardian of the Eternal Grove. Your task is to keep the forest alive by carefully managing resources, expanding your sanctuary, dealing with unpredictable events, and making difficult moral choices.

## Core Concept

The game is built around **balance**. Every action has consequences. Over-harvesting resources corrupts the Grove. Ignoring the needs of nature leads to disasters. Helping the forest and its inhabitants brings prosperity and new opportunities.

## Core Loop

1. Explore and gather resources from the forest
2. Process resources and craft items
3. Expand and upgrade your sanctuary
4. Survive changing seasons and random events
5. Maintain the magical balance of the Grove
6. Unlock new abilities, buildings, and story branches

## Main Systems

### 1. Resource System
- **12+ different resources** with unique properties:
  - Basic: Wood, Stone, Herbs, Water, Food
  - Advanced: Mana Crystals, Ancient Seeds, Spirit Essence, etc.
- Resources can be **perishable** (food spoils), **seasonal**, or **non-renewable**.
- Storage buildings have limited capacity.
- Resources have **quality** levels that affect crafting results.

### 2. Crafting & Processing System
- Multi-step crafting chains (raw material → processed material → finished product).
- Recipes are unlocked through progression and story events.
- Some recipes require specific buildings or environmental conditions.
- Quality of input materials affects quality of output.

### 3. Building & Sanctuary System
- Grid-based building placement.
- Buildings have levels (I → III) and can be upgraded.
- Different categories:
  - **Production** (Workshop, Herbal Garden, Mana Well)
  - **Storage** (Warehouse, Root Cellar)
  - **Living** (Living Quarters, Meditation Hut)
  - **Ritual/Magic** (Ritual Circle, Ancient Altar)
- Each building affects global balance and provides bonuses.

### 4. Time & Season System
- Full day/night cycle.
- **Four seasons** with unique mechanics:
  - Spring: Faster growth, more events
  - Summer: High food production, drought risk
  - Autumn: Harvest time, preparation for winter
  - Winter: High danger, low resource regeneration
- Long-term progression across multiple years.

### 5. Event & Decision System
- Random events every few days.
- Story-driven events with multiple branches.
- Moral choices that affect:
  - Grove's Corruption level
  - Relations with forest spirits
  - Available endings
- Events can be positive, negative, or mixed.

### 6. Balance & Corruption System
- Central meta-system of the game.
- The Grove has a "Balance" value.
- Overexploitation or ignoring nature increases Corruption.
- High Corruption leads to dangerous events and bad endings.
- Maintaining perfect balance leads to the best ending.

### 7. Save System
- Full save/load functionality.
- Multiple save slots.
- Save versioning (old saves won't break after updates).
- Auto-save on important decisions.

## Technical Goals

- Clean architecture using ScriptableObjects and Systems approach.
- Strong use of Event Bus for communication between systems.
- Data-Driven Design wherever possible.
- High modularity — systems should be reusable in future projects.

## Current Status

**In Development**
