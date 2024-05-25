```mermaid
---
title: YetAnotherDungeonCrawler
author: Alexandre Almeida
---
classDiagram
    Item <|-- HealthPotion
    Item <|-- SparklyChest
    Enemy <|-- Boss
    Room "1" <-- "1" Player : Current
    Room "1" o-- "0..1" Enemy
    Room "1" o-- "0..1" Item
    Room "1" o-- "1..*" Room : Exits
    Player "1" <-- "1" Controller : Controls
    Controller "1" o-- "2..*" Room
    IView "1" <-- "1" Controller : User Interface
```