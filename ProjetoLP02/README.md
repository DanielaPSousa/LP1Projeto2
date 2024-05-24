```mermaid
---
title: YetAnotherDungeonCrawler
author: Alexandre Almeida
---
classDiagram
    Item <|-- HealthPotion
    Item <|-- SparklyChest
    Player "1" <-- "1" Room : Current
    Room "1" o-- "0..1" Enemy
    Room "1" o-- "0..1" Item
    Room "1" o-- "1..*" Room : Exits
    Controller "1" <-- "1" Player : Controls
    Controller "1" o-- "2..*" Room
```