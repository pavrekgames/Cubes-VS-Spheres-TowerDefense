# Cubes-VS-Spheres-TowerDefense

Project for learning how to create a Tower Defense game. Cubes (Plants) VS Spheres (Zombies)

The project is based on the Plants Vs Zombies game where you plant cubes (plants) and have to survive 3 waves of spheres (zombies).

FEATURES:

1. Various cubes (plants)
  - Gold cube (sunflower) - Gold cube (sunflower) - This cube produces gold currency to plant other cubes (plants). The currency is moving at a random 
    speed and direction.
  - Nut cube (nut) - This cube has a lot of health to stop spheres. Spheres need to eat the nut for a long time to keep moving.
  - Simple shooter cube - This cube shoots one bullet with a certain frequency.
  - Double shooter cube - This cube shoots two bullets with a break between themselves with a particular frequency.
  - Freeze shooter cube - This cube shoots freezing bullets that freeze enemies. The enemies are slower and have longer attack frequency.
  - Three lines shooter cube - This cube shoots three bullets and each in a different line (Up line, middle line, and down line).
  - Mine cube - This cube is sleeping at the start but after 20 seconds makes a mine. Each enemy which touches the mine is destroyed by the mine.
  - Pear cube (Pear) - This cube is waiting for an enemy and when the sphere is close the pear cube goes to the enemy and kills him.
  - Cherry cube (Cherry) - This cube after some seconds kill all enemies in a certain range.
  - Pepper cube (Chilli Pepper) - This cube kills all enemies in the line.
  - Fire Stump cube - TThis cube increases the damage of bullets when the bullets went through it.
 
2. Various spheres (zombies)
  - Simple sphere - This sphere is slow and has default health.
  - Armored orange sphere - This sphere has more health than a simple sphere.
  - Armored grey sphere - This sphere has more health than an armored orange sphere
  - Newspaper sphere - This sphere has more health than a simple sphere and when his newspaper will be destroyed he is faster and has a shorter attack frequency.
  - Sportsman sphere - This sphere has more health than the armored grey sphere and is faster.
  - Poleman sphere - This sphere has a pole and can jump over cubes. With the pole is faster but after the jump has the default speed.
  - Boxman sphere - This sphere has a box and when dies inflicts damages in a certain range.
  
3. Planting cubes on tiles.
4. You can collect gold and put cubes.
5. Gold is updated after collecting.
6. The button has a system when each button can be used (amount of gold, time to buy).
7. Before planting the chosen cube is transparent.
8. Waves system when a certain amount of enemies is produced in a certain time and random lines.
9. Object pooling for bullets.
10. Game over when one sphere (zombie) will touch the finish line.

USED DESIGN PATTERNS:

1. Singleton Pattern - To create Game manager and factories
2. Observer Pattern - To update UI (gold, buttons) and some other behaviors.
3. Strategy Pattern - Cubes and Spheres.
4. Factory Pattern - To plant certain cubes on tiles and produce spheres during the waves.
5. Decorator Pattern - Behavior of Fire Tump cube to increase the damage of bullets.
6. Object Pooling Pattern - For creating bullets by shooters.
7. Flyweight Pattern - Scriptable objects of cubes and spheres.
8. Prototype Pattern - Scriptable objects of cubes and spheres.
